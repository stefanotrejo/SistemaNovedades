USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.GenerarMultasSuspensionesFinal]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[NovedadInasistencia.GenerarMultasSuspensionesFinal]
(
@liqId int
)

AS

declare @mesAnioLiquidacion varchar(5)
set @mesAnioLiquidacion = (select CONCAT(LI3.liqMes,'/',LI3.liqAnio) from Liquidacion LI3 where liqId=@liqId)

--////// ARCHIVO DE MULTAS Y SUSPENSIONES PARA CODIGOS DISTINTO DE 3,4 Y 5 //////

Select 
--ni.LIQid,
--NI.ninId ,
PA.NroCOntrol AS CONTROL1,
PA.PlantaTipo AS PLANTA, 
'04013' AS LUGAR, -- NUEVA VERSION - LUGAR DE PAGO DE PERSONAL
'35' AS HOJA,
--PA.NroCOntrol AS CONTROL1,
--CONCAT((CAST(REPLICATE('0', 3-len(NI.ninCantidad)) AS VARCHAR(3))),ni.ninCantidad)  AS DIAS1, 
CASE
		 WHEN NI.ninCantidad = -1 THEN ''		 
		 ELSE CONCAT((CAST(REPLICATE('0', 3-len(NI.ninCantidad)) AS VARCHAR(3))),ni.ninCantidad)
		 END AS DIAS1,
		 		 		 
-- Case para Fecha1 formato dd/mm/aa. Setea el primer dia del mes siguiente al de la Liquidacion
CASE 
			-- Cuando sea menor o igual a 8 -> pongo primer dia del mes siguiente del mismo año. Le agrego 1 0 antes del mes
		  WHEN (SELECT CAST(LIQ.liqMes AS INT)) <= 8 THEN CONCAT ('01/0',(SELECT (CAST(LIQ.liqMes AS INT)+1)),'/',LIQ.liqAnio)		  
			-- Cuando sea mes igual a 12, pongo 01/01/ del año siguiente
		  WHEN (SELECT CAST(LIQ.liqMes AS INT)) = 12 THEN CONCAT('01/01/',(SELECT CAST(LIQ.liqAnio AS INT))+1)		  
		  -- Mes 9, 10 y 11 -> no tengo que agregar 0 adelante
		  ELSE CONCAT ('01/',(SELECT (CAST(LIQ.liqMes AS INT)+1)),'/',LIQ.liqAnio)		  		  
		  END AS FECHA1,
CASE
		 WHEN NI.ncoId = 1 or NI.ncoId = 8 or NI.ncoId = 9  THEN '1'		 
		 WHEN NI.ncoId = 6 THEN '6'
		 WHEN NI.ncoId = 7 THEN '7'
		 WHEN NI.ncoId = 15 THEN '3'
		 -- Codigo 10 tardanza no se genera. Deben cargar la falta
		 ELSE ''
		 END AS MULTA1,
(REPLICATE(' ',8)) AS CONTROL2,
(REPLICATE(' ',3)) AS DIAS2, 
(REPLICATE(' ',6)) AS FECHA2, 
(REPLICATE(' ',1)) AS MULTA2, 
(REPLICATE(' ',8)) AS CONTROL3, 
(REPLICATE(' ',3)) AS DIAS3, 
(REPLICATE(' ',6)) AS FECHA3, 
(REPLICATE(' ',1)) AS MULTA3, 
(REPLICATE(' ',8)) AS CONTROL4, 
(REPLICATE(' ',3)) AS DIAS4, 
(REPLICATE(' ',6)) AS FECHA4, 
(REPLICATE(' ',1)) AS MULTA4, 

-- // COMIENZA CALCULO DE TOTAL  // -- 

CONCAT(
-- Inicio relleno de ceros
(CAST(REPLICATE('0', 10-len
 (CAST(PA.NroCOntrol AS int) 
+ CAST(NI.ninCantidad AS int)
+ CAST((CASE
		 WHEN NI.ncoId = 1 or NI.ncoId = 8 or NI.ncoId = 9  THEN '1'		 
		 WHEN NI.ncoId = 6 THEN '6'
		 WHEN NI.ncoId = 7 THEN '7'
		 WHEN NI.ncoId = 15 THEN '3'
		 ELSE ''
		 END) AS int))) AS VARCHAR(10))), 
-- Fin relleno de ceros
  CAST(PA.NroCOntrol AS int) 
+ CAST(NI.ninCantidad AS int) 
+ CAST((CASE
		 WHEN NI.ncoId = 1 or NI.ncoId = 8 or NI.ncoId = 9  THEN '1'		 
		 WHEN NI.ncoId = 15 THEN '3'
		 ELSE ''
		 END) AS int)) AS TOTAL,

-- // TERMINA CALCULO DE TOTAL  // -- 
(REPLICATE(' ',1)) AS MARCA,
'PERS' AS QUIEN,
(REPLICATE(' ',1)) AS CUANDO,
(REPLICATE(' ',6)) AS COMO

FROM 
NovedadInasistencia  NI
INNER JOIN PruebasAge PA
ON NI.NuevoAgeId1 = PA.NuevoAgeId1
INNER JOIN Liquidacion LIQ
ON ni.liqId = liq.liqId

WHERE 
NI.ninActivo = 1
and (NI.ncoId < 10
or NI.ncoId = 15)
and NI.ncoId != 3
and NI.ncoId != 4
and NI.ncoId != 5
and NI.ncoId != 6
and NI.ncoId != 7
and NI.liqId = @liqId 

union

--////// CODIGOS 3, 4 Y 5 AGRUPADOS POR NRO DE CONTROL Y CON SUMA DE DIAS //////

select distinct (Q.CONTROL1) as CONTROL1, 
pa0.PlantaTipo as PLANTA, 
'04013' AS LUGAR, 
 '35' AS HOJA,
 --pa0.NroCOntrol as CONTROL1, 
 --q.dias as DIAS1, 
 CONCAT((CAST(REPLICATE('0', 3-len(q.dias)) AS VARCHAR(3))),q.dias) AS DIAS1,
		 -- Case para Fecha1 formato dd/mm/aa. Setea el primer dia del mes siguiente al de la Liquidacion
CASE 
			-- Cuando sea menor o igual a 8 -> pongo primer dia del mes siguiente del mismo año. Le agrego 1 0 antes del mes
		  WHEN (SELECT CAST(li0.liqMes AS INT)) <= 8 THEN CONCAT ('01/0',(SELECT (CAST(li0.liqMes AS INT)+1)),'/',li0.liqAnio)		  
			-- Cuando sea mes igual a 12, pongo 01/01/ del año siguiente
		  WHEN (SELECT CAST(li0.liqMes AS INT)) = 12 THEN CONCAT('01/01/',(SELECT CAST(li0.liqAnio AS INT))+1)		  
		  -- Mes 9, 10 y 11 -> no tengo que agregar 0 adelante
		  ELSE CONCAT ('01/',(SELECT (CAST(li0.liqMes AS INT)+1)),'/',li0.liqAnio)		  		  
		  END AS FECHA1,
 '5' AS MULTA1, 
(REPLICATE(' ',8)) AS CONTROL2,
(REPLICATE(' ',3)) AS DIAS2, 
(REPLICATE(' ',6)) AS FECHA2, 
(REPLICATE(' ',1)) AS MULTA2, 
(REPLICATE(' ',8)) AS CONTROL3, 
(REPLICATE(' ',3)) AS DIAS3, 
(REPLICATE(' ',6)) AS FECHA3, 
(REPLICATE(' ',1)) AS MULTA3, 
(REPLICATE(' ',8)) AS CONTROL4, 
(REPLICATE(' ',3)) AS DIAS4, 
(REPLICATE(' ',6)) AS FECHA4, 
(REPLICATE(' ',1)) AS MULTA4, 
CONCAT((CAST(REPLICATE('0', 10-len(CAST(pa0.NroCOntrol AS int) 
+ CAST(Q.dias AS int) 
+ CAST('5' AS int))) AS VARCHAR(10))),
  CAST(pa0.NroCOntrol AS int) 
+ CAST(Q.dias AS int) 
+ CAST('5' AS int)) AS TOTAL, (REPLICATE(' ',1)) AS MARCA,
'PERS' AS QUIEN,
(REPLICATE(' ',1)) AS CUANDO,
(REPLICATE(' ',6)) AS COMO
FROM
-- Q -> Tiene control y suma de dias agrupados por numero de control
(select T.control1, sum(dias) as dias from
-- T -> Tiene Lugar, Hoja, Control1 y dias sin agrupar numero de control
(Select 
'04013' AS LUGAR, 
'35' AS HOJA,
PA.NroCOntrol AS CONTROL1, 
ni.ninCantidad as dias
from NovedadInasistencia  NI
INNER JOIN PruebasAge PA
ON NI.NuevoAgeId1 = PA.NuevoAgeId1
INNER JOIN Liquidacion LIQ
ON ni.liqId = liq.liqId
where NI.ninActivo = 1
and (NI.ncoId >=3 and NI.ncoId <= 5) 
and pa.MesAnioLiq=@mesAnioLiquidacion 
and ni.liqId=@liqId) as T
group by T.control1) as Q
inner join PruebasAge pa0 on pa0.NroCOntrol=q.CONTROL1 and pa0.MesAnioLiq = @mesAnioLiquidacion
inner join NovedadInasistencia ni0 on ni0.NuevoAgeId1=pa0.NuevoAgeId1 
inner join Liquidacion li0 on ni0.liqId = li0.liqId
where ni0.liqid=@liqId and (NI0.ncoId >=3 and NI0.ncoId <= 5)		 


union

-- CODIGOS 6 - AGRUPA POR Nº DE CONTROL Y SUMA DIAS

select distinct (Q.CONTROL1) as CONTROL1, 
pa0.PlantaTipo as PLANTA, 
'04013' AS LUGAR, 
'35' AS HOJA,
 --pa0.NroCOntrol as CONTROL1, 
 --q.dias as DIAS1, 
 CONCAT((CAST(REPLICATE('0', 3-len(q.dias)) AS VARCHAR(3))),q.dias) AS DIAS1,
-- Case para Fecha1 formato dd/mm/aa. Setea el primer dia del mes siguiente al de la Liquidacion
CASE 
		  -- Cuando sea menor o igual a 8 -> pongo primer dia del mes siguiente del mismo año. Le agrego 1 0 antes del mes
		  WHEN (SELECT CAST(li0.liqMes AS INT)) <= 8 THEN CONCAT ('01/0',(SELECT (CAST(li0.liqMes AS INT)+1)),'/',li0.liqAnio)		  
		  -- Cuando sea mes igual a 12, pongo 01/01/ del año siguiente
		  WHEN (SELECT CAST(li0.liqMes AS INT)) = 12 THEN CONCAT('01/01/',(SELECT CAST(li0.liqAnio AS INT))+1)		  
		  -- Mes 9, 10 y 11 -> no tengo que agregar 0 adelante
		  ELSE CONCAT ('01/',(SELECT (CAST(li0.liqMes AS INT)+1)),'/',li0.liqAnio)		  		  
		  END AS FECHA1,
 	 		 
'6' AS MULTA1,
(REPLICATE(' ',8)) AS CONTROL2,
(REPLICATE(' ',3)) AS DIAS2, 
(REPLICATE(' ',6)) AS FECHA2, 
(REPLICATE(' ',1)) AS MULTA2, 
(REPLICATE(' ',8)) AS CONTROL3, 
(REPLICATE(' ',3)) AS DIAS3, 
(REPLICATE(' ',6)) AS FECHA3, 
(REPLICATE(' ',1)) AS MULTA3, 
(REPLICATE(' ',8)) AS CONTROL4, 
(REPLICATE(' ',3)) AS DIAS4, 
(REPLICATE(' ',6)) AS FECHA4, 
(REPLICATE(' ',1)) AS MULTA4, 
CONCAT((CAST(REPLICATE('0', 10-len(CAST(pa0.NroCOntrol AS int) 
+ CAST(Q.dias AS int) 
+ CAST('5' AS int))) AS VARCHAR(10))),
  CAST(pa0.NroCOntrol AS int) 
+ CAST(Q.dias AS int) 
+ CAST('6' AS int)) AS TOTAL, (REPLICATE(' ',1)) AS MARCA,
'PERS' AS QUIEN,
(REPLICATE(' ',1)) AS CUANDO,
(REPLICATE(' ',6)) AS COMO
FROM
-- Q -> Tiene control y suma de dias agrupados por numero de control
(select T.control1, sum(dias) as dias from
-- T -> Tiene Lugar, Hoja, Control1 y dias sin agrupar numero de control
(Select 
'04013' AS LUGAR, 
'35' AS HOJA,
PA.NroCOntrol AS CONTROL1, 
ni.ninCantidad as dias
FROM NovedadInasistencia  NI
INNER JOIN PruebasAge PA
ON NI.NuevoAgeId1 = PA.NuevoAgeId1
INNER JOIN Liquidacion LIQ
ON ni.liqId = liq.liqId
WHERE
NI.ninActivo = 1
and NI.ncoId = 6 
and PA.MesAnioLiq=@mesAnioLiquidacion 
and NI.liqId=@liqid) as T
group by T.control1) as Q
inner join PruebasAge pa0 on pa0.NroCOntrol=q.CONTROL1 and pa0.MesAnioLiq = @mesAnioLiquidacion
inner join NovedadInasistencia ni0 on ni0.NuevoAgeId1=pa0.NuevoAgeId1 
inner join Liquidacion li0 on ni0.liqId = li0.liqId
where (ni0.liqid=@liqid and NI0.ncoId = 6)


union

-- CODIGOS 7 - AGRUPA POR Nº DE CONTROL Y SUMA DIAS

select distinct (Q.CONTROL1) as CONTROL1, 
pa0.PlantaTipo as PLANTA, 
'04013' AS LUGAR, 
'35' AS HOJA,
 --pa0.NroCOntrol as CONTROL1, 
 --q.dias as DIAS1, 
 CONCAT((CAST(REPLICATE('0', 3-len(q.dias)) AS VARCHAR(3))),q.dias) AS DIAS1,
-- Case para Fecha1 formato dd/mm/aa. Setea el primer dia del mes siguiente al de la Liquidacion
CASE 
		  -- Cuando sea menor o igual a 8 -> pongo primer dia del mes siguiente del mismo año. Le agrego 1 0 antes del mes
		  WHEN (SELECT CAST(li0.liqMes AS INT)) <= 8 THEN CONCAT ('01/0',(SELECT (CAST(li0.liqMes AS INT)+1)),'/',li0.liqAnio)		  
		  -- Cuando sea mes igual a 12, pongo 01/01/ del año siguiente
		  WHEN (SELECT CAST(li0.liqMes AS INT)) = 12 THEN CONCAT('01/01/',(SELECT CAST(li0.liqAnio AS INT))+1)		  
		  -- Mes 9, 10 y 11 -> no tengo que agregar 0 adelante
		  ELSE CONCAT ('01/',(SELECT (CAST(li0.liqMes AS INT)+1)),'/',li0.liqAnio)		  		  
		  END AS FECHA1,
 	 		 
'7' AS MULTA1,
(REPLICATE(' ',8)) AS CONTROL2,
(REPLICATE(' ',3)) AS DIAS2, 
(REPLICATE(' ',6)) AS FECHA2, 
(REPLICATE(' ',1)) AS MULTA2, 
(REPLICATE(' ',8)) AS CONTROL3, 
(REPLICATE(' ',3)) AS DIAS3, 
(REPLICATE(' ',6)) AS FECHA3, 
(REPLICATE(' ',1)) AS MULTA3, 
(REPLICATE(' ',8)) AS CONTROL4, 
(REPLICATE(' ',3)) AS DIAS4, 
(REPLICATE(' ',6)) AS FECHA4, 
(REPLICATE(' ',1)) AS MULTA4, 
CONCAT((CAST(REPLICATE('0', 10-len(CAST(pa0.NroCOntrol AS int) 
+ CAST(Q.dias AS int) -- CANTIDAD DE DIAS
+ CAST('5' AS int))) AS VARCHAR(10))),CAST(pa0.NroCOntrol AS int)  -- 
+ CAST(Q.dias AS int) 
+ CAST('7' AS int)) AS TOTAL, (REPLICATE(' ',1)) AS MARCA,
'PERS' AS QUIEN,
(REPLICATE(' ',1)) AS CUANDO,
(REPLICATE(' ',6)) AS COMO
FROM
-- Q -> Tiene control y suma de dias agrupados por numero de control
(select T.control1, sum(dias) as dias from
-- T -> Tiene Lugar, Hoja, Control1 y dias sin agrupar numero de control
(Select 
'04013' AS LUGAR, 
'35' AS HOJA,
PA.NroCOntrol AS CONTROL1, 
ni.ninCantidad as dias
FROM NovedadInasistencia  NI
INNER JOIN PruebasAge PA
ON NI.NuevoAgeId1 = PA.NuevoAgeId1
INNER JOIN Liquidacion LIQ
ON ni.liqId = liq.liqId
WHERE
NI.ninActivo = 1
and NI.ncoId = 7 
and PA.MesAnioLiq=@mesAnioLiquidacion 
and NI.liqId=@liqid) as T
group by T.control1) as Q
inner join PruebasAge pa0 on pa0.NroCOntrol=q.CONTROL1 and pa0.MesAnioLiq = @mesAnioLiquidacion
inner join NovedadInasistencia ni0 on ni0.NuevoAgeId1=pa0.NuevoAgeId1 
inner join Liquidacion li0 on ni0.liqId = li0.liqId
where (ni0.liqid=@liqid and NI0.ncoId = 7)
GO
