USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PagosEventuales.ObtenerAgentePorCuil]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PagosEventuales.ObtenerAgentePorCuil]
@cuil varchar(50)
AS
BEGIN
SELECT TOP 1
LPA.lpaNombre, 
PAG.Cuil, 
PAG.Nombre, 
PAG.Sexo,  
LPA.lpaId, 
LPA.lpaCodigo, 
PAG.FechaLiquidacion,
PAG.Juris,
PAG.Prog, 
PAG.NroCOntrol,
PAG.Juris,
PAG.Prog
FROM dbo.PruebasAge PAG 
INNER JOIN dbo.LugarPago LPA ON LPA.lpaCodigo = PAG.LugarPago 		  				  
where PAG.Cuil = @cuil
order by PAG.FechaLiquidacion DESC
END
GO
