DECLARE @mes_anio varchar(5)
SELECT @mes_anio = '09/22'

SELECT 
	t2.Docente, t1.nombre, t1.*
  FROM AgentesExtensionDocente_Cat1y2 t2
  INNER JOIN PruebasAge t1 ON t2.DNI = SUBSTRING(T1.Cuil, 3,8)
  WHERE 
	T1.MesAnioLiq = @mes_anio
-- Filtro cargos habilitados
	AND EXISTS (
		SELECT * 
		FROM CargosExtensionDocente	 t3
		WHERE t1.Agru = t3.agrupamiento
		AND t1.tramo = t3.tramo
		AND t1.Apertura = t3.apertura
				)
AND t1.SituRev != 'A' -- FILTRO ADSCRIPTOS
AND t1.SituRev != 'V' -- FILTRO VACANTES (ES LO MISMO QUE LEGAJO '9999999’)
AND t1.Legajo != '9999999'
AND t1.SituRev != 'N' -- FILTRO NACION 

UPDATE 
	AgentesExtensionDocente_Cat1y2 
SET 
	Control = t1.NroCOntrol
  FROM AgentesExtensionDocente_Cat1y2 t2
  INNER JOIN PruebasAge t1 ON t2.DNI = SUBSTRING(T1.Cuil, 3,8)
  WHERE 
	T1.MesAnioLiq = @mes_anio
-- Filtro cargos habilitados
	AND EXISTS (
		SELECT * 
		FROM CargosExtensionDocente	 t3
		WHERE t1.Agru = t3.agrupamiento
		AND t1.tramo = t3.tramo
		AND t1.Apertura = t3.apertura
				)
AND t1.SituRev != 'A' -- FILTRO ADSCRIPTOS
AND t1.SituRev != 'V' -- FILTRO VACANTES (ES LO MISMO QUE LEGAJO '9999999’)
AND t1.Legajo != '9999999'
AND t1.SituRev != 'N' -- FILTRO NACION 