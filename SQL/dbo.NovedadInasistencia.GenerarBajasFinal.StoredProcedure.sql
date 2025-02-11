USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.GenerarBajasFinal]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[NovedadInasistencia.GenerarBajasFinal]
(
@liqId int
)
AS

-- ARCHIVO BAJAS DE PERSONAL
Select 
PA.PlantaTipo AS PLANTA, 
--NI.ncoId ,
'AP935' AS HOJA,
CASE
		 WHEN NI.ncoId = 12 THEN '1'
		 WHEN NI.ncoId = 13 THEN '1'
		 WHEN NI.ncoId = 14 THEN '3'		 
		 WHEN NI.ncoId = 16 THEN '4'
		 END
		 AS NOVEDAD,
CASE		
		 WHEN NI.ncoId = 14 OR NI.ncoId = 16 THEN ''		 
		 ELSE 'XXXX'
		 END
		 AS PROGRAMA,
CASE		
		 WHEN NI.ncoId = 14 OR NI.ncoId = 16 THEN ''		 
		 ELSE 'X'
		 END
		 AS SUBPROG,
(REPLICATE(' ',5)) AS ESCUELA, 
--PA.LugarPago AS LUGAR,  
'04013' AS LUGAR, -- LUGAR DE PAGO DE PERSONAL
(REPLICATE(' ',11)) AS CUIL, 
(REPLICATE(' ',1)) AS SEXO, 
(REPLICATE(' ',7)) AS NUMIOSEP,
CASE		
		 WHEN NI.ncoId = 14 OR NI.ncoId = 16 THEN ''		 
		 ELSE REPLICATE('X',3)
		 END
		 AS ACTIVIDAD,
PA.NroCOntrol AS CONTROL,
CASE		
		 WHEN NI.ncoId = 14 OR NI.ncoId = 16  THEN ''		 
		 --ELSE (SELECT SUBSTRING(columna0, 798,7) as columna FROM [LiquidacionSueldos].[dbo].[agentes2008] JA WHERE PA.NroCOntrol = SUBSTRING(JA.Columna0, 3,8))
		 ELSE PA.Legajo
		 END
		 AS LEGAJO,
(REPLICATE(' ',6)) AS CARGO,
(REPLICATE(' ',25)) AS NOMBRE,
/*
'30'
+ SUBSTRING(CONVERT(VARCHAR, NI.ninFechaDesde, 5),4,2) 
+ SUBSTRING(CONVERT(VARCHAR, NI.ninFechaDesde, 5),7,2) AS FECHANAC,*/ -- VERSION ANTERIOR
CASE
		 WHEN NI.ncoId = 14  OR NI.ncoId = 16 THEN ''		 
		 WHEN NI.ninFechaDesde <= CONCAT('30','/',LIQ.liqMes,'/',liq.liqAnio) THEN CONCAT('30',LIQ.liqMes,liq.liqAnio)		 
		 ELSE SUBSTRING(CONVERT(VARCHAR, NI.ninFechaDesde, 5),1,2)  + SUBSTRING(CONVERT(VARCHAR, NI.ninFechaDesde, 5),4,2)  + SUBSTRING(CONVERT(VARCHAR, NI.ninFechaDesde, 5),7,2)
		 END
		 AS FECHANAC, -- VERSION NUEVA (SI LA NOVEDAD ES MENOR O IGUAL AL ULTIMO DIA DEL MES ANTERIOR, PONER 30 DE ESE MES. SINO, SE PONE LA FECHA QUE INGRESO EL USUARIO
(REPLICATE(' ',9)) AS DOCUMENTO,
(REPLICATE(' ',3)) AS ANTREC,
(REPLICATE(' ',6)) AS FECHAING,
(REPLICATE(' ',1)) AS ESTADO,
(REPLICATE(' ',1)) AS IOSEP,
(REPLICATE(' ',1)) AS CAJAJUB,
CASE
		 WHEN NI.ncoId = 14 OR NI.ncoId = 16  THEN '601'
		 ELSE REPLICATE(' ',27) 
		 END
		 AS BONIFIC,
(REPLICATE(' ',1)) AS OTROAPOR,
(REPLICATE(' ',1)) AS OSPLAD,
(REPLICATE(' ',1)) AS CAJACOMP,
(REPLICATE(' ',2)) AS HORAS,
(REPLICATE(' ',2)) AS JORNAL1,
(REPLICATE(' ',3)) AS JORNAL2,
(REPLICATE(' ',50)) AS MARCA,
'PERS' AS QUIEN,
(REPLICATE(' ',6)) AS CUANDO,
(REPLICATE(' ',1)) AS COMO

from NovedadInasistencia  NI
INNER JOIN PruebasAge PA ON NI.NuevoAgeId1 = PA.NuevoAgeId1
INNER JOIN Liquidacion LIQ ON ni.liqId = liq.liqId

where NI.ninActivo = 1
and
(NI.ncoId = 12
or NI.ncoId = 13
or NI.ncoId=14
OR NI.ncoId = 16)	
and NI.liqId = @liqId 
GO
