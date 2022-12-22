use LiquidacionSueldos

select * from PruebasAge
where SUBSTRING(cuil,3,8) in (
--'16505018'
'13511174'
--,'40444793'
--,'36878359'
--,'37510570'
--,'35465765'
--,'41647046'
--,'41362635'
--,'17235777'
--,'17890712'
--,'14637275'
--,'21339686'
--,'31417527'
--,'23410173'
)
AND MesAnioLiq = '09/22'



select * from PagosEventuales 
where PagosEventuales.pevId = 6362

select dpemes, dpeanio, dpeConcepto, pevImporteTotal  from DetallePagoEventual
inner join PagosEventuales 
on DetallePagoEventual.pevId = PagosEventuales.pevId
where dpeAnio = '2022'
and dpeMes = '11'


SELECT 
	* 
FROM 
	"PagosEventuales_13.7.22_servidor" t1
	INNER JOIN [DetallePagoEventual_13.7.22_servidor]  t2
	ON t1.pevId = t2.pevId 


	
		
	
				
	
		

					
			

	
		
			
	



declare @dni varchar(255)
declare @numero_control varchar(8)
set @dni = '28743673'
set @numero_control = ''


SELECT 
	ageApellidoNombre, pevLugarPagoCodigo, pevImporteTotal, dpemes, dpeanio, dpeConcepto
FROM
	PagosEventuales 
	LEFT JOIN DetallePagoEventual 
	ON PagosEventuales.pevId = DetallePagoEventual.pevId
WHERE 
	substring(ageCUIT, 3, 8) in (@dni)
OR ageNroControl = @numero_control

-----------------------------------------

SELECT 
	ageApellidoNombre, pevLugarPagoCodigo, pevImporteTotal, dpemes, dpeanio, dpeConcepto
FROM 
	"PagosEventuales_13.7.22_servidor" t1
	LEFT JOIN [DetallePagoEventual_13.7.22_servidor] t2
	ON t1.pevId = t2.pevId
WHERE 
	substring(ageCUIT, 3, 8) in (@dni)
OR ageNroControl = @numero_control

-----------------------------------------
SELECT 
		ageApellidoNombre, pevLugarPagoCodigo, pevImporteTotal, dpemes, dpeanio, dpeConcepto
FROM 
	"PagosEventuales_14.2.22" t1
	LEFT JOIN [DetallePagoEventual_14.2.22] t2
	ON t1.pevId = t2.pevId
WHERE 
	substring(ageCUIT, 3, 8) in (@dni)
OR ageNroControl = @numero_control

-----------------------------------------
SELECT 
	ageApellidoNombre, pevLugarPagoCodigo, pevImporteTotal, dpemes, dpeanio, dpeConcepto
FROM 
	"PagosEventuales_30.6.22" t1
	LEFT JOIN [DetallePagoEventual_30.6.22] t2
	ON t1.pevId = t2.pevId
WHERE 
	substring(ageCUIT, 3, 8) in (@dni)
OR ageNroControl = @numero_control

-----------------------------------------
SELECT 
	ageApellidoNombre, pevLugarPagoCodigo, pevImporteTotal, dpemes, dpeanio, dpeConcepto
FROM 
	"PagosEventuales_Sucio" t1
	LEFT JOIN DetallePagoEventual_Sucio t2
	ON t1.pevId = t2.pevId
WHERE 
	substring(ageCUIT, 3, 8) in (@dni)
OR ageNroControl = @numero_control


