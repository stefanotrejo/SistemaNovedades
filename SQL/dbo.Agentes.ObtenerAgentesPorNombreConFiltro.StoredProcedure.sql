USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ObtenerAgentesPorNombreConFiltro]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ObtenerAgentesPorNombreConFiltro]
	@nombre varchar(50), @periodo date, @periodo2 date
AS
BEGIN
SELECT  dbo.PruebasAge.Cuil,PruebasAge.NuevoAgeId1, dbo.PruebasAge.Nombre, 
dbo.LugarPago.lpaNombre as "Lugar de Pago", 
--ccp.ccpNombre AS Cargo, 
cgosden.nombre as Cargo,
PruebasAge.MesAnioLiq as Periodo,PruebasAge.Agru, PruebasAge.tramo,
PruebasAge.Apertura, PruebasAge.NroCOntrol AS "Numero de Control"
FROM dbo.PruebasAge LEFT JOIN
dbo.LugarPago ON dbo.LugarPago.lpaCodigo = dbo.PruebasAge.LugarPago 

--CARGO CATEGORIA PRESUPUESTADO (SUELDOS)
--INNER JOIN Sueldos.dbo.CargoCategoriaPresupuestado ccp ON PruebasAge.Agru=ccp.agrId and 
--PruebasAge.tramo=ccp.ccpTramo and PruebasAge.Apertura=ccp.ccpApertura
LEFT JOIN dbo.cgosden cgosden ON PruebasAge.Agru=cgosden.Agrupamiento and 
PruebasAge.tramo=cgosden.Tramo and PruebasAge.Apertura=cgosden.apertura	
    					  
where PruebasAge.Nombre like '%' + @nombre + '%' and PruebasAge.FechaLiquidacion>=@periodo 
and PruebasAge.FechaLiquidacion<=@periodo2
and PruebasAge.Activo=1
--AGREGADAS
AND PruebasAge.SituRev!='V'
AND PruebasAge.SituRev!='N'
--
--order by FechaLiquidacion, Cuil
order by FechaLiquidacion, Nombre ASC
END
GO
