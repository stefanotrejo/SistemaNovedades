-- SEPTIEMBRE - 4
select * from PagosEventuales t1 
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId 
inner join "bonoextratodos-set23" t3
on t1.ageCUIT = SUBSTRING(cuil,0,12)
where 
	t2.dpeMes = 09
and dpeAnio = 2023

-- OCTUBRE - 3
select * from PagosEventuales t1 
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId 
inner join "bonoextratodos-oct23" t3
on t1.ageCUIT = SUBSTRING(cuil,0,12)
where 
	t2.dpeMes = 10
and dpeAnio = 2023


-- NOVIEMBRE - 3
select * from PagosEventuales t1 
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId 
inner join "bonoextratodos-nov23" t3
on t1.ageCUIT = SUBSTRING(cuil,0,12)
where 
	t2.dpeMes = 11
and dpeAnio = 2023



-- DICIEMBRE - 3
select * from PagosEventuales t1 
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId 
inner join "bonoextratodos-dic23" t3
on t1.ageCUIT = SUBSTRING(cuil,0,12)
where 
	t2.dpeMes = 12
and dpeAnio = 2023


-- FEBRERO 24 - 3
select * from PagosEventuales t1 
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId 
inner join "bonoextratodos-feb24" t3
on t1.ageCUIT = t3.cuil
where 
	t2.dpeMes = 2
and t2.dpeAnio = 2024