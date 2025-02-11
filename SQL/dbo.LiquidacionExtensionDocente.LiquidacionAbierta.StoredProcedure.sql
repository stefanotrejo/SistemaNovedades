USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[LiquidacionExtensionDocente.LiquidacionAbierta]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LiquidacionExtensionDocente.LiquidacionAbierta]
AS

SELECT 
	[id]
    ,[descripcion]
    ,[mes]
    ,[anio]
    ,[etapa]
    ,[estado]
    ,[fechaInicio]
    ,[fechaCierre]
    ,[activo]
FROM 
	LiquidacionExtensionDocente 
WHERE 
		1 = 1  
	AND estado = 'A'
	AND activo = 1

ORDER BY fechaInicio DESC

GO
