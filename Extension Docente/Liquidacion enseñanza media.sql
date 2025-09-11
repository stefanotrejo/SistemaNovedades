select 
	PlantaTipo, NroCOntrol, LugarPago, Escuela, Escalafon, HsCat, Nombre, Cuil, FechaNac, Sexo, 
	EstadoCivil, FechaIngreso, AniosAntig, DiasTrabajados, ImponibleANSES, Imponible, [HaberS/aporte], 
	[HaberC/aporte], TotalHaberes, TotalDescuentos, liquido
from PruebasAge
where MesAnioLiq = '04/25'
and Agru = 06
and tramo = 0
and Apertura in 

(
129,
133,
301,
302,
303,
304,
452,
469,
660
)


--and Apertura = 133
and Apertura = 660