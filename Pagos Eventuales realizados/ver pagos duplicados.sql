select * from PagosEventuales t1
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId
where exists (
select * from PagosEventuales t3
inner join DetallePagoEventual t4
on t3.pevId = t4.pevId
where
	t1.ageCUIT = t3.ageCUIT
and t1.ageNroControl = t3.ageNroControl
and t2.dpeMes = t4.dpeMes
and t2.dpeAnio = t4.dpeAnio
and t2.pevId != t4.pevId
)