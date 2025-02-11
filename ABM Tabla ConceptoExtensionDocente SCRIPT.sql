-- INSERTA EN CONCEPTO EXTENSION DOCENTES LOS CONCEPTOS ACTUALIZADOS --
-- EJECUTAR TODOS LOS MESES Y ENVIAR EXCEL A MYRIAM !!

-- DELETE FROM ConceptoExtensionDocente

INSERT INTO 
	ConceptoExtensionDocente (conCodigo)
-- Conceptos percibidos por agentes con lugar de pago que comienzan con 38 y con cargo 060098, 060070
SELECT distinct t2.cteCodigoConcepto --, t1.*  
FROM PruebasAge t1
inner join ConceptoTemporal t2
on t1.NuevoAgeId1 = t2.ageId
where MesAnioLiq = '09/22'
and Agru = '06'
and tramo = '0'
and Apertura in (
'070',
'098')
and SUBSTRING(LugarPago,1,2) = '38'
and cteCodigoConcepto < '600'
and cteCodigoConcepto > '001'
and cteCodigoConcepto not in 
(
	'78', '553'
)
ORDER BY cteCodigoConcepto


---- SELECT ----

Select * from ConceptoExtensionDocente
ORDER BY conCodigo

-- UPDATE CONID ---

UPDATE 
	ConceptoExtensionDocente
SET 
	conId = t2.conId
FROM 
	ConceptoExtensionDocente T1
	INNER JOIN Concepto T2
	ON T1.conCodigo = T2.conCodigo

