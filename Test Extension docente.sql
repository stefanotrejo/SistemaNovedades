----------------  INICIO TESTS ---------------- 
 
SELECT numeroControl, IMP_601, IMP_601_1, Rem, PRES, PX_601 
FROM #agentes_filtrados 
WHERE IMP_601 > 0 -- que exista el 601
AND PRES != 0

SELECT numeroControl, IMP_601, IMP_601_1, Rem, PRES, PX_601, R, R_DEPURADO 
FROM #agentes_filtrados 
WHERE IMP_601 > 0 -- que exista el 601
AND  IMP_601_1 < Rem -- que sea menor que el totrem


SELECT NR_DEPURADO, R_DEPURADO 
FROM #agentes_filtrados 
WHERE NR_DEPURADO = 0
OR R_DEPURADO = 0



SELECT NOPRES, IMP_601, PRES, IMP_601_1, ageId
FROM #agentes_filtrados 
WHERE nopres != '1'


-- CASO 1 - CON NO PRESENTISMO Y PRESENTISMO = 601 --
/*
Si c.nopres = ‘1’ 
	NR = NR - i.cod199 --- NR = NR_1
Sino	NR = NR --- NR = NR_1
*/

SELECT NOPRES, PRES, NR,  NR_1, ageId
FROM #agentes_filtrados 
WHERE nopres != '1'


/*
Si existe c.cod746
	Si i.cod746 < NoRem
		PX = i.cod746 / NoRem (porcentaje a descontar)
NR = NR – (NR * PX) – NR = NR_DEPURADO
	Si i.cod746 = NoRem
NR = 0 -- NR = NR_DEPURADO
	Sino
		NR = 0 -- NR = NR_DEPURADO
 imprimir con leyenda y pasar a otra liquidación
*/

SELECT IMP_746,PRES, NoRem, PX_746, NR, NR_1, NR_DEPURADO, nopres
FROM #agentes_filtrados 
WHERE IMP_746 = 0
and nopres != '1'

-- TEST 601 PRESENTISMO Y NO PRESENTISMO --
-- a) FALTA DEFINIR QUE VALOR USAR EN LA FORMULA DE PX
SELECT nopres, IMP_601, PRES,IMP_601_1,  Rem, PX_601, R, R_DEPURADO
FROM #agentes_filtrados 
WHERE IMP_601 > 0
AND IMP_601_1 < Rem

-- B) Caso en el que el codigo 601 no existe
SELECT nopres, IMP_601, PRES,IMP_601_1,  Rem, PX_601, R, R_DEPURADO
FROM #agentes_filtrados 
WHERE IMP_601 = 0
and R = R_DEPURADO

-- TEST TOTALES FINALES --

SELECT  PX_601, R_DEPURADO, IMP_521, * from #agentes_filtrados
WHERE R_DEPURADO > 0

SELECT  PX_746, NR_DEPURADO, IMP_522,  * from #agentes_filtrados
WHERE NR_DEPURADO > 0


SELECT  R_DEPURADO,IMP_521, IMP_602,IMP_665 ,IMP_665_1
from #agentes_filtrados
WHERE IMP_665 > 0

-- test iosep --

SELECT  IMP_521, IMP_615, IMP_616, IOSEP, (CASE WHEN IOSEP > 4 					 
					THEN IMP_521 * 0.05
					ELSE 0 
					END), (CASE WHEN IOSEP > 5 					 					
					THEN (IMP_521 * (IOSEP-5)/100)
					ELSE 1
					END)
from #agentes_filtrados
WHERE IOSEP > 5


-- test osplad --
SELECT  IMP_521, IMP_663, IMP_664, OSPLAD
from #agentes_filtrados
WHERE OSPLAD > 2

SELECT  IMP_521, IMP_663, IMP_664, OSPLAD
from #agentes_filtrados
WHERE OSPLAD > 3

--------------

-- TEST OBRA SOCIAL --

SELECT  IMP_521, IMP_615, IMP_616, IOSEP, AP_IOSEP
from #agentes_filtrados
WHERE IOSEP > 4

-- TEST APORTE ANSES --
-- Ap.patronal ANSeS = Sumatoria de R * 0,1017 (10,17% del imponible)
SELECT  IMP_521, IMP_615, IMP_616, IOSEP, AP_ANSES
from #agentes_filtrados



SELECT  IMP_521, IMP_615, IMP_616, IOSEP, 
										 (CASE 
										WHEN IMP_521 > 0 
										THEN (IMP_521 + IMP_522 - (IMP_602 + IMP_615 + IMP_616 + IMP_663 + IMP_664 + IMP_665 ))
										END
										)  AS LIQUIDO

--AS LIQUIDO 
from #agentes_filtrados
WHERE IMP_521 > 0


/*
Si c.iosep > 5
		icod616 = R * [(c.iosep – 5) / 100]   (para el resto es el 1%) (1% POR ADHERENTE)

*/
-----------------


--insert into NovedadesExtensionDocente
--select dni, [N° Control], 30
--from "Hoja2$"

-- PENDIENTE -- OSTEP -- SIMILAR A OSPLAD --

-- PRUEBAS --
--select * from #agentes_filtrados t1 inner join ConceptoTemporal t2
--on t1.ageId = t2.ageId 
--where t2.cteCodigoConcepto = '888' or t2.cteCodigoConcepto = '889'

-- FIN - PRUEBAS --