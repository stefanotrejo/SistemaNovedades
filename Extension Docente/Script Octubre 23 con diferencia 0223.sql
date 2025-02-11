-- INICIO ACTUALIZACION DE TABLA CONCEPTOS --

-- INSERTA EN CONCEPTO EXTENSION DOCENTES LOS CONCEPTOS ACTUALIZADOS --
-- EJECUTAR TODOS LOS MESES Y ENVIAR EXCEL A MYRIAM !!


/*
REEMPLAZAR:
SELECT 	@mesanioPruebasAge = '10/23'
agentes_extdoc_diferencia_0223

SELECT 	@mesanio = '09/23'

*/

-- DELETE FROM ConceptoExtensionDocente

-- ESTE MES ES MES ACTUAL ES PARA  LA TABLA PRUEBAS AGE (PRE Y DEFINITIVA)
DECLARE @mesanioPruebasAge varchar(50) 
SELECT 	@mesanioPruebasAge = '10/23'

--INSERT INTO 
--	ConceptoExtensionDocente (conCodigo)
-- Conceptos percibidos por agentes con lugar de pago que comienzan con 38 y con cargo 060098, 060070
SELECT
	 distinct t2.cteCodigoConcepto --, t1.*  
FROM 
	PruebasAge t1
	inner join ConceptoTemporal t2
	on t1.NuevoAgeId1 = t2.ageId
	where MesAnioLiq = @mesanioPruebasAge
	and Agru = '06'
	and tramo = '0'
	and Apertura in ('070','098')
	and SUBSTRING(LugarPago,1,2) = '38'
	and cteCodigoConcepto < '600'
	and cteCodigoConcepto > '001'
	--AND cteCodigoConcepto NOT IN ('78', '553', '559', '595')
	--AND cteCodigoConcepto NOT IN ('78', '111', '112', '113', '114', '115', '117', '118', '137', '550', '553', '559', '595', '597')
	--AND cteCodigoConcepto NOT IN ('550') -> CONSULTAR
	AND NOT EXISTS (
	SELECT * FROM ConceptoExtensionDocente t3
	WHERE t2.cteCodigoConcepto = t3.conCodigo
	)

ORDER BY 
	cteCodigoConcepto

	-- 573 Y 580 SI INCLUIR CUANDO APAREZCAN




---- SELECT ----

Select * from ConceptoExtensionDocente ORDER BY conCodigo

-- UPDATE CONID ---

UPDATE 
	ConceptoExtensionDocente
SET 
	conId = t2.conId
FROM 
	ConceptoExtensionDocente T1
	INNER JOIN Concepto T2
	ON T1.conCodigo = T2.conCodigo

-- FIN ACTUALIZACION DE TABLA CONCEPTOS --


DROP TABLE #agentes_filtrados
DROP TABLE #t1

CREATE TABLE #agentes_filtrados (
	-- Agente
	ageId			int,
	liquidacion_id	int,	
	numeroControl	varchar(255),
	cuil			varchar(255),
	nopres			varchar(255),
    PRES			numeric (18,2),	
	AF				numeric (18,2), 
	IOSEP			int,			 -- AporteIOSEP			en PruebasAge
	OSPLAD			varchar(1),		 -- AporteOsocNac		en PruebasAge
	ANSES			varchar(2),		 -- AportePrevisional	en PruebasAge	
	tipoPlanta		VARCHAR(255),	 -- Tipo planta (PP-PC)
	
	-- No remunerativo
	haberSinAporte  varchar(255),
	NoRem 			numeric (18,2), -- c.totnorem � (AF + i.cod199)
	NR				numeric (18,2), -- Sumatoria NO remunerativos autorizados
	IMP_746			numeric (18,2), 
	PX_746			numeric (18,2), 
	NR_1 			numeric (18,2), 
	NR_DEPURADO		numeric (18,2), 
	IMP_522			numeric (18,2),
	IMP_522_original			numeric (18,2),

	-- Remunerativo
	haberConAporte  varchar(255),
	Rem				numeric (18,2), -- c.totrem
	R				numeric (18,2), -- Sumatoria remunerativos autorizados
	IMP_601			numeric (18,2), 	
	IMP_601_1		numeric (18,2), 	
	PX_601			numeric (18,2), 
	--R_1 			numeric (18,2), 	
	R_DEPURADO		numeric (18,2), 
	IMP_521			numeric (18,2),
	IMP_521_original			numeric (18,2),
	
	-- Descuentos
	IMP_602			numeric (18,2),	
	IMP_615			numeric (18,2),
	IMP_616			numeric (18,2),
	IMP_663			numeric (18,2),
	IMP_664			numeric (18,2),
	IMP_665			numeric (18,2),  -- VALOR QUE VIENE DE LA LIQUIDACION
	IMP_665_1		numeric (18,2), --	VALOR CALCULADO
	AP_IOSEP		numeric (18,2),
	AP_OSPLAD		numeric (18,2),
	AP_ANSES		numeric (18,2),

	-- Totalizadores
	total_haberes_sin_aporte numeric (18,2),	
	total_haberes_con_aporte numeric (18,2),	
	total_haberes			 numeric (18,2),	
	total_descuentos		 numeric (18,2),	
	liquido					 numeric (18,2),	
)

SELECT * from agentes_extdoc_diferencia_0223

select * from NovedadesExtensionDocente
where liq_id = 36
and activo = 1 -- 227
select * from LiquidacionExtensionDocente

--------------- INICIO COPIA EN #t1 --------------- 
-- drop table #t1

-- MES ANTERIOR (SE USA PARA OBTENER LIQ_ID DE NOVEDADES CARGADAS)
DECLARE @mesanio varchar(50) 
--SELECT 	@mesanio = '02/23'
SELECT 	@mesanio = '09/23'
	
-- ESTE MES ES MES ACTUAL ES PARA PRUEBAS AGE (PRE Y DEFINITIVA)
DECLARE @mesanioPruebasAge varchar(50) 
--SELECT 	@mesanioPruebasAge = '03/23'
SELECT 	@mesanioPruebasAge = '10/23'
 
SELECT
	t1.NuevoAgeId1, t1.NroCOntrol, t1.Cuil, t1.[HaberS/aporte] AS haberSinAporte,
	t1.[HaberC/aporte] as  haberConAporte, t1.[Nopres/RiesgoVida] AS NOPRES,
	ISNULL((SELECT cteImporte FROM ConceptoTemporal b2
			WHERE t1.NuevoAgeId1 = b2.ageId
			AND cteCodigoConcepto = '199'),0) AS PRES,     
	-- REMUNERATIVO AUTORIZADO
	(SELECT 
		SUM (cteImporte) 
	 FROM 
		ConceptoTemporal b1 
		INNER JOIN ConceptoExtensionDocente b2 ON b1.cteCodigoConcepto = b2.conCodigo
		INNER JOIN Concepto b3				   ON b2.conCodigo = b3.conCodigo
	 WHERE 
		b3.conRemunerativoNoRemunerativo = '1'
		AND b1.ageId = t1.NuevoAgeId1) as R,
	-- NO REMUNERATIVO
	(SELECT 
		SUM (cteImporte) 
	FROM 
		ConceptoTemporal b1 
		INNER JOIN ConceptoExtensionDocente b2 on b1.cteCodigoConcepto = b2.conCodigo
		INNER JOIN Concepto b3 on b2.conCodigo = b3.conCodigo
	 WHERE 
		b3.conRemunerativoNoRemunerativo = '2'
	 AND (b1.cteCodigoConcepto < '108' OR b1.cteCodigoConcepto > '118')
	 AND b1.cteCodigoConcepto not in ('137', '202', '208')
	 AND cteCodigoConcepto NOT IN ('550', '552', '553', '559', '595', '597') -- 28.8.23 - se agrega 552
	 --AND b2.liq_id = 14
	 AND b1.ageId = t1.NuevoAgeId1) as NR,
	-- ASIGNACIONES FAMILIARES
	 ISNULL((SELECT 
		SUM (b1.cteImporte) 
	FROM 
		ConceptoTemporal b1 
		INNER JOIN ConceptoExtensionDocente b2 on b1.cteCodigoConcepto = b2.conCodigo
		INNER JOIN Concepto b3 on b2.conCodigo = b3.conCodigo
	WHERE  
		 b1.ageId = t1.NuevoAgeId1
	AND	b3.conRemunerativoNoRemunerativo = '2'
	AND ((b1.cteCodigoConcepto >= '108' AND b1.cteCodigoConcepto <= '118')
	OR b1.cteCodigoConcepto in ('137', '202', '208') )),0) AS AF,
	ISNULL((SELECT cteImporte FROM ConceptoTemporal b2
			WHERE t1.NuevoAgeId1 = b2.ageId
			AND cteCodigoConcepto = '746'),0) AS IMP_746,
	ISNULL((SELECT cteImporte FROM ConceptoTemporal b2
			WHERE t1.NuevoAgeId1 = b2.ageId
			AND cteCodigoConcepto = '601'),0) AS IMP_601,
	(CASE 
		WHEN AporteIOSEP = 'A' THEN 10
		WHEN AporteIOSEP = 'B' THEN 11
		WHEN AporteIOSEP = 'C' THEN 12
		WHEN AporteIOSEP = 'D' THEN 13
		WHEN AporteIOSEP = 'E' THEN 14
		ELSE AporteIOSEP
	END)
	AS IOSEP,
	AporteOsocNac AS OSPLAD,			
	AportePrevisional AS ANSES,
	ISNULL((SELECT cteImporte 
			FROM ConceptoTemporal b2
			WHERE t1.NuevoAgeId1 = b2.ageId
			AND cteCodigoConcepto = '665'),0) AS IMP_665		
INTO 
	#t1
FROM 
	PruebasAge t1
WHERE 
		t1.MesAnioLiq = @mesanioPruebasAge
	-- Filtro escuelas habilitadas
	AND EXISTS (
		SELECT CUISE FROM EscuelaExtensionDocente	 t2
		WHERE CONVERT(int,t1.Escuela) = t2.CUISE
	)
	-- Filtro cargos habilitados
	AND EXISTS (
		SELECT * 
		FROM CargosExtensionDocente	 t3
		WHERE t1.Agru = t3.agrupamiento
		AND t1.tramo = t3.tramo
		AND t1.Apertura = t3.apertura
	)
	AND t1.SituRev != 'A' -- FILTRO ADSCRIPTOS
	AND t1.SituRev != 'V' -- FILTRO VACANTES (ES LO MISMO QUE LEGAJO '9999999�)
	AND t1.Legajo != '9999999'
	AND t1.SituRev != 'N' -- FILTRO NACION 
	AND t1.SituRev != 'R' -- FILTRO RETENIDO 
	AND t1.Liquido != 0 -- FILTRO LIQUIDO
	AND t1.TotalHaberes != 0 -- FILTRO tot.hab.rem
	AND t1.TotalSinCargosAlHaber != 0 -- FILTRO tot.hab.no rem
	-- FILTRO que tengan codigo 002
	AND exists ( 	 
		SELECT * FROM ConceptoTemporal b2
		WHERE t1.NuevoAgeId1 = b2.ageId
		AND cteCodigoConcepto = '002'
	)
	AND not exists ( -- FILTRO 1 solo item
		SELECT * FROM PruebasAge b1
		WHERE b1.CantItemsOcupados = 1
		AND MesAnioLiq = @mesanioPruebasAge
		AND b1.NuevoAgeId1 = t1.NuevoAgeId1
		AND exists ( -- FILTRO que tengan solo codigo 595
		SELECT * FROM ConceptoTemporal b2
		WHERE b1.NuevoAgeId1 = b2.ageId
		AND cteCodigoConcepto = '595')
	)
	-- FILTRO Registros con cero en d�as trab y l�quido, e (importe cod.601 = tot.desctos)
	AND not exists (
		SELECT * FROM PruebasAge b1
		WHERE 
			b1.DiasTrabajados = 0
		AND b1.Liquido = 0
		AND MesAnioLiq = @mesanioPruebasAge
		AND b1.NuevoAgeId1 = t1.NuevoAgeId1
		AND b1.TotalDescuentos = (
						SELECT cteImporte FROM ConceptoTemporal b2
						WHERE b1.NuevoAgeId1 = b2.ageId
						AND cteCodigoConcepto = '601'
						)
	)
	-- FILTRO ARCHIVO NOVEDADES PARA DESCONTAR (FILTRO POR NRO CONTROL Y DIAS)
	AND not exists (
		SELECT * FROM NovedadesExtensionDocente p2
		WHERE t1.NroCOntrol = p2.age_nrocontrol
		AND p2.dias_descontar >= 30
		AND t1.PlantaTipo = 'D'
		AND p2.activo = 1
		AND liq_id = (SELECT id
					  FROM LiquidacionExtensionDocente 
					  WHERE 
						 CONCAT(mes_referencia,'/',anio_referencia) = @mesanio
					  AND etapa = (SELECT max(etapa) 
									FROM LiquidacionExtensionDocente
									WHERE 
										 CONCAT(mes_referencia,'/',anio_referencia) = @mesanio
									) 
						AND Activo = 1
						)
	)

--------------- FINAL COPIA EN #t1 --------------- 
-- 6652 PRE
--  DEF 6689

-- SELECT * FROM #t1 --Tiene todos los agentes a liquidar
-- drop table #t1
-- DELETE FROM #agentes_filtrados 

select COUNT(1) from #t1
select COUNT(1) from #agentes_filtrados

select * from #agentes_filtrados

select distinct NroCOntrol from 	#t1
select distinct numeroControl from 	#agentes_filtrados

--------------- COPIA EN #agentes_filtrados  --------------- 

INSERT INTO  
	#agentes_filtrados 
	(ageId,		 numeroControl, cuil, haberSinAporte, haberConAporte, nopres, PRES, R, NR, AF, IMP_746, IMP_601, IOSEP, OSPLAD, ANSES, IMP_665)
SELECT 
	NuevoAgeId1, NroCOntrol,	cuil, haberSinAporte, haberConAporte,nopres, PRES, R, NR, AF, IMP_746, IMP_601, IOSEP, OSPLAD, ANSES, IMP_665
FROM 
	#t1

--SELECT * FROM #agentes_filtrados
-- 6709

--------------- FIN - COPIA EN #agentes_filtrados  --------------- 


----------------------->>>>> INICIO - CALCULOS <<<<<-----------------------

-- CALCULO NR_1 (NR CON FILTRO PRESENTISMO) 
-- CALCULO NoRem

UPDATE 
	#agentes_filtrados
SET 
	NoRem = haberSinAporte - (AF+PRES),
	NR_1 = (CASE WHEN NOPRES ='1' THEN NR - PRES ELSE NR END) -- CON FILTRO PRESENTISMO

-- SELECT * FROM #agentes_filtrados

----------------------->>>>> CALCULOS <<<<<-----------------------

-- CALCULO PX_746 (PORCENTAJE A DESCONTAR NOREM)
-- CALCULO NR_DEPURADO (NR FINAL PARA EL CALCULO DEL 25%)

UPDATE 
	#agentes_filtrados
SET 
	PX_746		= (CASE WHEN IMP_746 != 0 -- SI EXISTE 746 
					AND IMP_746 < NoRem -- ES MENOR QUE NoRem
					THEN  IMP_746 / NoRem
					ELSE 0 -- = O MAYOR
					END)

-- SELECT * FROM #agentes_filtrados

UPDATE 
	#agentes_filtrados
SET 
	NR_DEPURADO = (CASE 
					WHEN IMP_746 != 0 -- SI EXISTE 746 
					AND IMP_746 < NoRem -- ES MENOR QUE NoRem
					THEN NR_1 - (NR_1 * PX_746)
					
					WHEN IMP_746 != 0 -- SI EXISTE 746 
					AND IMP_746 >= NoRem 
					THEN 0
					
					ELSE NR_1 -- = o MAYOR 
					END)

-- SELECT * FROM #agentes_filtrados

------>> INICIO CALCULO REMUNERATIVO <<--------

-- CALCULO: i.cod601 (filtro presentismo)

-- CALCULO :
-- Rem

UPDATE 
	#agentes_filtrados
SET 
	Rem = haberConAporte ,
	IMP_601_1 = (CASE WHEN NOPRES ='1' THEN IMP_601 - PRES ELSE IMP_601 END) -- CON FILTRO PRESENTISMO


UPDATE 
	#agentes_filtrados
SET 
	PX_601		= (CASE WHEN IMP_601 != 0 -- SI EXISTE 601 
					AND IMP_601_1 < Rem -- ES MENOR QUE Rem
					THEN  IMP_601_1 / Rem
					ELSE 0 -- = O MAYOR
					END)

UPDATE 
	#agentes_filtrados
SET 
	R_DEPURADO = (CASE 
					WHEN IMP_601 != 0 -- SI EXISTE 601 
					AND IMP_601_1 < Rem -- ES MENOR QUE Rem
					THEN R - (R * PX_601)
															
					WHEN IMP_601 != 0 -- SI EXISTE 601 
					AND IMP_601_1 >= Rem -- ES mayor o igual a Rem
					THEN 0
					
					ELSE R -- CUANDO NO EXISTE 601
					END)

-- SELECT * FROM #agentes_filtrados

----------------  C) ---------------- 
UPDATE 
	#agentes_filtrados
SET 
	IMP_522 = (CASE WHEN NR_DEPURADO > 0 
					THEN NR_DEPURADO * 0.25
					ELSE 0 -- = O MAYOR
					END),
	IMP_521 = (CASE WHEN R_DEPURADO > 0 
					THEN R_DEPURADO * 0.25
					ELSE 0 -- = O MAYOR
					END)


--------- INICIO DIFERENCIAS ---------------
UPDATE 
	#agentes_filtrados
SET 
	IMP_521_original = IMP_521, 
	IMP_522_original = IMP_522


UPDATE agentes_extdoc_diferencia_0223 set monto_destino_rem_descontado = null
UPDATE agentes_extdoc_diferencia_0223 set monto_destino_norem_descontado = null


---------------- ACTUALIZA DIFERENCIAS DESCONTADAS ----------------
UPDATE 
	agentes_extdoc_diferencia_0223
SET 
	monto_destino_rem_descontado =
								(CASE WHEN IMP_521 >= convert(decimal (18,2), t2.monto_origen_rem_descontar)
									THEN t2.monto_origen_rem_descontar
									ELSE Convert(varchar, IMP_521) 
									END),
	monto_destino_norem_descontado =
									(CASE WHEN IMP_522 >= convert(decimal (18,2),t2.monto_origen_norem_descontar) 
									THEN t2.monto_origen_norem_descontar 
									ELSE Convert(varchar,IMP_522) 
									END)	
FROM
	#agentes_filtrados t1
	INNER JOIN agentes_extdoc_diferencia_0223 t2
	ON T1.numeroControl = t2.NroCOntrol


	UPDATE 
		agentes_extdoc_diferencia_0223
	SET
		saldo_rem = convert(decimal (18,2),t2.monto_origen_rem_descontar) - convert(decimal (18,2),monto_destino_rem_descontado),
		saldo_norem = convert(decimal (18,2),t2.monto_origen_norem_descontar) - convert(decimal (18,2),monto_destino_norem_descontado)
	FROM
		#agentes_filtrados t1
		INNER JOIN agentes_extdoc_diferencia_0223 t2
		ON T1.numeroControl = t2.NroCOntrol

---------------- FIN----------------

--6190 -- encuentra los controles 

-- PARCIAL 1378 / 1522
select * from agentes_extdoc_diferencia_0223
where CONVERT(Numeric (18,2),saldo_norem) != 0
AND CONVERT(numeric (18,2),monto_origen_norem_descontar) > 0 

-- TOTAL 4053 - 3909
select * from agentes_extdoc_diferencia_0223
where CONVERT(Numeric (18,2),saldo_norem) = 0
AND CONVERT(numeric (18,2),monto_origen_norem_descontar) > 0 

-- NO LOS ENCONTR� 376 / 376
select * from agentes_extdoc_diferencia_0223
where saldo_norem is null
AND CONVERT(numeric (18,2),monto_origen_norem_descontar) > 0 

-- AGENTES A DESCONTAR ORIGINALMENTE -- 5807 / xxx
select * from agentes_extdoc_diferencia_0223  t1
where 	
 CONVERT(numeric (18,2),monto_origen_norem_descontar) != 0.00

-- DESGLOSE DE LOS QUE NO ENCONTR�
-- 144
select * from agentes_extdoc_diferencia_0223 t1
inner join PruebasAge t2
on t1.NroCOntrol = t2.NroCOntrol
where monto_destino_rem_descontado is null
and t2.CantItemsOcupados = 1
and t2.MesAnioLiq = '08/23'

--190
select * from agentes_extdoc_diferencia_0223 t1
inner join NovedadesExtensionDocente t2
on t1.NroCOntrol = t2.age_nrocontrol
where t2.liq_id = 33

-- FIN - AGENTES A LOS QUE NO SE LE PODRA COBRAR POR DISTINTOS FILTROS --


----------------  EJECUTAR ESTO PARA DETERMINAR SI SE CANCEL� LA DEUDA O NO ----------------
UPDATE 
	agentes_extdoc_diferencia_0223
SET 
	activoRem = 0 ,
	activonoRem = 0
WHERE 
	CONVERT(numeric (18,2),monto_origen_norem_descontar) <= 0 

----------------  EJECUTAR ESTO PARA DETERMINAR SI SE CANCEL� LA DEUDA O NO ----------------

----------------  EJECUTAR ESTO PARA DETERMINAR SI SE CANCEL� LA DEUDA O NO ----------------
UPDATE 
	agentes_extdoc_diferencia_0223
SET 
	activoRem = (CASE WHEN CONVERT(numeric (18,2), saldo_rem) = 0 
									THEN 0
									ELSE 1								
										END),
	activonoRem = (CASE WHEN Convert(numeric (18,2), saldo_norem) = 0 
									THEN 0
									ELSE 1								
										END)
WHERE 
	CONVERT(numeric (18,2),monto_origen_norem_descontar) > 0 

----------------  EJECUTAR ESTO PARA DETERMINAR SI SE CANCEL� LA DEUDA O NO ----------------



SELECT * FROM agentes_extdoc_diferencia_0223
where activoNoRem = 1

-- NO TIENE SENTIDO --
--UPDATE 
--	#agentes_filtrados
--SET 
--	IMP_521 = ( IMP_521 - CONVERT(numeric (18,2), t2.monto_destino_rem_descontado)),	
--	IMP_522 = ( IMP_522 - CONVERT(numeric (18,2), t2.monto_destino_norem_descontado))	
--FROM
--	#agentes_filtrados t1
--INNER JOIN 
--	agentes_extdoc_diferencia_0223 t2
--ON  T1.numeroControl = t2.NroCOntrol


--------- FIN DIFERENCIAS ---------------


-- CALCULO APORTE PREVISIONAL 
UPDATE 
	#agentes_filtrados
SET 
	IMP_602 = IMP_521 * 0.13,
	IMP_665_1 = (CASE WHEN IMP_665 > 0 
					THEN IMP_521 * 0.045
					ELSE 0 -- = O MAYOR
					END)

-- CALCULO APORTE EMPLEADO Y FLIAR A CARGO OBRA SOCIAL 
UPDATE 
	#agentes_filtrados
SET 
	-- IOSEP
	IMP_615 = (CASE WHEN IOSEP > 4 					 
					THEN IMP_521 * 0.05
					ELSE 0 
					END),
	
	IMP_616 = (CASE WHEN IOSEP > 5 					 					
					THEN (IMP_521 * (IOSEP-5)/100)
					ELSE 0
					END),
	-- OSPLAD
	IMP_663 = (CASE WHEN OSPLAD > 2			 
					THEN IMP_521 * 0.03
					ELSE 0 
					END),
	IMP_664 = (CASE WHEN OSPLAD > 3			 
					THEN (IMP_521 * (OSPLAD - 3) * 0.015)
					ELSE 0 
					END)


--select I01  from agentes_extension_docente_historico
--where CONVERT(numeric (18,2), I07) > 0
--AND liq_id = 26
--and NroCOntrol = '38760553'
				
				
				
--select AporteOsocNac from PruebasAge
--where MesAnioLiq = '08/23'
--and NroCOntrol = '38760553'





-- CALCULO APORTE PATRONAL OBRA SOCIAL
UPDATE 
	#agentes_filtrados
SET 
	-- IOSEP
	AP_IOSEP = (CASE WHEN IOSEP > 4 					  		
					THEN IMP_521 * 0.06
					ELSE 0 
					END),
	-- OSPLAD
	AP_OSPLAD = (CASE WHEN OSPLAD > 2 					  		
					THEN IMP_521 * 0.06
					ELSE 0 
					END)

-- CALCULO APORTE PATRONAL PREVISIONAL
UPDATE 
	#agentes_filtrados
SET 
	-- ANSES
	AP_ANSES = IMP_521 * 0.1017


----------------------->>>>> FIN - CALCULOS <<<<<-----------------------



select * from agentes_extdoc_diferencia_0223
where monto_destino_norem_descontado is  null

select * from #agentes_filtrados  t1
inner join agentes_extdoc_diferencia_0223  t2
on t1.numeroControl = t2.NroCOntrol


-- TOTAL DESCUENTOS GENERAL -> $$17.634.243,24 / $17.036.824,47
SELECT  				
	 SUM (convert(decimal (18,2), t3.monto_destino_norem_descontado))
	 --count(1)
AS Columna 
FROM  
	#agentes_filtrados t1
	INNER JOIN PruebasAge t2	
	ON t1.ageId = t2.NuevoAgeId1
	LEFT JOIN agentes_extdoc_diferencia_0223 t3
	ON t1.numeroControl = t3.NroCOntrol
	 AND t3.id not in (
4609,
4642,
4643,
4650,
4651,
4652,
4657,
4658,
4659,
4661,
4662,
4698,
4760,
4762,
4765,
4766,
4767,
4768,
4773,
4774,
4775,
4778,
4779,
4880,
4882,
4884,
4886,
4887,
4892,
4897,
4898,
4899,
4900,
4901,
4961,
4962,
4964,
4966,
4967,
4968,
4969,
6595,
6596,
6597,
6601,
6602,
6603,
6605,
6606,
6607,
6609,
6610,
6615,
6616
	 )

----------------------->>>>> INICIO GENERACION TXT PARA EL BANCO V2 <<<<<-----------------------
SELECT  				
	  CAST (dbo.RellenarTextoDerecha(t2.Nombre,' ',25) AS VARCHAR(25)) -- NOMBRE + RELLENO
    + CAST (dbo.RellenarTextoIzquierda(SUBSTRING(t1.cuil,3,8),'0',8) AS VARCHAR(8)) -- RELLENO + DNI
    + CAST (dbo.RellenarTextoIzquierda(t2.LugarPago,'0',5) AS VARCHAR(5)) -- RELLENO + LUGAR PAGO 	
    + CAST (dbo.RellenarTextoIzquierda(t2.Escuela,'0',5) AS VARCHAR(5)) -- RELLENO + ESCUELA	
    + CAST (dbo.RellenarTextoIzquierda(t2.NroCOntrol,'0',8) AS VARCHAR(8)) -- RELLENO + CONTROL		
    + CAST (dbo.RellenarTextoIzquierda(t2.Agru + t2.tramo + t2.Apertura,' ',6) AS VARCHAR(6)) -- RELLENO + CARGO
    + CAST (dbo.RellenarTextoIzquierda(replace(cast(t1.IMP_522 AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9)) -- RELLENO + TOT. HAB. SIN APORTE
	+ CAST (dbo.RellenarTextoIzquierda(replace(cast(t1.IMP_521 AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9)) -- RELLENO + TOT. HAB. CON APORTE
	+ CAST (dbo.RellenarTextoIzquierda(replace(cast(convert(decimal (18,2), t1.IMP_521) 
		+ (convert(decimal (18,2),t1.IMP_522)) AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9)) -- RELLENO + TOT. HAB.
	+ CAST (dbo.RellenarTextoIzquierda(replace(cast(convert(decimal (18,2), t1.IMP_602)
			+ (convert(decimal (18,2),t1.imp_615)) + (convert(decimal (18,2),t1.imp_616)) + (convert(decimal (18,2),t1.imp_663)) 
			+ (convert(decimal (18,2),t1.IMP_664)) + convert(decimal (18,2), t1.IMP_665_1)  
			+ ISNULL(convert(decimal (18,2), t3.monto_destino_rem_descontado),'000000000') 
			+ ISNULL(convert(decimal (18,2), t3.monto_destino_norem_descontado), '000000000')
			AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9)) -- RELLENO + TOTAL DESCUENTOS	
	+ CAST(t2.PlantaTipo AS VARCHAR(1))  -- PLANTA
	+ '000000000' -- SALARIO	
	+ CAST (dbo.RellenarTextoIzquierda(replace(cast(
			  (convert(decimal (18,2), t1.IMP_521) + (convert(decimal (18,2),t1.IMP_522))) -- total hab.
			- (
					 ISNULL(convert(decimal (18,2), t3.monto_destino_rem_descontado),'000000000') -- 601
					+ convert(decimal (18,2), t1.IMP_602) 
					+ convert(decimal (18,2), t1.IMP_615) 
					+ convert(decimal (18,2), t1.IMP_616) 					
					+ convert(decimal (18,2), t1.IMP_663) 
					+ convert(decimal (18,2), t1.IMP_664)
					+ convert(decimal (18,2), t1.IMP_665_1) 								
					+ ISNULL(convert(decimal (18,2), t3.monto_destino_norem_descontado),'000000000') -- 746
				) 
				 -- tot desc. 
			AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9)) -- RELLENO + TOT LIQ.		
	+ CAST (dbo.RellenarTextoIzquierda(t2.FechaIngreso,'0',6) AS VARCHAR(6)) -- RELLENO + FECHA INGRESO			
	+ CAST (dbo.RellenarTextoIzquierda(t1.cuil ,'0',11) AS VARCHAR(11)) -- RELLENO + CUIL	
	+ CAST(t2.Sexo AS VARCHAR(1)) -- SEXO
	--+ '000000000' -- PORCENTAJE DE IMP DESCUENTO - 
AS Columna 
FROM  
	#agentes_filtrados t1
	INNER JOIN PruebasAge t2	
	ON t1.ageId = t2.NuevoAgeId1	
	LEFT JOIN agentes_extdoc_diferencia_0223 t3
	ON t1.numeroControl = t3.NroCOntrol
 	AND t3.id not in (
4609,
4642,
4643,
4650,
4651,
4652,
4657,
4658,
4659,
4661,
4662,
4698,
4760,
4762,
4765,
4766,
4767,
4768,
4773,
4774,
4775,
4778,
4779,
4880,
4882,
4884,
4886,
4887,
4892,
4897,
4898,
4899,
4900,
4901,
4961,
4962,
4964,
4966,
4967,
4968,
4969,
6595,
6596,
6597,
6601,
6602,
6603,
6605,
6606,
6607,
6609,
6610,
6615,
6616
	 )
	-- ids de controles pagados 2 veces en liq 22 (ya habian cobrado en liq 3)}
	-- esto fue causado por un pedido de pago de una lista de nro de controles 
	
 -- 6652

 -- DUPLICADOS --
 
 select COUNT(1) from #agentes_filtrados
 select  NroCOntrol from agentes_extdoc_diferencia_0223 
 group by NroCOntrol having COUNT(1) > 1 

 select * from agentes_extdoc_diferencia_0223
 where NroCOntrol = 38747372

----------------------->>>>> FIN GENERACION TXT PARA EL BANCO V2 <<<<<-----------------------

----------------------->>>>> INICIO UPDATE TIPO PLANTA <<<<<-----------------------

--SELECT * FROM #agentes_filtrados

UPDATE #agentes_filtrados 
SET tipoPlanta =  (CASE 
			
		WHEN (t2.LugarPago IN (27101, 28104, 28514, 29107) 
			OR (t2.LugarPago>=38153 AND t2.LugarPago<=38265) 
			OR t2.LugarPago IN (39102, 57107, 58103, 59106, 62101)) 
			OR t2.LugarPago IN (56015, 56023, 56031, 56046, 56054, 56062 ,56077, 56085, 56112, 56104, 56127) 
			-- lugares nuevos EXT DOC 26/10/2023
			--THEN 'DOCENT.TITULAR' -- TITUL88
			THEN 'PP' -- TITUL88
		
		WHEN t2.LugarPago IN (27116, 28112, 28522, 29115) 
			OR t2.LugarPago>=38281 AND t2.LugarPago<=38393 
			OR t2.LugarPago IN (39117, 57115, 58111, 59114, 62116)
			OR t2.LugarPago IN (56197, 56201, 56143, 56247) -- lugar nuevos ext doc 26/10/2023
			--THEN 'DOCENT.INTERINO' -- INTER88
			THEN 'PP' -- INTER88
		
		WHEN t2.LugarPago IN (27124, 28127, 28537, 29123) 
			OR t2.LugarPago>=38524 AND t2.LugarPago<=38636 
			OR t2.LugarPago IN (39125, 57123, 58126, 59122, 62124) 
			OR t2.LugarPago IN (56375, 56383 ,56391, 56402, 56417, 56425, 
								56433, 56441 ,56464, 56472, 56487) -- lugares nuevos EXT DOC 26/10/2023
			--THEN 'DOCEN.SUPLENTE' -- SUPLE88
			THEN 'PC' -- SUPLE88	

		WHEN t2.LugarPago IN (27132, 28135, 28545, 29131) 
			OR t2.LugarPago>=38652 AND t2.LugarPago<=38764
			OR t2.LugarPago IN (39133, 57131, 58134, 59137, 62132) 
			--THEN 'DOC.CONTRATADO' -- CONTR88
			THEN 'PC' -- CONTR88	

		WHEN t2.LugarPago IN (27147, 28143, 28553, 29146) 
			OR t2.LugarPago>=38787 AND t2.LugarPago<=38892
			OR t2.LugarPago IN (39141, 57146, 58142, 59145, 62147) 
			--THEN 'SUPL.CONTINUID' -- SUPCO88
			THEN 'PC' -- SUPCO88	

		WHEN t2.LugarPago IN (27155, 28151, 28561, 29177) 
			OR t2.LugarPago>=38404 AND t2.LugarPago<=38516
			OR t2.LugarPago IN (39156, 57154, 58157, 59153, 62171) 
			--THEN 'PERS.NO.DOCENT' -- PERMA88
			THEN 'PP' -- PERMA88	
		
		-- NO APLICA
		--WHEN t2.LugarPago IN (27913, 28916, 28947, 29154, 38911, 39601, 39914, 61604, 62155) THEN 'SUPL.CONTINUID' -- AMIN88
		
		WHEN (t2.LugarPago IN (27921, 28924, 28955, 29162, 38926) 
			OR (t2.LugarPago>=39616 AND t2.LugarPago<=39663)
			OR t2.LugarPago IN (39922, 62163) 
			OR t2.LugarPago>=61612 AND t2.LugarPago<=61651)
			AND t2.PlantaTipo IN ('P','D')
			--THEN 'PERSON.DOCENTE' -- DOCEN88
			THEN 'PP'

		WHEN (t2.LugarPago IN (27921, 28924, 28955, 29162, 38926) 
			OR (t2.LugarPago>=39616 AND t2.LugarPago<=39663)
			OR t2.LugarPago IN (39922, 62163) 
			OR t2.LugarPago>=61612 AND t2.LugarPago<=61651)
			AND t2.PlantaTipo NOT IN ('P','D')
			--THEN 'PERSON.DOCENTE' -- DOCEN88
			THEN 'PC'

		WHEN t2.LugarPago IN (27936, 28932, 28963, 38934, 39937) 
		--THEN 'DOCEN.SUPLENTE' -- DOCSUP88
		THEN 'PC'

	END)		
FROM  
	#agentes_filtrados t1
	inner join PruebasAge t2	
	on t1.ageId = t2.NuevoAgeId1

----------------------->>>>> FIN - UPDATE TIPO PLANTA <<<<<-----------------------

-- VALIDAR QUE SE HAYA SETEADO PP Y PC
SELECT * from #agentes_filtrados 
where tipoPlanta is null

----------------------->>>>> INICIO - ORDEN DE PAGO <<<<<-----------------------
SELECT 
	-- LIQUIDO
	SUM(
		(t1.IMP_521 + t1.IMP_522) 
			- ( 
				ISNULL(t3.monto_destino_rem_descontado,0) -- 601 
				+ t1.IMP_602 + + t1.IMP_615 + t1.IMP_616 
				+ t1.IMP_663 + t1.IMP_664 
				+ t1.IMP_665_1 								 							 
				+ ISNULL(t3.monto_destino_norem_descontado,0) -- 746
			) 
		) AS liquido,
	-- AP EMPLEADO ANSES
	SUM (
		t1.IMP_602 + t1.IMP_665_1
		) AS aporteAnsesEmpleado, 
	-- AP PATRONAL ANSES
	SUM (
		 t1.AP_ANSES
		 ) 
		 AS aporteAnsesPatronal, 
	-- TOTAL APORTE ANSES
	SUM (
		t1.IMP_602 + t1.IMP_665_1 + t1.AP_ANSES
		) AS ANSES,

	-- AP EMPLEADO IOSEP
	SUM (
		t1.imp_615 + t1.IMP_616
		) AS aporteIosepEmpleado, 
	-- AP PATRONAL IOSEP
	SUM (
		 t1.AP_IOSEP
		 ) 
		 AS aporteIosepPatronal, 
	-- TOTAL APORTE IOSEP
	SUM (
		t1.imp_615 + t1.IMP_616 + t1.AP_IOSEP
		) AS IOSEP ,

		-- AP EMPLEADO OSPLAD
	SUM (
		t1.IMP_663 + t1.IMP_664
		) AS aporteOspladEmpleado, 
	-- AP PATRONAL OSPLAD
	SUM (
		 t1.AP_OSPLAD
		 ) 
		 AS aporteOspladPatronal, 
	-- TOTAL APORTE OSPLAD
	SUM (
		t1.IMP_663 + t1.IMP_664 +  t1.AP_OSPLAD
		) AS OSPLAD		
FROM  
	#agentes_filtrados t1
	INNER JOIN PruebasAge t2	
	ON t1.ageId = t2.NuevoAgeId1
	LEFT JOIN agentes_extdoc_diferencia_0223 t3
	ON t2.NroCOntrol = t3.NroCOntrol
	 	AND t3.id not in (
4609,
4642,
4643,
4650,
4651,
4652,
4657,
4658,
4659,
4661,
4662,
4698,
4760,
4762,
4765,
4766,
4767,
4768,
4773,
4774,
4775,
4778,
4779,
4880,
4882,
4884,
4886,
4887,
4892,
4897,
4898,
4899,
4900,
4901,
4961,
4962,
4964,
4966,
4967,
4968,
4969,
6595,
6596,
6597,
6601,
6602,
6603,
6605,
6606,
6607,
6609,
6610,
6615,
6616
	 )
	-- ids de controles pagados 2 veces en liq 22 (ya habian cobrado en liq 3)}
	-- esto fue causado por un pedido de pago de una lista de nro de controles 
	-- quitar el segundo registro
WHERE 
	t1.tipoPlanta = 'PC'
	--t1.tipoPlanta = 'PP'


----------------------->>>>> FIN - ORDEN DE PAGO <<<<<-----------------------

select COUNT(1) from #agentes_filtrados

SELECT 	 SUM (convert(decimal (18,2), t1.I01) + (convert(decimal (18,2),t1.I02)))
from agentes_extension_docente t1


SELECT 	 SUM (convert(decimal (18,2), t1.IMP_746))
from #agentes_filtrados t1

-- PARA VERIFICAR DIFERENCIAS EN TOTAL HABERES EXCEL
SELECT 	 SUM (convert(decimal (18,2), t1.monto_destino_norem_descontado))
from agentes_extdoc_diferencia_0223 t1
where 	 id not in (
4609,
4642,
4643,
4650,
4651,
4652,
4657,
4658,
4659,
4661,
4662,
4698,
4760,
4762,
4765,
4766,
4767,
4768,
4773,
4774,
4775,
4778,
4779,
4880,
4882,
4884,
4886,
4887,
4892,
4897,
4898,
4899,
4900,
4901,
4961,
4962,
4964,
4966,
4967,
4968,
4969,
6595,
6596,
6597,
6601,
6602,
6603,
6605,
6606,
6607,
6609,
6610,
6615,
6616
	 )
	-- ids de controles pagados 2 veces en liq 22 (ya habian cobrado en liq 3)}
	-- esto fue causado por un pedido de pago de una lista de nro de controles 



select * from EscuelaExtensionDocente_historico
where mes = 7
and anio = 23

select COUNT(1) from EscuelaExtensionDocente

select * from agentes_extension_docente_historico t1
where t1.mes = 07
and t1.anio = 23
and exists (
	select * from agentes_extension_docente t2
	where t2.NroCOntrol = t1.NroCOntrol
	and t1.C01 = t2.C01
	and t1.C09 = t2.C09
)


SELECT * from agentes_extension_docente

select * from #agentes_filtrados t1
where exists (
select * from NovedadesExtensionDocente t2
where t2.liq_id = 32
and t2.activo = 1
and t1.numeroControl = t2.age_nrocontrol
)


select top 5 * from #agentes_filtrados
where numeroControl = 38282144
select * from agentes_extension_docente_historico
where NroCOntrol = 38282144
and liq_id = 30

select * from agentes_extension_docente
select * from agentes_extension_docente_historico
where mes = 08
and anio= 23

delete from agentes_extension_docente



----------------------->>>>> INICIO - INSERTA EN AGENTE_EXT_DOC <<<<<-----------------------
INSERT INTO 
	agentes_extension_docente 
	(age_id,NroCOntrol, PlantaTipo,tipo_planta_OP , agrupamiento, tramo, apertura, cuil, LugarPago, Escuela, Juris, Prog, SubP, Actividad, fuente,dias_trabajados, haberSinAporte, haberConAporte, total_haberes,
	total_descuentos, total_liquido, AP_IOSEP, AP_OSPLAD, AP_ANSES,
	C01, I01, C02, I02, C03, I03, C04, I04, C05, I05, C06, I06, C07, I07, C08, I08, C09, I09,C10, I10)
SELECT 
	t2.NuevoAgeId1,
	t2.NroCOntrol, 
	t2.PlantaTipo, 
	t1.tipoPlanta,
	t2.Agru,
	t2.tramo,
	t2.Apertura,
	t2.Cuil,
	t2.LugarPago, 
	t2.Escuela, 
	t2.Juris, 
	t2.Prog,
	t2.SubP, 
	t2.Actividad,
	'R' AS fuente, 
	'030' AS dias_trabajados, 
	
	REPLICATE('0', 9- len(ltrim(CAST(replace(cast(t1.IMP_522 as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO TOT. HAB. SIN APORTE
	+CAST(replace(cast(t1.IMP_522 as decimal(18,2)),'.','') AS VARCHAR(9))
	AS haberSinAporte, 
	REPLICATE('0', 9- len(ltrim(CAST(replace(cast(t1.IMP_521 as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO TOT. HAB. CON APORTE
	+CAST(replace(cast(t1.IMP_521 as decimal(18,2)),'.','') AS VARCHAR(9)) -- TOT. HAB. CON APORTE	
	AS haberConAporte, 

	REPLICATE('0', 9- len(ltrim(CAST(replace(cast(convert(decimal (18,2), t1.IMP_521) + (convert(decimal (18,2),t1.IMP_522)) as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO TOT. HAB.
	+CAST(replace(cast((convert(decimal (18,2), t1.IMP_521) + (convert(decimal (18,2),t1.IMP_522))) as decimal(18,2)),'.','') AS VARCHAR(9)) -- TOT. HAB. 
	AS total_haberes,
	REPLICATE('0', 9- len(ltrim(CAST(replace(cast(convert(decimal (18,2), t1.IMP_602) + convert(decimal (18,2), t1.IMP_665_1) + (convert(decimal (18,2),t1.imp_615)) + (convert(decimal (18,2),t1.imp_616)) + (convert(decimal (18,2),t1.imp_663)) + (convert(decimal (18,2),t1.IMP_664)) 
		+ ISNULL(convert(decimal (18,2), t3.monto_destino_rem_descontado),0) 
		+ ISNULL(convert(decimal (18,2), t3.monto_destino_norem_descontado),0) as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO TOTAL DESCUENTOS
	+CAST(replace(cast((convert(decimal (18,2), t1.IMP_602) 
	+ convert(decimal (18,2), t1.IMP_665_1) + (convert(decimal (18,2),t1.imp_615)) 
	+ (convert(decimal (18,2),t1.imp_616)) + (convert(decimal (18,2),t1.imp_663)) 
	+ (convert(decimal (18,2),t1.IMP_664)))
	+ ISNULL(convert(decimal (18,2), t3.monto_destino_rem_descontado),0) 
	+ ISNULL(convert(decimal (18,2), t3.monto_destino_norem_descontado),0) as decimal(18,2)),'.','') AS VARCHAR(9)) -- TOTAL DESCUENTOS
	AS total_descuentos,
	REPLICATE('0', 9- len(ltrim(CAST(replace(cast(
		(convert(decimal (18,2), t1.IMP_521) + (convert(decimal (18,2),t1.IMP_522))) -- total hab.
		- (
				convert(decimal (18,2), t1.IMP_602) + convert(decimal (18,2), t1.IMP_665_1) 
				+ convert(decimal (18,2), t1.IMP_615) + convert(decimal (18,2), t1.IMP_616) 
				+ convert(decimal (18,2), t1.IMP_663) + convert(decimal (18,2), t1.IMP_664)
				+ ISNULL(convert(decimal (18,2), t3.monto_destino_rem_descontado),0) 
				+ ISNULL(convert(decimal (18,2), t3.monto_destino_norem_descontado),0)
			) -- tot desc.
		as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO TOT LIQ.
	+CAST(replace(cast((
		(convert(decimal (18,2), t1.IMP_521) + (convert(decimal (18,2),t1.IMP_522))) -- total hab.
		- (convert(decimal (18,2), t1.IMP_602) + convert(decimal (18,2), t1.IMP_665_1) 
			+ convert(decimal (18,2), t1.IMP_615) + convert(decimal (18,2), t1.IMP_616) 
			+ convert(decimal (18,2), t1.IMP_663) + convert(decimal (18,2), t1.IMP_664)
			+ ISNULL(convert(decimal (18,2), t3.monto_destino_rem_descontado),0) 
			+ ISNULL(convert(decimal (18,2), t3.monto_destino_norem_descontado),0)
			) -- tot desc.
		) as decimal(18,2)),'.','') AS VARCHAR(9)) -- TOTAL LIQ.
	AS total_liquido,
	t1.AP_IOSEP, 
	t1.AP_OSPLAD, 
	t1.AP_ANSES,
	'521',
	t1.IMP_521, 
	'522', 
	IMP_522, 
	'602', 
	IMP_602, 
	'615', 
	IMP_615, 
	'616', 
	IMP_616, 
	'663', 
	IMP_663, 
	'664', 
	IMP_664, 
	'665', 
	IMP_665_1,
	--- CODIGOS NUEVOS DIFERENCIA
	'601', 		
	ISNULL(t3.monto_destino_rem_descontado, 0.00),
	'746', 
	ISNULL(t3.monto_destino_norem_descontado, 0.00)
FROM  
	--#agentes_filtrados t1
	#agentes_filtrados t1
	INNER JOIN PruebasAge t2	
	ON t1.ageId = t2.NuevoAgeId1
	LEFT JOIN agentes_extdoc_diferencia_0223 t3
	ON t2.NroCOntrol = t3.NroCOntrol
	AND t3.id not in (
4609,
4642,
4643,
4650,
4651,
4652,
4657,
4658,
4659,
4661,
4662,
4698,
4760,
4762,
4765,
4766,
4767,
4768,
4773,
4774,
4775,
4778,
4779,
4880,
4882,
4884,
4886,
4887,
4892,
4897,
4898,
4899,
4900,
4901,
4961,
4962,
4964,
4966,
4967,
4968,
4969,
6595,
6596,
6597,
6601,
6602,
6603,
6605,
6606,
6607,
6609,
6610,
6615,
6616
	 )
	-- ids de controles pagados 2 veces en liq 22 (ya habian cobrado en liq 3)}
	-- esto fue causado por un pedido de pago de una lista de nro de controles 
----------------------->>>>> FIN - INSERTA EN AGENTE_EXT_DOC <<<<<-----------------------


select  I01, I02,* from agentes_extension_docente
where NroCOntrol = '38000131'

select * from ConceptoTemporal t1
inner join Concepto t2
on t1.cteCodigoConcepto = t2.conCodigo
where ageId = 16652992
and t2.conRemunerativoNoRemunerativo = 1

select COUNT (1) from #agentes_filtrados
SELECT total_liquido
from agentes_extension_docente


select * from agentes_extension_docente_historico
where liq_id = 26


update agentes_extension_docente_historico
where liq_id = 26



select SUM(CONVERT(NUMERIC (18,2),total_liquido)) from agentes_extension_docente_historico
where liq_id = 26

select * from agentes_extension_docente_historico
where mes = 05
and anio = 23

exec [ExtensionDocente.Archivo_Ministerio] 

select * from LiquidacionExtensionDocente
select * from agentes_extension_docente_historico
where 

exec [ExtensionDocente.Eliminar_En_Historico] '06', '23', 26


select * from agentes_extension_docente_historico
where mes = 06
and anio = 23

select * from liquidacionex

select * from agentes_extdoc_diferencia_0223
where NroCOntrol = '38827114'

select * from PruebasAge
where MesAnioLiq = '05/23'
and NroCOntrol = '38827114'

select * from ConceptoTemporal 
where ageId = 15920108


select * from #agentes_filtrados 
where ageId = 15920108
15920108	38827114

exec [ExtensionDocente.Archivo_Ministerio] '10', '23' 


SELECT * from agentes_extension_docente

select * from LiquidacionExtensionDocente


select * from LiquidacionExtensionDocente

select * from agentes_extension_docente_historico
where mes = 09
and anio = 23

exec [ExtensionDocente.Guardar_En_Historico] '10', '23', 36, 0, 0


select * from agentes_extension_docente

select * from agentes_extension_docente_historico
where mes = 10
and anio = 23
and liq_id = 36



exec [ExtensionDocente.Archivo_Ministerio] '08', '23'


exec [ExtensionDocente.ArchivoRectificativaV2] 36, 0,0,0
