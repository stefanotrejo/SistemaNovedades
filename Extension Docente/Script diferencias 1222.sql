-- INICIO ACTUALIZACION DE TABLA CONCEPTOS --

-- INSERTA EN CONCEPTO EXTENSION DOCENTES LOS CONCEPTOS ACTUALIZADOS --
-- EJECUTAR TODOS LOS MESES Y ENVIAR EXCEL A MYRIAM !!

-- ESTE MES ES MES ACTUAL ES PARA  LA TABLA PRUEBAS AGE (PRE Y DEFINITIVA)
DECLARE @mesanioPruebasAge varchar(50) 
SELECT 	@mesanioPruebasAge = '12/22'

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
	NoRem 			numeric (18,2), -- c.totnorem – (AF + i.cod199)
	NR				numeric (18,2), -- Sumatoria NO remunerativos autorizados
	IMP_746			numeric (18,2), 
	PX_746			numeric (18,2), 
	NR_1 			numeric (18,2), 
	NR_DEPURADO		numeric (18,2), 
	IMP_522			numeric (18,2),

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

--------------- INICIO COPIA EN #t1 --------------- 

-- drop table #t1

	
-- ESTE MES ES MES ACTUAL ES PARA PRUEBAS AGE (PRE Y DEFINITIVA)
DECLARE @mesanioPruebasAge varchar(50) 
--SELECT 	@mesanioPruebasAge = '03/23'
SELECT 	@mesanioPruebasAge = '12/22'
 
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
		--AND b2.liq_id = 14
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
	 AND cteCodigoConcepto NOT IN ('550', '553', '559', '595', '597') -- nuevo filtro 28.4.23
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
	--AND b2.liq_id = 14
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
	AND EXISTS (
		SELECT * FROM agentes_extension_docente_historico t2
		where t2.liq_id in (3,13,22) -- TODOS LOS LIQID DE DICIEMBRE
		AND t1.NroCOntrol =  t2.NroCOntrol
	)
			AND t1.SituRev != 'A' -- FILTRO ADSCRIPTOS
			AND t1.SituRev != 'V' -- FILTRO VACANTES (ES LO MISMO QUE LEGAJO '9999999’)
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
			-- FILTRO Registros con cero en días trab y líquido, e (importe cod.601 = tot.desctos)
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
	
-- 6721

--------------- FINAL COPIA EN #t1 --------------- 

--------------- COPIA EN #agentes_filtrados  --------------- 

INSERT INTO  
	#agentes_filtrados 
	(ageId,		 numeroControl, cuil, haberSinAporte, haberConAporte, nopres, PRES, R, NR, AF, IMP_746, IMP_601, IOSEP, OSPLAD, ANSES, IMP_665)
SELECT 
	NuevoAgeId1, NroCOntrol,	cuil, haberSinAporte, haberConAporte,nopres, PRES, R, NR, AF, IMP_746, IMP_601, IOSEP, OSPLAD, ANSES, IMP_665
FROM 
	#t1

	

--ORDER BY ageid
-- 1626

--------------- FIN - COPIA EN #agentes_filtrados  --------------- 

--SELECT * from LiquidacionExtensionDocente
--where  id = 14

--SELECT distinct agrupamiento,tramo, apertura from agentes_extension_docente_historico
--WHERE liq_id = 7
--AND 
--SELECT distinct agrupamiento,tramo, apertura from agentes_extension_docente_historico
--WHERE liq_id = 9

--SELECT  * from agentes_extension_docente_historico
--where NroCOntrol = '38272063'




--SELECT * FROM #agentes_filtrados

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

 --SELECT NR_1, NR_DEPURADO, IMP_746, NR_1, * FROM #agentes_filtrados 

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

 
 --select * from #agentes_filtrados
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


-- CALCULO TOTALIZADORES 
UPDATE 
	#agentes_filtrados
SET 
	-- ANSES
	AP_ANSES = IMP_521 * 0.1017

----------------------->>>>> FIN - CALCULOS <<<<<-----------------------

-- DISTINTO REMUNERATIVO
SELECT T1.IMP_521, T1.IMP_522, t2.I01, t2.I02, t2.I02 - T1.IMP_522 
from #agentes_filtrados T1
inner join agentes_extension_docente_historico t2
on T1.numeroControl = t2.NroCOntrol
where t2.liq_id in (3,13,22)  -- TODOS LOS LIQID DE DICIEMBRE
AND T1.IMP_521 != t2.I01

-- DISTINTO NO REMUNERATIVO
SELECT T1.IMP_521, T1.IMP_522, t2.I01, t2.I02, t2.I02 - T1.IMP_522 
from #agentes_filtrados T1
inner join agentes_extension_docente_historico t2
on T1.numeroControl = t2.NroCOntrol
where t2.liq_id in (3,13,22)  -- TODOS LOS LIQID DE DICIEMBRE
AND T1.IMP_522 != t2.I02
-- 5669


----------------------->>>>> INICIO - INSERTA TABLA DE DIFERENCIAS <<<<<-----------------------
DECLARE @liq_id_destino int
SELECT @liq_id_destino = 31

INSERT INTO 
	agentes_extdoc_diferencia_1222 
	(age_id,NroCOntrol, PlantaTipo,tipo_planta_OP , agrupamiento, tramo, apertura, cuil, LugarPago, Escuela, Juris, Prog, SubP, Actividad, fuente,dias_trabajados, haberSinAporte, haberConAporte, total_haberes,
	total_descuentos, total_liquido, AP_IOSEP, AP_OSPLAD, AP_ANSES,
	C01, I01, C02, I02, C03, I03, C04, I04, C05, I05, C06, I06, C07, I07, C08, I08, liq_id_origen, liq_id_destino)
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

	REPLICATE('0', 9- len(ltrim(CAST(replace(cast(convert(decimal (18,2), t1.IMP_602) + convert(decimal (18,2), t1.IMP_665_1) + (convert(decimal (18,2),t1.imp_615)) + (convert(decimal (18,2),t1.imp_616)) + (convert(decimal (18,2),t1.imp_663)) + (convert(decimal (18,2),t1.IMP_664)) as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO TOTAL DESCUENTOS
	+CAST(replace(cast((convert(decimal (18,2), t1.IMP_602) + convert(decimal (18,2), t1.IMP_665_1) + (convert(decimal (18,2),t1.imp_615)) + (convert(decimal (18,2),t1.imp_616)) + (convert(decimal (18,2),t1.imp_663)) + (convert(decimal (18,2),t1.IMP_664))) as decimal(18,2)),'.','') AS VARCHAR(9)) -- TOTAL DESCUENTOS
	AS total_descuentos,

	REPLICATE('0', 9- len(ltrim(CAST(replace(cast(
		(convert(decimal (18,2), t1.IMP_521) + (convert(decimal (18,2),t1.IMP_522))) -- total hab.
		- (convert(decimal (18,2), t1.IMP_602) + convert(decimal (18,2), t1.IMP_665_1) + convert(decimal (18,2), t1.IMP_615) + convert(decimal (18,2), t1.IMP_616) + convert(decimal (18,2), t1.IMP_663) + convert(decimal (18,2), t1.IMP_664)) -- tot desc.
		as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO TOT LIQ.
	+CAST(replace(cast((
		(convert(decimal (18,2), t1.IMP_521) + (convert(decimal (18,2),t1.IMP_522))) -- total hab.
		- (convert(decimal (18,2), t1.IMP_602) + convert(decimal (18,2), t1.IMP_665_1) + convert(decimal (18,2), t1.IMP_615) + convert(decimal (18,2), t1.IMP_616) + convert(decimal (18,2), t1.IMP_663) + convert(decimal (18,2), t1.IMP_664)) -- tot desc.
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
	t3.liq_id, -- liq id origen
	@liq_id_destino --  liq id destino (liquidacion actual)
FROM  
	#agentes_filtrados t1
	INNER JOIN PruebasAge t2	
	ON t1.ageId = t2.NuevoAgeId1
	inner join agentes_extension_docente_historico t3
	on T1.numeroControl = t3.NroCOntrol
	where t3.liq_id in (3,13,22)  -- TODOS LOS LIQID DE DICIEMBRE


	

-- ACTUALIZA MONTOS A DESCONTAR REM Y NO REM ----
UPDATE 
	agentes_extdoc_diferencia_1222
SET
	monto_origen_rem_descontar = (CASE WHEN convert(decimal (18,2), incorrecto.I01) >= convert(decimal (18,2), correcto.I01)
									THEN convert(decimal (18,2), incorrecto.I01) - convert(decimal (18,2), correcto.I01)
									ELSE 0 
									END),
	monto_origen_norem_descontar = (CASE WHEN convert(decimal (18,2), incorrecto.I02) >= convert(decimal (18,2), correcto.I02)
									THEN convert(decimal (18,2), incorrecto.I02) - convert(decimal (18,2), correcto.I02)
									ELSE 0 
									END)
FROM
	agentes_extdoc_diferencia_1222 correcto
	inner join agentes_extension_docente_historico incorrecto
	on correcto.NroCOntrol = incorrecto.NroCOntrol
	where incorrecto.liq_id in (3,13,22)  -- TODOS LOS LIQID DE DICIEMBRE
	


-- A DESCONTAR NO REM -- 5670
SELECT * from agentes_extdoc_diferencia_1222 	
WHERE CONVERT(decimal (18,2) ,monto_origen_norem_descontar) != 0


-- AGENTES QUE SE LIQUIDARON 2 VECES -- NO DEBERIA PASAR PERO VERIFICAR

select  NroCOntrol from agentes_extdoc_diferencia_1222 
group by NroCOntrol having COUNT(1) > 1 

select * from agentes_extdoc_diferencia_1222
where NroCOntrol = '38747372'

----------------------->>>>> FIN - INSERTA EN AGENTE_EXT_DOC <<<<<-----------------------
