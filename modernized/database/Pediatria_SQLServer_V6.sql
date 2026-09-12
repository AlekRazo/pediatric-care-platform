/* =====================================================================
   PEDIATRÍA — Base de datos modernizada (SQL Server 2022 / nivel 160)
   Fuente de requisitos: Documento de Requisitos V6.1 (Manuel Razo)
   Cumplimiento: NOM-004-SSA3-2012 (expediente clínico)
   Generado: 2026-09-08

   DECISIONES DE DISEÑO (resumen — detalle en la respuesta de chat):
   - GUID (UNIQUEIDENTIFIER) en las entidades raíz expuestas por API:
     usuarios, pacientes, citas, consultas, recetas.
     El GUID lo genera la capa de aplicación (no la BD): por eso estas
     columnas NO llevan DEFAULT. Esto permite que el dominio conozca el
     Id de la entidad antes de llamar a SaveChanges() (necesario para
     agregados/eventos de dominio), y evita que el generador del PK
     dependa del motor. Si se requiere mitigar fragmentación del índice
     clúster (problema real de UNIQUEIDENTIFIER como PK en SQL Server),
     eso se resuelve generando un GUID "secuencial"/COMB en C# — no
     delegándolo a NEWSEQUENTIALID().
   - Tablas satélite/detalle (antecedentes, vacunación, medicamentos de
     receta, interrogatorio por aparatos, etc.) usan INT IDENTITY:
     nunca se exponen ni se referencian de forma independiente, siempre
     se accede a través del GUID del padre.
   - bitacora_auditoria usa BIGINT IDENTITY: es una tabla de solo
     inserción de alto volumen; un GUID ahí no aporta valor y sí
     penaliza inserciones.
   - numero_expediente (paciente) y folio (receta) son enteros
     autonuméricos independientes del GUID: el GUID es el identificador
     técnico/API; el folio es el identificador legal/humano que ya
     pedían los requisitos (REQ-PAC-003, REQ-REC-002).
   - Baja lógica (activo BIT) en paciente/consulta/receta en lugar de
     DELETE físico, para cumplir la retención de 5 años (REQ-PAC-018,
     REQ-EXT-001) y REQ-REC-005 (cancelar, no eliminar).
   ===================================================================== */

SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

CREATE DATABASE [PediatriaV2];
GO
ALTER DATABASE [PediatriaV2] SET READ_COMMITTED_SNAPSHOT ON;
GO
USE [PediatriaV2];
GO

/* =====================================================================
   1. USUARIOS  (REQ-USR-001 a 016 / REQ-SEC-001 a 005)
   ===================================================================== */

CREATE TABLE dbo.roles (
    id              INT IDENTITY(1,1) PRIMARY KEY,
    nombre          NVARCHAR(30) NOT NULL UNIQUE
        CHECK (nombre IN (N'Administrador', N'Medico', N'Recepcionista'))
);
GO
INSERT INTO dbo.roles (nombre) VALUES (N'Administrador'), (N'Medico'), (N'Recepcionista');
GO

-- Tabla base de autenticación. GUID: es el "sub" natural de un JWT y evita
-- enumeración de usuarios en endpoints de administración (REQ-USR-006/007).
CREATE TABLE dbo.usuarios (
    id                  UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    nombre_usuario      NVARCHAR(50)  NOT NULL UNIQUE,
    correo_electronico  NVARCHAR(100) NOT NULL UNIQUE,           -- REQ-USR-003: recuperación por correo
    contrasena_hash     NVARCHAR(256) NOT NULL,                  -- REQ-SEC-004: nunca texto plano
    id_rol              INT NOT NULL REFERENCES dbo.roles(id),   -- REQ-USR-005
    activo              BIT NOT NULL DEFAULT 1,
    fecha_registro      DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    fecha_ultimo_acceso DATETIME2(0) NULL,
    fecha_baja          DATETIME2(0) NULL                        -- REQ-USR-015: baja lógica, no física
);
GO
CREATE INDEX IX_usuarios_rol ON dbo.usuarios(id_rol) WHERE activo = 1;
GO

-- Perfil extendido de médico (1:1 con usuarios, PK compartida).
CREATE TABLE dbo.medicos (
    id_usuario              UNIQUEIDENTIFIER NOT NULL PRIMARY KEY
        REFERENCES dbo.usuarios(id) ON DELETE CASCADE,
    nombre_completo          NVARCHAR(100) NOT NULL,
    fecha_nacimiento         DATE NOT NULL,
    sexo                     NVARCHAR(10) NOT NULL CHECK (sexo IN (N'Masculino', N'Femenino', N'Otro')),
    cedula_profesional       NVARCHAR(20) NOT NULL UNIQUE,        -- REQ-USR-010
    institucion_educativa    NVARCHAR(100) NOT NULL,
    especialidad             NVARCHAR(100) NOT NULL,
    firma                    VARBINARY(MAX) NULL                  -- REQ-USR-009 / REQ-REC-002 (firma en receta)
);
GO

-- Perfil extendido de recepcionista (1:1 con usuarios).
CREATE TABLE dbo.recepcionistas (
    id_usuario        UNIQUEIDENTIFIER NOT NULL PRIMARY KEY
        REFERENCES dbo.usuarios(id) ON DELETE CASCADE,
    nombre_completo   NVARCHAR(100) NOT NULL,
    fecha_nacimiento  DATE NOT NULL,
    sexo              NVARCHAR(10) NOT NULL CHECK (sexo IN (N'Masculino', N'Femenino', N'Otro'))
);
GO

-- Datos del consultorio, editables por el administrador sin tocar código (REQ-SOP-003)
-- y usados para imprimir la receta (REQ-REC-002).
CREATE TABLE dbo.consultorio (
    id           INT NOT NULL PRIMARY KEY CHECK (id = 1),   -- fila única (patrón singleton)
    nombre       NVARCHAR(100) NOT NULL,
    domicilio    NVARCHAR(150) NOT NULL,
    telefono     NVARCHAR(15)  NOT NULL
);
GO

CREATE TABLE dbo.refresh_tokens (
    id                 UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    id_usuario         UNIQUEIDENTIFIER NOT NULL REFERENCES dbo.usuarios(id) ON DELETE CASCADE,
    token_hash         NVARCHAR(256) NOT NULL,
    fecha_creacion     DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    fecha_expiracion   DATETIME2(0) NOT NULL,
    revocado           BIT NOT NULL DEFAULT 0,
    creado_por_ip      NVARCHAR(45) NULL
);
GO
CREATE INDEX IX_refresh_tokens_usuario ON dbo.refresh_tokens(id_usuario) WHERE revocado = 0;
GO

-- Recuperación de contraseña: contraseña temporal generada por el administrador,
-- expira en 24h, obliga a cambio en siguiente inicio de sesión.
CREATE TABLE dbo.password_resets (
    id                    UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    id_usuario            UNIQUEIDENTIFIER NOT NULL REFERENCES dbo.usuarios(id) ON DELETE CASCADE,
    id_admin_ejecuta      UNIQUEIDENTIFIER NOT NULL REFERENCES dbo.usuarios(id),
    temp_password_hash    NVARCHAR(256) NOT NULL,
    fecha_creacion        DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    fecha_expiracion      DATETIME2(0) NOT NULL,       -- fecha_creacion + 24h, calculado en aplicación
    usado                 BIT NOT NULL DEFAULT 0
);
GO

-- Bitácora de auditoría unificada (REQ-USR-016, REQ-PAC-020, REQ-SOP-005).
-- BIGINT IDENTITY: tabla append-only de alto volumen, GUID no aporta aquí.
CREATE TABLE dbo.bitacora_auditoria (
    id            BIGINT IDENTITY(1,1) PRIMARY KEY,
    id_usuario    UNIQUEIDENTIFIER NULL REFERENCES dbo.usuarios(id),  -- NULL: intento fallido antes de autenticar
    entidad       NVARCHAR(50) NOT NULL,      -- 'Usuario' | 'Paciente' | 'Consulta' | 'Receta' | 'Cita'
    id_entidad    NVARCHAR(50) NULL,          -- GUID o entero como texto; agnóstico al tipo de PK
    accion        NVARCHAR(30) NOT NULL
        CHECK (accion IN (N'Acceso', N'Creación', N'Modificación', N'Eliminación')),
    fecha_hora    DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    direccion_ip  NVARCHAR(45) NULL,
    detalles      NVARCHAR(500) NULL
);
GO
CREATE INDEX IX_bitacora_entidad ON dbo.bitacora_auditoria(entidad, id_entidad);
CREATE INDEX IX_bitacora_usuario_fecha ON dbo.bitacora_auditoria(id_usuario, fecha_hora);
GO

/* =====================================================================
   2. CITAS  (REQ-CIT-001 a 013)
   ===================================================================== */

CREATE TABLE dbo.dias_no_disponibles (
    id      INT IDENTITY(1,1) PRIMARY KEY,
    fecha   DATE NOT NULL UNIQUE,
    motivo  NVARCHAR(100) NULL
);
GO

-- GUID: se referencia desde flujos de recepción (reagendar/cancelar por URL).
-- id_paciente es NULLABLE: una cita puede agendarse para alguien aún no
-- registrado formalmente como paciente (flujo walk-in / telefónico).
-- Nota: id_paciente no lleva REFERENCES aquí porque dbo.pacientes todavía
-- no existe en este punto del script (citas se documenta antes que
-- pacientes en los requisitos). La restricción real se agrega más abajo
-- con ALTER TABLE, una vez creada dbo.pacientes.
CREATE TABLE dbo.citas (
    id               UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    id_paciente      UNIQUEIDENTIFIER NULL,
    nombre_paciente  NVARCHAR(100) NOT NULL,
    fecha            DATE NOT NULL,
    hora             TIME(0) NOT NULL,
    es_primera_vez   BIT NOT NULL DEFAULT 0,
    telefono         NVARCHAR(15) NULL,
    afiliacion       NVARCHAR(20) NULL CHECK (afiliacion IN (N'Carl''s Jr', N'Pemex', N'Ninguno')),
    estado           NVARCHAR(20) NOT NULL DEFAULT N'Programada'
        CHECK (estado IN (N'Programada', N'Reagendada', N'Cancelada', N'Atendida')),
    fecha_registro   DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME()
    -- Nota: las reglas de negocio "no domingo" (REQ-CIT-011) y "horario en
    -- múltiplos de 20 min" (REQ-CIT-003) se validan en la capa de dominio
    -- (Value Object HorarioCita), no aquí. La BD solo conserva las
    -- restricciones de integridad de datos (enum de estado/afiliación).
);
GO

/* =====================================================================
   3. PACIENTES  (REQ-PAC-001 a 020)
   ===================================================================== */

-- GUID como PK técnica/API; numero_expediente como folio legal consecutivo
-- (REQ-PAC-003), independiente y NOT NULL UNIQUE.
CREATE TABLE dbo.pacientes (
    id                        UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    numero_expediente         INT IDENTITY(1000,1) NOT NULL UNIQUE,
    nombre_completo           NVARCHAR(100) NOT NULL,
    fecha_nacimiento          DATE NOT NULL,
    sexo                      NVARCHAR(10) NOT NULL CHECK (sexo IN (N'Masculino', N'Femenino')),
    curp                      CHAR(18) NOT NULL UNIQUE,                -- NOM-004
    domicilio                 NVARCHAR(150) NOT NULL,
    codigo_postal             CHAR(5) NOT NULL,
    lugar_nacimiento          NVARCHAR(100) NOT NULL,
    grupo_etnico              NVARCHAR(50) NULL,                       -- NOM-004
    tipo_sangre               NVARCHAR(3) NULL
        CHECK (tipo_sangre IN (N'A+', N'A-', N'B+', N'B-', N'AB+', N'AB-', N'O+', N'O-')),
    nombre_tutor               NVARCHAR(100) NULL,
    parentesco_tutor           NVARCHAR(30) NULL,
    telefono_tutor              NVARCHAR(15) NULL,
    afiliacion                 NVARCHAR(20) NULL CHECK (afiliacion IN (N'Pemex', N'Carl''s Jr', N'Ninguno')),
    numero_seguro_particular    NVARCHAR(30) NULL,
    otro_tipo_seguro             NVARCHAR(50) NULL,
    numero_seguro                NVARCHAR(30) NULL,
    observaciones_generales      NVARCHAR(MAX) NULL,
    id_medico_asignado           UNIQUEIDENTIFIER NULL REFERENCES dbo.medicos(id_usuario),
    fecha_registro                DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    activo                        BIT NOT NULL DEFAULT 1,              -- baja lógica: retención 5 años
    fecha_baja_logica             DATETIME2(0) NULL
);
GO

-- Ahora que dbo.pacientes ya existe, se agrega la FK real de citas.
ALTER TABLE dbo.citas
    ADD CONSTRAINT FK_citas_paciente FOREIGN KEY (id_paciente)
    REFERENCES dbo.pacientes(id) ON DELETE SET NULL;
GO
CREATE INDEX IX_citas_paciente ON dbo.citas(id_paciente);
CREATE UNIQUE INDEX UX_citas_fecha_hora_activas ON dbo.citas(fecha, hora)
    WHERE estado <> N'Cancelada';   -- REQ-CIT-013: no choque de horarios (IN no es válido en predicados de índice filtrado)
GO

CREATE INDEX IX_pacientes_nombre ON dbo.pacientes(nombre_completo);          -- REQ-PAC-001
CREATE INDEX IX_pacientes_medico ON dbo.pacientes(id_medico_asignado);
GO

-- REQ-PAC-004: antecedentes patológicos (1:1)
CREATE TABLE dbo.antecedentes_patologicos (
    id                          INT IDENTITY(1,1) PRIMARY KEY,
    id_paciente                 UNIQUEIDENTIFIER NOT NULL UNIQUE REFERENCES dbo.pacientes(id) ON DELETE CASCADE,
    enfermedades_previas         BIT NULL, enfermedades_previas_tipo         NVARCHAR(200) NULL,
    secuelas                     BIT NULL, secuelas_tipo                     NVARCHAR(200) NULL,
    hospitalizaciones            BIT NULL, hospitalizaciones_tipo            NVARCHAR(200) NULL,
    cirugias                     BIT NULL, cirugias_tipo                     NVARCHAR(200) NULL,
    transfusiones                BIT NULL, transfusiones_tipo                NVARCHAR(200) NULL,
    fracturas                    BIT NULL, fracturas_tipo                    NVARCHAR(200) NULL,
    traumatismos_accidentes      BIT NULL, traumatismos_accidentes_tipo      NVARCHAR(200) NULL,
    enf_exantematicas            BIT NULL, enf_exantematicas_tipo            NVARCHAR(200) NULL,
    enf_cronico_degenerativas    BIT NULL, enf_cronico_degenerativas_tipo    NVARCHAR(200) NULL
);
GO

-- REQ-PAC-005: antecedentes no patológicos (1:1)
CREATE TABLE dbo.antecedentes_no_patologicos (
    id                     INT IDENTITY(1,1) PRIMARY KEY,
    id_paciente            UNIQUEIDENTIFIER NOT NULL UNIQUE REFERENCES dbo.pacientes(id) ON DELETE CASCADE,
    tipo_vivienda          NVARCHAR(100) NULL,
    servicios              NVARCHAR(200) NULL,
    hacinamiento           NVARCHAR(100) NULL,
    habitos_higiene        NVARCHAR(200) NULL,
    habitos_alimenticios   NVARCHAR(200) NULL,
    escolaridad            NVARCHAR(100) NULL,
    convivencia_animales   BIT NULL, convivencia_animales_tipo NVARCHAR(200) NULL,
    actividad_fisica       BIT NULL, actividad_fisica_tipo     NVARCHAR(200) NULL
);
GO

-- REQ-PAC-006 / REQ-PAC-007: heredofamiliares padre / madre.
-- Se separa en dos tablas porque los campos no son simétricos (madre
-- agrega historial obstétrico) y así evita columnas NULL sin sentido en el padre.
CREATE TABLE dbo.antecedentes_heredofamiliares_padre (
    id                    INT IDENTITY(1,1) PRIMARY KEY,
    id_paciente           UNIQUEIDENTIFIER NOT NULL UNIQUE REFERENCES dbo.pacientes(id) ON DELETE CASCADE,
    nombre_completo       NVARCHAR(100) NULL,
    fecha_nacimiento      DATE NULL,
    ocupacion             NVARCHAR(50) NULL,
    tabaquismo            BIT NULL,
    alcoholismo           BIT NULL,
    toxicomanias          BIT NULL, toxicomanias_tipo   NVARCHAR(200) NULL,
    hipertension          BIT NULL,
    dismorfologicos       BIT NULL, dismorfologicos_tipo NVARCHAR(200) NULL,
    diabetes              BIT NULL, diabetes_tipo        NVARCHAR(100) NULL,   -- NOM-004: tipo de diabetes
    cancer                BIT NULL, cancer_tipo          NVARCHAR(200) NULL,
    alergias              BIT NULL, alergias_tipo        NVARCHAR(200) NULL,
    padecimientos         BIT NULL, padecimientos_tipo   NVARCHAR(200) NULL,
    medicamentos          BIT NULL, medicamentos_tipo    NVARCHAR(200) NULL,
    estado_salud_actual   NVARCHAR(100) NULL
);
GO

CREATE TABLE dbo.antecedentes_heredofamiliares_madre (
    id                    INT IDENTITY(1,1) PRIMARY KEY,
    id_paciente           UNIQUEIDENTIFIER NOT NULL UNIQUE REFERENCES dbo.pacientes(id) ON DELETE CASCADE,
    nombre_completo       NVARCHAR(100) NULL,
    fecha_nacimiento      DATE NULL,
    ocupacion             NVARCHAR(50) NULL,
    tabaquismo            BIT NULL,
    alcoholismo           BIT NULL,
    toxicomanias          BIT NULL, toxicomanias_tipo   NVARCHAR(200) NULL,
    hipertension          BIT NULL,
    dismorfologicos       BIT NULL, dismorfologicos_tipo NVARCHAR(200) NULL,
    diabetes              BIT NULL, diabetes_tipo        NVARCHAR(100) NULL,
    cancer                BIT NULL, cancer_tipo          NVARCHAR(200) NULL,
    alergias              BIT NULL, alergias_tipo        NVARCHAR(200) NULL,
    padecimientos         BIT NULL, padecimientos_tipo   NVARCHAR(200) NULL,
    medicamentos          BIT NULL, medicamentos_tipo    NVARCHAR(200) NULL,
    estado_salud_actual   NVARCHAR(100) NULL,
    numero_embarazos       INT NULL,
    numero_partos_naturales INT NULL,
    numero_cesareas        INT NULL,
    numero_abortos          INT NULL
);
GO

-- REQ-PAC-008
CREATE TABLE dbo.antecedentes_prenatales (
    id                          INT IDENTITY(1,1) PRIMARY KEY,
    id_paciente                 UNIQUEIDENTIFIER NOT NULL UNIQUE REFERENCES dbo.pacientes(id) ON DELETE CASCADE,
    embarazo_planeado            BIT NULL,
    metodo_fertilizacion         NVARCHAR(50) NULL CHECK (metodo_fertilizacion IN (N'Fecundación in vitro', N'Inseminación artificial', N'Ninguno')),
    control_embarazo             BIT NULL,
    fecha_inicio_control          DATE NULL,
    responsable_control           NVARCHAR(50) NULL,
    padecimientos_madre           BIT NULL,
    fecha_inicio_padecimiento     DATE NULL,
    fecha_alta_padecimiento       DATE NULL
);
GO

-- REQ-PAC-009
CREATE TABLE dbo.antecedentes_natales (
    id                    INT IDENTITY(1,1) PRIMARY KEY,
    id_paciente           UNIQUEIDENTIFIER NOT NULL UNIQUE REFERENCES dbo.pacientes(id) ON DELETE CASCADE,
    hospital              NVARCHAR(100) NULL,
    tipo_nacimiento       NVARCHAR(20) NULL CHECK (tipo_nacimiento IN (N'Natural', N'Cesárea')),
    tipo_parto            NVARCHAR(20) NULL CHECK (tipo_parto IN (N'Único', N'Múltiple')),
    talla_nacimiento_cm   DECIMAL(4,1) NULL,
    peso_nacimiento_kg    DECIMAL(4,2) NULL
);
GO

-- REQ-PAC-010
CREATE TABLE dbo.antecedentes_posnatales (
    id                       INT IDENTITY(1,1) PRIMARY KEY,
    id_paciente              UNIQUEIDENTIFIER NOT NULL UNIQUE REFERENCES dbo.pacientes(id) ON DELETE CASCADE,
    requirio_vigilancia       BIT NULL,
    requirio_respirador        BIT NULL,
    requirio_incubadora        BIT NULL,
    requirio_fototerapia       BIT NULL,
    numero_fototerapias         INT NULL,
    otros_tratamientos          NVARCHAR(300) NULL
);
GO

-- REQ-PAC-011
CREATE TABLE dbo.alimentacion (
    id                INT IDENTITY(1,1) PRIMARY KEY,
    id_paciente       UNIQUEIDENTIFIER NOT NULL UNIQUE REFERENCES dbo.pacientes(id) ON DELETE CASCADE,
    pecho             BIT NULL, pecho_tiempo_meses     INT NULL,
    formula           BIT NULL, formula_edad_inicio    INT NULL,
    cereal            BIT NULL, cereal_edad_inicio     INT NULL,
    frutas            BIT NULL, frutas_edad_inicio     INT NULL,
    citricos          BIT NULL, citricos_edad_inicio   INT NULL,
    verduras          BIT NULL, verduras_edad_inicio   INT NULL,
    tomate            BIT NULL, tomate_edad_inicio     INT NULL
);
GO

-- REQ-PAC-012
CREATE TABLE dbo.desarrollo_psicomotor (
    id                    INT IDENTITY(1,1) PRIMARY KEY,
    id_paciente           UNIQUEIDENTIFIER NOT NULL UNIQUE REFERENCES dbo.pacientes(id) ON DELETE CASCADE,
    control_esfinteres    BIT NULL, control_esfinteres_edad_meses INT NULL,
    bipedestacion         BIT NULL, bipedestacion_edad_meses      INT NULL,
    deambulacion          BIT NULL, deambulacion_edad_meses       INT NULL,
    sosten_cefalico       BIT NULL, sosten_cefalico_edad_meses    INT NULL,
    volteo                BIT NULL, volteo_edad_meses             INT NULL,
    sedestacion           BIT NULL, sedestacion_edad_meses        INT NULL,
    gateo                 BIT NULL, gateo_edad_meses              INT NULL
);
GO

-- REQ-PAC-013
CREATE TABLE vacunas (
    id          INT IDENTITY(1,1) PRIMARY KEY,
    nombre      VARCHAR(100) NOT NULL, -- Ej. 'Hepatitis B', 'Influenza', 'DPT'
    enfermedad  VARCHAR(150) NOT NULL, -- Ej. 'Hepatitis B', 'Influenza estacional', 'Difteria, Tos ferina y Tétanos'
    activo      BIT NOT NULL DEFAULT 1
);

-- REQ-PAC-013 (Optimizado)
CREATE TABLE vacunacion (
    id                  INT IDENTITY(1,1) PRIMARY KEY,
    id_paciente         UNIQUEIDENTIFIER NOT NULL UNIQUE REFERENCES dbo.pacientes(id) ON DELETE CASCADE,
    id_vacuna           INT NOT NULL REFERENCES vacunas(id),
    
    -- La NOM exige claridad en las dosis/fechas si están disponibles
    num_dosis           INT NOT NULL DEFAULT 1, -- 1 para dosis única, o 1, 2, 3 para esquemas multidosis
    es_refuerzo         BIT NOT NULL DEFAULT 1,  -- Para identificar si es un refuerzo anual o periódico
    fecha_aplicacion    DATE NULL,              -- Puede ser NULL si el paciente no recuerda el día exacto pero afirma tenerla
    
    -- Soporte normativo: ¿Cómo validó el médico esta información?
    metodo_comprobacion VARCHAR(50) CHECK (metodo_comprobacion IN ('CARTILLA', 'INTERROGATORIO', 'EXPEDIENTE_PREVIO')),
    
    notas               VARCHAR(200) NULL,              -- Para registrar reacciones adversas, lote o marca (ej. Pfizer, Abdala)
    creado_en           DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    
    -- Evita que se duplique exactamente la misma dosis del mismo biológico para el mismo paciente
    CONSTRAINT uq_paciente_vacuna_dosis UNIQUE (id_paciente, id_vacuna, num_dosis, es_refuerzo)
);

/* CREATE TABLE dbo.vacunacion (
    id                       INT IDENTITY(1,1) PRIMARY KEY,
    id_paciente              UNIQUEIDENTIFIER NOT NULL UNIQUE REFERENCES dbo.pacientes(id) ON DELETE CASCADE,
    hepatitis_a              BIT NULL,
    hepatitis_b              BIT NULL,
    hib                      BIT NULL,
    meningococo              BIT NULL,
    dpt                      BIT NULL,
    poliomielitis            BIT NULL,
    rotavirus                BIT NULL,
    neumococo                BIT NULL,
    influenza                BIT NULL,
    mmr                      BIT NULL,
    varicela                 BIT NULL,
    hpv                      BIT NULL,
    tuberculosis             BIT NULL
); */

INSERT INTO vacunas (nombre, enfermedad) VALUES
-- Esquema Infantil / Básico (Alineado a Cartilla Nacional de 0 a 9 años)
('BCG', 'Tuberculosis meníngea y miliar'),
('Hepatitis B', 'Infección por el virus de la Hepatitis B'),
('Hexavalente Celular / DPaT+VPI+Hib+HB', 'Difteria, Tétanos, Tos ferina, Poliomielitis, Haemophilus influenzae tipo b y Hepatitis B'),
('Rotavirus', 'Diarrea severa por Rotavirus'),
('Neumocócica Conjugada', 'Infecciones neumocócicas (Neumonía, Meningitis)'),
('Influenza Estacional', 'Influenza (Gripe estacional)'),
('SRP (Triple Viral)', 'Sarampión, Rúbeola y Parotiditis (Paperas)'),
('DPT (Triple Bacteriana)', 'Difteria, Tos ferina y Tétanos'),
('OPV (Sabin)', 'Poliomielitis anterior aguda'),

-- Esquema de Adolescentes y Adultos (10 a 59 años)
('SR (Doble Viral)', 'Sarampión y Rúbeola'),
('Td (Tétanos y Difteria)', 'Tétanos y Difteria'),
('VPH (Virus del Papiloma Humano)', 'Infección por VPH y Cáncer Cervicouterino'),
('Tdpa', 'Tétanos, Difteria y Tos ferina acelular (Especialmente en embarazadas)'),

-- Otras vacunas comunes en el medio mexicano y adultos mayores
('Meningocócica', 'Meningitis por Neisseria meningitidis'),
('Hepatitis A', 'Infección por el virus de la Hepatitis A'),
('Varicela', 'Varicela y sus complicaciones'),
('Neumocócica Polisacárida (23 Valente)', 'Infecciones neumocócicas en adultos mayores y grupos de riesgo'),
('COVID-19', 'Infección por el virus SARS-CoV-2 (Coronavirus)');

GO

-- REQ-PAC-014
CREATE TABLE dbo.alergias (
    id                INT IDENTITY(1,1) PRIMARY KEY,
    id_paciente       UNIQUEIDENTIFIER NOT NULL UNIQUE REFERENCES dbo.pacientes(id) ON DELETE CASCADE,
    medicamentos      BIT NULL, medicamentos_agentes NVARCHAR(200) NULL,
    alimentos         BIT NULL, alimentos_agentes    NVARCHAR(200) NULL,
    flora             BIT NULL, flora_agentes        NVARCHAR(200) NULL,
    ropa              BIT NULL, ropa_agentes         NVARCHAR(200) NULL
);
GO

/* =====================================================================
   4. CONSULTAS  (REQ-CON-001 a 008)
   ===================================================================== */

CREATE TABLE dbo.consultas (
    id                            UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    id_paciente                   UNIQUEIDENTIFIER NOT NULL REFERENCES dbo.pacientes(id),   -- sin CASCADE: registro médico-legal
    id_medico                     UNIQUEIDENTIFIER NOT NULL REFERENCES dbo.medicos(id_usuario), -- REQ-CON-003/004
    fecha_consulta                DATE NOT NULL,
    hora_consulta                 TIME(0) NOT NULL DEFAULT CONVERT(TIME(0), SYSUTCDATETIME()),
    motivo                        NVARCHAR(100) NOT NULL,
    frecuencia_cardiaca            INT NOT NULL,
    frecuencia_respiratoria         INT NOT NULL,
    presion_sistolica               INT NOT NULL,
    presion_diastolica              INT NOT NULL,
    temperatura                     DECIMAL(4,1) NOT NULL,
    peso                            DECIMAL(5,2) NOT NULL,
    talla                           DECIMAL(5,2) NOT NULL,
    habitus_exterior                NVARCHAR(300) NULL,
    piel_anexos                     NVARCHAR(300) NULL,
    cabeza                          NVARCHAR(300) NULL,
    cuello                          NVARCHAR(300) NULL,
    torax                           NVARCHAR(300) NULL,
    abdomen                         NVARCHAR(300) NULL,
    extremidades                     NVARCHAR(300) NULL,
    imagen                           VARBINARY(MAX) NULL,
    resultados_estudios_previos       NVARCHAR(MAX) NULL,
    diagnostico                      NVARCHAR(MAX) NOT NULL,
    diagnostico_cie10                 NVARCHAR(10) NULL,             -- NOM-004
    padecimiento_actual                NVARCHAR(MAX) NULL,           -- NOM-004
    pronostico                         NVARCHAR(MAX) NOT NULL,
    tratamiento_indicaciones            NVARCHAR(MAX) NULL,
    fecha_registro                      DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    activo                              BIT NOT NULL DEFAULT 1
);
GO
CREATE INDEX IX_consultas_paciente ON dbo.consultas(id_paciente, fecha_consulta DESC);   -- REQ-CON-007
CREATE INDEX IX_consultas_medico ON dbo.consultas(id_medico);
GO

-- REQ-CON-001: tratamientos previos, lista 0..N
CREATE TABLE dbo.consulta_tratamientos_previos (
    id                     INT IDENTITY(1,1) PRIMARY KEY,
    id_consulta            UNIQUEIDENTIFIER NOT NULL REFERENCES dbo.consultas(id) ON DELETE CASCADE,
    nombre_comercial       NVARCHAR(100) NULL,
    principio_activo       NVARCHAR(100) NULL,
    dosis                  NVARCHAR(50) NULL,
    via                    NVARCHAR(30) NULL,
    frecuencia             NVARCHAR(50) NULL,
    fecha_administracion   DATE NULL,
    hora_administracion    TIME(0) NULL
);
GO

-- REQ-CON-001: interrogatorio por aparatos (1:1)
CREATE TABLE dbo.consulta_interrogatorio_aparatos (
    id                              INT IDENTITY(1,1) PRIMARY KEY,
    id_consulta                     UNIQUEIDENTIFIER NOT NULL UNIQUE REFERENCES dbo.consultas(id) ON DELETE CASCADE,
    respiratorio_cardiovascular     NVARCHAR(300) NULL,
    digestivo                       NVARCHAR(300) NULL,
    endocrino                       NVARCHAR(300) NULL,
    musculo_esqueletico             NVARCHAR(300) NULL,
    genito_urinario                 NVARCHAR(300) NULL,
    hematopoyetico_linfatico        NVARCHAR(300) NULL,
    piel_anexos                     NVARCHAR(300) NULL,
    neurologico_psiquiatrico        NVARCHAR(300) NULL
);
GO

/* =====================================================================
   5. RECETAS  (REQ-REC-001 a 008)
   ===================================================================== */

CREATE TABLE dbo.recetas (
    id                UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    folio             INT IDENTITY(1000,1) NOT NULL UNIQUE,     -- REQ-REC-002: folio impreso
    id_paciente       UNIQUEIDENTIFIER NOT NULL REFERENCES dbo.pacientes(id),
    id_consulta       UNIQUEIDENTIFIER NULL REFERENCES dbo.consultas(id),
    id_medico         UNIQUEIDENTIFIER NOT NULL REFERENCES dbo.medicos(id_usuario),
    fecha_emision     DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    peso              DECIMAL(5,2) NULL,
    talla             DECIMAL(5,2) NULL,
    -- IMC (REQ-REC-002) no se persiste: es un valor derivado y determinista
    -- de peso/talla (ya almacenados en esta misma fila), y su fórmula es
    -- lógica de negocio. La capa de aplicación lo calcula al generar o
    -- imprimir la receta.
    tension_arterial  VARCHAR(8) NULL,
    temperatura       DECIMAL(4,1) NULL,
    diagnostico       NVARCHAR(MAX) NULL,
    estado            NVARCHAR(20) NOT NULL DEFAULT N'Emitida'
        CHECK (estado IN (N'Emitida', N'Cancelada')),             -- REQ-REC-005: cancelar, no eliminar
    fecha_registro    DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME()
);
GO
CREATE INDEX IX_recetas_paciente ON dbo.recetas(id_paciente, fecha_emision DESC);   -- REQ-REC-004
GO

-- REQ-REC-001: medicamentos prescritos, lista 1..N
CREATE TABLE dbo.receta_medicamentos (
    id                    INT IDENTITY(1,1) PRIMARY KEY,
    id_receta             UNIQUEIDENTIFIER NOT NULL REFERENCES dbo.recetas(id) ON DELETE CASCADE,
    nombre_generico       NVARCHAR(100) NOT NULL,
    presentacion          NVARCHAR(20) NOT NULL CHECK (presentacion IN (N'Tabletas', N'Solución')),
    dosis                 NVARCHAR(50) NOT NULL,
    frecuencia_horas      INT NOT NULL,
    via_administracion    NVARCHAR(20) NOT NULL CHECK (via_administracion IN (N'Oral', N'Intravenosa')),
    indicaciones          NVARCHAR(200) NULL,
    duracion_dias         INT NOT NULL
);
GO

/* =====================================================================
   6. ESTADÍSTICAS  (REQ-EST-001 a 004)
   ===================================================================== */

-- Tabla de referencia OMS (LMS), estática, sin exposición externa: sin GUID.
CREATE TABLE dbo.crecimiento_oms (
    id          INT IDENTITY(1,1) PRIMARY KEY,
    indicador   NVARCHAR(20) NOT NULL,     -- 'PesoEdad','TallaEdad', etc.
    sexo        NVARCHAR(10) NOT NULL,
    mes_edad    INT NULL,
    medicion    NVARCHAR(10) NULL,
    l           FLOAT NULL,
    m           FLOAT NULL,
    s           FLOAT NULL
);
GO
CREATE INDEX IX_crecimiento_oms_lookup ON dbo.crecimiento_oms(indicador, sexo, mes_edad);
GO

PRINT 'Esquema Pediatria V6.1 (SQL Server) creado correctamente.';
GO
