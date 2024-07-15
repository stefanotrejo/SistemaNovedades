-- SCRIPT PARA UNIFICAR LIQUIDACION ORIGINAL Y COMPLEMENTARIA MAYO 24 

delete from [agentes_extension_docente_mayo24_unificado]


INSERT INTO [dbo].[agentes_extension_docente_mayo24_unificado]
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
	liq_id =  54 -- 6483


SELECT * from LiquidacionExtensionDocente

rollback tran t1


begin tran t1

UPDATE 
	[agentes_extension_docente_mayo24_unificado]
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
	[agentes_extension_docente_mayo24_unificado] t1
	inner join agentes_extension_docente_historico t2
	on t1.NroCOntrol = t2.NroCOntrol
	WHERE 
	t2.liq_id =  53




begin tran t1
rollback tran t1

select * from [agentes_extension_docente_mayo24_unificado]
 where NroCOntrol = 38222893



UPDATE
	[agentes_extension_docente_mayo24_unificado]
SET
	haberSinAporte = convert(numeric(18,2), haberSinAporte)/100,
	haberConAporte = convert(numeric(18,2), haberConAporte)/100,
	total_haberes = convert(numeric(18,2), total_haberes)/100,
	total_descuentos = convert(numeric(18,2), total_descuentos)/100,
	total_liquido = convert(numeric(18,2), total_liquido)/100



UPDATE
	[agentes_extension_docente_mayo24_unificado]
SET
	haberSinAporte = dbo.RellenarTextoIzquierda(replace(cast(haberSinAporte AS decimal(18,2)),'.',''),'0',9),
	haberConAporte = dbo.RellenarTextoIzquierda(replace(cast(haberConAporte AS decimal(18,2)),'.',''),'0',9),
	total_haberes = dbo.RellenarTextoIzquierda(replace(cast(total_haberes AS decimal(18,2)),'.',''),'0',9),
	total_descuentos = dbo.RellenarTextoIzquierda(replace(cast(total_descuentos AS decimal(18,2)),'.',''),'0',9),
	total_liquido = dbo.RellenarTextoIzquierda(replace(cast(total_liquido AS decimal(18,2)),'.',''),'0',9)






	select top 5 * from agentes_extension_docente_mayo24_unificado	
	where NroCOntrol = 38222893

	2335773800
	23357738.00


select * from agentes_extension_docente_historico
where liq_id = 53
and NroCOntrol = 38222893

select * from agentes_extension_docente_historico
where liq_id = 54
and NroCOntrol = 38222893




select top 5 * from agentes_extension_docente_historico 
where liq_id = 53
and NroCOntrol = '38002735'

select * from agentes_extension_docente_historico
where liq_id = 54
and NroCOntrol = '38002735'


select * from agentes_extension_docente_mayo24_unificado
where liq_id = 54
and NroCOntrol = '38002735'
	