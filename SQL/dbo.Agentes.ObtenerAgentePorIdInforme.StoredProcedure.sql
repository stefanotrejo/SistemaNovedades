USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ObtenerAgentePorIdInforme]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ObtenerAgentePorIdInforme]
	@id int
	--, @periodo varchar(5)
AS
BEGIN
SELECT  dbo.PruebasAge.Cuil,PruebasAge.NuevoAgeId1, dbo.PruebasAge.Nombre, 
(SELECT SUELDOS.dbo.Escuela.esuNombre 
FROM SUELDOS.dbo.Escuela
where esuCodigo=PruebasAge.Escuela) as "Escuela",
dbo.LugarPago.lpaNombre as "Lugar de Pago",
--'Planta' =
--	CASE
--		 WHEN PruebasAge.PlantaTipo='T' THEN 'Temporal'
--		 WHEN PruebasAge.PlantaTipo='P' THEN 'Permanente'
--		 ELSE ''
--		 END,
dbo.PruebasAge.PlantaTipo as Planta, 
ccp.ccpNombre AS Cargo, PruebasAge.HsCat as "Horas Catedra", 
PruebasAge.FechaIngreso as "Fecha de Ingreso", PruebasAge.AniosAntig as Antiguedad, 
PruebasAge.MesAnioLiq as Periodo, PruebasAge.DiasTrabajados as "Dias Trabajados",
'Situacion de Revista' =
      CASE 
		 WHEN PruebasAge.SituRev='A' THEN 'A'
         ELSE ''
		 END,

--PruebasAge.SituRev as "Situacion de Revista", 
PruebasAge.TotalHaberes as "Total Haberes",
--(SELECT 
--SUM(cteImporte) as Total
--FROM [LiquidacionSueldos].[dbo].[ConceptoTemporal] 
--where cteCodigoConcepto >= 108 
--and cteCodigoConcepto <=118 and ageId=pruebasage.NuevoAgeId1) 
PruebasAge.SalarioFamiliar as "Salario Familiar",
PruebasAge.TotalDescuentos as "Total Descuentos", PruebasAge.Liquido, PruebasAge.Agru, PruebasAge.tramo,
PruebasAge.Apertura, PruebasAge.Anios, PruebasAge.Meses, PruebasAge.TotalSinCargosAlHaber as 
"Total sin cargos al haber", PruebasAge.RemuneracionOit as "Remuneracion OIT", 
PruebasAge.FechaNac as "Fecha nacimiento", PruebasAge.Juris as jurisdiccion, PruebasAge.NroCOntrol as "Control",
PruebasAge.AsistenciaPerfecta as "Asistencia Perfecta", PruebasAge.RiesgoDeVida as "Riesgo de vida",
PruebasAge.JubRetActivo as "JubRetActivo", PruebasAge.Fonid as Fonid, 
PruebasAge.DiasNoTrabajados as "Dias no trabajados", PruebasAge.Imponible as "Imponible",
PruebasAge.[HaberC/aporte] as "HaberConAporte", PruebasAge.[HaberS/aporte] as "HaberSinAporte"
FROM dbo.PruebasAge INNER JOIN
dbo.LugarPago ON dbo.LugarPago.lpaCodigo = dbo.PruebasAge.LugarPago 
INNER JOIN Sueldos.dbo.CargoCategoriaPresupuestado ccp ON PruebasAge.Agru=ccp.agrId and 
PruebasAge.tramo=ccp.ccpTramo and PruebasAge.Apertura=ccp.ccpApertura    					  
where PruebasAge.NuevoAgeId1 = @id 
--and PruebasAge.MesAnioLiq = @periodo
END
GO
