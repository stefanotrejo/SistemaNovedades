CREATE TABLE  (cuil varchar(11), monto numeric(18,2))

select top 10 CONVERT(numeric (18,2), monto_origen_norem_descontar) - CONVERT(numeric (18,2),monto_destino_norem_descontado),* from agentes_extdoc_diferencia_unificada
where NroCOntrol = '38266151'

select top 10 * from agentes_extdoc_diferencia_saldo_final
where NroCOntrol = '38266151'




INSERT INTO agentes_extdoc_diferencia_saldo_final (NroCOntrol) 
select distinct NroCOntrol from agentes_extdoc_diferencia_unificada

UPDATE 
	agentes_extdoc_diferencia_saldo_final 
set monto_origen_norem_descontar = (SELECT SUM(CONVERT(numeric (18,2), monto_origen_norem_descontar) - CONVERT(numeric (18,2),monto_destino_norem_descontado)) 
										FROM agentes_extdoc_diferencia_unificada t1 where agentes_extdoc_diferencia_saldo_final.NroCOntrol= t1.NroCOntrol)


select * from agentes_extdoc_diferencia_unificada t1
where exists  (
select * from PruebasAge
where MesAnioLiq = '01/24'
and t1.NroCOntrol = PruebasAge.NroCOntrol
)