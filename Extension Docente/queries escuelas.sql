/****** Script para el comando SelectTopNRows de SSMS  ******/
SELECT  [PROVINCIA]
      ,[ETAPA]
      ,[CUE ANEXO]
      ,[COD_EST_JURI]
      ,[REP]
      ,[COD_LIQ]
      ,[NOMBRE_ESC]
      ,[ZONA]
      ,[COD_CARGO]
      ,[DENOMINACION_CARGO]
      ,[CANT_CARGOS]
      ,[CARGA HORARIA]
      ,[SALARIO BRUTO]
      ,[HS_CAT_ADIC]
      ,[HS_RLJ_ADIC]
      ,[MONTO BRUTO ADICIONAL POR CARGO]
      ,[MONTO ADIC_EST_X_ EXT_JORNADA]
      ,[REND]
      ,[MONTO_FINANCIADO]
  FROM [LiquidacionSueldos].[dbo].['Anexo Convenio$']


  select * from ['Anexo Convenio$'] t1
  join escuelas_cuise_cue t2
  on t1.[CUE ANEXO] = t2.CUE


select * From EscuelaExtensionDocente_historico
where mes = 02 and anio = 24
and liq_id = 45

select t1.CUISE from EscuelaExtensionDocente t1 
inner join escuelas_cuise_cue t2
on t1.CUISE = t2.CUISE
inner join ['Anexo Convenio$'] t3
on t2.CUE = t3.[CUE ANEXO]


select t1.CUISE from EscuelaExtensionDocente t1 
inner join escuelas_cuise_cue_anexo t2
on t1.CUISE = t2.CUISE_Anexo
inner join ['Anexo Convenio$'] t3
on t2.[CUE Anexo] = t3.[CUE ANEXO]



select SUBSTRING(cuil,3,8)
from agentes_extension_docente_historico
where liq_id = 50
and 
(CONVERT(NUMERIC(18,2),I01) > 0
or CONVERT(NUMERIC(18,2),I02) > 0)


select * from 


select * from EscuelaExtensionDocente_historico
where mes = 02 and anio = 24

select * from LiquidacionExtensionDocente


select 
	t2.CUE, t1.Escuela, t2.* 
from #temp t1 
inner join escuelas_cuise_cue t2
on t1.Escuela = t2.CUISE
order by t2.CUE
where not exists (
	select * from ['Anexo Convenio$'] t3
	where t2.CUE = t3.[CUE ANEXO]	
)

select * from escuelas_cuise_cue_anexo
where CUISE_Anexo = '12457'

select 
	t1.Escuela 
from #temp t1 
inner join escuelas_cuise_cue_anexo t2
on t1.Escuela = t2.CUISE_Anexo
inner join ['Anexo Convenio$'] t3
on t2.[CUE Anexo] = t3.[CUE ANEXO]


select * from escuelas_cuise_cue
where Nombre like '%673%'

select * from EscuelaExtensionDocente
where CUISE = 8235




select t2.dni from agentes_extension_docente_historico t1
left join #t1 t2
on SUBSTRING(t1.cuil,3,8) = t2.dni
where t1.liq_id = 50
group by t2.dni having COUNT (1) > 1




select * from agentes_extension_docente_historico
where cuil = 20169996467
and liq_id = 50

where id = 200415
where liq_id = 51


select * from 

20169996467

select distinct dni into #t1 from agentes_rendicion_liq50_2402
where dni = 16999646


select t1.escuela from agentes_extension_docente_historico t1 
where not exists (
	select * from escuelas_con_rendicion t3
	inner join escuelas_cuise_cue t2
	on t3.[CUE ANEXO] = t2.CUE
	where t2.CUISE = t1.Escuela
) 
and not exists (
	select * from escuelas_con_rendicion t3
	inner join escuelas_cuise_cue_anexo t2
	on t3.[CUE ANEXO] = t2.[CUE Anexo]
	where t2.CUISE = t1.Escuela
)




select distinct t1.escuela from agentes_extension_docente_historico t1 
where  t1.liq_id = 50
and 
(CONVERT(NUMERIC(18,2),I01) > 0
or CONVERT(NUMERIC(18,2),I02) > 0)


-- ESCUELAS CON RENDICION CON CUISE/CUE 
select distinct t1.escuela, t2.CUE from agentes_extension_docente_historico t1 
inner join escuelas_cuise_cue t2 on t1.Escuela = t2.CUISE
where  t1.liq_id = 50
and 
(CONVERT(NUMERIC(18,2),I01) > 0
or CONVERT(NUMERIC(18,2),I02) > 0)
and ISNULL(CUE,0) > 0
order by CUE

select distinct t1.escuela, t2.[CUE Anexo] from agentes_extension_docente_historico t1 
inner join escuelas_cuise_cue_anexo t2 on t1.Escuela = t2.CUISE
where  t1.liq_id = 50
and 
(CONVERT(NUMERIC(18,2),I01) > 0
or CONVERT(NUMERIC(18,2),I02) > 0)
and ISNULL([CUE Anexo],0) > 0
order by [CUE Anexo]



select * from escuelas_cuise_cue_anexo
where CUISE_Anexo in (
06735
,00553
,00592
,02873
,03153
,03315
,04222
,04856
,05094
,06461
,06863
,09134
,10064
,11752
,11802
,12457
,12933
,12956
,13012
,23022
,24257
,80435
,02173
,04334
,05337
,05496
,06975
,07681
,08951
,11423
,11694
,11841
,11906
,23014
,80443
,00263
,00286
,00696
,00986
,01703
,03532
,08653
,08726
,09173
,11817
,12191
,12241
,13027
,04663
,04984
,06387
,06766
,07007
,07642
,07843
,10903
,11284
,12442
,12465
,12925
,13004
,13035
,23006
)


 
 select * from escuelas_con_rendicion
 where [CUE ANEXO] = 860063600


 -- ESCUELAS CON RENDICION CON CUISE/CUE 
select distinct t1.escuela, t2.CUE, t3.[CUE ANEXO] from agentes_extension_docente_historico t1 
inner join escuelas_cuise_cue t2 on t1.Escuela = t2.CUISE
inner join escuelas_con_rendicion t3 on t2.CUE = t3.[CUE ANEXO]
where  t1.liq_id = 50
and 
(CONVERT(NUMERIC(18,2),I01) > 0
or CONVERT(NUMERIC(18,2),I02) > 0)
and ISNULL(CUE,0) > 0
order by CUE


select * from escuelas_cuise_cue
order by CUE

select * from escuelas_cuise_cue_anexo
where [CUE Anexo] = '6766'


select * from escuelas_sin_rendicion t1
inner join escuelas_cuise_cue t2
on t1.[CUE ANEXO] = t2.CUE
where t2.Nivel like '%pri%'
and not exists (
	select * from EscuelaExtensionDocente t3
	where t2.CUISE = t3.CUISE
) 



select * from escuelas_sin_rendicion t1
inner join escuelas_cuise_cue_anexo t2
on t1.[CUE ANEXO] = t2.[CUE Anexo]
and not exists (
	select * from EscuelaExtensionDocente t3
	where t2.CUISE = t3.CUISE
) 



inner join EscuelaExtensionDocente t3
on t2.CUISE = t3.cuise



SELECT * from PruebasAge t1
where MesAnioLiq = '07/24'
and Escuela in (
1251,
2006,
5063,
34952,
35174,
36796,
37196,
39013,
39156,
39156
)
and exists (
select * from CargosExtensionDocente
where Agru = t1.Agru
and tramo = t1.tramo
and apertura = t1.Apertura
)



SELECT CUISE, nombre, CUE from EscuelaExtensionDocente
where cuise in (
 1251
,2006
,5063
,34952
,35174
,36796
,37196
,39013
,39156
)

select * from escuelas_cuise_cue t1
where Nombre like '%prado%'

where  t1.CUISE= '01251'



select * from [escuela-0724]
where SUBSTRING([Columna 0],1,5) = '60083'


begin tran t1 

commit tran t1

INSERT INTO EscuelaExtensionDocente (CUISE,nombre,cue) 
select cuise, NOMBRE_ESC, CUE from escuelas_sin_rendicion t1
inner join escuelas_cuise_cue t2
on t1.[CUE ANEXO] = t2.CUE
where 
CUISE in (
 1251
,2006
,5063
,35174
,37196
,39013
,39156
)


commit tran t1
select * from EscuelaExtensionDocente
where CUE is not null

select * from escuelas_sin_rendicion
where [CUE ANEXO]   = 860227800

update EscuelaExtensionDocente
set fecha_alta = GETDATE()
where CUE is not null
	
select * from EscuelaExtensionDocente


begin tran t1


update EscuelaExtensionDocente 
set CUE = t3.cue
FROM
EscuelaExtensionDocente t2
inner join escuelas_cuise_cue t3
on t2.CUISE = t3.CUISE

select * from EscuelaExtensionDocente


select t1.CUE, t1.nombre, t2.CUE, t2.Nombre from EscuelaExtensionDocente  t1
where t1.CUE is  null



commit tran t1


select * from PruebasAge
inner join CargosExtensionDocente t2
on PruebasAge.Agru = t2.agrupamiento
AND PruebasAge.tramo = t2.tramo
AND PruebasAge.Apertura = t2.apertura
where MesAnioLiq = '07/24'

and Escuela in (
 1251
,2006
,5063
,34952
,35174
,36796
,37196
,39013
,39156
)

select * from escuelas_sin_rendicion  t1
inner join escuelas_cuise_cue t2
on t1.[CUE ANEXO] = t2.CUE
inner join EscuelaExtensionDocente t3
on t2.CUISE= t3.CUISE
where 
(t3.CUE is null or t3.CUE <= 0)



select * from escuelas_cuise_cue
where CUE  in (
860000800
,860021900
,860022601
,860030200
,860052301
,860054400
,860076401
,860083601
,860086800
,860152101
,860162801
,860163500
,860172101
,860218000
,860226100


)

select * from escuelas_cuise_cue_anexo
where [CUE Anexo]  in (
860000800
,860021900
,860022601
,860030200
,860052301
,860054400
,860076401
,860083601
,860086800
,860152101
,860162801
,860163500
,860172101
,860218000
,860226100


)

select * from EscuelaExtensionDocente
where CUE = 860052301

select * from escuelas_cuise_cue
where Nombre like '%865%'

Escuela N° 865 / JI 829


860052301


where [CUE Anexo] = 860052301

select * from escuelas_cuise_cue
where CUE = 860052301


select * from EscuelaExtensionDocente
where CUE in (
 860000800
,860021900
,860022601
,860030200
,860052300
,860054400
,860076401
,860083601
,860086800
,860152101
,860162801
,860163500
,860172101
,860226100
)



select * from EscuelaExtensionDocente
where nombre like '%379%'


ESCUELA Nº 355 PEDRO JOSE LAMI 

select * from escuelas_cuise_cue
where CUE like '%005440%'



select * from EscuelaExtensionDocente

where CUE in (
860000080
,86002190
,8000226
,86003020
,860052300
--,0
,86007640
,86008360
,86008680
,86015210
,86016280
,8601635
--,0
--,0
,860226100

) 

