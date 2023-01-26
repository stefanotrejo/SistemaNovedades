EXEC [PagosEventuales.Validar] '26215086', '64050301'

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

EXEC [PagosEventuales.Validar] '26215086', '64050301'

SELECT 
	*
FROM
	[PagosEventuales_30.6.22] t1
	LEFT JOIN [DetallePagoEventual_30.6.22] t2
	ON t1.pevId = t2.pevId


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


---------------- FILTRO DE PAGOS EVENTUALES -------------------


SELECT 
	   t1.[pevId]
      ,[lpaId]
      ,[ageApellidoNombre]
      ,[ageDNI]
      ,[ageCUIT]
      ,[ageSexo]
      ,[ageJurisdiccion]
      ,[agePrograma]
      ,[ageNroControl]
      ,[pevLugarPagoCodigo]
      ,[pevImporteTotal]
      ,[pevFechaCarga]	  
  FROM [LiquidacionSueldos].[dbo].[PagosEventuales] T1
  INNER JOIN [LiquidacionSueldos].[dbo].[DetallePagoEventual] T2
  ON T1.pevId = T2.pevId
  WHERE NOT EXISTS 
  (  
	SELECT 
		*
	FROM 
		"PagosEventuales_13.7.22_servidor" t3
		INNER JOIN [DetallePagoEventual_13.7.22_servidor] t4
		ON t1.pevId = t2.pevId
	WHERE
		t1.[lpaId]					= t3.[lpaId]				
		AND t1.[ageApellidoNombre]      = t3.[ageApellidoNombre]  
		AND t1.[ageDNI]                 = t3.[ageDNI]             
		AND t1.[ageCUIT]                = t3.[ageCUIT]            
		AND t1.[ageSexo]                = t3.[ageSexo]            
		AND t1.[ageJurisdiccion]        = t3.[ageJurisdiccion]    
		AND t1.[agePrograma]            = t3.[agePrograma]        
		AND t1.[ageNroControl]          = t3.[ageNroControl]      
		AND t1.[pevLugarPagoCodigo]     = t3.[pevLugarPagoCodigo] 
		AND t1.[pevImporteTotal]        = t3.[pevImporteTotal]    
		AND t1.[pevFechaCarga]	        = t3.[pevFechaCarga]	   
		AND	t2.[dpeId]       = t4.[dpeId]      
		AND t2.[pevId]       = t4.[pevId]      
		AND t2.[dpeMes]      = t4.[dpeMes]     
		AND t2.[dpeAnio]     = t4.[dpeAnio]    
		AND t2.[dpeConcepto] = t4.[dpeConcepto]
  )



  SELECT 
	   [dpeId]
      ,[pevId]
      ,[dpeMes]
      ,[dpeAnio]
      ,[dpeConcepto]
  FROM 
	[LiquidacionSueldos].[dbo].[DetallePagoEventual]
  WHERE
	[dpeMes] = 
    [dpeAnio]
    [dpeConcepto]
	

