USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Perfil.ObtenerNombrePorCodigo]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Perfil.ObtenerNombrePorCodigo]
@perEsAdministrador tinyint
AS
BEGIN
select perNombre from Perfil where perEsAdministrador = @perEsAdministrador
END


GO
