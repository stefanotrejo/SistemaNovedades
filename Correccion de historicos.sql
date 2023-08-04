

select * from LiquidacionExtensionDocente



select * from agentes_extension_docente_historico t1
left join agentes_extdoc_diferencia_0922 t2
on t1.NroCOntrol = t2.NroCOntrol
where 
	t1.liq_id = 23
and t2.monto_destino_norem_descontado > 0 


select * from agentes_extdoc_diferencia_0922 t1
inner join agentes_extension_docente_historico t2
on t1.NroCOntrol = t2.NroCOntrol
where CONVERT(numeric(18,2), monto_destino_norem_descontado) > 0  
and t2.liq_id = 23



UPDATE
    agentes_extension_docente_historico 
SET
    agentes_extension_docente_historico.total_descuentos = CAST (dbo.RellenarTextoIzquierda(replace(cast(convert (numeric (18,2), (convert(numeric, agentes_extension_docente_historico.total_descuentos) / 100)) + t1.monto_destino_norem_descontado AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9))
	-- agentes_extension_docente_historico.total_descuentos  = convert (numeric (18,2), (convert(numeric, agentes_extension_docente_historico.total_descuentos) / 100)) + t1.monto_destino_norem_descontado  -- bien

	--total_descuentos =  CAST (dbo.RellenarTextoIzquierda( REPLACE(SUBSTRING(cast(convert(numeric (18,2), t2.total_descuentos)/100 as varchar),0,8), '.', '') ,'0',9) AS VARCHAR(9))
from agentes_extdoc_diferencia_0922 t1
--inner join agentes_extension_docente_historico_copia t2
--on t1.NroCOntrol = t2.NroCOntrol
where CONVERT(numeric(18,2), t1.monto_destino_norem_descontado) > 0  
and agentes_extension_docente_historico.liq_id = 23
and agentes_extension_docente_historico.NroCOntrol = t1.NroCOntrol


select * 

from agentes_extdoc_diferencia_0922 t1
inner join agentes_extension_docente_historico_copia t2
on t1.NroCOntrol = t2.NroCOntrol
where CONVERT(numeric(18,2), t1.monto_destino_norem_descontado) > 0  
and t2.liq_id = 23




select 

	t2.total_descuentos + t1.monto_destino_norem_descontado,
	t2.total_descuentos ,
	t1.monto_destino_norem_descontado,
	t2.total_descuentos ,
	convert (numeric (18,2), (convert(numeric, t2.total_descuentos) / 100)) ,
	t1.monto_destino_norem_descontado,
	 
	 convert (numeric (18,2), (convert(numeric, t2.total_descuentos) / 100)) + t1.monto_destino_norem_descontado,  -- bien
	 convert (numeric (18,2), (convert(numeric, t2.total_descuentos) / 100)) + convert(numeric, t1.monto_destino_norem_descontado) as dos,  -- bien

	CAST (dbo.RellenarTextoIzquierda(replace(cast(convert (numeric (18,2), (convert(numeric, t2.total_descuentos) / 100)) + t1.monto_destino_norem_descontado AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9))

	--t2.total_descuentos
	--cast((CONVERT(numeric (18,2),t2.total_descuentos) + CONVERT(numeric (18,2), t1.monto_destino_norem_descontado))  AS VARCHAR(9)) ,
	--CONVERT(numeric (18,2),t2.total_descuentos),
	--CONVERT(numeric (18,2), t1.monto_destino_norem_descontado),
	--replace(cast((CONVERT(numeric (18,2),t2.total_descuentos) + CONVERT(numeric (18,2), t1.monto_destino_norem_descontado))  AS VARCHAR(9)),'.','') 
from agentes_extdoc_diferencia_0922 t1
inner join agentes_extension_docente_historico t2
on t1.NroCOntrol = t2.NroCOntrol
where 
	--cast(t1.monto_destino_norem_descontado as decimal(18,2)) > 0  	 
	t2.liq_id = 23
and t1.NroCOntrol in ('38000131', '38000173')



38000131	000398654
38000173	000374271

38000131	000398654
38000173	000374271


select  

CAST (dbo.RellenarTextoIzquierda(
REPLACE(SUBSTRING(cast(convert(numeric (18,2), total_descuentos)/100 as varchar),0,8), '.', '') 
,'0',9) AS VARCHAR(9))

from agentes_extension_docente_historico
where liq_id = 23
and NroCOntrol in ('38000131', '38000173')

select * from agentes_extension_docente_historico
where liq_id = 23
and NroCOntrol in ('38000131', '38000173')
order by NroCOntrol

select * from agentes_extension_docente_historico_copia
where liq_id = 23
and NroCOntrol in ('38000131', '38000173')
order by NroCOntrol

select * from agentes_extension_docente_historico_copia_2
where liq_id = 23
and NroCOntrol in ('38000131', '38000173')
order by NroCOntrol

select monto_destino_norem_descontado from agentes_extdoc_diferencia_0922
where NroCOntrol in ('38000131', '38000173')
order by NroCOntrol

delete from agentes_extension_docente_historico

select * from agentes_extension_docente_historico

select * from agentes_extension_docente_historico_copia




update agentes_extension_docente_historico 
set total_descuentos = t2.total_descuentos
from 
	agentes_extension_docente_historico_copia t2
where agentes_extension_docente_historico.id = t2.id


-- MES ID 23 - MAYO
UPDATE
    agentes_extension_docente_historico 
SET
    agentes_extension_docente_historico.total_descuentos = CAST (dbo.RellenarTextoIzquierda(replace(cast(convert (numeric (18,2), (convert(numeric, agentes_extension_docente_historico.total_descuentos) / 100)) + t1.monto_destino_norem_descontado AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9))
	-- agentes_extension_docente_historico.total_descuentos  = convert (numeric (18,2), (convert(numeric, agentes_extension_docente_historico.total_descuentos) / 100)) + t1.monto_destino_norem_descontado  -- bien

	--total_descuentos =  CAST (dbo.RellenarTextoIzquierda( REPLACE(SUBSTRING(cast(convert(numeric (18,2), t2.total_descuentos)/100 as varchar),0,8), '.', '') ,'0',9) AS VARCHAR(9))
from agentes_extdoc_diferencia_0922 t1
--inner join agentes_extension_docente_historico_copia t2
--on t1.NroCOntrol = t2.NroCOntrol
where CONVERT(numeric(18,2), t1.monto_destino_norem_descontado) > 0  
and agentes_extension_docente_historico.liq_id = 23
and agentes_extension_docente_historico.NroCOntrol = t1.NroCOntrol


-- MES ID 26 - JUNIO
UPDATE
    agentes_extension_docente_historico 
SET
    agentes_extension_docente_historico.total_descuentos = CAST (dbo.RellenarTextoIzquierda(replace(cast(convert (numeric (18,2), (convert(numeric, agentes_extension_docente_historico.total_descuentos) / 100)) + t1.monto_destino_norem_descontado AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9))
	-- agentes_extension_docente_historico.total_descuentos  = convert (numeric (18,2), (convert(numeric, agentes_extension_docente_historico.total_descuentos) / 100)) + t1.monto_destino_norem_descontado  -- bien

	--total_descuentos =  CAST (dbo.RellenarTextoIzquierda( REPLACE(SUBSTRING(cast(convert(numeric (18,2), t2.total_descuentos)/100 as varchar),0,8), '.', '') ,'0',9) AS VARCHAR(9))
from agentes_extdoc_diferencia_1022 t1
--inner join agentes_extension_docente_historico_copia t2
--on t1.NroCOntrol = t2.NroCOntrol
where CONVERT(numeric(18,2), t1.monto_destino_norem_descontado) > 0  
and agentes_extension_docente_historico.liq_id = 26
and agentes_extension_docente_historico.NroCOntrol = t1.NroCOntrol


-- MES ID 30 - JULIO
UPDATE
    agentes_extension_docente_historico 
SET
    agentes_extension_docente_historico.total_descuentos = CAST (dbo.RellenarTextoIzquierda(replace(cast(convert (numeric (18,2), (convert(numeric, agentes_extension_docente_historico.total_descuentos) / 100)) + t1.monto_destino_norem_descontado AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9))
	-- agentes_extension_docente_historico.total_descuentos  = convert (numeric (18,2), (convert(numeric, agentes_extension_docente_historico.total_descuentos) / 100)) + t1.monto_destino_norem_descontado  -- bien

	--total_descuentos =  CAST (dbo.RellenarTextoIzquierda( REPLACE(SUBSTRING(cast(convert(numeric (18,2), t2.total_descuentos)/100 as varchar),0,8), '.', '') ,'0',9) AS VARCHAR(9))
from agentes_extdoc_diferencia_1122 t1
--inner join agentes_extension_docente_historico_copia t2
--on t1.NroCOntrol = t2.NroCOntrol
where CONVERT(numeric(18,2), t1.monto_destino_norem_descontado) > 0  
and agentes_extension_docente_historico.liq_id = 30
and agentes_extension_docente_historico.NroCOntrol = t1.NroCOntrol

select NroCOntrol, monto_destino_norem_descontado
from agentes_extdoc_diferencia_1022 
--inner join agentes_extension_docente_historico_copia t2
--on t1.NroCOntrol = t2.NroCOntrol
where CONVERT(numeric(18,2), t1.monto_destino_norem_descontado) > 0  
and agentes_extension_docente_historico.liq_id = 26
and agentes_extension_docente_historico.NroCOntrol = t1.NroCOntrol

select NroCOntrol, total_descuentos from agentes_extension_docente_historico
where liq_id = 26
and NroCOntrol in ('38000173', '38001491')

38000173	1971.00
38001491	1971.00

38000173	000655285
38001491	000803837




-- MES ID 30 - JULIO
UPDATE
    agentes_extension_docente_historico 
SET
    agentes_extension_docente_historico.total_descuentos = CAST (dbo.RellenarTextoIzquierda(replace(cast(convert (numeric (18,2), (convert(numeric, agentes_extension_docente_historico.total_descuentos) / 100)) + t1.monto_destino_norem_descontado AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9))
	-- agentes_extension_docente_historico.total_descuentos  = convert (numeric (18,2), (convert(numeric, agentes_extension_docente_historico.total_descuentos) / 100)) + t1.monto_destino_norem_descontado  -- bien

	--total_descuentos =  CAST (dbo.RellenarTextoIzquierda( REPLACE(SUBSTRING(cast(convert(numeric (18,2), t2.total_descuentos)/100 as varchar),0,8), '.', '') ,'0',9) AS VARCHAR(9))
from agentes_extdoc_diferencia_1122 t1
--inner join agentes_extension_docente_historico_copia t2
--on t1.NroCOntrol = t2.NroCOntrol
where CONVERT(numeric(18,2), t1.monto_destino_norem_descontado) > 0  
and agentes_extension_docente_historico.liq_id = 30
and agentes_extension_docente_historico.NroCOntrol = t1.NroCOntrol

select * 
from agentes_extdoc_diferencia_1122 t1
--inner join agentes_extension_docente_historico_copia t2
--on t1.NroCOntrol = t2.NroCOntrol
where CONVERT(numeric(18,2), t1.monto_destino_norem_descontado) > 0  
and agentes_extension_docente_historico.liq_id = 30
and agentes_extension_docente_historico.NroCOntrol = t1.NroCOntrol
