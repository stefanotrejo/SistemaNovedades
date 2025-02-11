USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.ArchivoMultas]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NovedadInasistencia.ArchivoMultas]
	@liqId int	
AS
BEGIN

-- ARCHIVO DE MULTAS Y SUSPENSIONES
Select 
--ni.LIQid,
--NI.ninId ,
--PA.PlantaTipo AS PLANTA, 
(select SUBSTRING(JA.Columna0, 2,1)  
from agentes2007 JA
where 
PA.NroCOntrol = SUBSTRING(JA.Columna0, 3,8) AND
PA.LugarPago = SUBSTRING(Columna0, 11,5) AND
PA.Escuela	 = SUBSTRING(Columna0, 16,5) AND
pa.Escalafon = SUBSTRING(Columna0, 21,1) AND
PA.Agru = SUBSTRING(Columna0, 22,2) AND
pa.tramo = SUBSTRING(Columna0, 24,1) and
pa.Apertura = SUBSTRING(Columna0, 25,3) 
/*AND
PA.Categoria = SUBSTRING(Columna0, 28,2) AND
PA.HsCat = SUBSTRINRG(Columna0, 30,2) AND
PA.Juris = SUBSTRING(Columna0, 32,2) and
PA.Prog = SUBSTRING(Columna0, 34,2) AND
pa.SubP = SUBSTRING(Columna0, 36,2)  AND 
PA.Actividad = SUBSTRING(Columna0, 38,2) and
PA.Nombre = SUBSTRING(Columna0, 40,25) AND
Pa.Cuil = SUBSTRING(Columna0, 65,11)*/
) AS PLANTA,
--PA.LugarPago AS LUGAR,  
'04013' AS LUGAR, -- NUEVA VERSION - LUGAR DE PAGO DE PERSONAL
'35' AS HOJA,
PA.NroCOntrol AS CONTROL1,
--CONCAT((CAST(REPLICATE('0', 3-len(NI.ninCantidad)) AS VARCHAR(3))),ni.ninCantidad)  AS DIAS1, 
CASE
		 WHEN NI.ninCantidad = -1 THEN ''		 
		 ELSE CONCAT((CAST(REPLICATE('0', 3-len(NI.ninCantidad)) AS VARCHAR(3))),ni.ninCantidad)
		 END AS DIAS1,

-- COMIENZA FECHA1 VERSION ANTERIOR DD/MM/AAAA

SUBSTRING(CONVERT(VARCHAR, NI.ninFechaDesde, 5),1,2)
+ '/' 
+ SUBSTRING(CONVERT(VARCHAR, NI.ninFechaDesde, 5),4,2) 
+ '/' 
+ '20' + 
+ SUBSTRING(CONVERT(VARCHAR, NI.ninFechaDesde, 5),7,2) AS FECHA1,

-- TERMINA FECHA1 VERSION  DD/MM/AAAA 

/*
-- NUEVA VERSION FECHA1 MM/DD/AAAA

SUBSTRING(CONVERT(VARCHAR, NI.ninFechaDesde, 5),4,2) 
+ '/' 
+SUBSTRING(CONVERT(VARCHAR, NI.ninFechaDesde, 5),1,2)
+ '/' 
+ '20' + SUBSTRING(CONVERT(VARCHAR, NI.ninFechaDesde, 5),7,2) AS FECHA1,

-- TERMINA NUEVA VERSION FECHA1 CON FORMATO MM/DD/AAAA
*/

CASE
		 WHEN NI.ncoId = 1 or NI.ncoId = 8 or NI.ncoId = 9  THEN '1'
		 WHEN NI.ncoId = 3 or NI.ncoId = 4 or NI.ncoId = 5  THEN '5'
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
CONCAT((CAST(REPLICATE('0', 10-len(CAST(PA.NroCOntrol AS int) 
+ CAST(NI.ninCantidad AS int) 
+ CAST((CASE
		 WHEN NI.ncoId = 1 or NI.ncoId = 8 or NI.ncoId = 9  THEN '1'
		 WHEN NI.ncoId = 3 or NI.ncoId = 4 or NI.ncoId = 5  THEN '5'
		 WHEN NI.ncoId = 6 THEN '6'
		 WHEN NI.ncoId = 7 THEN '7'
		 WHEN NI.ncoId = 15 THEN '3'
		 ELSE ''
		 END) AS int))) AS VARCHAR(10))),CAST(PA.NroCOntrol AS int) 
+ CAST(NI.ninCantidad AS int) 
+ CAST((CASE
		 WHEN NI.ncoId = 1 or NI.ncoId = 8 or NI.ncoId = 9  THEN '1'
		 WHEN NI.ncoId = 3 or NI.ncoId = 4 or NI.ncoId = 5  THEN '5'
		 WHEN NI.ncoId = 6 THEN '6'
		 WHEN NI.ncoId = 7 THEN '7'
		 WHEN NI.ncoId = 15 THEN '3'
		 ELSE ''
		 END) AS int)) AS TOTAL, 

-- TOTAL (Suma de NroControl + Cant de Dias + Codigo Novedad)
/*CAST(PA.NroCOntrol AS int) 
+ CAST(NI.ninCantidad AS int) 
+ CAST((CASE
		 WHEN NI.ncoId = 1 or NI.ncoId = 8 or NI.ncoId = 9  THEN '1'
		 WHEN NI.ncoId = 3 or NI.ncoId = 4 or NI.ncoId = 5  THEN '5'
		 WHEN NI.ncoId = 6 THEN '6'
		 WHEN NI.ncoId = 7 THEN '7'
		 WHEN NI.ncoId = 15 THEN '3'
		 ELSE ''
		 END) AS int) 
AS TOTAL,*/ -- VERSION VIEJA SIN RELLENO DE 0 ADELANTE HASTA COMPLETAR LOS 10 CARACTERES

(REPLICATE(' ',1)) AS MARCA,
'PERS' AS QUIEN,
(REPLICATE(' ',1)) AS CUANDO,
(REPLICATE(' ',6)) AS COMO

from NovedadInasistencia  NI
INNER JOIN PruebasAge PA
ON NI.NuevoAgeId1 = PA.NuevoAgeId1
INNER JOIN Liquidacion LIQ
ON ni.liqId = liq.liqId

where NI.ninActivo = 1
and (NI.ncoId < 10
or NI.ncoId = 15)
and NI.liqId = @liqId -- CAMBIAR LIQID ANTES DE EJECUTAR

--AND NroCOntrol='77327494'

END

GO
