USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PagosEventuales.ObtenerAgentePorNroControl]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PagosEventuales.ObtenerAgentePorNroControl]
	@nrocontrol varchar(50)
AS
BEGIN
SELECT TOP 1
LPA.lpaNombre, 
PAG.Cuil, 
PAG.Nombre, 
PAG.Sexo,  
LPA.lpaId, 
LPA.lpaCodigo, 
PAG.Juris,
PAG.Prog, 
PAG.NroCOntrol,
PAG.Juris,
PAG.Prog
FROM dbo.LugarPago LPA
INNER JOIN dbo.PruebasAge PAG 
ON LPA.lpaCodigo = PAG.LugarPago 			  				  
where NroCOntrol = @nrocontrol
order by PAG.FechaLiquidacion DESC
END
GO
