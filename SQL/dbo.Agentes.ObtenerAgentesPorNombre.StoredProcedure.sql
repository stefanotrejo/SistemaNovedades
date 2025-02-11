USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ObtenerAgentesPorNombre]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ObtenerAgentesPorNombre]
	@nombre varchar(50), @periodo date, @periodo2 date
AS
BEGIN
SELECT  dbo.PruebasAge.Cuil,PruebasAge.NuevoAgeId1, dbo.PruebasAge.Nombre, dbo.LugarPago.lpaNombre 
as "Lugar de Pago", ccp.ccpNombre AS Cargo, PruebasAge.MesAnioLiq as Periodo,PruebasAge.Agru, 
PruebasAge.tramo, PruebasAge.Apertura, PruebasAge.NroCOntrol AS "Numero de Control", 
PruebasAge.Fonid as Fonid, PruebasAge.DiasNoTrabajados as "Dias no trabajados", 
PruebasAge.Imponible as "Imponible", PruebasAge.[HaberC/aporte] as "HaberConAporte", 
PruebasAge.[HaberS/aporte] as "HaberSinAporte", dbo.PruebasAge.PlantaTipo as Planta,
PruebasAge.SalarioFamiliar as "Salario Familiar",
PruebasAge.TotalHaberes as "Total Haberes",
'Situacion de Revista' =
      CASE 
		 WHEN PruebasAge.SituRev='A' THEN 'A'
         ELSE ''
		 END
FROM dbo.PruebasAge INNER JOIN
dbo.LugarPago ON dbo.LugarPago.lpaCodigo = dbo.PruebasAge.LugarPago 
INNER JOIN dbo.CargoCategoriaPresupuestado ccp ON PruebasAge.Agru=ccp.agrId and 
PruebasAge.tramo=ccp.ccpTramo and PruebasAge.Apertura=ccp.ccpApertura    					  
where PruebasAge.Nombre like '%' + @nombre + '%' and PruebasAge.FechaLiquidacion>=@periodo 
and PruebasAge.FechaLiquidacion<=@periodo2
order by FechaLiquidacion, Cuil
END
GO
