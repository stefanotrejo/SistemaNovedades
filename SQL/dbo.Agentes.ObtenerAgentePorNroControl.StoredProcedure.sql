USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ObtenerAgentePorNroControl]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ObtenerAgentePorNroControl]
	@nrocontrol varchar(50), @periodo date, @periodo2 date
AS
BEGIN
SELECT  dbo.PruebasAge.Cuil,PruebasAge.NuevoAgeId1, dbo.PruebasAge.Nombre, dbo.LugarPago.lpaNombre 
as "Lugar de Pago", ccp.ccpNombre AS Cargo, PruebasAge.MesAnioLiq as Periodo,PruebasAge.Agru, PruebasAge.tramo,
PruebasAge.Apertura, PruebasAge.NroCOntrol AS "Numero de Control"
FROM dbo.PruebasAge 

INNER JOIN dbo.LugarPago 
ON dbo.LugarPago.lpaCodigo = dbo.PruebasAge.LugarPago 

INNER JOIN dbo.CargoCategoriaPresupuestado ccp 
ON PruebasAge.Agru=ccp.agrId and PruebasAge.tramo=ccp.ccpTramo and PruebasAge.Apertura=ccp.ccpApertura   			  
where NroCOntrol = @nrocontrol and PruebasAge.FechaLiquidacion>=@periodo 
and PruebasAge.FechaLiquidacion<=@periodo2

order by FechaLiquidacion, Cuil
END
GO
