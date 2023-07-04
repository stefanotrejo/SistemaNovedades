DROP TABLE #pre_aguinaldo
DROP TABLE #aguinaldo

CREATE TABLE #pre_aguinaldo(
	[id] [int] IDENTITY(1,1) NOT NULL,
	ageId			int,
	[NroCOntrol] [varchar](50) NULL,
	[PlantaTipo] [varchar](50) NULL,
	[agrupamiento] [varchar](50) NULL,
	[tramo] [varchar](50) NULL,
	[apertura] [varchar](50) NULL,
	[cuil] [varchar](50) NULL,
	[LugarPago] [varchar](50) NULL,
	[Escuela] [varchar](50) NULL,
	[Juris] [varchar](50) NULL,
	[Prog] [varchar](50) NULL,
	[SubP] [varchar](50) NULL,
	[Actividad] [varchar](50) NULL,
	[fuente] [varchar](50) NULL,
	tipoPlanta		VARCHAR(255),	 -- Tipo planta (PP-PC)
	[dias_trabajados] INT NULL,
	IOSEP_string	varchar(2),
	IOSEP			INT,
	OSPLAD			INT,
	IMP_521			numeric (18,2), -- actualmente 122	
	IMP_522			numeric (18,2), -- actualmente 123
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
	[haberSinAporte] [varchar](50) NULL,
	[haberConAporte] [varchar](50) NULL,
	[total_haberes] [varchar](50) NULL,
	[total_descuentos] [varchar](50) NULL,
	[total_liquido] [varchar](50) NULL,
	[C01] [varchar](50) NULL,
	[I01] [varchar](50) NULL,
	[C02] [varchar](50) NULL,
	[I02] [varchar](50) NULL,
	[C03] [varchar](50) NULL,
	[I03] [varchar](50) NULL,
	[C04] [varchar](50) NULL,
	[I04] [varchar](50) NULL,
	[C05] [varchar](50) NULL,
	[I05] [varchar](50) NULL,
	[C06] [varchar](50) NULL,
	[I06] [varchar](50) NULL,
	[C07] [varchar](50) NULL,
	[I07] [varchar](50) NULL,
	[C08] [varchar](50) NULL,
	[I08] [varchar](50) NULL,
	[C09] [varchar](50) NULL,
	[I09] [varchar](50) NULL,
	[C10] [varchar](50) NULL,
	[I10] [varchar](50) NULL,
	[mes] [varchar](2) NULL,
	[anio] [varchar](2) NULL
) ON [PRIMARY]




--DROP TABLE #aguinaldo
CREATE TABLE #aguinaldo(
	[preaguinaldo_id] [int],
	ageId			int,
	[NroCOntrol] [varchar](50) NULL,
	[PlantaTipo] [varchar](50) NULL,
	[agrupamiento] [varchar](50) NULL,
	[tramo] [varchar](50) NULL,
	[apertura] [varchar](50) NULL,
	[cuil] [varchar](50) NULL,
	[LugarPago] [varchar](50) NULL,
	[Escuela] [varchar](50) NULL,
	[Juris] [varchar](50) NULL,
	[Prog] [varchar](50) NULL,
	[SubP] [varchar](50) NULL,
	[Actividad] [varchar](50) NULL,
	[fuente] [varchar](50) NULL,
	tipoPlanta		VARCHAR(255),	 -- Tipo planta (PP-PC)
	[dias_trabajados] INT NULL,
	IOSEP_string	varchar(2),
	IOSEP			INT,
	OSPLAD			INT,	
	IMP_521			numeric (18,2), -- actualmente 122	
	IMP_522			numeric (18,2), -- actualmente 123
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
	[haberSinAporte] [varchar](50) NULL,
	[haberConAporte] [varchar](50) NULL,
	[total_haberes] [varchar](50) NULL,
	[total_descuentos] [varchar](50) NULL,
	[total_liquido] [varchar](50) NULL,
	[total_haberes_sac] [varchar](50)  NULL,
	[haberSinAporte_sac] [varchar](50)  NULL,
	[haberConAporte_sac] [varchar](50)  NULL,
	[C01] [varchar](50) NULL,
	[I01] [varchar](50) NULL,
	[C02] [varchar](50) NULL,
	[I02] [varchar](50) NULL,
	[C03] [varchar](50) NULL,
	[I03] [varchar](50) NULL,
	[C04] [varchar](50) NULL,
	[I04] [varchar](50) NULL,
	[C05] [varchar](50) NULL,
	[I05] [varchar](50) NULL,
	[C06] [varchar](50) NULL,
	[I06] [varchar](50) NULL,
	[C07] [varchar](50) NULL,
	[I07] [varchar](50) NULL,
	[C08] [varchar](50) NULL,
	[I08] [varchar](50) NULL,
	[C09] [varchar](50) NULL,
	[I09] [varchar](50) NULL,
	[C10] [varchar](50) NULL,
	[I10] [varchar](50) NULL,
	[mes] [varchar](2) NULL,
	[anio] [varchar](2) NULL
) ON [PRIMARY]


INSERT INTO 
	#pre_aguinaldo -- (15957 filas afectadas)
	(
	[NroCOntrol]  ,
	[PlantaTipo]  ,
	[agrupamiento]  ,
	[tramo]  ,
	[apertura]  ,
	[cuil]  ,
	[LugarPago]  ,
	[Escuela]  ,
	[Juris]  ,
	[Prog]  ,
	[SubP]  ,
	[Actividad]  ,
	[fuente]  ,
	[dias_trabajados]  ,
	[haberSinAporte]  ,
	[haberConAporte]  ,
	[total_haberes]  ,
	[total_descuentos]  ,
	[total_liquido]  ,
	[C01]  ,
	[I01]  ,
	[C02]  ,
	[I02]  ,
	[C03]  ,
	[I03]  ,
	[C04]  ,
	[I04]  ,
	[C05]  ,
	[I05]  ,
	[C06]  ,
	[I06]  ,
	[C07]  ,
	[I07]  ,
	[C08]  ,
	[I08]  ,
	[C09] ,
	[I09] ,
	[C10] ,
	[I10] ,
	[mes]  ,
	[anio] ,
	ageId)
SELECT 
	[NroCOntrol]  ,
	[PlantaTipo]  ,
	[agrupamiento]  ,
	[tramo]  ,
	[apertura]  ,
	[cuil]  ,
	[LugarPago]  ,
	[Escuela]  ,
	[Juris]  ,
	[Prog]  ,
	[SubP]  ,
	[Actividad]  ,
	[fuente]  ,
	[dias_trabajados]  ,
	[haberSinAporte]  ,
	[haberConAporte]  ,
	[total_haberes]  ,
	[total_descuentos]  ,
	[total_liquido]  ,
	[C01]  ,
	[I01]  ,
	[C02]  ,
	[I02]  ,
	[C03]  ,
	[I03]  ,
	[C04]  ,
	[I04]  ,
	[C05]  ,
	[I05]  ,
	[C06]  ,
	[I06]  ,
	[C07]  ,
	[I07]  ,
	[C08]  ,
	[I08]  ,
	[C09] ,
	[I09] ,
	[C10] ,
	[I10] ,
	[mes]  ,
	[anio] ,
	age_id
FROM 
	agentes_extension_docente_historico t1 -- 15864 
WHERE
	EXISTS (
	SELECT * from LiquidacionExtensionDocente t2
	WHERE 
	t1.liq_id = t2.id AND 
	t2.definitiva = 1
	AND ((CONVERT(int,t2.mes_referencia) = 12 AND (CONVERT(int,t2.anio_referencia) = 22))
	OR (CONVERT(int,t2.mes_referencia) < 6) AND (CONVERT(int,t2.anio_referencia) = 23))
	)

	
	
-- (39687 filas afectadas)
	

SELECT top 100 * from LiquidacionExtensionDocente
where id in (25,5,7)
and definitiva = 1


---- ACTUALIZA AGRU, TRAMO , APERTURA y CUIL
--UPDATE 
--	#pre_aguinaldo
--SET 
--	#pre_aguinaldo.agrupamiento= t2.agru,
--	#pre_aguinaldo.tramo = t2.tramo,
--	#pre_aguinaldo.apertura = t2.apertura,
--	#pre_aguinaldo.cuil= t2.Cuil
--FROM 
--	#pre_aguinaldo t1
--	INNER JOIN PruebasAge t2
--	ON t1.NroCOntrol = t2.NroCOntrol
--AND t1.PlantaTipo = t2.PlantaTipo
--WHERE 
--	t2.MesAnioLiq = CONCAT(t1.mes,'/',t1.anio)



--delete FROM #aguinaldo
-- AGENTES A LIQUIDAR
INSERT INTO 	
	#aguinaldo (PlantaTipo, NroCOntrol, agrupamiento, tramo, apertura, cuil)	
SELECT DISTINCT 
	PlantaTipo, NroCOntrol, agrupamiento, tramo, apertura, cuil
FROM #pre_aguinaldo -- 7102

--(7102 filas afectadas)


Declare 
@preaguinaldo_id int,
@NroCOntrol varchar(50) ,
@PlantaTipo varchar(50) ,
@agrupamiento varchar(50) ,
@tramo varchar(50) ,
@apertura varchar(50) ,
@cuil varchar(50) ,
@LugarPago varchar(50) ,
@Escuela varchar(50) ,
@Juris varchar(50) ,
@Prog varchar(50) ,
@SubP varchar(50) ,
@Actividad varchar(50) ,
@fuente varchar(50) ,
@dias_trabajados INT ,
@haberSinAporte varchar(50) ,
@haberConAporte varchar(50) ,
@total_haberes varchar(50) ,
@total_descuentos varchar(50) ,
@total_liquido varchar(50) ,
@total_haberes_sac varchar(50) ,
@haberSinAporte_sac varchar(50) ,
@haberConAporte_sac varchar(50) ,
@C01 varchar(50) ,
@I01 varchar(50) ,
@C02 varchar(50) ,
@I02 varchar(50) ,
@C03 varchar(50) ,
@I03 varchar(50) ,
@C04 varchar(50) ,
@I04 varchar(50) ,
@C05 varchar(50) ,
@I05 varchar(50) ,
@C06 varchar(50) ,
@I06 varchar(50) ,
@C07 varchar(50) ,
@I07 varchar(50) ,
@C08 varchar(50) ,
@I08 varchar(50) ,
@C09 varchar(50) ,
@I09 varchar(50) ,
@C10 varchar(50) ,
@I10 varchar(50) ,
@mes varchar(2)  ,
@anio varchar(2) 


DECLARE CursorExtDoc CURSOR FOR
-- CONSULTA A GUARDAR EN EL CURSOR
SELECT
	NroCOntrol  ,
	PlantaTipo  ,
	agrupamiento  ,
	tramo  ,
	apertura  ,
	cuil  ,
	LugarPago  ,
	Escuela  ,
	Juris  ,
	Prog  ,
	SubP  ,
	Actividad  ,
	fuente  ,
	dias_trabajados  ,
	haberSinAporte  ,
	haberConAporte  ,
	total_haberes  ,
	total_descuentos  ,
	total_liquido  ,
	total_haberes_sac  ,
	haberSinAporte_sac  ,
	haberConAporte_sac  ,
	C01  ,
	I01  ,
	C02  ,
	I02  ,
	C03  ,
	I03  ,
	C04  ,
	I04  ,
	C05  ,
	I05  ,
	C06  ,
	I06  ,
	C07  ,
	I07  ,
	C08  ,
	I08  ,
	C09  ,
	I09  ,
	C10  ,
	I10  ,
	mes   ,
	anio  
from #aguinaldo t1


OPEN 
	CursorExtDoc
FETCH 
	CursorExtDoc 
INTO
	@NroCOntrol  ,
	@PlantaTipo  ,
	@agrupamiento  ,
	@tramo  ,
	@apertura  ,
	@cuil  ,
	@LugarPago  ,
	@Escuela  ,
	@Juris  ,
	@Prog  ,
	@SubP  ,
	@Actividad  ,
	@fuente  ,
	@dias_trabajados  ,
	@haberSinAporte  ,
	@haberConAporte  ,
	@total_haberes  ,
	@total_descuentos  ,
	@total_liquido  ,
	@total_haberes_sac  ,
	@haberSinAporte_sac  ,
	@haberConAporte_sac  ,
	@C01  ,
	@I01  ,
	@C02  ,
	@I02  ,
	@C03  ,
	@I03  ,
	@C04  ,
	@I04  ,
	@C05  ,
	@I05  ,
	@C06  ,
	@I06  ,
	@C07  ,
	@I07  ,
	@C08  ,
	@I08  ,
	@C09  ,
	@I09  ,
	@C10  ,
	@I10  ,
	@mes   ,
	@anio  
WHILE (@@FETCH_STATUS = 0)
BEGIN


--SELECT  top 100 * from #pre_aguinaldo

-- ACTUALIZO ID de historico para extraer toda la info desde ahi
UPDATE #aguinaldo 
SET preaguinaldo_id = 
(select top 1 t1.id 
FROM #pre_aguinaldo t1
WHERE 
	T1.PlantaTipo = @PlantaTipo
AND	t1.NroCOntrol = @NroCOntrol
AND	t1.agrupamiento = @agrupamiento
AND	t1.tramo = @tramo
AND	t1.apertura = @apertura
AND	t1.cuil = @cuil
ORDER BY t1.total_haberes DESC)
WHERE
	PlantaTipo = @PlantaTipo
AND	NroCOntrol = @NroCOntrol
AND	agrupamiento = @agrupamiento
AND	tramo = @tramo
AND	apertura = @apertura
AND	cuil = @cuil
	
-- SUMA DIAS TRABAJADOS
UPDATE 
	#aguinaldo
SET dias_trabajados = (
	SELECT SUM(dias_trabajados)
	FROM #pre_aguinaldo t1
	WHERE
	t1.PlantaTipo = @PlantaTipo
AND	t1.NroCOntrol = @NroCOntrol
AND	t1.agrupamiento = @agrupamiento
AND	t1.tramo = @tramo
AND	t1.apertura = @apertura
AND	t1.cuil = @cuil 
)
WHERE
	PlantaTipo = @PlantaTipo
AND	NroCOntrol = @NroCOntrol
AND	agrupamiento = @agrupamiento
AND	tramo = @tramo
AND	apertura = @apertura
AND	cuil = @cuil

	
FETCH NEXT FROM CursorExtDoc 
INTO
	@NroCOntrol  ,
	@PlantaTipo  ,
	@agrupamiento  ,
	@tramo  ,
	@apertura  ,
	@cuil  ,
	@LugarPago  ,
	@Escuela  ,
	@Juris  ,
	@Prog  ,
	@SubP  ,
	@Actividad  ,
	@fuente  ,
	@dias_trabajados  ,
	@haberSinAporte  ,
	@haberConAporte  ,
	@total_haberes  ,
	@total_descuentos  ,
	@total_liquido  ,
	@total_haberes_sac  ,
	@haberSinAporte_sac  ,
	@haberConAporte_sac  ,
	@C01  ,
	@I01  ,
	@C02  ,
	@I02  ,
	@C03  ,
	@I03  ,
	@C04  ,
	@I04  ,
	@C05  ,
	@I05  ,
	@C06  ,
	@I06  ,
	@C07  ,
	@I07  ,
	@C08  ,
	@I08  ,
	@C09  ,
	@I09  ,
	@C10  ,
	@I10  ,
	@mes   ,
	@anio  
END

CLOSE CursorExtDoc
DEALLOCATE CursorExtDoc

--select * from #aguinaldo

-- ACUALIZO EL RESTO DE CAMPOS DEL MEJOR MES DEL AGENTE
UPDATE 
	#aguinaldo
SET
	LugarPago  =				t1.LugarPago  		
,	Escuela  =                  t1.Escuela  
,	Juris  =                    t1.Juris  
,	Prog  =                     t1.Prog  
,	SubP  =                     t1.SubP  
,	Actividad  =                t1.Actividad  
,	fuente  =                   t1.fuente  
,	haberSinAporte  =           t1.haberSinAporte  
,	haberConAporte  =           t1.haberConAporte  
,	total_haberes  =            t1.total_haberes  
,	total_descuentos  =         t1.total_descuentos  
,	total_liquido  =            t1.total_liquido  
,	C01  =                      t1.C01  
,	I01  =                      t1.I01  
,	C02  =                      t1.C02  
,	I02  =                      t1.I02  
,	C03  =                      t1.C03  
,	I03  =                      t1.I03  
,	C04  =                      t1.C04  
,	I04  =                      t1.I04  
,	C05  =                      t1.C05  
,	I05  =                      t1.I05  
,	C06  =                      t1.C06  
,	I06  =                      t1.I06  
,	C07  =                      t1.C07  
,	I07  =                      t1.I07  
,	C08  =                      t1.C08  
,	I08  =                      t1.I08  
,	C09  =                      t1.C09  
,	I09  =                      t1.I09  
,	C10  =                      t1.C10  
,	I10  =                      t1.I10  
,	mes   =                     t1.mes   
,	anio  =                     t1.anio 
,   ageId =						t1.ageId 
FROM 
	#pre_aguinaldo t1
WHERE 
	preaguinaldo_id  = t1.id

-- ACTUALIZO OSPLAD
UPDATE
	#aguinaldo
SET 
	OSPLAD = (
		SELECT AporteOsocNac FROM PruebasAge
		WHERE 
			MesAnioLiq = CONCAT(#aguinaldo.mes,'/',#aguinaldo.anio)
		AND NroCOntrol = #aguinaldo.NroCOntrol
		AND PlantaTipo = #aguinaldo.PlantaTipo
		AND agrupamiento = #aguinaldo.agrupamiento
		AND tramo = #aguinaldo.tramo
		AND apertura = #aguinaldo.apertura
		AND cuil = #aguinaldo.cuil
		AND LugarPago = #aguinaldo.LugarPago
		AND Escuela = #aguinaldo.Escuela
		AND liquido > 0)

-- ACTUALIZO CAMPO IOSEP
UPDATE
	#aguinaldo
SET 
	IOSEP_string = (
		SELECT AporteIOSEP FROM PruebasAge
		WHERE 
			MesAnioLiq = CONCAT(#aguinaldo.mes,'/',#aguinaldo.anio)
		AND NroCOntrol = #aguinaldo.NroCOntrol
		AND PlantaTipo = #aguinaldo.PlantaTipo
		AND agrupamiento = #aguinaldo.agrupamiento
		AND tramo = #aguinaldo.tramo
		AND apertura = #aguinaldo.apertura
		AND cuil = #aguinaldo.cuil
		AND LugarPago = #aguinaldo.LugarPago
		AND Escuela = #aguinaldo.Escuela
		AND liquido > 0)


-- ACTUALIZO IOSEP
UPDATE
	#aguinaldo
SET 
	IOSEP = 
(CASE 
		WHEN IOSEP_string = 'A' THEN 10
		WHEN IOSEP_string = 'B' THEN 11
		WHEN IOSEP_string = 'C' THEN 12
		WHEN IOSEP_string = 'D' THEN 13
		WHEN IOSEP_string = 'E' THEN 14
		ELSE IOSEP_string
END)

-- ACTUALIZA HABER CON APORTE SAC Y HABER SIN APORTE SAC
UPDATE 
	#aguinaldo
SET 
	haberConAporte_sac = ((haberConAporte * dias_trabajados) / 180) / 2,
	haberSinAporte_sac  = ((haberSinAporte * dias_trabajados) / 180) / 2

-- ELIMINA CONCEPTOS
UPDATE
	#aguinaldo
SET 
	C01 = '',
	I01 = '',
	C02 = '',
	I02 = '',
	C03 = '',
	I03 = '',
	C04 = '',
	I04 = '',
	C05 = '',
	I05 = '',
	C06 = '',
	I06 = '',
	C07 = '',
	I07 = '',
	C08 = '',
	I08 = '',
	C09 = '',
	I09 = '',
	C10 = '',
	I10 = ''


---- ACTUALIZO PRUEBAS AGE ID
--UPDATE
--	#aguinaldo
--SET 
--	ageId = (
--		SELECT NuevoAgeId1 FROM PruebasAge
--		WHERE 
--			MesAnioLiq = CONCAT(#aguinaldo.mes,'/',#aguinaldo.anio)
--		AND NroCOntrol = #aguinaldo.NroCOntrol
--		AND PlantaTipo = #aguinaldo.PlantaTipo
--		AND agrupamiento = #aguinaldo.agrupamiento
--		AND tramo = #aguinaldo.tramo
--		AND apertura = #aguinaldo.apertura
--		AND cuil = #aguinaldo.cuil
--		AND LugarPago = #aguinaldo.LugarPago
--		AND Escuela = #aguinaldo.Escuela
--		AND liquido > 0)

--SELECT * from #aguinaldo

----------------- INICIO CALCULOS -----------------
-- CALCULO APORTE PREVISIONAL 
UPDATE 	
	#aguinaldo
SET 
	IMP_602 = CONVERT(numeric(18,2) ,(convert(numeric(18,2), haberConAporte_sac))/100) * 0.13,
	IMP_665_1 = (CASE WHEN IMP_665 > 0 
					THEN CONVERT(numeric(18,2) ,(convert(numeric(18,2), haberConAporte_sac))/100) * 0.045
					ELSE 0 -- = O MAYOR
					END)

-- CALCULO APORTE EMPLEADO Y FLIAR A CARGO OBRA SOCIAL 
UPDATE 
	#aguinaldo
SET 
	-- IOSEP
	IMP_615 = (CASE WHEN IOSEP > 4 					 
					THEN CONVERT(numeric(18,2) ,(convert(numeric(18,2), haberConAporte_sac))/100) * 0.05
					ELSE 0 
					END),
	
	IMP_616 = (CASE WHEN IOSEP > 5 					 					
					THEN (CONVERT(numeric(18,2) ,(convert(numeric(18,2), haberConAporte_sac))/100) * (IOSEP-5)/100)
					ELSE 0
					END),
	-- OSPLAD
	IMP_663 = (CASE WHEN OSPLAD > 2			 
					THEN CONVERT(numeric(18,2) ,(convert(numeric(18,2), haberConAporte_sac))/100) * 0.03
					ELSE 0 
					END),
	IMP_664 = (CASE WHEN OSPLAD > 3			 
					THEN CONVERT(numeric (18,2), (CONVERT(numeric (18,2), haberConAporte_sac)/100) * (OSPLAD - 3) * 0.015)
					ELSE 0 
					END)

--SELECT * from #aguinaldo
--where NroCOntrol = '38760553'


-- CALCULO APORTE PATRONAL OBRA SOCIAL
UPDATE 
	#aguinaldo
SET 
	-- IOSEP
	AP_IOSEP = (CASE WHEN IOSEP > 4 					  		
					THEN CONVERT(numeric(18,2) ,(convert(numeric(18,2), haberConAporte_sac))/100) * 0.06
					ELSE 0 
					END),
	-- OSPLAD
	AP_OSPLAD = (CASE WHEN OSPLAD > 2 					  		
					THEN CONVERT(numeric(18,2) ,(convert(numeric(18,2), haberConAporte_sac))/100) * 0.06
					ELSE 0 
					END)

-- CALCULO APORTE PATRONAL PREVISIONAL
UPDATE 
	#aguinaldo
SET 
	-- ANSES
	AP_ANSES = CONVERT(numeric(18,2) ,(convert(numeric(18,2), haberConAporte_sac))/100) * 0.1017


-- CALCULO TOTALIZADORES 
UPDATE 
	#aguinaldo
SET 
	-- ANSES
	AP_ANSES = CONVERT(numeric(18,2) ,(convert(numeric(18,2), haberConAporte_sac))/100) * 0.1017

----------------- FIN CALCULOS -----------------


-- ACTUALIZO 521 (ACTUALMENTE 122) Y 522 (123) SOLO PARA NO REEMPLAZAR EN TODOS LADOS
UPDATE 
	#aguinaldo
SET 
	-- ANSES
	IMP_521 = CONVERT(numeric(18,2) ,(convert(numeric(18,2), haberConAporte_sac))/100) ,
	IMP_522 = CONVERT(numeric(18,2) ,(convert(numeric(18,2), haberSinAporte_sac))/100) 


--select * from #aguinaldo


----------------------->>>>> INICIO GENERACION TXT PARA EL BANCO <<<<<-----------------------
--SELECT  	
--	 RTRIM(LTRIM(CAST(UPPER(
--	 replace((replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(t2.Nombre, 'ñ', 'n'),'/',''),'á','a'),'é','e'),'í','i'),'ó','o'),'ú','u'),'Ñ','N'),'´',''),'''',''),'Á','A'),'É','E'),'Í','I'),'Ó','O'),'Ú','U')) ,',',''))
--	 AS VARCHAR(25)))) -- NOMBRE (25)
--	+REPLICATE(' ', 25-len(RTRIM(
--	(LTRIM(CAST(UPPER(
--	 replace((replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(t2.Nombre, 'ñ', 'n'),'/',''),'á','a'),'é','e'),'í','i'),'ó','o'),'ú','u'),'Ñ','N'),'´',''),'''',''),'Á','A'),'É','E'),'Í','I'),'Ó','O'),'Ú','U')) ,',',''))
--	 AS VARCHAR(25)))) -- relleno
--	))) +
--	+REPLICATE('0', 8-len(ltrim(CAST(SUBSTRING(t1.cuil,3,8) AS VARCHAR(8))))) -- RELLENO DNI
--	+CAST(SUBSTRING(t1.cuil,3,8) AS VARCHAR(8)) -- DNI
--	+REPLICATE('0', 5-len(ltrim(CAST(t2.LugarPago AS VARCHAR(5))))) -- RELLENO LUGAR DE PAGO
--	+ltrim(CAST(t2.LugarPago AS VARCHAR(5))) -- LUGAR DE PAGO
--	+REPLICATE('0', 5-len(ltrim(CAST(t2.Escuela AS VARCHAR(5))))) -- RELLENO ESCUELA
--	+ltrim(CAST(t2.Escuela AS VARCHAR(5))) -- ESCUELA
--	+REPLICATE('0', 8-len(ltrim(CAST(t2.NroCOntrol AS VARCHAR(8))))) -- RELLENO CONTROL
--	+ltrim(CAST(t2.NroCOntrol AS VARCHAR(8))) -- CONTROL
--	+REPLICATE(' ', 6-len(ltrim(CAST(t2.Agru + t2.tramo + t2.Apertura AS VARCHAR(6))))) -- RELLENO CARGO
--	+ltrim(CAST(t2.Agru + t2.tramo + t2.Apertura  AS VARCHAR(6))) -- CARGO
--	+REPLICATE('0', 9- len(ltrim(CAST(replace(cast(t1.IMP_522 as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO TOT. HAB. SIN APORTE
--	+CAST(replace(cast(t1.IMP_522 as decimal(18,2)),'.','') AS VARCHAR(9)) -- TOT. HAB. SIN APORTE
--	+REPLICATE('0', 9- len(ltrim(CAST(replace(cast(t1.IMP_521 as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO TOT. HAB. CON APORTE
--	+CAST(replace(cast(t1.IMP_521 as decimal(18,2)),'.','') AS VARCHAR(9)) -- TOT. HAB. CON APORTE
--	+REPLICATE('0', 9- len(ltrim(CAST(replace(cast(convert(decimal (18,2), t1.IMP_521) + (convert(decimal (18,2),t1.IMP_522)) as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO TOT. HAB.
--	+CAST(replace(cast((convert(decimal (18,2), t1.IMP_521) + (convert(decimal (18,2),t1.IMP_522))) as decimal(18,2)),'.','') AS VARCHAR(9)) -- TOT. HAB. 
--	+REPLICATE('0', 9- len(ltrim(CAST(replace(cast(convert(decimal (18,2), t1.IMP_602) + convert(decimal (18,2), t1.IMP_665_1) + (convert(decimal (18,2),t1.imp_615)) + (convert(decimal (18,2),t1.imp_616)) + (convert(decimal (18,2),t1.imp_663)) + (convert(decimal (18,2),t1.IMP_664)) as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO TOTAL DESCUENTOS
--	+CAST(replace(cast((convert(decimal (18,2), t1.IMP_602) + convert(decimal (18,2), t1.IMP_665_1) + (convert(decimal (18,2),t1.imp_615)) + (convert(decimal (18,2),t1.imp_616)) + (convert(decimal (18,2),t1.imp_663)) + (convert(decimal (18,2),t1.IMP_664))) as decimal(18,2)),'.','') AS VARCHAR(9)) -- TOTAL DESCUENTOS
--	+CAST(t2.PlantaTipo AS VARCHAR(1))  -- PLANTA
--	+'000000000' -- SALARIO	
--	+REPLICATE('0', 9- len(ltrim(CAST(replace(cast(
--		(convert(decimal (18,2), t1.IMP_521) + (convert(decimal (18,2),t1.IMP_522))) -- total hab.
--		- (convert(decimal (18,2), t1.IMP_602) + convert(decimal (18,2), t1.IMP_665_1) + convert(decimal (18,2), t1.IMP_615) + convert(decimal (18,2), t1.IMP_616) + convert(decimal (18,2), t1.IMP_663) + convert(decimal (18,2), t1.IMP_664)) -- tot desc.
--		as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO TOT LIQ.
--	+CAST(replace(cast((
--		(convert(decimal (18,2), t1.IMP_521) + (convert(decimal (18,2),t1.IMP_522))) -- total hab.
--		- (convert(decimal (18,2), t1.IMP_602) + convert(decimal (18,2), t1.IMP_665_1) + convert(decimal (18,2), t1.IMP_615) + convert(decimal (18,2), t1.IMP_616) + convert(decimal (18,2), t1.IMP_663) + convert(decimal (18,2), t1.IMP_664)) -- tot desc.
--		) as decimal(18,2)),'.','') AS VARCHAR(9)) -- TOTAL LIQ.
--	+REPLICATE('0', 6-len(ltrim(CAST(t2.FechaIngreso AS VARCHAR(6))))) -- RELLENO FECHA INGRESO
--	+CAST(t2.FechaIngreso AS VARCHAR(6)) -- FECHA INGRESO
--	+REPLICATE('0', 11-len(ltrim(CAST(t1.cuil AS VARCHAR(11))))) -- RELLENO CUIL
--	+CAST(t1.cuil AS VARCHAR(11)) -- CUIL
--	+CAST(t2.Sexo AS VARCHAR(1)) -- SEXO
--	--+ '000000000' -- PORCENTAJE DE IMP DESCUENTO - 
--AS Columna 
--FROM  
--	#aguinaldo t1
--	INNER JOIN PruebasAge t2	
--	ON t1.ageId = t2.NuevoAgeId1

------------------  FIN GENERACION TXT PARA EL BANCO----------------

select IMP_664, I07, NroCOntrol from #aguinaldo
where IMP_664 != I07

select * from #aguinaldo
where NroCOntrol = '38760553'

where I07 > 0


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
		  AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9)) -- RELLENO + TOTAL DESCUENTOS	
	+ CAST(t2.PlantaTipo AS VARCHAR(1))  -- PLANTA
	+ '000000000' -- SALARIO	
	+ CAST (dbo.RellenarTextoIzquierda(replace(cast(
			  (convert(decimal (18,2), t1.IMP_521) + (convert(decimal (18,2),t1.IMP_522))) -- total hab.
			- (
					convert(decimal (18,2), t1.IMP_602) 					
					+ convert(decimal (18,2), t1.IMP_615) 
					+ convert(decimal (18,2), t1.IMP_616) 
					+ convert(decimal (18,2), t1.IMP_663) 
					+ convert(decimal (18,2), t1.IMP_664)
					+ convert(decimal (18,2), t1.IMP_665_1) 
				) -- tot desc. 
			AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9)) -- RELLENO + TOT LIQ.			
	+ CAST (dbo.RellenarTextoIzquierda(t2.FechaIngreso,'0',6) AS VARCHAR(6)) -- RELLENO + FECHA INGRESO			
	+ CAST (dbo.RellenarTextoIzquierda(t1.cuil ,'0',11) AS VARCHAR(11)) -- RELLENO + CUIL	
	+ CAST(t2.Sexo AS VARCHAR(1)) -- SEXO
	--+ '000000000' -- PORCENTAJE DE IMP DESCUENTO - 
AS Columna 
FROM  
	#aguinaldo t1
	INNER JOIN PruebasAge t2	
	ON t1.ageId = t2.NuevoAgeId1
----------------  FIN GENERACION TXT PARA EL BANCO V2 ----------------

select * from #aguinaldo
where cuil  ='27319625327'

select * from PruebasAge
where FechaLiquidacion >= '01/01/2023'
and Fechliquida



SELECT * from LiquidacionExtensionDocente


select * from #pre_aguinaldo
where cuil = '27319625327'

select * from 

select * from 

select * from PruebasAge
where MesAnioLiq = '01/23'
and Cuil = '27319625327'


-- 2 REGISTROS
select I01, I02, dias_trabajados from #pre_aguinaldo
where mes = '01'
and Cuil = '27319625327'
and NroCOntrol = '38001802'


-- REGISTROS
select I01, I02, dias_trabajados from #aguinaldo
where  NroCOntrol = '38963371'



select  total_haberes, mes, anio, ageId from #pre_aguinaldo
where NroCOntrol = '38963371'
order by total_haberes desc

select * from #aguinaldo
where NroCOntrol = '38963371'


 mes = '01'
and Cuil = '27319625327'
and NroCOntrol = '38963371'




-- 1 REGISTRO
select I01, I02, dias_trabajados from #pre_aguinaldo
where NroCOntrol = '38274484'


select * from agentes_extension_docente_historico
where cuil = '27211599273'

select






select * from #aguinaldo
where NroCOntrol = '38274484'






where NroCOntrol = '38001802'




----------------------->>>>> INICIO UPDATE TIPO PLANTA <<<<<-----------------------

--SELECT * FROM #agentes_filtrados

UPDATE #aguinaldo 
SET tipoPlanta =  (CASE 
			
		WHEN (t2.LugarPago IN (27101, 28104, 28514, 29107) 
			OR (t2.LugarPago>=38153 AND t2.LugarPago<=38265) 
			OR t2.LugarPago IN (39102, 57107, 58103, 59106, 62101)) 
			--THEN 'DOCENT.TITULAR' -- TITUL88
			THEN 'PP' -- TITUL88
		
		WHEN t2.LugarPago IN (27116, 28112, 28522, 29115) 
			OR t2.LugarPago>=38281 AND t2.LugarPago<=38393 
			OR t2.LugarPago IN (39117, 57115, 58111, 59114, 62116) 
			--THEN 'DOCENT.INTERINO' -- INTER88
			THEN 'PP' -- INTER88
		
		WHEN t2.LugarPago IN (27124, 28127, 28537, 29123) 
			OR t2.LugarPago>=38524 AND t2.LugarPago<=38636 
			OR t2.LugarPago IN (39125, 57123, 58126, 59122, 62124) 
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
	#aguinaldo t1
	inner join PruebasAge t2	
	on t1.ageId = t2.NuevoAgeId1

----------------------->>>>> FIN - UPDATE TIPO PLANTA <<<<<-----------------------

SELECT * from #aguinaldo
where i0


----------------------->>>>> INICIO - ORDEN DE PAGO <<<<<-----------------------
SELECT 
	-- LIQUIDO
	SUM(
		(t1.IMP_521 + t1.IMP_522) 
			- ( t1.IMP_602 
				+ t1.IMP_615 + t1.IMP_616
				 + t1.IMP_663 
				 +ISNULL(t1.IMP_664,0)
				 + t1.IMP_665_1 
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
	#aguinaldo t1
	INNER JOIN PruebasAge t2	
	ON t1.ageId = t2.NuevoAgeId1
WHERE 
	t1.tipoPlanta = 'PC'
	--t1.tipoPlanta = 'PP'

----------------------->>>>> FIN - ORDEN DE PAGO <<<<<-----------------------

delete from agentes_extension_docente

select * from agentes_extension_docente_historico
where mes = 06
and anio = 23

select * from agentes_extension_docente
select * from agentes_extension_docente_historico
where mes = 06
and anio = 23


delete from agentes_extension_docente

SELECT * from agentes_extension_docente
where NroCOntrol = '38760553'

INSERT INTO 
	agentes_extension_docente 
	(age_id,NroCOntrol, PlantaTipo,tipo_planta_OP , agrupamiento, tramo, apertura, cuil, LugarPago, Escuela, Juris, Prog, SubP, Actividad, fuente,dias_trabajados, haberSinAporte, haberConAporte, total_haberes,
	total_descuentos, total_liquido, AP_IOSEP, AP_OSPLAD, AP_ANSES,
	C01, I01, C02, I02, C03, I03, C04, I04, C05, I05, C06, I06, C07, I07, C08, I08)

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
		- (
				convert(decimal (18,2), t1.IMP_602) 				
				+ convert(decimal (18,2), t1.IMP_615) 
				+ convert(decimal (18,2), t1.IMP_616) 
				+ convert(decimal (18,2), t1.IMP_663) 
				+ convert(decimal (18,2), t1.IMP_664)
				+ convert(decimal (18,2), t1.IMP_665_1) 
			) -- tot desc.
		as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO TOT LIQ.
	+CAST(replace(cast((
		(convert(decimal (18,2), t1.IMP_521) + (convert(decimal (18,2),t1.IMP_522))) -- total hab.
		- (
			convert(decimal (18,2), t1.IMP_602) 				
			+ convert(decimal (18,2), t1.IMP_615) 
			+ convert(decimal (18,2), t1.IMP_616) 
			+ convert(decimal (18,2), t1.IMP_663) 
			+ convert(decimal (18,2), t1.IMP_664)
			+ convert(decimal (18,2), t1.IMP_665_1) 
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
	IMP_665_1
	--- CODIGOS NUEVOS DIFERENCIA
FROM  
	#aguinaldo t1
	INNER JOIN PruebasAge t2	
	ON t1.ageId = t2.NuevoAgeId1
----------------------->>>>> FIN - INSERTA EN AGENTE_EXT_DOC <<<<<-----------------------


select total_liquido from agentes_extension_docente

exec [ExtensionDocente.Eliminar_En_Historico] '13','23', 27

select * from agentes_extension_docente_historico
where NroCOntrol = '38963371'
and liq_id in (
7,
9,
11,
15,
17,
18,
23,
26
)


select IMP_521, IMP_522, dias_trabajados, * from #aguinaldo
where NroCOntrol = '38001802'

se

-- FORMULAS
haberConAporte_sac = ((haberConAporte * dias_trabajados) / 180) / 2,
haberSinAporte_sac  = ((haberSinAporte * dias_trabajados) / 180) / 2

select I01, I02 from #pre_aguinaldo
where id = 5074


EXEC [ExtensionDocente.Archivo_Ministerio]

SELECT * FROM agentes_extension_docente_historico
602, 615, 616, 663, 664, 665

	SELECT * from LiquidacionExtensionDocente t2
	WHERE 
	--t1.liq_id = t2.id AND 
	t2.definitiva = 1
	AND ((CONVERT(int,t2.mes_referencia) = 12 AND (CONVERT(int,t2.anio_referencia) = 22))
	OR (CONVERT(int,t2.mes_referencia) < 6) AND (CONVERT(int,t2.anio_referencia) = 23))
	)


	exec [ExtensionDocente.Archivo_Ministerio]

	select * from LiquidacionExtensionDocente
	exec [ExtensionDocente.Guardar_En_Historico] '13','23', 27, 0, 0 -- FEBRERO DEFINITVA 

	select SUM(CONVERT(NUMERIC (18,2), total_liquido)) 
	SELECT total_liquido
	from agentes_extension_docente_historico
	where liq_id = 27

	select * from LiquidacionExtensionDocente

	select * from agentes_extension_docente