EXEC [PagosEventuales.Validar]	'33092900',	'43011734'
EXEC [PagosEventuales.Validar]	'27392981',	'64005961'
EXEC [PagosEventuales.Validar]	'36878227',	'56002992'
EXEC [PagosEventuales.Validar]	'27905729',	'56002845'
EXEC [PagosEventuales.Validar]	'31806940',	'62008545'
EXEC [PagosEventuales.Validar]	'27457089',	'28833615'
EXEC [PagosEventuales.Validar]	'27475968',	'77193311'
EXEC [PagosEventuales.Validar]	'37411616',	'57057803'
EXEC [PagosEventuales.Validar]	'39899469',	'90070343'
EXEC [PagosEventuales.Validar]	'31297195',	'64009902'
EXEC [PagosEventuales.Validar]	'26368265',	'73012612'

select * from PagosEventuales
where ageNroControl = '28836184'
EXEC [PagosEventuales.Validar] '22243313',''
EXEC [PagosEventuales.Validar] '','28836184'




EXEC [PagosEventuales.Validar]	'25709295',	'82012544'
EXEC [PagosEventuales.Validar]	'35344700',	'82011323'
EXEC [PagosEventuales.Validar]	'21968585',	'82013082'

EXEC [PagosEventuales.Validar]	'18524036',	'94023671'

select * from PagosEventuales
where pevFechaCarga >= '09/11/2023'

select * from PruebasAge
where MesAnioLiq = '10/23'
and NroCOntrol = '56002992'

select * from LugarPago
where lpaCodigo = '56015'

select * from LugarPagoExtensionDocente
where lpaCodigo = '56015'



select * from PagosEventuales
where ageNroControl = '94023671'

select * from LugarPago
where lpaCodigo = '94017'

select * from LugarPagoExtensionDocente
where lpaCodigo = '94017'



update PagosEventuales 
set pevGenerado = 0
where pevid >= 1219


select * from PagosEventuales t1
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId
where pevFechaCarga >= '09/11/2023'
and t2.dpeMes = 11
and t2.dpeAnio = 2023

select * from LugarPagoExtensionDocente
where lpaCodigo = '56112'

select * from PagosEventuales
where pevId >= 1219

exec  [PagosEventuales.GenerarExcel] '10/11/2023', 63

select * from Usuario


-- CONTROL DE BLOQUEOS
select * from PagosEventuales
where pevFechaCarga >= '09/11/2023'
and ageCUIT in (
'20281399862',
'20265708553',
'27273922836',
'20280485633',
'20368858529',
'27254703007',
'27394519788',
'27338874516',
'27256680926',
'20377340109',
'27218026872',
'27352876890',
'20386397946',
'20358452397',
'27937139336',
'27256680926',
'20120498828',
'20258531672',
'27336171364',
'20382259611',
'27354767363',
'27285307045'
)
OR  ageNroControl = '28863851'


select * from PagosEventuales t1
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId
where 
--	pevFechaCarga >= '09/11/2023' and 
	t2.dpeMes = 11
and t2.dpeAnio = 2023
AND NOT EXISTS (
	select * from PagosEventuales t3
	inner join DetallePagoEventual t4
	on t3.pevId = t4.pevId
	where 
--		pevFechaCarga >= '09/11/2023'and 
		t4.dpeMes in (09, 10)
	and t4.dpeAnio = 2023
	and (
		   t1.ageNroControl = t3.ageNroControl
		OR t1.ageCUIT = t3.ageCUIT 
		)
	)		


select * from PagosEventuales t1
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId
where 
	pevFechaCarga >= '09/11/2023' 
and t2.dpeMes != 11
and t2.dpeAnio = 2023


update PagosEventuales
set pevGenerado = 0 
where pevId in (
1204,
1205,
1206,
1207,
1208,
1209,
1210,
1211,
1212,
1213,
1214,
1215,
1216,
1217,
1218
)



select * from Liquidacion


select * from NovedadInasistencia
where liqId = 1163
and NuevoAgeId1 = 16692804

select * from PruebasAge
where MesAnioLiq = '09/23'
and NroCOntrol = '66010681'



EXEC [PagosEventuales.Validar]	'23082135',	'38977422'

select * from LiquidacionPagosEventuales
exec [PagosEventuales.GenerarExcel] '14/11/2023', 77


SELEct * from PagosEventuales
where pevFechaCarga >= '14/11/2023'

update PagosEventuales
set pevImporteTotal = 30000
where pevId = 1258

EXEC [PagosEventuales.Validar]	'38482690',	'77326715'

delete from PagosEventuales
where pevId = 1265

delete from DetallePagoEventual
where pevId = 1265



EXEC [PagosEventuales.Validar]	'11493432',	'15001802'

EXEC [PagosEventuales.Validar]	'38643088',	'65027455'
EXEC [PagosEventuales.Validar]	'38779305',	'29045013'
EXEC [PagosEventuales.Validar]	'16309393',	'15028993'

EXEC [PagosEventuales.Validar]	'27905729',	'38722351'
EXEC [PagosEventuales.Validar]	'39703652',	'39317083'
EXEC [PagosEventuales.Validar]	'36639266',	'39302122'


SELECT * from PagosEventuales
where pevFechaCarga >= ''



select * from PagosEventuales t1
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId
where 
	pevFechaCarga >= '09/11/2023' 
and pevFechaCarga <= '10/11/2023' 

	t2.dpeMes = 11
and t2.dpeAnio = 2023


update PagosEventuales
set liq_id = 76
where pevId in (
1204,
1205,
1206,
1207,
1208,
1209,
1210,
1211,
1212,
1213,
1214,
1215
)




select * from PagosEventuales t1 
inner join DetallePagoEventual t2
on t1.pevId  = t2.pevId 
where 
--t1.pevId in (
--1216,
--1217,
--1218
--)
--or 
	t2.dpeMes = 10
and t2.dpeAnio = 2023
and pevFechaCarga >= '14/11/2023'


update PagosEventuales
set liq_id = 77
where pevId in (
1216,
1217,
1218
)

update PagosEventuales
set pevGenerado = 0
where pevId in (
1216,
1217,
1218,
1280,
1281,
1282,
1283,
1284,
1285,
1286,
1287,
1288,
1289,
1290,
1291,
1292,
1293
)

select * from PagosEventuales



EXEC [PagosEventuales.Validar]	'27905729',	'38722351'


SELECT * from pagos



select * from PagosEventuales t1
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId
where 
--	pevFechaCarga >= '09/11/2023' and 
	t2.dpeMes = 10
and t2.dpeAnio = 2023
AND NOT EXISTS (
	select * from PagosEventuales t3
	inner join DetallePagoEventual t4
	on t3.pevId = t4.pevId
	where 
--		pevFechaCarga >= '09/11/2023'and 
		t4.dpeMes in (11)
	and t4.dpeAnio = 2023
	and (
		   t1.ageNroControl = t3.ageNroControl
		OR t1.ageCUIT = t3.ageCUIT 
		)
	)		


-- PRIMERA CUOTA 32
select * from PagosEventuales t1
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId
where 
	t2.dpeMes = 09
and t2.dpeAnio = 2023


-- SEGUNDA CUOTA 35
select * from PagosEventuales t1
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId
where 
	t2.dpeMes = 10
and t2.dpeAnio = 2023


-- TERCERA CUOTA 35
select * from PagosEventuales t1
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId
where 
	t2.dpeMes = 11
and t2.dpeAnio = 2023







-- PRIMERA CUOTA 32
select * from PagosEventuales t1
where ageCUIT in (
'20281399862',
'20265708553',
'27273922836',
'20280485633',
'20368858529',
'27254703007',
'27394519788',
'27338874516',
'27256680926',
'20377340109',
'27218026872',
'27352876890',
'20386397946',
'20358452397',
'27937139336',
'20120498828',
'20258531672'
)

OR ageNroControl = '28863851'


select * from LiquidacionPagosEventuales

select * from PagosEventuales t1 inner join DetallePagoEventual t2 
on t1.pevId = t2.pevId


update DetallePagoEventual
set dpeConcepto = 'Gratificacion 2023 1ra cuota Septiembre'
where pevId = 1278


-- 1ra cuota duplicados
select * from PagosEventuales t1
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId
where 
	t2.dpeMes = 09
and t2.dpeAnio = 2023
AND EXISTS (
	select * from PagosEventuales t3
	inner join DetallePagoEventual t4
	on t3.pevId = t4.pevId
	where 
		t4.dpeMes = 09
	and t4.dpeAnio = 2023
	and t2.pevId != t4.pevId
	and 
		(t1.ageCUIT = t3.ageCUIT
	or t1.ageNroControl = t3.ageNroControl)
) 


-- 2da cuota duplicados
select * from PagosEventuales t1
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId
where 
	t2.dpeMes = 10
and t2.dpeAnio = 2023
AND EXISTS (
	select * from PagosEventuales t3
	inner join DetallePagoEventual t4
	on t3.pevId = t4.pevId
	where 
		t4.dpeMes = 10
	and t4.dpeAnio = 2023
	and t2.pevId != t4.pevId
	and 
		(t1.ageCUIT = t3.ageCUIT
	or t1.ageNroControl = t3.ageNroControl)
) 

-- 3ra cuota duplicados
select * from PagosEventuales t1
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId
where 
	t2.dpeMes = 11
and t2.dpeAnio = 2023
AND EXISTS (
	select * from PagosEventuales t3
	inner join DetallePagoEventual t4
	on t3.pevId = t4.pevId
	where 
		t4.dpeMes = 11
	and t4.dpeAnio = 2023
	and t2.pevId != t4.pevId
	and 
		(t1.ageCUIT = t3.ageCUIT
	or t1.ageNroControl = t3.ageNroControl)
) 


select * from PagosEventuales t1
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId 
where 
		t2.dpeMes = 09
	and t2.dpeAnio = 2023


select * from PruebasAge
where MesAnioLiq = '11/23'

delete from ConceptoTemporal
where ageId = 17034778

delete from PruebasAge
where NuevoAgeId1 = 17034778

