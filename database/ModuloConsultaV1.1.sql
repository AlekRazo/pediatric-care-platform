USE [Pediatria]
GO

/****** Object:  Table [dbo].[Consulta]    Script Date: 05/20/2014 02:39:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Consulta](
	[idConsulta] [int] IDENTITY(1,1) NOT NULL,
	[idPaciente] [int] NULL,
	[FechaConsulta] [date] NULL,
	[Motivo] [text] NULL,
	[Responsabilidad] [nvarchar](50) NULL,
	[FrecCardiaca] [int] NULL,
	[FrecRespiratoria] [int] NULL,
	[TensionArterial] [varchar](8) NULL,
	[Temperatura] [float] NULL,
	[Peso] [float] NULL,
	[Talla] [float] NULL,
	[Diagnostico] [text] NULL,
 CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED 
(
	[idConsulta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Paciente] FOREIGN KEY([idPaciente])
REFERENCES [dbo].[Paciente] ([idPaciente])
GO

ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Paciente]
GO

