CREATE DATABASE BD_Evaluacion
GO
USE BD_Evaluacion
GO
/****** Object:  Table [dbo].[Tbl_Persona]    Script Date: 25/01/2020 11:23:46 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tbl_Persona](
	[intIdPersona] [int] IDENTITY(1,1) NOT NULL,
	[strCorreoElectronico] [varchar](100) NULL,
	[strNombreCompleto] [varchar](100) NULL,
	[dtFechaCreacion] [datetime] NULL,
	[chEstado] [char](1) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Tbl_Evaluacion](
	[intIdEvaluacion] [int] IDENTITY(1,1) NOT NULL,
	[intIdPersona] [int] NULL,
	[intCalificacion] [int] NULL,
	[dtFechaCreacion] [datetime] NULL,
	[dtFechaActualizacion] [datetime] NULL,
	[chEstado] [char](1) NULL
) ON [PRIMARY]
GO