
-- PLANTA CONTRATADA
select NroCOntrol, pruebasage.Nombre, CONCAT(pruebasage.Agru,pruebasage.tramo,pruebasage.apertura) "codigo de cargo",
cgosden.nombre as Cargo,
PruebasAge.Anios as "antiguedad reconocida años",
CASE 
	WHEN PruebasAge.Meses='A' THEN '10'
	WHEN PruebasAge.Meses!='O' AND PruebasAge.Meses!='A' THEN PruebasAge.Meses
	ELSE '0'
	END AS "antiguedad reconocida meses",
CONCAT(SUBSTRING (FechaIngreso,0,3), '-', SUBSTRING (FechaIngreso,3,2), '-', SUBSTRING (FechaIngreso,5,2)) as FechaIngreso,
AniosAntig,
ISNULL(Concepto.conNombre,'') AS Titulo
FROM PruebasAge 
	LEFT JOIN dbo.cgosden cgosden 
	ON PruebasAge.Agru=cgosden.Agrupamiento 
	and PruebasAge.tramo=cgosden.Tramo 
	and PruebasAge.Apertura=cgosden.apertura
	LEFT JOIN ConceptoTemporal 
	ON PruebasAge.NuevoAgeId1 = ConceptoTemporal.ageId
	AND ConceptoTemporal.cteCodigoConcepto in ('021','022','023','024','025','026')
	LEFT JOIN Concepto ON Concepto.conCodigo = ConceptoTemporal.cteCodigoConcepto
where MesAnioLiq = '07/23'
and LugarPago = '55012'
and PlantaTipo = 'C'
ORDER BY nombre

-- PLANTA PERMANENTE
select NroCOntrol, pruebasage.Nombre, CONCAT(pruebasage.Agru,pruebasage.tramo,pruebasage.apertura) "codigo de cargo",
cgosden.nombre as Cargo,
PruebasAge.Anios as "antiguedad reconocida años",
CASE 
	WHEN PruebasAge.Meses='A' THEN '10'
	WHEN PruebasAge.Meses!='O' AND PruebasAge.Meses!='A' THEN PruebasAge.Meses
	ELSE '0'
	END AS "antiguedad reconocida meses",
CONCAT(SUBSTRING (FechaIngreso,0,3), '-', SUBSTRING (FechaIngreso,3,2), '-', SUBSTRING (FechaIngreso,5,2)) as FechaIngreso,
AniosAntig,
ISNULL(Concepto.conNombre,'') AS Titulo
FROM PruebasAge 
	LEFT JOIN dbo.cgosden cgosden 
	ON PruebasAge.Agru=cgosden.Agrupamiento 
	and PruebasAge.tramo=cgosden.Tramo 
	and PruebasAge.Apertura=cgosden.apertura
	LEFT JOIN ConceptoTemporal 
	ON PruebasAge.NuevoAgeId1 = ConceptoTemporal.ageId
	AND ConceptoTemporal.cteCodigoConcepto in ('021','022','023','024','025','026')
	LEFT JOIN Concepto ON Concepto.conCodigo = ConceptoTemporal.cteCodigoConcepto
where MesAnioLiq = '07/23'
and LugarPago = '55012'
and PlantaTipo = 'P'
ORDER BY nombre


select * from ConceptoTemporal
select * from Concepto




select distinct PlantaTipo
from PruebasAge 
LEFT JOIN dbo.cgosden cgosden 
ON PruebasAge.Agru=cgosden.Agrupamiento and 
PruebasAge.tramo=cgosden.Tramo and PruebasAge.Apertura=cgosden.apertura
where MesAnioLiq = '07/23'
and LugarPago = '55012'


-- IMPORTAR CGOSDNE

INSERT INTO 
	cgosden
SELECT
	SUBSTRING([Columna 0],0,3), 
	SUBSTRING([Columna 0],3,1), 
	SUBSTRING([Columna 0],4,3), 
	SUBSTRING([Columna 0],7,50)  
  FROM "cgosden 0723"
WHERE 
SUBSTRING([Columna 0],7,50)  LIKE '%categoria 24%'