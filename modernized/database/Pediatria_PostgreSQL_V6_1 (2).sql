/* =====================================================================
   PEDIATRÍA — Base de datos modernizada (PostgreSQL 16+)
   Fuente de requisitos: Documento de Requisitos V6.1 (Manuel Razo)
   Cumplimiento: NOM-004-SSA3-2012 (expediente clínico)
   Generado: 2026-09-08

   Equivalente funcional de Pediatria_SQLServer_V6_1.sql. Ver ese archivo
   para el detalle completo de las decisiones de diseño; aquí solo se
   anotan las diferencias propias del motor:

   - UNIQUEIDENTIFIER -> UUID. El GUID lo genera la capa de aplicación
     (no la BD): estas columnas NO llevan DEFAULT ni dependen de
     gen_random_uuid()/pgcrypto. Mismo motivo que en el script de SQL
     Server: el dominio necesita el Id antes de persistir, y así el
     generador del PK es idéntico sin importar el motor. Si en el
     futuro se requiere orden temporal real (ej. paginación eficiente),
     generar UUIDv7 en la aplicación es la ruta recomendada — en
     Postgres la fragmentación por PK aleatoria ya es un problema menor
     que en SQL Server porque las tablas heap no tienen índice clúster.
   - IDENTITY(n,1) -> GENERATED ALWAYS AS IDENTITY (START WITH n).
   - IMC en receta: no se calcula en la BD en ninguno de los dos motores
     (decisión de diseño: es lógica de negocio, ver comentario en la
     tabla recetas), así que no hay diferencia de sintaxis que anotar aquí.
   - Índice filtrado (WHERE ...) -> índice parcial, misma sintaxis.
   - NVARCHAR(MAX)/VARBINARY(MAX) -> TEXT / BYTEA.
   - BIT -> BOOLEAN.
   - SYSUTCDATETIME() -> now() AT TIME ZONE 'utc' (o timestamptz con
     CURRENT_TIMESTAMP, ya almacenado en UTC internamente).
   ===================================================================== */

-- Ejecutar conectado a la base de datos "pediatria" ya creada
-- (CREATE DATABASE no puede ir dentro de una transacción/script portable).
-- CREATE DATABASE pediatria;
-- \c pediatria

-- pgcrypto ya no es necesaria: el GUID lo genera la aplicación, no la BD.

CREATE SCHEMA IF NOT EXISTS pediatria;
SET search_path TO pediatria;

/* =====================================================================
   1. USUARIOS  (REQ-USR-001 a 016 / REQ-SEC-001 a 005)
   ===================================================================== */

CREATE TABLE roles (
    id      INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nombre  VARCHAR(30) NOT NULL UNIQUE
        CHECK (nombre IN ('Administrador', 'Medico', 'Recepcionista'))
);

INSERT INTO roles (nombre) VALUES ('Administrador'), ('Medico'), ('Recepcionista');

-- Tabla base de autenticación. UUID: es el "sub" natural de un JWT y evita
-- enumeración de usuarios en endpoints de administración (REQ-USR-006/007).
CREATE TABLE usuarios (
    id                   UUID NOT NULL PRIMARY KEY,
    nombre_usuario       VARCHAR(50)  NOT NULL UNIQUE,
    correo_electronico   VARCHAR(100) NOT NULL UNIQUE,          -- REQ-USR-003: recuperación por correo
    contrasena_hash      VARCHAR(256) NOT NULL,                 -- REQ-SEC-004: nunca texto plano
    id_rol               INT NOT NULL REFERENCES roles(id),     -- REQ-USR-005
    activo               BOOLEAN NOT NULL DEFAULT TRUE,
    fecha_registro       TIMESTAMPTZ NOT NULL DEFAULT now(),
    fecha_ultimo_acceso  TIMESTAMPTZ NULL,
    fecha_baja           TIMESTAMPTZ NULL                       -- REQ-USR-015: baja lógica, no física
);
CREATE INDEX IX_usuarios_rol ON usuarios(id_rol) WHERE activo = TRUE;

-- Perfil extendido de médico (1:1 con usuarios, PK compartida).
CREATE TABLE medicos (
    id_usuario              UUID NOT NULL PRIMARY KEY
        REFERENCES usuarios(id) ON DELETE CASCADE,
    nombre_completo          VARCHAR(100) NOT NULL,
    fecha_nacimiento         DATE NOT NULL,
    sexo                     VARCHAR(10) NOT NULL CHECK (sexo IN ('Masculino', 'Femenino', 'Otro')),
    cedula_profesional       VARCHAR(20) NOT NULL UNIQUE,        -- REQ-USR-010
    institucion_educativa    VARCHAR(100) NOT NULL,
    especialidad             VARCHAR(100) NOT NULL,
    firma                    BYTEA NULL                          -- REQ-USR-009 / REQ-REC-002 (firma en receta)
);

-- Perfil extendido de recepcionista (1:1 con usuarios).
CREATE TABLE recepcionistas (
    id_usuario        UUID NOT NULL PRIMARY KEY
        REFERENCES usuarios(id) ON DELETE CASCADE,
    nombre_completo   VARCHAR(100) NOT NULL,
    fecha_nacimiento  DATE NOT NULL,
    sexo              VARCHAR(10) NOT NULL CHECK (sexo IN ('Masculino', 'Femenino', 'Otro'))
);

-- Datos del consultorio, editables por el administrador sin tocar código (REQ-SOP-003)
-- y usados para imprimir la receta (REQ-REC-002).
CREATE TABLE consultorio (
    id           INT NOT NULL PRIMARY KEY CHECK (id = 1),   -- fila única (patrón singleton)
    nombre       VARCHAR(100) NOT NULL,
    domicilio    VARCHAR(150) NOT NULL,
    telefono     VARCHAR(15)  NOT NULL
);

CREATE TABLE refresh_tokens (
    id                 UUID NOT NULL PRIMARY KEY,
    id_usuario         UUID NOT NULL REFERENCES usuarios(id) ON DELETE CASCADE,
    token_hash         VARCHAR(256) NOT NULL,
    fecha_creacion     TIMESTAMPTZ NOT NULL DEFAULT now(),
    fecha_expiracion   TIMESTAMPTZ NOT NULL,
    revocado           BOOLEAN NOT NULL DEFAULT FALSE,
    creado_por_ip      VARCHAR(45) NULL
);
CREATE INDEX IX_refresh_tokens_usuario ON refresh_tokens(id_usuario) WHERE revocado = FALSE;

-- Recuperación de contraseña: contraseña temporal generada por el administrador,
-- expira en 24h, obliga a cambio en siguiente inicio de sesión.
CREATE TABLE password_resets (
    id                    UUID NOT NULL PRIMARY KEY,
    id_usuario            UUID NOT NULL REFERENCES usuarios(id) ON DELETE CASCADE,
    id_admin_ejecuta      UUID NOT NULL REFERENCES usuarios(id),
    temp_password_hash    VARCHAR(256) NOT NULL,
    fecha_creacion        TIMESTAMPTZ NOT NULL DEFAULT now(),
    fecha_expiracion      TIMESTAMPTZ NOT NULL,       -- fecha_creacion + 24h, calculado en aplicación
    usado                 BOOLEAN NOT NULL DEFAULT FALSE
);

-- Bitácora de auditoría unificada (REQ-USR-016, REQ-PAC-020, REQ-SOP-005).
-- BIGINT identity: tabla append-only de alto volumen, UUID no aporta aquí.
CREATE TABLE bitacora_auditoria (
    id            BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_usuario    UUID NULL REFERENCES usuarios(id),   -- NULL: intento fallido antes de autenticar
    entidad       VARCHAR(50) NOT NULL,      -- 'Usuario' | 'Paciente' | 'Consulta' | 'Receta' | 'Cita'
    id_entidad    VARCHAR(50) NULL,          -- UUID o entero como texto; agnóstico al tipo de PK
    accion        VARCHAR(30) NOT NULL
        CHECK (accion IN ('Acceso', 'Creación', 'Modificación', 'Eliminación')),
    fecha_hora    TIMESTAMPTZ NOT NULL DEFAULT now(),
    direccion_ip  VARCHAR(45) NULL,
    detalles      VARCHAR(500) NULL
);
CREATE INDEX IX_bitacora_entidad ON bitacora_auditoria(entidad, id_entidad);
CREATE INDEX IX_bitacora_usuario_fecha ON bitacora_auditoria(id_usuario, fecha_hora);

/* =====================================================================
   2. CITAS  (REQ-CIT-001 a 013)
   ===================================================================== */

CREATE TABLE dias_no_disponibles (
    id      INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    fecha   DATE NOT NULL UNIQUE,
    motivo  VARCHAR(100) NULL
);

-- UUID: se referencia desde flujos de recepción (reagendar/cancelar por URL).
-- id_paciente es NULLABLE: una cita puede agendarse para alguien aún no
-- registrado formalmente como paciente (flujo walk-in / telefónico).
-- La FK se agrega más abajo con ALTER TABLE, una vez creada "pacientes".
CREATE TABLE citas (
    id               UUID NOT NULL PRIMARY KEY,
    id_paciente      UUID NULL,
    nombre_paciente  VARCHAR(100) NOT NULL,
    fecha            DATE NOT NULL,
    hora             TIME(0) NOT NULL,
    es_primera_vez   BOOLEAN NOT NULL DEFAULT FALSE,
    telefono         VARCHAR(15) NULL,
    afiliacion       VARCHAR(20) NULL CHECK (afiliacion IN ('Carl''s Jr', 'Pemex', 'Ninguno')),
    estado           VARCHAR(20) NOT NULL DEFAULT 'Programada'
        CHECK (estado IN ('Programada', 'Reagendada', 'Cancelada', 'Atendida')),
    fecha_registro   TIMESTAMPTZ NOT NULL DEFAULT now()
    -- Nota: las reglas de negocio "no domingo" (REQ-CIT-011) y "horario en
    -- múltiplos de 20 min" (REQ-CIT-003) se validan en la capa de dominio
    -- (Value Object HorarioCita), no aquí. La BD solo conserva las
    -- restricciones de integridad de datos (enum de estado/afiliación).
);

/* =====================================================================
   3. PACIENTES  (REQ-PAC-001 a 020)
   ===================================================================== */

-- UUID como PK técnica/API; numero_expediente como folio legal consecutivo
-- (REQ-PAC-003), independiente y NOT NULL UNIQUE.
CREATE TABLE pacientes (
    id                         UUID NOT NULL PRIMARY KEY,
    numero_expediente          INT GENERATED ALWAYS AS IDENTITY (START WITH 1000) NOT NULL UNIQUE,
    nombre_completo            VARCHAR(100) NOT NULL,
    fecha_nacimiento           DATE NOT NULL,
    sexo                       VARCHAR(10) NOT NULL CHECK (sexo IN ('Masculino', 'Femenino')),
    curp                       CHAR(18) NOT NULL UNIQUE,                -- NOM-004
    domicilio                  VARCHAR(150) NOT NULL,
    codigo_postal              CHAR(5) NOT NULL,
    lugar_nacimiento           VARCHAR(100) NOT NULL,
    grupo_etnico               VARCHAR(50) NULL,                       -- NOM-004
    tipo_sangre                VARCHAR(3) NULL
        CHECK (tipo_sangre IN ('A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-')),
    nombre_tutor                VARCHAR(100) NULL,
    parentesco_tutor            VARCHAR(30) NULL,
    telefono_tutor               VARCHAR(15) NULL,
    afiliacion                  VARCHAR(20) NULL CHECK (afiliacion IN ('Pemex', 'Carl''s Jr', 'Ninguno')),
    numero_seguro_particular     VARCHAR(30) NULL,
    otro_tipo_seguro              VARCHAR(50) NULL,
    numero_seguro                 VARCHAR(30) NULL,
    observaciones_generales       TEXT NULL,
    id_medico_asignado            UUID NULL REFERENCES medicos(id_usuario),
    fecha_registro                 TIMESTAMPTZ NOT NULL DEFAULT now(),
    activo                         BOOLEAN NOT NULL DEFAULT TRUE,       -- baja lógica: retención 5 años
    fecha_baja_logica              TIMESTAMPTZ NULL
);

-- Ahora que "pacientes" ya existe, se agrega la FK real de citas.
ALTER TABLE citas
    ADD CONSTRAINT FK_citas_paciente FOREIGN KEY (id_paciente)
    REFERENCES pacientes(id) ON DELETE SET NULL;

CREATE INDEX IX_citas_paciente ON citas(id_paciente);
CREATE UNIQUE INDEX UX_citas_fecha_hora_activas ON citas(fecha, hora)
    WHERE estado <> 'Cancelada';   -- REQ-CIT-013: no choque de horarios

CREATE INDEX IX_pacientes_nombre ON pacientes(nombre_completo);          -- REQ-PAC-001
CREATE INDEX IX_pacientes_medico ON pacientes(id_medico_asignado);

-- REQ-PAC-004: antecedentes patológicos (1:1)
CREATE TABLE antecedentes_patologicos (
    id                          INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_paciente                 UUID NOT NULL UNIQUE REFERENCES pacientes(id) ON DELETE CASCADE,
    enfermedades_previas         BOOLEAN NULL, enfermedades_previas_tipo         VARCHAR(200) NULL,
    secuelas                     BOOLEAN NULL, secuelas_tipo                     VARCHAR(200) NULL,
    hospitalizaciones            BOOLEAN NULL, hospitalizaciones_tipo            VARCHAR(200) NULL,
    cirugias                     BOOLEAN NULL, cirugias_tipo                     VARCHAR(200) NULL,
    transfusiones                BOOLEAN NULL, transfusiones_tipo                VARCHAR(200) NULL,
    fracturas                    BOOLEAN NULL, fracturas_tipo                    VARCHAR(200) NULL,
    traumatismos_accidentes      BOOLEAN NULL, traumatismos_accidentes_tipo      VARCHAR(200) NULL,
    enf_exantematicas            BOOLEAN NULL, enf_exantematicas_tipo            VARCHAR(200) NULL,
    enf_cronico_degenerativas    BOOLEAN NULL, enf_cronico_degenerativas_tipo    VARCHAR(200) NULL
);

-- REQ-PAC-005: antecedentes no patológicos (1:1)
CREATE TABLE antecedentes_no_patologicos (
    id                     INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_paciente            UUID NOT NULL UNIQUE REFERENCES pacientes(id) ON DELETE CASCADE,
    tipo_vivienda          VARCHAR(100) NULL,
    servicios              VARCHAR(200) NULL,
    hacinamiento           VARCHAR(100) NULL,
    habitos_higiene        VARCHAR(200) NULL,
    habitos_alimenticios   VARCHAR(200) NULL,
    escolaridad            VARCHAR(100) NULL,
    convivencia_animales   BOOLEAN NULL, convivencia_animales_tipo VARCHAR(200) NULL,
    actividad_fisica       BOOLEAN NULL, actividad_fisica_tipo     VARCHAR(200) NULL
);

-- REQ-PAC-006 / REQ-PAC-007: heredofamiliares padre / madre.
-- Se separa en dos tablas porque los campos no son simétricos (madre
-- agrega historial obstétrico) y así evita columnas NULL sin sentido en el padre.
CREATE TABLE antecedentes_heredofamiliares_padre (
    id                    INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_paciente           UUID NOT NULL UNIQUE REFERENCES pacientes(id) ON DELETE CASCADE,
    nombre_completo       VARCHAR(100) NULL,
    fecha_nacimiento      DATE NULL,
    ocupacion             VARCHAR(50) NULL,
    tabaquismo            BOOLEAN NULL,
    alcoholismo           BOOLEAN NULL,
    toxicomanias          BOOLEAN NULL, toxicomanias_tipo   VARCHAR(200) NULL,
    hipertension          BOOLEAN NULL,
    dismorfologicos       BOOLEAN NULL, dismorfologicos_tipo VARCHAR(200) NULL,
    diabetes              BOOLEAN NULL, diabetes_tipo        VARCHAR(100) NULL,   -- NOM-004: tipo de diabetes
    cancer                BOOLEAN NULL, cancer_tipo          VARCHAR(200) NULL,
    alergias              BOOLEAN NULL, alergias_tipo        VARCHAR(200) NULL,
    padecimientos         BOOLEAN NULL, padecimientos_tipo   VARCHAR(200) NULL,
    medicamentos          BOOLEAN NULL, medicamentos_tipo    VARCHAR(200) NULL,
    estado_salud_actual   VARCHAR(100) NULL
);

CREATE TABLE antecedentes_heredofamiliares_madre (
    id                    INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_paciente           UUID NOT NULL UNIQUE REFERENCES pacientes(id) ON DELETE CASCADE,
    nombre_completo       VARCHAR(100) NULL,
    fecha_nacimiento      DATE NULL,
    ocupacion             VARCHAR(50) NULL,
    tabaquismo            BOOLEAN NULL,
    alcoholismo           BOOLEAN NULL,
    toxicomanias          BOOLEAN NULL, toxicomanias_tipo   VARCHAR(200) NULL,
    hipertension          BOOLEAN NULL,
    dismorfologicos       BOOLEAN NULL, dismorfologicos_tipo VARCHAR(200) NULL,
    diabetes              BOOLEAN NULL, diabetes_tipo        VARCHAR(100) NULL,
    cancer                BOOLEAN NULL, cancer_tipo          VARCHAR(200) NULL,
    alergias              BOOLEAN NULL, alergias_tipo        VARCHAR(200) NULL,
    padecimientos         BOOLEAN NULL, padecimientos_tipo   VARCHAR(200) NULL,
    medicamentos          BOOLEAN NULL, medicamentos_tipo    VARCHAR(200) NULL,
    estado_salud_actual   VARCHAR(100) NULL,
    numero_embarazos        INT NULL,
    numero_partos_naturales INT NULL,
    numero_cesareas          INT NULL,
    numero_abortos            INT NULL
);

-- REQ-PAC-008
CREATE TABLE antecedentes_prenatales (
    id                          INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_paciente                 UUID NOT NULL UNIQUE REFERENCES pacientes(id) ON DELETE CASCADE,
    embarazo_planeado            BOOLEAN NULL,
    metodo_fertilizacion         VARCHAR(50) NULL CHECK (metodo_fertilizacion IN ('Fecundación in vitro', 'Inseminación artificial', 'Ninguno')),
    control_embarazo             BOOLEAN NULL,
    fecha_inicio_control          DATE NULL,
    responsable_control           VARCHAR(50) NULL,
    padecimientos_madre           BOOLEAN NULL,
    fecha_inicio_padecimiento     DATE NULL,
    fecha_alta_padecimiento       DATE NULL
);

-- REQ-PAC-009
CREATE TABLE antecedentes_natales (
    id                    INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_paciente           UUID NOT NULL UNIQUE REFERENCES pacientes(id) ON DELETE CASCADE,
    hospital              VARCHAR(100) NULL,
    tipo_nacimiento       VARCHAR(20) NULL CHECK (tipo_nacimiento IN ('Natural', 'Cesárea')),
    tipo_parto            VARCHAR(20) NULL CHECK (tipo_parto IN ('Único', 'Múltiple')),
    talla_nacimiento_cm   NUMERIC(4,1) NULL,
    peso_nacimiento_kg    NUMERIC(4,2) NULL
);

-- REQ-PAC-010
CREATE TABLE antecedentes_posnatales (
    id                       INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_paciente              UUID NOT NULL UNIQUE REFERENCES pacientes(id) ON DELETE CASCADE,
    requirio_vigilancia       BOOLEAN NULL,
    requirio_respirador        BOOLEAN NULL,
    requirio_incubadora        BOOLEAN NULL,
    requirio_fototerapia       BOOLEAN NULL,
    numero_fototerapias         INT NULL,
    otros_tratamientos          VARCHAR(300) NULL
);

-- REQ-PAC-011
CREATE TABLE alimentacion (
    id                INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_paciente       UUID NOT NULL UNIQUE REFERENCES pacientes(id) ON DELETE CASCADE,
    pecho             BOOLEAN NULL, pecho_tiempo_meses     INT NULL,
    formula           BOOLEAN NULL, formula_edad_inicio    INT NULL,
    cereal            BOOLEAN NULL, cereal_edad_inicio     INT NULL,
    frutas            BOOLEAN NULL, frutas_edad_inicio     INT NULL,
    citricos          BOOLEAN NULL, citricos_edad_inicio   INT NULL,
    verduras          BOOLEAN NULL, verduras_edad_inicio   INT NULL,
    tomate            BOOLEAN NULL, tomate_edad_inicio     INT NULL
);

-- REQ-PAC-012
CREATE TABLE desarrollo_psicomotor (
    id                    INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_paciente           UUID NOT NULL UNIQUE REFERENCES pacientes(id) ON DELETE CASCADE,
    control_esfinteres    BOOLEAN NULL, control_esfinteres_edad_meses INT NULL,
    bipedestacion         BOOLEAN NULL, bipedestacion_edad_meses      INT NULL,
    deambulacion          BOOLEAN NULL, deambulacion_edad_meses       INT NULL,
    sosten_cefalico       BOOLEAN NULL, sosten_cefalico_edad_meses    INT NULL,
    volteo                BOOLEAN NULL, volteo_edad_meses             INT NULL,
    sedestacion           BOOLEAN NULL, sedestacion_edad_meses        INT NULL,
    gateo                 BOOLEAN NULL, gateo_edad_meses              INT NULL
);

-- REQ-PAC-013
CREATE TABLE vacunas (
    id          INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nombre      VARCHAR(100) NOT NULL, -- Ej. 'Hepatitis B', 'Influenza', 'DPT'
    enfermedad  VARCHAR(150) NOT NULL, -- Ej. 'Hepatitis B', 'Influenza estacional', 'Difteria, Tos ferina y Tétanos'
    activo      BOOLEAN DEFAULT TRUE
);

-- REQ-PAC-013 (Optimizado)
CREATE TABLE vacunacion (
    id                  INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_paciente         UUID NOT NULL REFERENCES pacientes(id) ON DELETE CASCADE,
    id_vacuna           INT NOT NULL REFERENCES vacunas(id),
    
    -- La NOM exige claridad en las dosis/fechas si están disponibles
    num_dosis           INT NOT NULL DEFAULT 1, -- 1 para dosis única, o 1, 2, 3 para esquemas multidosis
    es_refuerzo         BOOLEAN DEFAULT FALSE,  -- Para identificar si es un refuerzo anual o periódico
    fecha_aplicacion    DATE NULL,              -- Puede ser NULL si el paciente no recuerda el día exacto pero afirma tenerla
    
    -- Soporte normativo: ¿Cómo validó el médico esta información?
    metodo_comprobacion VARCHAR(50) CHECK (metodo_comprobacion IN ('CARTILLA', 'INTERROGATORIO', 'EXPEDIENTE_PREVIO')),
    
    notas               TEXT NULL,              -- Para registrar reacciones adversas, lote o marca (ej. Pfizer, Abdala)
    creado_en           TIMESTAMPTZ DEFAULT NOW(),
    
    -- Evita que se duplique exactamente la misma dosis del mismo biológico para el mismo paciente
    CONSTRAINT uq_paciente_vacuna_dosis UNIQUE (id_paciente, id_vacine, num_dosis, es_refuerzo)
);

/* CREATE TABLE vacunacion (
    id                       INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_paciente              UUID NOT NULL UNIQUE REFERENCES pacientes(id) ON DELETE CASCADE,
    hepatitis_a              BOOLEAN NULL,
    hepatitis_b              BOOLEAN NULL,
    hib                      BOOLEAN NULL,
    meningococo              BOOLEAN NULL,
    dpt                      BOOLEAN NULL,
    poliomielitis            BOOLEAN NULL,
    rotavirus                BOOLEAN NULL,
    neumococo                BOOLEAN NULL,
    influenza                BOOLEAN NULL,
    mmr                      BOOLEAN NULL,
    varicela                 BOOLEAN NULL,
    hpv                      BOOLEAN NULL,
    tuberculosis             BOOLEAN NULL
); */

INSERT INTO cat_vacunas (nombre, enfermedad) VALUES
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


-- REQ-PAC-014
CREATE TABLE alergias (
    id                INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_paciente       UUID NOT NULL UNIQUE REFERENCES pacientes(id) ON DELETE CASCADE,
    medicamentos      BOOLEAN NULL, medicamentos_agentes VARCHAR(200) NULL,
    alimentos         BOOLEAN NULL, alimentos_agentes    VARCHAR(200) NULL,
    flora             BOOLEAN NULL, flora_agentes        VARCHAR(200) NULL,
    ropa              BOOLEAN NULL, ropa_agentes         VARCHAR(200) NULL
);

/* =====================================================================
   4. CONSULTAS  (REQ-CON-001 a 008)
   ===================================================================== */

CREATE TABLE consultas (
    id                            UUID NOT NULL PRIMARY KEY,
    id_paciente                   UUID NOT NULL REFERENCES pacientes(id),   -- sin CASCADE: registro médico-legal
    id_medico                     UUID NOT NULL REFERENCES medicos(id_usuario), -- REQ-CON-003/004
    fecha_consulta                DATE NOT NULL,
    hora_consulta                 TIME(0) NOT NULL DEFAULT CURRENT_TIME(0),
    motivo                        VARCHAR(100) NOT NULL,
    frecuencia_cardiaca            INT NOT NULL,
    frecuencia_respiratoria         INT NOT NULL,
    presion_sistolica               INT NOT NULL,
    presion_diastolica              INT NOT NULL,
    temperatura                     NUMERIC(4,1) NOT NULL,
    peso                            NUMERIC(5,2) NOT NULL,
    talla                           NUMERIC(5,2) NOT NULL,
    habitus_exterior                VARCHAR(300) NULL,
    piel_anexos                     VARCHAR(300) NULL,
    cabeza                          VARCHAR(300) NULL,
    cuello                          VARCHAR(300) NULL,
    torax                           VARCHAR(300) NULL,
    abdomen                         VARCHAR(300) NULL,
    extremidades                     VARCHAR(300) NULL,
    imagen                           BYTEA NULL,
    resultados_estudios_previos       TEXT NULL,
    diagnostico                      TEXT NOT NULL,
    diagnostico_cie10                 VARCHAR(10) NULL,             -- NOM-004
    padecimiento_actual                TEXT NULL,                   -- NOM-004
    pronostico                         TEXT NOT NULL,
    tratamiento_indicaciones            TEXT NULL,
    fecha_registro                      TIMESTAMPTZ NOT NULL DEFAULT now(),
    activo                               BOOLEAN NOT NULL DEFAULT TRUE
);
CREATE INDEX IX_consultas_paciente ON consultas(id_paciente, fecha_consulta DESC);   -- REQ-CON-007
CREATE INDEX IX_consultas_medico ON consultas(id_medico);

-- REQ-CON-001: tratamientos previos, lista 0..N
CREATE TABLE consulta_tratamientos_previos (
    id                     INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_consulta            UUID NOT NULL REFERENCES consultas(id) ON DELETE CASCADE,
    nombre_comercial       VARCHAR(100) NULL,
    principio_activo       VARCHAR(100) NULL,
    dosis                  VARCHAR(50) NULL,
    via                    VARCHAR(30) NULL,
    frecuencia             VARCHAR(50) NULL,
    fecha_administracion   DATE NULL,
    hora_administracion    TIME(0) NULL
);

-- REQ-CON-001: interrogatorio por aparatos (1:1)
CREATE TABLE consulta_interrogatorio_aparatos (
    id                              INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_consulta                     UUID NOT NULL UNIQUE REFERENCES consultas(id) ON DELETE CASCADE,
    respiratorio_cardiovascular     VARCHAR(300) NULL,
    digestivo                       VARCHAR(300) NULL,
    endocrino                       VARCHAR(300) NULL,
    musculo_esqueletico             VARCHAR(300) NULL,
    genito_urinario                 VARCHAR(300) NULL,
    hematopoyetico_linfatico        VARCHAR(300) NULL,
    piel_anexos                     VARCHAR(300) NULL,
    neurologico_psiquiatrico        VARCHAR(300) NULL
);

/* =====================================================================
   5. RECETAS  (REQ-REC-001 a 008)
   ===================================================================== */

CREATE TABLE recetas (
    id                UUID NOT NULL PRIMARY KEY,
    folio             INT GENERATED ALWAYS AS IDENTITY (START WITH 1000) NOT NULL UNIQUE,  -- REQ-REC-002
    id_paciente       UUID NOT NULL REFERENCES pacientes(id),
    id_consulta       UUID NULL REFERENCES consultas(id),
    id_medico         UUID NOT NULL REFERENCES medicos(id_usuario),
    fecha_emision     TIMESTAMPTZ NOT NULL DEFAULT now(),
    peso              NUMERIC(5,2) NULL,
    talla             NUMERIC(5,2) NULL,
    imc               NUMERIC(5,2) GENERATED ALWAYS AS (
                          CASE WHEN talla > 0 THEN peso / ((talla / 100.0) * (talla / 100.0)) END
                      ) STORED,
    tension_arterial  VARCHAR(8) NULL,
    temperatura       NUMERIC(4,1) NULL,
    diagnostico       TEXT NULL,
    estado            VARCHAR(20) NOT NULL DEFAULT 'Emitida'
        CHECK (estado IN ('Emitida', 'Cancelada')),             -- REQ-REC-005: cancelar, no eliminar
    fecha_registro    TIMESTAMPTZ NOT NULL DEFAULT now()
);
CREATE INDEX IX_recetas_paciente ON recetas(id_paciente, fecha_emision DESC);   -- REQ-REC-004

-- REQ-REC-001: medicamentos prescritos, lista 1..N
CREATE TABLE receta_medicamentos (
    id                    INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_receta             UUID NOT NULL REFERENCES recetas(id) ON DELETE CASCADE,
    nombre_generico       VARCHAR(100) NOT NULL,
    presentacion          VARCHAR(20) NOT NULL CHECK (presentacion IN ('Tabletas', 'Solución')),
    dosis                 VARCHAR(50) NOT NULL,
    frecuencia_horas      INT NOT NULL,
    via_administracion    VARCHAR(20) NOT NULL CHECK (via_administracion IN ('Oral', 'Intravenosa')),
    indicaciones          VARCHAR(200) NULL,
    duracion_dias         INT NOT NULL
);

/* =====================================================================
   6. ESTADÍSTICAS  (REQ-EST-001 a 004)
   ===================================================================== */

-- Tabla de referencia OMS (LMS), estática, sin exposición externa: sin UUID.
CREATE TABLE crecimiento_oms (
    id          INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    indicador   VARCHAR(20) NOT NULL,     -- 'PesoEdad','TallaEdad', etc.
    sexo        VARCHAR(10) NOT NULL,
    mes_edad    INT NULL,
    medicion    VARCHAR(10) NULL,
    l           DOUBLE PRECISION NULL,
    m           DOUBLE PRECISION NULL,
    s           DOUBLE PRECISION NULL
);
CREATE INDEX IX_crecimiento_oms_lookup ON crecimiento_oms(indicador, sexo, mes_edad);
