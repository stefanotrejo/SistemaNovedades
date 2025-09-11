-- SCRIPT PARA UNIFICAR LIQUIDACION ORIGINAL Y COMPLEMENTARIA MARZO 25

DELETE FROM [agentes_extension_docente_marzo25_unificado];

select * from [agentes_extension_docente_marzo25_unificado]

-- Insertar base: liq_id = 112
INSERT INTO [dbo].[agentes_extension_docente_marzo25_unificado]
           ([age_id], [NroCOntrol], [PlantaTipo], [tipo_planta_OP], [agrupamiento], [tramo],
            [apertura], [cuil], [LugarPago], [Escuela], [Juris], [Prog], [SubP],
            [Actividad], [fuente], [dias_trabajados], [haberSinAporte], [haberConAporte],
            [total_haberes], [total_descuentos], [total_liquido], [AP_IOSEP], [AP_OSPLAD], [AP_ANSES],
            [C01], [I01], [C02], [I02], [C03], [I03], [C04], [I04], [C05], [I05],
            [C06], [I06], [C07], [I07], [C08], [I08], [C09], [I09], [C10], [I10],
            [mes], [anio], [liq_id], [fecha_creacion])
SELECT [age_id], [NroCOntrol], [PlantaTipo], [tipo_planta_OP], [agrupamiento], [tramo],
       [apertura], [cuil], [LugarPago], [Escuela], [Juris], [Prog], [SubP],
       [Actividad], [fuente], [dias_trabajados], [haberSinAporte], [haberConAporte],
       [total_haberes], [total_descuentos], [total_liquido], [AP_IOSEP], [AP_OSPLAD], [AP_ANSES],
       [C01], [I01], [C02], [I02], [C03], [I03], [C04], [I04], [C05], [I05],
       [C06], [I06], [C07], [I07], [C08], [I08], [C09], [I09], [C10], [I10],
       [mes], [anio], [liq_id], [fecha_creacion]
FROM agentes_extension_docente_historico
WHERE liq_id = 112;



SELECT * FROM agentes_extension_docente_historico WHERE liq_id IN (112,108) AND NroCOntrol = 38002743;
select * from agentes_extension_docente_marzo25_unificado where NroCOntrol = 38002743

BEGIN TRAN t1;

rollback tran t1

------ INICIO SUMA LIQUIDACIÓN 108 ----- 
UPDATE t1
SET
	haberSinAporte = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.haberSinAporte AS decimal(18,2)),'.',''))/100) +
	                  CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.haberSinAporte AS decimal(18,2)),'.',''))/100),
	haberConAporte = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.haberConAporte AS decimal(18,2)),'.',''))/100) +
	                  CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.haberConAporte AS decimal(18,2)),'.',''))/100),
	total_haberes = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.total_haberes AS decimal(18,2)),'.',''))/100) +
	                 CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.total_haberes AS decimal(18,2)),'.',''))/100),
	total_descuentos = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.total_descuentos AS decimal(18,2)),'.',''))/100) +
	                    CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.total_descuentos AS decimal(18,2)),'.',''))/100),
	total_liquido = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.total_liquido AS decimal(18,2)),'.',''))/100) +
	                 CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.total_liquido AS decimal(18,2)),'.',''))/100),
	AP_IOSEP = t1.AP_IOSEP + t2.AP_IOSEP,
	AP_OSPLAD = t1.AP_OSPLAD + t2.AP_OSPLAD,
	AP_ANSES = t1.AP_ANSES + t2.AP_ANSES,
	I01 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I01 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I01 AS decimal(18,2)),'.',''))/100),
	I02 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I02 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I02 AS decimal(18,2)),'.',''))/100),
	I03 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I03 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I03 AS decimal(18,2)),'.',''))/100),
	I04 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I04 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I04 AS decimal(18,2)),'.',''))/100),
	I05 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I05 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I05 AS decimal(18,2)),'.',''))/100),
	I06 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I06 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I06 AS decimal(18,2)),'.',''))/100),
	I07 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I07 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I07 AS decimal(18,2)),'.',''))/100),
	I08 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I08 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I08 AS decimal(18,2)),'.',''))/100),
	I09 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I09 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I09 AS decimal(18,2)),'.',''))/100),
	I10 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I10 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I10 AS decimal(18,2)),'.',''))/100)
FROM agentes_extension_docente_marzo25_unificado t1
INNER JOIN agentes_extension_docente_historico t2 ON t1.NroCOntrol = t2.NroCOntrol
WHERE t2.liq_id = 108;


--SELECT * FROM agentes_extension_docente_historico WHERE liq_id IN (108, 112) AND NroCOntrol = 38002743;
--select * from agentes_extension_docente_marzo25_unificado where NroCOntrol = 38002743

-- NORMALIZACIÓN
UPDATE agentes_extension_docente_marzo25_unificado
SET
	haberSinAporte   = CONVERT(numeric(18,2), haberSinAporte)/100,
	haberConAporte   = CONVERT(numeric(18,2), haberConAporte)/100,
	total_haberes    = CONVERT(numeric(18,2), total_haberes)/100,
	total_descuentos = CONVERT(numeric(18,2), total_descuentos)/100,
	total_liquido    = CONVERT(numeric(18,2), total_liquido)/100;


UPDATE agentes_extension_docente_marzo25_unificado
SET
	haberSinAporte   = dbo.RellenarTextoIzquierda(REPLACE(CONVERT(varchar(20), CONVERT(decimal(18,2), haberSinAporte)), '.', ''), '0', 9),
	haberConAporte   = dbo.RellenarTextoIzquierda(REPLACE(CONVERT(varchar(20), CONVERT(decimal(18,2), haberConAporte)), '.', ''), '0', 9),
	total_haberes    = dbo.RellenarTextoIzquierda(REPLACE(CONVERT(varchar(20), CONVERT(decimal(18,2), total_haberes)), '.', ''), '0', 9),
	total_descuentos = dbo.RellenarTextoIzquierda(REPLACE(CONVERT(varchar(20), CONVERT(decimal(18,2), total_descuentos)), '.', ''), '0', 9),
	total_liquido    = dbo.RellenarTextoIzquierda(REPLACE(CONVERT(varchar(20), CONVERT(decimal(18,2), total_liquido)), '.', ''), '0', 9);


SELECT * FROM agentes_extension_docente_historico WHERE liq_id IN (108,111,112) AND NroCOntrol = 38002743;
SELECT * FROM agentes_extension_docente_marzo25_unificado WHERE NroCOntrol = 38002743;

rollback tran t1

COMMIT TRAN t1;

------ FIN SUMA LIQUIDACIÓN 108 -----



------ INICIO SUMA LIQUIDACIÓN 111 ----- 
begin tran t1

UPDATE t1
SET
	haberSinAporte = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.haberSinAporte AS decimal(18,2)),'.',''))/100) +
	                  CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.haberSinAporte AS decimal(18,2)),'.',''))/100),
	haberConAporte = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.haberConAporte AS decimal(18,2)),'.',''))/100) +
	                  CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.haberConAporte AS decimal(18,2)),'.',''))/100),
	total_haberes = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.total_haberes AS decimal(18,2)),'.',''))/100) +
	                 CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.total_haberes AS decimal(18,2)),'.',''))/100),
	total_descuentos = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.total_descuentos AS decimal(18,2)),'.',''))/100) +
	                    CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.total_descuentos AS decimal(18,2)),'.',''))/100),
	total_liquido = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.total_liquido AS decimal(18,2)),'.',''))/100) +
	                 CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.total_liquido AS decimal(18,2)),'.',''))/100),
	AP_IOSEP = t1.AP_IOSEP + t2.AP_IOSEP,
	AP_OSPLAD = t1.AP_OSPLAD + t2.AP_OSPLAD,
	AP_ANSES = t1.AP_ANSES + t2.AP_ANSES,
	I01 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I01 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I01 AS decimal(18,2)),'.',''))/100),
	I02 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I02 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I02 AS decimal(18,2)),'.',''))/100),
	I03 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I03 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I03 AS decimal(18,2)),'.',''))/100),
	I04 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I04 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I04 AS decimal(18,2)),'.',''))/100),
	I05 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I05 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I05 AS decimal(18,2)),'.',''))/100),
	I06 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I06 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I06 AS decimal(18,2)),'.',''))/100),
	I07 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I07 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I07 AS decimal(18,2)),'.',''))/100),
	I08 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I08 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I08 AS decimal(18,2)),'.',''))/100),
	I09 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I09 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I09 AS decimal(18,2)),'.',''))/100),
	I10 = CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t1.I10 AS decimal(18,2)),'.',''))/100) +
	      CONVERT(numeric(18,2), CONVERT(numeric(18), REPLACE(CAST(t2.I10 AS decimal(18,2)),'.',''))/100)
FROM agentes_extension_docente_marzo25_unificado t1
INNER JOIN agentes_extension_docente_historico t2 ON t1.NroCOntrol = t2.NroCOntrol
WHERE t2.liq_id = 111;


--SELECT * FROM agentes_extension_docente_historico WHERE liq_id IN (108, 112) AND NroCOntrol = 38002743;
--select * from agentes_extension_docente_marzo25_unificado where NroCOntrol = 38002743

-- NORMALIZACIÓN
UPDATE agentes_extension_docente_marzo25_unificado
SET
	haberSinAporte   = CONVERT(numeric(18,2), haberSinAporte)/100,
	haberConAporte   = CONVERT(numeric(18,2), haberConAporte)/100,
	total_haberes    = CONVERT(numeric(18,2), total_haberes)/100,
	total_descuentos = CONVERT(numeric(18,2), total_descuentos)/100,
	total_liquido    = CONVERT(numeric(18,2), total_liquido)/100;


UPDATE agentes_extension_docente_marzo25_unificado
SET
	haberSinAporte   = dbo.RellenarTextoIzquierda(REPLACE(CONVERT(varchar(20), CONVERT(decimal(18,2), haberSinAporte)), '.', ''), '0', 9),
	haberConAporte   = dbo.RellenarTextoIzquierda(REPLACE(CONVERT(varchar(20), CONVERT(decimal(18,2), haberConAporte)), '.', ''), '0', 9),
	total_haberes    = dbo.RellenarTextoIzquierda(REPLACE(CONVERT(varchar(20), CONVERT(decimal(18,2), total_haberes)), '.', ''), '0', 9),
	total_descuentos = dbo.RellenarTextoIzquierda(REPLACE(CONVERT(varchar(20), CONVERT(decimal(18,2), total_descuentos)), '.', ''), '0', 9),
	total_liquido    = dbo.RellenarTextoIzquierda(REPLACE(CONVERT(varchar(20), CONVERT(decimal(18,2), total_liquido)), '.', ''), '0', 9);


SELECT * FROM agentes_extension_docente_historico WHERE liq_id IN (108,111,112) AND NroCOntrol = 38002743;
SELECT * FROM agentes_extension_docente_marzo25_unificado WHERE NroCOntrol = 38002743;

rollback tran t1

COMMIT TRAN t1;

------ FIN SUMA LIQUIDACIÓN 111 -----