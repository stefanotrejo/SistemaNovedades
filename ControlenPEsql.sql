use LiquidacionSueldos

select * from PagosEventuales 

select * from DetallePagoEventual

aguantame

declare @dni decimal(11)
set @dni='29486809'

SELECT 
	* 
FROM 
	PagosEventuales
WHERE substring(ageCUIT, 3, 8) in (
 @dni
)


SELECT 
	* 
FROM 
	"PagosEventuales_13.7.22_servidor"
WHERE substring(ageCUIT, 3, 8) in (
@dni
)


SELECT 
	* 
FROM 
	"PagosEventuales_14.2.22"
WHERE substring(ageCUIT, 3, 8) in (
@dni
)


SELECT 
	* 
FROM 
	"PagosEventuales_30.6.22"
WHERE substring(ageCUIT, 3, 8) in (
@dni
)

SELECT 
	* 
FROM 
	"PagosEventuales_Sucio"
WHERE substring(ageCUIT, 3, 8) in (
@dni
)

select * from DetallePagoEventual
