DECLARE @mes_anio varchar (5) 
SELECT @mes_anio = '03/23'

SELECT  
	t1.Cuil,t1.NuevoAgeId1, t1.Nombre, dbo.LugarPago.lpaNombre as "Lugar de Pago", 
	cgosden.nombre as Cargo,t1.MesAnioLiq as Periodo,t1.Agru, t1.tramo, t1.Apertura, 
	t1.NroCOntrol AS "Numero de Control"
FROM 
	PruebasAge t1
	LEFT JOIN dbo.LugarPago			ON dbo.LugarPago.lpaCodigo = t1.LugarPago 
	LEFT JOIN dbo.cgosden cgosden   ON t1.Agru=cgosden.Agrupamiento 
									AND t1.tramo=cgosden.Tramo 
									AND t1.Apertura=cgosden.apertura	
WHERE 
		t1.MesAnioLiq = @mes_anio
	-- Filtro escuelas habilitadas
	AND EXISTS (
		SELECT CUISE FROM EscuelaExtensionDocente	 t2
		WHERE convert(int,t1.Escuela) = t2.CUISE
				)
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
	AND t1.SituRev != 'R' -- FILTRO RETENIDO 
	AND t1.Liquido != 0 -- FILTRO LIQUIDO
	AND t1.TotalHaberes != 0 -- FILTRO tot.hab.rem
	AND t1.TotalSinCargosAlHaber != 0 -- FILTRO tot.hab.no rem
	-- FILTRO que tengan codigo 002
	AND EXISTS ( 	 
		SELECT * FROM ConceptoTemporal b2
		WHERE t1.NuevoAgeId1 = b2.ageId
		AND cteCodigoConcepto = '002'
				)
	AND NOT EXISTS ( -- FILTRO 1 solo item y ese codigo sea 595
		SELECT * FROM PruebasAge b1
		WHERE b1.CantItemsOcupados = 1
		AND MesAnioLiq = @mes_anio
		AND b1.NuevoAgeId1 = t1.NuevoAgeId1

		AND EXISTS ( -- FILTRO que tengan solo codigo 595
		SELECT * FROM ConceptoTemporal b2
		WHERE b1.NuevoAgeId1 = b2.ageId
		AND cteCodigoConcepto = '595')
					)
	-- FILTRO Registros con cero en días trab y líquido, e (importe cod.601 = tot.desctos)
	AND NOT EXISTS (
		SELECT * FROM PruebasAge b1
		WHERE 
			b1.DiasTrabajados = 0
		AND b1.Liquido = 0
		AND MesAnioLiq = @mes_anio
		AND b1.NuevoAgeId1 = t1.NuevoAgeId1
		AND b1.TotalDescuentos = (
						SELECT cteImporte FROM ConceptoTemporal b2
						WHERE b1.NuevoAgeId1 = b2.ageId
						AND cteCodigoConcepto = '601'
								)
				)
AND t1.Agru = 06 
AND t1.tramo = 0
AND t1.Apertura = 098
AND t1.AniosAntig = 10
