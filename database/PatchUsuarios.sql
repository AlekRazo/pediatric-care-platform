USE [Pediatria]
GO

ALTER TABLE [dbo].[Usuario]
	ADD [CorreoElectronico] [nvarchar](50) NULL

GO

SELECT * FROM [dbo].[Usuario]
GO
