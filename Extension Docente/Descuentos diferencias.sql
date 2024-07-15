
select * from agentes_extension_docente_historico
where liq_id = 45
and NroCOntrol = '38215192'


select * from agentes_extdoc_diferencia_saldo_final
where 
NroCOntrol = '38215192'

select * from agentes_extdoc_diferencia_saldo_final_febreroV2
where 
NroCOntrol = '38215192'

--select * from agentes_extdoc_diferencia_saldo_marzo
--where NroCOntrol = '38215192'



select * from LiquidacionExtensionDocente
where id in(43, 45)

-- FEBRERO
begin tran t1

UPDATE agentes_extdoc_diferencia_saldo_final_febreroV2
--set monto_destino_norem_descontado = t2.monto_destino_norem_descontado 
set saldo_norem = convert(decimal (18,2),t1.monto_origen_norem_descontar) - convert(decimal (18,2),t1.monto_destino_norem_descontado)
FROM agentes_extdoc_diferencia_saldo_final_febreroV2 t1
inner join agentes_extdoc_diferencia_saldo_final t2
on t1.NroCOntrol = t2.NroCOntrol

commit tran t1

select * from agentes_extension_docente_historico
where liq_id = 45
and NroCOntrol = '38215192'



-- ACTUALIZACION MARZO

select * from agentes_extension_docente_historico
where liq_id = 47
and NroCOntrol = '38215192'

select * from agentes_extdoc_diferencia_saldo_final_febreroV2
where 
NroCOntrol = '38215192'

select * from agentes_extdoc_diferencia_saldo_marzo
where 
NroCOntrol = '38215192'


begin tran t1

UPDATE agentes_extdoc_diferencia_saldo_marzo
--set monto_origen_norem_descontar = t2.saldo_norem -- ACTUALIZA EL SALDO A DESCONTAR
--set monto_destino_norem_descontado = t2.monto_destino_norem_descontado -- ACTUALIZA LO DESCONTADO (ENVIADO)
set saldo_norem = convert(decimal (18,2),t1.monto_origen_norem_descontar) - convert(decimal (18,2),t1.monto_destino_norem_descontado) -- ACTUALIZA EL SALDO PENDIENTE
FROM agentes_extdoc_diferencia_saldo_marzo t1
inner join agentes_extdoc_diferencia_saldo_final_febreroV2 t2
on t1.NroCOntrol = t2.NroCOntrol

commit tran t1


SELECT *, CONVERT(numeric (18,2), saldo_norem) as snorem from agentes_extdoc_diferencia_saldo_marzo
where CONVERT(numeric (18,2), saldo_norem) < -900
order by snorem 