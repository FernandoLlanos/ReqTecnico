﻿USE [BD_Evaluacion]
GO
/****** Object:  StoredProcedure [dbo].[Usp_Listar_Evaluacion]    Script Date: 25/01/2020 11:26:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Usp_Listar_Evaluacion]
@strCorreoElectronico Varchar(100),
@dtFechaInicio DateTime,
@dtFechaFin DateTime
AS
	SELECT P.intIdPersona,P.strNombreCompleto,P.strCorreoElectronico,E.intCalificacion,E.chEstado,E.intIdEvaluacion,E.dtFechaCreacion
		FROM Tbl_Evaluacion E INNER JOIN Tbl_Persona P ON E.intIdPersona = P.intIdPersona
	WHERE P.strCorreoElectronico = @strCorreoElectronico AND E.dtFechaCreacion BETWEEN @dtFechaInicio AND DATEADD(day, DATEDIFF(day, 0, @dtFechaFin), '23:59:59')
GO

CREATE Proc [dbo].[Usp_Listar_Evaluacion_Por_Correo]
@strCorreoElectronico Varchar(100)
AS
	SELECT E.intIdEvaluacion,P.intIdPersona,P.strNombreCompleto,P.strCorreoElectronico,E.intCalificacion,E.chEstado, E.dtFechaCreacion
		FROM Tbl_Evaluacion E INNER JOIN Tbl_Persona P ON E.intIdPersona = P.intIdPersona
	WHERE P.strCorreoElectronico = @strCorreoElectronico 
GO

CREATE Proc [dbo].[Usp_Registrar_Evaluacion]
@strCorreoElectronico Varchar(100),
@strNombreCompleto Varchar(100),
@intCalificacion Int
AS
	DECLARE @intIdPersona INT

	IF(NOT EXISTS(Select 1 From Tbl_Persona Where LTRIM(RTRIM(strCorreoElectronico)) = LTRIM(RTRIM(@strCorreoElectronico)) And chEstado = 'A'))
	BEGIN
		INSERT INTO Tbl_Persona(strNombreCompleto,strCorreoElectronico,dtFechaCreacion,chEstado) 
			VALUES(@strNombreCompleto,@strCorreoElectronico,Getdate(),'A') -- A = Activo   I = Inactivo
	END

	SET @intIdPersona = (Select intIdPersona From Tbl_Persona Where LTRIM(RTRIM(strCorreoElectronico)) = LTRIM(RTRIM(@strCorreoElectronico)))

	INSERT INTO Tbl_Evaluacion(intIdPersona,intCalificacion,dtFechaCreacion,chEstado) 
		VALUES(@intIdPersona,@intCalificacion,Getdate(),'A') -- A = Activo   I = Inactivo
GO

CREATE Proc [dbo].[Usp_Actualizar_Evaluacion]
@intIdEvaluacion Int,
@intCalificacion Int
AS

	UPDATE Tbl_Evaluacion 
		SET intCalificacion      = @intCalificacion,
			dtFechaActualizacion = Getdate()
	WHERE intIdEvaluacion = @intIdEvaluacion
GO
