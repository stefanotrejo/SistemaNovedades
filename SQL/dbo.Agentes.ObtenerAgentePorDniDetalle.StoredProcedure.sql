USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ObtenerAgentePorDniDetalle]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ObtenerAgentePorDniDetalle]
	@dni varchar(50), @periodo date, @periodo2 date
AS
BEGIN
SELECT  dbo.PruebasAge.Cuil,PruebasAge.NuevoAgeId1, dbo.PruebasAge.Nombre, 
(SELECT SUELDOS.dbo.Escuela.esuNombre 
FROM SUELDOS.dbo.Escuela
where esuCodigo=PruebasAge.Escuela) as "Escuela",
dbo.LugarPago.lpaNombre as "Lugar de Pago",
'Planta' =
	CASE
		 WHEN PruebasAge.PlantaTipo='T' THEN 'Temporal'
		 WHEN PruebasAge.PlantaTipo='P' THEN 'Permanente'
		 ELSE ''
		 END,
--dbo.PruebasAge.PlantaTipo as Planta, 
ccp.ccpNombre AS Cargo, PruebasAge.HsCat as "Horas Catedra", 
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

PruebasAge.SituRev as "Situacion de Revista", PruebasAge.TotalHaberes as "Total Haberes",
--(SELECT 
--SUM(cteImporte) as Total
--FROM [LiquidacionSueldos].[dbo].[ConceptoTemporal] 
--where cteCodigoConcepto >= 108 
--and cteCodigoConcepto <=118 and ageId=pruebasage.NuevoAgeId1) 
PruebasAge.SalarioFamiliar as "Salario Familiar",
PruebasAge.TotalDescuentos as "Total Descuentos", PruebasAge.Liquido, PruebasAge.Agru, PruebasAge.tramo,
PruebasAge.Apertura, PruebasAge.Anios, PruebasAge.Meses, PruebasAge.TotalSinCargosAlHaber as 
"Total sin cargos al haber", PruebasAge.RemuneracionOit as "Remuneracion OIT"
FROM dbo.PruebasAge INNER JOIN
dbo.LugarPago ON dbo.LugarPago.lpaCodigo = dbo.PruebasAge.LugarPago 
INNER JOIN Sueldos.dbo.CargoCategoriaPresupuestado ccp ON PruebasAge.Agru=ccp.agrId and 
PruebasAge.tramo=ccp.ccpTramo and PruebasAge.Apertura=ccp.ccpApertura    
where Substring(PruebasAge.Cuil,3,8)= @dni and PruebasAge.FechaLiquidacion>=@periodo 
and PruebasAge.FechaLiquidacion<=@periodo2
order by FechaLiquidacion, Cuil
END
GO
