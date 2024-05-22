-- SEPTIEMBRE - 4
select t1.*, t2.* from PagosEventuales t1 
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId 
inner join "bonoextratodos-set23" t3
on t1.ageCUIT = SUBSTRING(cuil,0,12)
where 
	t2.dpeMes = 09
and dpeAnio = 2023

UNION
-- OCTUBRE - 3
select t1.*, t2.* from PagosEventuales t1 
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId 
inner join "bonoextratodos-oct23" t3
on t1.ageCUIT = SUBSTRING(cuil,0,12)
where 
	t2.dpeMes = 10
and dpeAnio = 2023

UNION
-- NOVIEMBRE - 3
select t1.*, t2.* from PagosEventuales t1 
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId 
inner join "bonoextratodos-nov23" t3
on t1.ageCUIT = SUBSTRING(cuil,0,12)
where 
	t2.dpeMes = 11
and dpeAnio = 2023


UNION
-- DICIEMBRE - 3
select t1.*, t2.* from PagosEventuales t1 
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId 
inner join "bonoextratodos-dic23" t3
on t1.ageCUIT = SUBSTRING(cuil,0,12)
where 
	t2.dpeMes = 12
and dpeAnio = 2023

UNION
-- FEBRERO 24 - 3
select t1.*, t2.* from PagosEventuales t1 
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId 
inner join "bonoextratodos-feb24" t3
on t1.ageCUIT = t3.cuil
where 
	t2.dpeMes = 2
and t2.dpeAnio = 2024


select * from 
"bonoextratodos-feb24" 
where cuil = ''