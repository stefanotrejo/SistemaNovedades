select 
	ageCUIT,
	+RTRIM(LTRIM(CAST(UPPER(replace(replace(replace(replace(replace(REPLACE(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(ageApellidoNombre, 'ñ', 'n'),'/',''),'á','a'),'é','e'),'í','i'),'ó','o'),'ú','u'),'Ñ','N'),'´',''),'''',''),'Á','A'),'À', 'A'),'É','E'),'Í','I'),'Ó','O'),'Ú','U'),'¥','N')) AS VARCHAR(40)))) + 
	   +REPLICATE(' ', 40-len(LTRIM(CAST(UPPER(replace((replace(replace(replace(replace(REPLACE(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(ageApellidoNombre, 'ñ', 'n'),'/',''),'á','a'),'é','e'),'í','i'),'ó','o'),'ú','u'),'Ñ','N'),'´',''),'''',''),'Á','A'),'À','A'),'É','E'),'Í','I'),'Ó','O'),'Ú','U')),'¥','N')) AS VARCHAR(40)))))
	   as nombre,	
	t3.lpaNombre, 
	t2.dpeConcepto, t1.pevFechaCarga, t1.pevUtlimaVezGenerado, 
	t2.dpeMes, t2.dpeAnio, t1.pevId
from 
	PagosEventuales t1
	inner join DetallePagoEventual  t2
	on t1.pevId = t2.pevId
	inner join LugarPago t3 
	on t1.pevLugarPagoCodigo = t3.lpaCodigo
where 
	pevFechaCarga > '04/08/2022'
order by dpeConcepto


UPDATE DetallePagoEventual
set dpeConcepto = 'Bono Aguinaldo 2022 2da cuota Julio'
WHERE dpeConcepto = 'Bono aguinaldo 2.021 2da cuota'
and dpeMes = 7

update
PagosEventuales
set pevenviado = 'Enviado el dia 16-2-23 por mail de stefano'
where 
	pevFechaCarga > '04/08/2022'



select  ageCUIT,ageApellidoNombre, pevLugarPagoCodigo, t2.dpeConcepto, dpeMes, dpeAnio
from PagosEventuales t1
inner join DetallePagoEventual  t2	
on t1.pevId = t2.pevId
order by dpeAnio, dpeMes, t2.dpeConcepto

Gratificacion 2018 3º cuota

select COUNT(1) from PagosEventuales