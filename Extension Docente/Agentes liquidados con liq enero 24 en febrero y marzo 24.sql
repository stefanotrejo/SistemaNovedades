-- AGENTES LIQUIDADOS EN FEBRERO Y MARZO 24 CON PRUEBAS AGE DE ENERO 24 
-- Y QUE NO APARECEN EN LA LIQUIDACION GENERAL DE FEBRERO Y MARZO 24

-- ENERO 2024 -- 0
select * from agentes_extension_docente_historico t1 
where  
	t1.mes = 01
and t1.anio = 24
and not exists (
	select * from PruebasAge t2
	where MesAnioLiq = '01/24'
	and t2.NroCOntrol = t1.NroCOntrol
				)

-- FEBRERO 2024 -- 79
select * from agentes_extension_docente_historico t1 
where  
	t1.mes = 02
and t1.anio = 24
and not exists (
	select * from PruebasAge t2
	where MesAnioLiq = '02/24'
	and t2.NroCOntrol = t1.NroCOntrol
				)

-- MARZO 2024 - 118
select * from agentes_extension_docente_historico t1 
where  
	t1.mes = 03
and t1.anio = 24
and not exists (
	select * from PruebasAge t2
	where MesAnioLiq = '03/24'
	and t2.NroCOntrol = t1.NroCOntrol
				)



-- AGENTES CON LICENCIA POR ENFERMAD AL 50%
-- 10
select t2.Nombre, t2.NroCOntrol, t2.Cuil, t2.SituRev from agentes_extension_docente_historico t1 inner join PruebasAge t2
on t1.age_id = t2.NuevoAgeId1
where mes = 01 and anio = 24
and t2.SituRev = 7


-- 43
select t2.Nombre, t2.NroCOntrol, t2.Cuil, t2.SituRev from agentes_extension_docente_historico t1 inner join PruebasAge t2
on t1.NroCOntrol = t2.NroCOntrol
where mes = 02 and anio = 24
and t2.MesAnioLiq = '02/24'
and t2.SituRev = '7'
order by t1.NroCOntrol

-- 35
select t2.Nombre, t2.NroCOntrol, t2.Cuil, t2.SituRev from agentes_extension_docente_historico t1 inner join PruebasAge t2
on t1.NroCOntrol = t2.NroCOntrol
where mes = 03 and anio = 24
and t2.MesAnioLiq = '03/24'
and t2.SituRev = '7'
order by t1.NroCOntrol

