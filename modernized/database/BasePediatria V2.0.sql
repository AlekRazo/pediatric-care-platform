USE [master]
GO

/****** Base de datos Pediatria V2 ******/
CREATE DATABASE [pediatriaV2]
GO

USE [pediatriaV2]
GO

/****** MODULO USUARIOS ******/
CREATE TABLE [dbo].[roles] (
	[id] SMALLINT NOT NULL,
	[rol] VARCHAR(50) NOT NULL,
	[descripcion] VARCHAR(255),
	CONSTRAINT [PK_roles] PRIMARY KEY ([id])
)
GO

INSERT INTO [dbo].[roles] ([id],[rol]) VALUES (1,'Administrador','');
INSERT INTO [dbo].[roles] ([id],[rol]) VALUES (2,'Pediatra','');
INSERT INTO [dbo].[roles] ([id],[rol]) VALUES (3,'Recepcionista','');
GO

CREATE TABLE [dbo].[usuarios] (
	[id] BIGINT IDENTITY(1, 1) NOT NULL,
	[nombre] VARCHAR(50) NOT NULL,
	[correo_electronico] VARCHAR(50) NULL,
	[contrasena_hash] VARCHAR(255) NOT NULL,
	[id_rol] SMALLINT NOT NULL,
	[activo] BIT NOT NULL,
	[intentos_fallidos] SMALLINT DEFAULT 0,
	[bloqueado] BIT NOT NULL DEFAULT 0,
	[ultimo_acceso] DATETIME NULL,
	[fecha_registro] DATETIME NULL CONSTRAINT [DF_usuarios_fecha_registro] DEFAULT CURRENT_TIMESTAMP,
	[fecha_modificacion] DATETIME NULL CONSTRAINT [DF_usuarios_fecha_modificacion] DEFAULT CURRENT_TIMESTAMP,
	CONSTRAINT [PK_usuarios] PRIMARY KEY ([id]),
	CONSTRAINT [FK_usuarios_rol] FOREIGN KEY ([id_rol]) REFERENCES [dbo].[roles]([id]),
	CONSTRAINT [UQ_usuarios_correo] UNIQUE ([correo_electronico])
)
GO

CREATE TABLE [dbo].[refresh_token] (
	[id] BIGINT IDENTITY(1, 1) NOT NULL,
	[id_usuario] BIGINT NOT NULL,
	[token] VARCHAR(255) NOT NULL,
	[fecha_expiracion] DATETIME NOT NULL,
	[revocado] BIT NOT NULL DEFAULT 0,
	[fecha_creacion] DATETIME NOT NULL CONSTRAINT [DF_refresh_token_fecha_creacion] DEFAULT CURRENT_TIMESTAMP,
	CONSTRAINT [PK_refresh_token] PRIMARY KEY ([id]),
	CONSTRAINT [FK_refresh_token_usuario] FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[usuarios]([id]),
	CONSTRAINT [UQ_refresh_token_token] UNIQUE ([token])
)
GO

CREATE TABLE [dbo].[medicos] (
	[id_usuario] BIGINT NOT NULL,
	[nombre] VARCHAR(50) NOT NULL,
	[fecha_nacimiento] DATE NULL,
	[sexo] VARCHAR(20) NULL,
	[cedula] VARCHAR(20) NULL,
	[especialidad] VARCHAR(100) NULL,
	[fecha_registro] DATETIME NULL CONSTRAINT [DF_medicos_fecha_registro] DEFAULT CURRENT_TIMESTAMP,
	[fecha_modificacion] DATETIME NULL CONSTRAINT [DF_medicos_fecha_modificacion] DEFAULT CURRENT_TIMESTAMP,
	CONSTRAINT [PK_medicos] PRIMARY KEY ([id_usuario]),
	CONSTRAINT [FK_medicos_usuario] FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[usuarios]([id]),
	CONSTRAINT [UQ_medicos_cedula] UNIQUE ([cedula])
)
GO

CREATE TABLE [dbo].[recepcionistas] (
	[id_usuario] BIGINT NOT NULL,
	[nombre] VARCHAR(50) NOT NULL,
	[fecha_nacimiento] DATE NULL,
	[sexo] VARCHAR(20) NULL,
	[fecha_registro] DATETIME NULL CONSTRAINT [DF_recepcionistas_fecha_registro] DEFAULT CURRENT_TIMESTAMP,
	[fecha_modificacion] DATETIME NULL CONSTRAINT [DF_recepcionistas_fecha_modificacion] DEFAULT CURRENT_TIMESTAMP,
	CONSTRAINT [PK_recepcionistas] PRIMARY KEY ([id_usuario]),
	CONSTRAINT [FK_recepcionistas_usuario] FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[usuarios]([id])
)
GO

/****** MODULO PACIENTES ******/
CREATE TABLE [dbo].[afiliacion] (
	[id] SMALLINT NOT NULL,
	[afiliacion] VARCHAR(20) NOT NULL,
	CONSTRAINT [PK_afiliacion] PRIMARY KEY ([id])
)
GO

INSERT INTO [dbo].[afiliacion] ([id],[afiliacion]) VALUES (1,'Pemex');
INSERT INTO [dbo].[afiliacion] ([id],[afiliacion]) VALUES (2,'Carls JR');
INSERT INTO [dbo].[afiliacion] ([id],[afiliacion]) VALUES (3,'IMSS');
INSERT INTO [dbo].[afiliacion] ([id],[afiliacion]) VALUES (4,'ISSTE');

GO

CREATE TABLE [dbo].[tipo_sanguineo] (
	[id] SMALLINT NOT NULL,
	[tipo_sanguineo] VARCHAR(3) NOT NULL,
	CONSTRAINT [PK_tipo_sanguineo] PRIMARY KEY([id])
)
GO

INSERT INTO [dbo].[tipo_sanguineo] ([id], [tipo_sanguineo]) VALUES (1, 'A+');
INSERT INTO [dbo].[tipo_sanguineo] ([id], [tipo_sanguineo]) VALUES (2, 'A-');
INSERT INTO [dbo].[tipo_sanguineo] ([id], [tipo_sanguineo]) VALUES (3, 'B+');
INSERT INTO [dbo].[tipo_sanguineo] ([id], [tipo_sanguineo]) VALUES (4, 'B-');
INSERT INTO [dbo].[tipo_sanguineo] ([id], [tipo_sanguineo]) VALUES (5, 'AB+');
INSERT INTO [dbo].[tipo_sanguineo] ([id], [tipo_sanguineo]) VALUES (6, 'AB-');
INSERT INTO [dbo].[tipo_sanguineo] ([id], [tipo_sanguineo]) VALUES (7, 'O+');
INSERT INTO [dbo].[tipo_sanguineo] ([id], [tipo_sanguineo]) VALUES (8, 'O-');
GO

CREATE TABLE [dbo].[pacientes] (
	[id] BIGINT IDENTITY(1, 1) NOT NULL,
	[uuid] VARCHAR(36) NOT NULL,
	[nombre] VARCHAR(50) NULL,
	[nombre_tutor] VARCHAR(50) NULL,
	[id_afiliacion] SMALLINT NULL,
	[otra_afiliacion] VARCHAR(50) NULL,
	[numero_seguro] VARCHAR(30) NULL,
	[domicilio] VARCHAR(100) NULL,
	[codigo_postal] VARCHAR(6) NULL,
	[fecha_nacimiento] DATE NULL,
	[lugar_nacimiento] VARCHAR(50) NULL,
	[telefono_casa] VARCHAR(10) NULL,
	[telefono_celular] VARCHAR(13) NULL,
	[sexo] CHAR(1) NULL,
	[id_tipo_sanguineo] SMALLINT NOT NULL,
	[observaciones] VARCHAR(512) NULL,
	[fecha_registro] DATETIME NULL CONSTRAINT [DF_pacientes_fecha_registro] DEFAULT CURRENT_TIMESTAMP,
	[fecha_modificacion] DATETIME NULL CONSTRAINT [DF_pacientes_fecha_modificacion] DEFAULT CURRENT_TIMESTAMP,
	CONSTRAINT [PK_pacientes] PRIMARY KEY ([id]),
	CONSTRAINT [FK_pacientes_afiliacion] FOREIGN KEY ([id_afiliacion]) REFERENCES [dbo].[afiliacion]([id]),
	CONSTRAINT [UQ_pacientes_uuid] UNIQUE ([uuid]),
	CONSTRAINT [UQ_pacientes_numero_seguro] UNIQUE ([numero_seguro])
)
GO

CREATE TABLE [dbo].[alergias] (
	[id_paciente] BIGINT NOT NULL,
	[alergia_medicamentos] BIT NULL,
	[medicamentos] VARCHAR(512) NULL,
	[alergia_alimentos] BIT NULL,
	[alimentos] VARCHAR(512) NULL,
	[alergia_flora] BIT NULL,
	[flora] VARCHAR(512) NULL,
	[alergia_ropa] BIT NULL,
	[ropa] VARCHAR(512) NULL,
	CONSTRAINT [PK_alergias] PRIMARY KEY ([id_paciente]),
	CONSTRAINT [FK_alergias_paciente] FOREIGN KEY ([id_paciente]) REFERENCES [dbo].[pacientes]([id])
)
GO

CREATE TABLE [dbo].[alimentacion] (
	[id_paciente] BIGINT NOT NULL,
	[pecho] BIT NULL,
	[inicio_pecho] INT NULL,
	[tipo_formula] VARCHAR(50) NULL,
	[inicio_formula] INT NULL,
	[cereal] BIT NULL,
	[inicio_cereal] INT NULL,
	[frutas] BIT NULL,
	[inicio_frutas] INT NULL,
	[inicio_citricos] INT NULL,
	[verduras] BIT NULL,
	[inicio_verduras] INT NULL,
	[inicio_tomate] INT NULL,
	CONSTRAINT [PK_alimentacion] PRIMARY KEY ([id_paciente]),
	CONSTRAINT [FK_alimentacion_paciente] FOREIGN KEY ([id_paciente]) REFERENCES [dbo].[pacientes]([id])
)
GO

CREATE TABLE [dbo].[antecedentes_madre] (
	[id_paciente] BIGINT NOT NULL,
	[nombre_madre] VARCHAR(50) NULL,
	[fecha_nacimiento] DATE NULL,
	[ocupacion] VARCHAR(50) NULL,
	[tabaquismo] BIT NULL,
	[alcoholismo] BIT NULL,
	[toxicomanias] VARCHAR(512) NULL,
	[alergias] VARCHAR(512) NULL,
	[diabetes] BIT NULL,
	[hipertension] BIT NULL,
	[dismorfologicos] VARCHAR(512) NULL,
	[cancer] BIT NULL,
	[tipos_cancer] VARCHAR(512) NULL,
	[otros] VARCHAR(512) NULL,
	[medicamentos] VARCHAR(512) NULL,
	[estado_actual] VARCHAR(50) NULL,
	[embarazos] INT NULL,
	[partos] INT NULL,
	[abortos] INT NULL,
	[cesareas] INT NULL,
	CONSTRAINT [PK_antecedentes_madre] PRIMARY KEY CLUSTERED ([id_paciente]),
	CONSTRAINT [FK_antecedentes_madre_paciente] FOREIGN KEY ([id_paciente]) REFERENCES [dbo].[pacientes]([id])
)
GO

CREATE TABLE [dbo].[antecedentes_padre] (
	[id_paciente] BIGINT NOT NULL,
	[nombre_padre] VARCHAR(50) NULL,
	[fecha_nacimiento] DATE NULL,
	[ocupacion] VARCHAR(50) NULL,
	[tabaquismo] BIT NULL,
	[alcoholismo] BIT NULL,
	[toxicomanias] VARCHAR(512) NULL,
	[alergias] VARCHAR(512) NULL,
	[diabetes] BIT NULL,
	[hipertension] BIT NULL,
	[dismorfologicos] VARCHAR(512) NULL,
	[cancer] BIT NULL,
	[tipos_cancer] VARCHAR(512) NULL,
	[otros] VARCHAR(512) NULL,
	[medicamentos] VARCHAR(512) NULL,
	[estado_actual] VARCHAR(50) NULL,
	CONSTRAINT [PK_antecedentes_padre] PRIMARY KEY ([id_paciente]),
	CONSTRAINT [FK_antecedentes_padre_paciente] FOREIGN KEY ([id_paciente]) REFERENCES [dbo].[pacientes]([id])
)
GO

CREATE TABLE [dbo].[cuidado_prenatal] (
	[id_paciente] BIGINT NOT NULL,
	[planeado] BIT NULL,
	[metodo_fertilizacion] VARCHAR(50) NULL,
	[mes_inicio_control] INT NULL,
	[responsable_control] VARCHAR(50) NULL,
	[enfermedades] VARCHAR(512) NULL,
	CONSTRAINT [PK_cuidado_prenatal] PRIMARY KEY ([id_paciente]),
	CONSTRAINT [FK_cuidado_prenatal_paciente] FOREIGN KEY ([id_paciente]) REFERENCES [dbo].[pacientes]([id])
)
GO

CREATE TABLE [dbo].[cuidado_natal] (
	[id_paciente] BIGINT NOT NULL,
	[hospital] VARCHAR(50) NULL,
	[tipo_nacimiento] VARCHAR(50) NULL,
	[multiple] BIT NULL,
	[peso_nacimiento] FLOAT NULL,
	[talla_nacimiento] FLOAT NULL,
	[indicaciones] VARCHAR(512) NULL,
	CONSTRAINT [PK_cuidado_natal] PRIMARY KEY ([id_paciente]),
	CONSTRAINT [FK_cuidado_natal_paciente] FOREIGN KEY ([id_paciente]) REFERENCES [dbo].[pacientes]([id])
)
GO

CREATE TABLE [dbo].[cuidado_posnatal] (
	[id_paciente] BIGINT NOT NULL,
	[necesidad_vigilancia] BIT NULL,
	[respirador] BIT NULL,
	[incubadora] BIT NULL,
	[fototerapias] VARCHAR(50) NULL,
	[otros] VARCHAR(512) NULL,
	CONSTRAINT [PK_cuidado_posnatal] PRIMARY KEY ([id_paciente]),
	CONSTRAINT [FK_cuidado_posnatal_paciente] FOREIGN KEY ([id_paciente]) REFERENCES [dbo].[pacientes]([id])
)
GO

CREATE TABLE [dbo].[psicomotor] (
	[id_paciente] BIGINT NOT NULL,
	[sostiene_cabeza] BIT NULL,
	[sentado] BIT NULL,
	[inicio_sentado] INT NULL,
	[gateo] BIT NULL,
	[inicio_gateo] INT NULL,
	[control_esfinter] BIT NULL,
	[inicio_control_esfinter] INT NULL,
	[rodado] BIT NULL,
	[inicio_rodado] INT NULL,
	[bipedestacion] BIT NULL,
	[inicio_bipedestacion] INT NULL,
	[deambulacion] BIT NULL,
	[inicio_deambulacion] INT NULL,
	CONSTRAINT [PK_psicomotor] PRIMARY KEY ([id_paciente]),
	CONSTRAINT [FK_psicomotor_paciente] FOREIGN KEY ([id_paciente]) REFERENCES [dbo].[pacientes]([id])
)
GO

CREATE TABLE [dbo].[vacunas] (
	[id_paciente] BIGINT NOT NULL,
	[hepatitis_a] BIT NULL,
	[hepatitis_b] BIT NULL,
	[hib] BIT NULL,
	[meningococo] BIT NULL,
	[bpt] BIT NULL,
	[poliomielitis] BIT NULL,
	[rotavirus] BIT NULL,
	[neumococo] BIT NULL,
	[influenza_estacionaria] BIT NULL,
	[mmr] BIT NULL,
	[varicela] BIT NULL,
	[hpv] BIT NULL,
	[tuberculosis] BIT NULL,
	CONSTRAINT [PK_vacunas] PRIMARY KEY ([id_paciente]),
	CONSTRAINT [FK_vacunas_paciente] FOREIGN KEY ([id_paciente]) REFERENCES [dbo].[pacientes]([id])
)
GO

/****** MODULO CITAS ******/
CREATE TABLE [dbo].[citas] (
	[id] BIGINT IDENTITY(1, 1) NOT NULL,
	[id_paciente] BIGINT NULL,
	[nombre_paciente] VARCHAR(50) NULL,
	[fecha] DATE NULL,
	[hora] TIME(7) NULL,
	[primera_vez] BIT NULL,
	[telefono] VARCHAR(13) NULL,
	[id_afiliacion] SMALLINT NULL,
	CONSTRAINT [PK_citas] PRIMARY KEY ([id]),
	CONSTRAINT [FK_citas_paciente] FOREIGN KEY ([id_paciente]) REFERENCES [dbo].[pacientes]([id]),
	CONSTRAINT [FK_citas_afiliacion] FOREIGN KEY ([id_afiliacion]) REFERENCES [dbo].[afiliacion]([id]),
	CONSTRAINT [CK_citas_paciente_o_datos] CHECK ([id_paciente] IS NOT NULL OR ([nombre_paciente] IS NOT NULL AND [telefono] IS NOT NULL))
)
GO

CREATE TABLE [dbo].[fechas_no_habiles] (
	[id] INT IDENTITY(1, 1) NOT NULL,
	[fecha_no_habil] DATE NOT NULL,
	CONSTRAINT [PK_fechas_no_habiles] PRIMARY KEY ([id])
)
GO

/******* MODULO CONSULTAS ******/
CREATE TABLE [dbo].[consultas] (
	[id] BIGINT IDENTITY(1, 1) NOT NULL,
	[id_paciente] BIGINT NOT NULL,
	[id_medico] BIGINT NOT NULL,
	[fecha_consulta] DATE NULL,
	[motivo] VARCHAR(100) NULL,
	[responsabilidad] VARCHAR(50) NULL,
	[frec_cardiaca] INT NULL,
	[frec_respiratoria] INT NULL,
	[tension_arterial] VARCHAR(8) NULL,
	[temperatura] FLOAT NULL,
	[peso] FLOAT NULL,
	[talla] FLOAT NULL,
	[diagnostico] VARCHAR(255) NULL,
	CONSTRAINT [PK_consultas] PRIMARY KEY ([id]),
	CONSTRAINT [FK_consultas_paciente] FOREIGN KEY ([id_paciente]) REFERENCES [dbo].[pacientes]([id]),
	CONSTRAINT [FK_consultas_medico] FOREIGN KEY ([id_medico]) REFERENCES [dbo].[medicos]([id])
)
GO

CREATE TABLE [dbo].[recetas] (
	[id] BIGINT IDENTITY(1, 1) NOT NULL,
	[uuid] VARCHAR(36) NOT NULL,
	[id_consulta] BIGINT NOT NULL,
	[fecha_emision] DATETIME NULL CONSTRAINT [DF_recetas_fecha_emision] DEFAULT CURRENT_TIMESTAMP,
	CONSTRAINT [PK_recetas] PRIMARY KEY ([id]),
	CONSTRAINT [FK_recetas_consulta] FOREIGN KEY ([id_consulta]) REFERENCES [dbo].[consultas]([id]),
	CONSTRAINT [UQ_recetas_uuid] UNIQUE([uuid])
)
GO

CREATE TABLE [dbo].[medicamentos] (
	[id] INT IDENTITY(1, 1) NOT NULL,
	[nombre] VARCHAR (255) NOT NULL,
	[tipo] VARCHAR(20) NOT NULL,
	[activo] BIT NOT NULL,
	[fecha_creacion] DATETIME NULL CONSTRAINT [DF_medicamentos_fecha_creacion] DEFAULT CURRENT_TIMESTAMP,
	[fecha_modificacion] DATETIME NULL CONSTRAINT [DF_medicamentos_fecha_modificacion] DEFAULT CURRENT_TIMESTAMP,
	CONSTRAINT [PK_medicamento] PRIMARY KEY([id])
)
GO

CREATE TABLE [dbo].[prescripcion] (
	[id] BIGINT IDENTITY(1, 1) NOT NULL,
	[id_receta] BIGINT NOT NULL,
	[id_medicamento] INT NOT NULL,
	[dosis] VARCHAR(255) NOT NULL,
	CONSTRAINT [PK_prescripcion] PRIMARY KEY ([id]),
	CONSTRAINT [FK_prescripcion_receta] FOREIGN KEY ([id_receta]) REFERENCES [dbo].[recetas]([id]),
	CONSTRAINT [FK_prescripcion_medicamento] FOREIGN KEY ([id_medicamento]) REFERENCES [dbo].[medicamentos]([id])
)
GO

CREATE TABLE [dbo].[crecimiento_oms] (
	[id] INT IDENTITY(1, 1) NOT NULL,
	[indicador] VARCHAR(20) NOT NULL,
	[sexo] VARCHAR(10) NOT NULL,
	[mes_edad] INT NULL,
	[medicion] VARCHAR(10) NULL,
	[l] FLOAT NULL,
	[m] FLOAT NULL,
	[s] FLOAT NULL,
	CONSTRAINT [PK_crecimiento_oms] PRIMARY KEY ([id])
)
GO


