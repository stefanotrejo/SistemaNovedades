/*
select * from PruebasAge
where MesAnioLiq = '06/22'
--and NroCOntrol = '72064114'
and Nombre like '%72064122%'
--and LugarPago = 72591

select * from LugarPago
where lpaNombre like '%vialidad%'
*/

SELECT * FROM PagosEventuales
WHERE ageCUIT in (
'20366825437'
,'20313923151'
,'20267746592'
,'20383680159'
,'20325240084'
,'20383656614'
,'20255200594'
,'27307119639'
,'20379552685'
)
OR ageNroControl in (
'64003493'
,'64004193'
,'64004795'
,'64006093'
,'64006195'
,'64006292'
,'64006695'
,'64003702'
,'64006404'
)

SELECT * FROM [PagosEventuales_13.7.22_servidor]
WHERE ageCUIT in (
'20366825437'
,'20313923151'
,'20267746592'
,'20383680159'
,'20325240084'
,'20383656614'
,'20255200594'
,'27307119639'
,'20379552685'
)
OR ageNroControl in (
'64003493'
,'64004193'
,'64004795'
,'64006093'
,'64006195'
,'64006292'
,'64006695'
,'64003702'
,'64006404'
)

SELECT * FROM  [PagosEventuales_14.2.22]
WHERE ageCUIT in (
'20366825437'
,'20313923151'
,'20267746592'
,'20383680159'
,'20325240084'
,'20383656614'
,'20255200594'
,'27307119639'
,'20379552685'
)
OR ageNroControl in (
'64003493'
,'64004193'
,'64004795'
,'64006093'
,'64006195'
,'64006292'
,'64006695'
,'64003702'
,'64006404'
)

SELECT * FROM [PagosEventuales_30.6.22]
WHERE ageCUIT in (
'20366825437'
,'20313923151'
,'20267746592'
,'20383680159'
,'20325240084'
,'20383656614'
,'20255200594'
,'27307119639'
,'20379552685'
)
OR ageNroControl in (
'64003493'
,'64004193'
,'64004795'
,'64006093'
,'64006195'
,'64006292'
,'64006695'
,'64003702'
,'64006404'
)

SELECT * FROM PagosEventuales_Sucio
WHERE ageCUIT in (
'20366825437'
,'20313923151'
,'20267746592'
,'20383680159'
,'20325240084'
,'20383656614'
,'20255200594'
,'27307119639'
,'20379552685'
)
OR ageNroControl in (
'64003493'
,'64004193'
,'64004795'
,'64006093'
,'64006195'
,'64006292'
,'64006695'
,'64003702'
,'64006404'
)
