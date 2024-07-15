select * from PruebasAge t1 inner join agentes_extension_docente_historico t2
on t1.NroCOntrol = t2.NroCOntrol
--inner join ConceptoTemporal t2
--on t1.NuevoAgeId1 = t2.ageId
where MesAnioLiq = '04/24'
and AniosAntig = '18'
and Agru = 06
and t1.Apertura = 098
and t2.mes = 04
and t2.anio = 24
and not exists (
	select * from ConceptoTemporal t3
	where t3.cteCodigoConcepto in ('215','216', '069', '070', '071')
	and t1.NuevoAgeId1 = t3.ageId
)
and exists (
 select * from agentes_extension_docente_historico
 where mes = 04
 and anio = 24
 and NroCOntrol = t1.NroCOntrol
) 

 
 select * from ConceptoTemporal t1 inner join Concepto t2
 on t1.cteCodigoConcepto = t2.conCodigo
 where ageId = 17883933

 select * from  CargosExtensionDocente t1 inner join  cgosden t2
 on t1.agrupamiento = t2.agrupamiento
 and t1.apertura =  t2.apertura


select * from PruebasAge
 where MesAnioLiq = '04/24'
 and NroCOntrol = '28681982'
 
 select * from Concepto where conNombre like '%zona%'




 select * from agentes_extension_docente_historico
 where mes	= 04
 and anio = 24
 --and NroCOntrol = '56003605'
 and SUBSTRING(cuil,3,8) = '23498599'