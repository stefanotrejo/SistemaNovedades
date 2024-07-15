

INSERT INTO [dbo].[agentes_extension_docente_febrero24_unificado_filtrado]
           ([age_id]
           ,[NroCOntrol]
           ,[PlantaTipo]
           ,[tipo_planta_OP]
           ,[agrupamiento]
           ,[tramo]
           ,[apertura]
           ,[cuil]
           ,[LugarPago]
           ,[Escuela]
           ,[Juris]
           ,[Prog]
           ,[SubP]
           ,[Actividad]
           ,[fuente]
           ,[dias_trabajados]
           ,[haberSinAporte]
           ,[haberConAporte]
           ,[total_haberes]
           ,[total_descuentos]
           ,[total_liquido]
           ,[AP_IOSEP]
           ,[AP_OSPLAD]
           ,[AP_ANSES]
           ,[C01]
           ,[I01]
           ,[C02]
           ,[I02]
           ,[C03]
           ,[I03]
           ,[C04]
           ,[I04]
           ,[C05]
           ,[I05]
           ,[C06]
           ,[I06]
           ,[C07]
           ,[I07]
           ,[C08]
           ,[I08]
           ,[C09]
           ,[I09]
           ,[C10]
           ,[I10]
           ,[mes]
           ,[anio]
           ,[liq_id]
           ,[fecha_creacion])

SELECT
	[age_id]
           ,[NroCOntrol]
           ,[PlantaTipo]
           ,[tipo_planta_OP]
           ,[agrupamiento]
           ,[tramo]
           ,[apertura]
           ,[cuil]
           ,[LugarPago]
           ,[Escuela]
           ,[Juris]
           ,[Prog]
           ,[SubP]
           ,[Actividad]
           ,[fuente]
           ,[dias_trabajados]
           ,[haberSinAporte]
           ,[haberConAporte]
           ,[total_haberes]
           ,[total_descuentos]
           ,[total_liquido]
           ,[AP_IOSEP]
           ,[AP_OSPLAD]
           ,[AP_ANSES]
           ,[C01]
           ,[I01]
           ,[C02]
           ,[I02]
           ,[C03]
           ,[I03]
           ,[C04]
           ,[I04]
           ,[C05]
           ,[I05]
           ,[C06]
           ,[I06]
           ,[C07]
           ,[I07]
           ,[C08]
           ,[I08]
           ,[C09]
           ,[I09]
           ,[C10]
           ,[I10]
           ,[mes]
           ,[anio]
           ,[liq_id]
           ,[fecha_creacion]
FROM
	agentes_extension_docente_historico
WHERE 
	liq_id =  50 -- 6584





UPDATE 
	[agentes_extension_docente_febrero24_unificado_filtrado]
SET
	haberSinAporte = t1.haberSinAporte + t2.haberSinAporte,
	haberConAporte = t1.haberConAporte + t2.haberConAporte,
	total_haberes = t1.total_haberes + t2.total_haberes,
	total_descuentos = t1.total_descuentos + t2.total_descuentos,
	total_liquido = t1.total_liquido + t2.total_liquido,
	AP_IOSEP = t1.AP_IOSEP + t2.AP_IOSEP,
	AP_OSPLAD = t1.AP_OSPLAD + t2.AP_OSPLAD,
	AP_ANSES = t1.AP_ANSES + t2.AP_ANSES,
	I01 = t1.I01 + t2.I01,
	I02 = t1.I02 + t2.I02,
	I03 = t1.I03 + t2.I03,
	I04 = t1.I04 + t2.I04,
	I05 = t1.I05 + t2.I05,
	I06 = t1.I06 + t2.I06,
	I07 = t1.I07 + t2.I07,
	I08 = t1.I08 + t2.I08,
	I09 = t1.I09 + t2.I09,
	I10 = t1.I10 + t2.I10
FROM 
	[agentes_extension_docente_febrero24_unificado_filtrado] t1
	inner join agentes_extension_docente_historico t2
	on t1.NroCOntrol = t2.NroCOntrol
	WHERE 
	t2.liq_id =  45



begin tran t1
rollback tran t1


UPDATE 
	[agentes_extension_docente_febrero24_unificado_filtrado]
SET
	haberSinAporte = CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t1.haberSinAporte AS decimal(18,2)),'.',''))/100) + 
		CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t2.haberSinAporte AS decimal(18,2)),'.',''))/100),
	haberConAporte = CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t1.haberConAporte AS decimal(18,2)),'.',''))/100) + 
		CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t2.haberConAporte AS decimal(18,2)),'.',''))/100),
	total_haberes = CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t1.total_haberes AS decimal(18,2)),'.',''))/100) + 
		CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t2.total_haberes AS decimal(18,2)),'.',''))/100),
	total_descuentos = CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t1.total_descuentos AS decimal(18,2)),'.',''))/100) + 
		CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t2.total_descuentos AS decimal(18,2)),'.',''))/100),
	total_liquido = CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t1.total_liquido AS decimal(18,2)),'.',''))/100) + 
		CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t2.total_liquido AS decimal(18,2)),'.',''))/100),
	AP_IOSEP = t1.AP_IOSEP + t2.AP_IOSEP,
	AP_OSPLAD = t1.AP_OSPLAD + t2.AP_OSPLAD,
	AP_ANSES = t1.AP_ANSES + t2.AP_ANSES,
	I01 = CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t1.I01 AS decimal(18,2)),'.',''))/100) + 
		CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t2.I01 AS decimal(18,2)),'.',''))/100),
	I02 = CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t1.I02 AS decimal(18,2)),'.',''))/100) + 
		CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t2.I02 AS decimal(18,2)),'.',''))/100),
	I03 = CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t1.I03 AS decimal(18,2)),'.',''))/100) + 
		CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t2.I03 AS decimal(18,2)),'.',''))/100),
	I04 = CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t1.I04 AS decimal(18,2)),'.',''))/100) + 
		CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t2.I04 AS decimal(18,2)),'.',''))/100),
	I05 = CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t1.I05 AS decimal(18,2)),'.',''))/100) + 
		CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t2.I05 AS decimal(18,2)),'.',''))/100),
	I06 = CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t1.I06 AS decimal(18,2)),'.',''))/100) + 
		CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t2.I06 AS decimal(18,2)),'.',''))/100),
	I07 = CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t1.I07 AS decimal(18,2)),'.',''))/100) + 
		CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t2.I07 AS decimal(18,2)),'.',''))/100),
	I08 = CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t1.I08 AS decimal(18,2)),'.',''))/100) + 
		CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t2.I08 AS decimal(18,2)),'.',''))/100),
	I09 = CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t1.I09 AS decimal(18,2)),'.',''))/100) + 
		CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t2.I09 AS decimal(18,2)),'.',''))/100),
	I10 = CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t1.I10 AS decimal(18,2)),'.',''))/100) + 
		CONVERT(numeric (18,2), convert(numeric (18), replace(cast(t2.I10 AS decimal(18,2)),'.',''))/100)
FROM 
	[agentes_extension_docente_febrero24_unificado_filtrado] t1
	inner join agentes_extension_docente_historico t2
	on t1.NroCOntrol = t2.NroCOntrol
	WHERE 
	t2.liq_id =  45


UPDATE
	agentes_extension_docente_febrero24_unificado_filtrado
SET
	haberSinAporte = dbo.RellenarTextoIzquierda(replace(cast(haberSinAporte AS decimal(18,2)),'.','')/100,'0',9),
	haberConAporte = dbo.RellenarTextoIzquierda(replace(cast(haberConAporte AS decimal(18,2)),'.','')/100,'0',9),
	total_haberes = dbo.RellenarTextoIzquierda(replace(cast(total_haberes AS decimal(18,2)),'.','')/100,'0',9),
	total_descuentos = dbo.RellenarTextoIzquierda(replace(cast(total_descuentos AS decimal(18,2)),'.','')/100,'0',9),
	total_liquido = dbo.RellenarTextoIzquierda(replace(cast(total_liquido AS decimal(18,2)),'.','')/100,'0',9)
	


BEGIN TRAN T1

-- ULTIMO
INSERT INTO [dbo].[agentes_extension_docente_febrero24_unificado_filtrado]
           ([age_id]
           ,[NroCOntrol]
           ,[PlantaTipo]
           ,[tipo_planta_OP]
           ,[agrupamiento]
           ,[tramo]
           ,[apertura]
           ,[cuil]
           ,[LugarPago]
           ,[Escuela]
           ,[Juris]
           ,[Prog]
           ,[SubP]
           ,[Actividad]
           ,[fuente]
           ,[dias_trabajados]
           ,[haberSinAporte]
           ,[haberConAporte]
           ,[total_haberes]
           ,[total_descuentos]
           ,[total_liquido]
           ,[AP_IOSEP]
           ,[AP_OSPLAD]
           ,[AP_ANSES]
           ,[C01]
           ,[I01]
           ,[C02]
           ,[I02]
           ,[C03]
           ,[I03]
           ,[C04]
           ,[I04]
           ,[C05]
           ,[I05]
           ,[C06]
           ,[I06]
           ,[C07]
           ,[I07]
           ,[C08]
           ,[I08]
           ,[C09]
           ,[I09]
           ,[C10]
           ,[I10]
           ,[mes]
           ,[anio]
           ,[liq_id]
           ,[fecha_creacion])

SELECT
	[age_id]
           ,[NroCOntrol]
           ,[PlantaTipo]
           ,[tipo_planta_OP]
           ,[agrupamiento]
           ,[tramo]
           ,[apertura]
           ,[cuil]
           ,[LugarPago]
           ,[Escuela]
           ,[Juris]
           ,[Prog]
           ,[SubP]
           ,[Actividad]
           ,[fuente]
           ,[dias_trabajados]
           ,[haberSinAporte]
           ,[haberConAporte]
           ,[total_haberes]
           ,[total_descuentos]
           ,[total_liquido]
           ,[AP_IOSEP]
           ,[AP_OSPLAD]
           ,[AP_ANSES]
           ,[C01]
           ,[I01]
           ,[C02]
           ,[I02]
           ,[C03]
           ,[I03]
           ,[C04]
           ,[I04]
           ,[C05]
           ,[I05]
           ,[C06]
           ,[I06]
           ,[C07]
           ,[I07]
           ,[C08]
           ,[I08]
           ,[C09]
           ,[I09]
           ,[C10]
           ,[I10]
           ,[mes]
           ,[anio]
           ,[liq_id]
           ,[fecha_creacion]
FROM
	agentes_extension_docente_historico
WHERE 
	liq_id =  45
	and NroCOntrol in (
	'38993431',
	'56006454',
	'38500461',
	'38565563',
	'38867193',
	'38887541',
	'38888495',
	'38890701',
	'38893393'	
	)