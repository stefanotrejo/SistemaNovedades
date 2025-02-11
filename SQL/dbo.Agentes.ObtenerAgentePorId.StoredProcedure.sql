USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ObtenerAgentePorId]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ObtenerAgentePorId]
	@id int
	--, @periodo varchar(5)
AS
BEGIN
SELECT  dbo.PruebasAge.Cuil,PruebasAge.NuevoAgeId1, dbo.PruebasAge.Nombre, 
(SELECT dbo.Escuela.esuNombre 
FROM dbo.Escuela
where esuCodigo=PruebasAge.Escuela) as "Escuela",
-- 31.3.22- Se agrega cod. de lug. de pago a pedido de DGP
CONCAT(dbo.LugarPago.lpaNombre,' (',dbo.LugarPago.lpaCodigo,')') 
as "Lugar de Pago",
'Planta' =
	CASE
		 WHEN PruebasAge.PlantaTipo='T' THEN 'Temporal'
		 WHEN PruebasAge.PlantaTipo='P' THEN 'Permanente'
		 WHEN PruebasAge.PlantaTipo='D' THEN 'Docente'
		 WHEN PruebasAge.PlantaTipo='C' THEN 'Contratado'
		 WHEN PruebasAge.PlantaTipo='J' THEN 'Jornalizado'
		 WHEN PruebasAge.PlantaTipo='K' THEN 'Policia'
		 ELSE PruebasAge.PlantaTipo		 		 
		 END,
--ccp.ccpNombre AS Cargo, 
cgosden.nombre as Cargo,
PruebasAge.HsCat as "Horas Catedra", 
PruebasAge.FechaIngreso as "Fecha de Ingreso", PruebasAge.AniosAntig as Antiguedad, 
PruebasAge.MesAnioLiq as Periodo, PruebasAge.DiasTrabajados as "Dias Trabajados",
'Situacion de Revista' =
      CASE 
		 WHEN PruebasAge.SituRev='1' THEN 'Licencia sin goce de haberes'
		 WHEN PruebasAge.SituRev='2' THEN 'Licencia sin goce de haberes con reemplazante'
		 WHEN PruebasAge.SituRev='3' THEN 'No percibe riesgo de vida'
		 WHEN PruebasAge.SituRev='4' THEN 'Faltas injustificadas por paro docente'
		 WHEN PruebasAge.SituRev='5' THEN 'Con faltas injustificadas o suspension o multa'
		 WHEN PruebasAge.SituRev='6' THEN 'Licencia por enfermedad con 75%'
		 WHEN PruebasAge.SituRev='7' THEN 'Licencia por enfermedad con 50%'
		 WHEN PruebasAge.SituRev='8' THEN 'Falta injustificada por tardanzas'
		 WHEN PruebasAge.SituRev='A' THEN 'Adscripcion'
		 WHEN PruebasAge.SituRev='A' THEN 'Adscripcion'
         WHEN PruebasAge.SituRev='N' THEN 'Solo percibe fondos de la Nacion'
		 WHEN PruebasAge.SituRev='R' THEN 'Cargo retenido'
		 WHEN PruebasAge.SituRev='V' THEN 'Cargo vacante'
		 WHEN PruebasAge.SituRev='S' THEN 'Disponibilidad Simple'
		 WHEN PruebasAge.SituRev='T' THEN 'Fondo de terceros'
		 WHEN PruebasAge.SituRev='F' THEN 'Comision de servicios FONAVI'
		 WHEN PruebasAge.SituRev='Z' THEN 'Bloqueo liquidacion por incompatibilidad'
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
PruebasAge.FechaNac as "Fecha nacimiento", 
--PruebasAge.Juris as jurisdiccion, 
JUR.jurNombre as jurisdiccion,
PruebasAge.NroCOntrol as "Control",
PruebasAge.AsistenciaPerfecta as "Asistencia Perfecta", PruebasAge.RiesgoDeVida as "Riesgo de vida",
PruebasAge.JubRetActivo as "JubRetActivo", PruebasAge.Fonid as Fonid, 
PruebasAge.DiasNoTrabajados as "Dias no trabajados",
'Bloqueo' =
CASE 
		 WHEN UPPER(PruebasAge.Bloqueo)='Z' THEN 'SI'
		 ELSE 'NO'
END

FROM dbo.PruebasAge 
--LUGAR PAGO (LIQ. SUELDO)
LEFT JOIN dbo.LugarPago ON dbo.LugarPago.lpaCodigo = dbo.PruebasAge.LugarPago 
--CARGO CATEGORIA PRESUPUESTADO (SUELDOS)
--INNER JOIN Sueldos.dbo.CargoCategoriaPresupuestado ccp ON PruebasAge.Agru=ccp.agrId and 
--PruebasAge.tramo=ccp.ccpTramo and PruebasAge.Apertura=ccp.ccpApertura
LEFT JOIN dbo.cgosden cgosden ON PruebasAge.Agru=cgosden.Agrupamiento and 
PruebasAge.tramo=cgosden.Tramo and PruebasAge.Apertura=cgosden.apertura

--agregado
LEFT JOIN dbo.Jurisdiccion JUR ON PruebasAge.Juris=JUR.jurCodigo        					  
where PruebasAge.NuevoAgeId1 = @id 
--and PruebasAge.MesAnioLiq = @periodo
END
GO
