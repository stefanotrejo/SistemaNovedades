select 
	PlantaTipo, NroCOntrol, LugarPago, Escuela, Escalafon, HsCat, Nombre, Cuil, FechaNac, Sexo, 
	EstadoCivil, FechaIngreso, AniosAntig, DiasTrabajados, ImponibleANSES, Imponible, [HaberS/aporte], 
	[HaberC/aporte], TotalHaberes, TotalDescuentos, liquido
from PruebasAge
where MesAnioLiq = '04/25'
and Agru = 06
and Apertura = 133