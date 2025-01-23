use LiquidacionSueldos

select t1.*, t2.nombre from PruebasAge t1
left join cgosden t2
on t1.Agru = t2.agrupamiento
and t1.tramo = t2.tramo
and t1.Apertura = t2.apertura
where 
LugarPago = '70015' and 
MesAnioLiq = '11/24'

order by SituRev


select 
	t1.Nombre, t1.Cuil, t1.NroCOntrol, t1.Agru, t1.tramo, t1.Apertura, t2.nombre,
	'Planta' =
	CASE
		 WHEN t1.PlantaTipo='T' THEN 'Temporal'
		 WHEN t1.PlantaTipo='P' THEN 'Permanente'
		 WHEN t1.PlantaTipo='D' THEN 'Docente'
		 WHEN t1.PlantaTipo='C' THEN 'Contratado'
		 WHEN t1.PlantaTipo='J' THEN 'Jornalizado'
		 WHEN t1.PlantaTipo='K' THEN 'Policia'
		 ELSE t1.PlantaTipo		 		 
		 END, 
	'Situacion de Revista' =
      CASE 
		 WHEN t1.SituRev='1' THEN 'Licencia sin goce de haberes'
		 WHEN t1.SituRev='2' THEN 'Licencia sin goce de haberes con reemplazante'
		 WHEN t1.SituRev='3' THEN 'No percibe riesgo de vida'
		 WHEN t1.SituRev='4' THEN 'Faltas injustificadas por paro docente'
		 WHEN t1.SituRev='5' THEN 'Con faltas injustificadas o suspension o multa'
		 WHEN t1.SituRev='6' THEN 'Licencia por enfermedad con 75%'
		 WHEN t1.SituRev='7' THEN 'Licencia por enfermedad con 50%'
		 WHEN t1.SituRev='8' THEN 'Falta injustificada por tardanzas'
		 WHEN t1.SituRev='A' THEN 'Adscripcion'
		 WHEN t1.SituRev='A' THEN 'Adscripcion'
         WHEN t1.SituRev='N' THEN 'Solo percibe fondos de la Nacion'
		 WHEN t1.SituRev='R' THEN 'Cargo retenido'
		 WHEN t1.SituRev='V' THEN 'Cargo vacante'
		 WHEN t1.SituRev='S' THEN 'Disponibilidad Simple'
		 WHEN t1.SituRev='T' THEN 'Fondo de terceros'
		 WHEN t1.SituRev='F' THEN 'Comision de servicios FONAVI'
		 WHEN t1.SituRev='Z' THEN 'Bloqueo liquidacion por incompatibilidad'
         ELSE ''
		 END
from PruebasAge t1
left join cgosden t2
on t1.Agru = t2.agrupamiento
and t1.tramo = t2.tramo
and t1.Apertura = t2.apertura
where 
LugarPago = '70015' and 
MesAnioLiq = '11/24'

order by SituRev

SELECT * from LugarPago where lpaCodigo = 70015