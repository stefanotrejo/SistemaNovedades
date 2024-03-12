SELECT MesAnioLiq as fechaliq,* from PruebasAge 
--inner join ConceptoTemporal t2
--on t1.NuevoAgeId1 = t2.ageId
where FechaLiquidacion >= '01/01/2023'
and FechaLiquidacion <= '01/12/2023'
and NroCOntrol = '38987825'
order by FechaLiquidacion


DECLARE  @ageid int
select @ageid = 17314336

--17314336

	SELECT 
		SUM(cteimporte) AS HABERSINAPORTE
	FROM 
		ConceptoTemporal b1 
		INNER JOIN ConceptoExtensionDocente b2 on b1.cteCodigoConcepto = b2.conCodigo
		INNER JOIN Concepto b3 on b2.conCodigo = b3.conCodigo
	 WHERE 
		b3.conRemunerativoNoRemunerativo = '2'
	 AND (b1.cteCodigoConcepto < '108' OR b1.cteCodigoConcepto > '118')
	 AND b1.cteCodigoConcepto not in ('137', '202', '208')
	 AND cteCodigoConcepto NOT IN ('550', '552', '553', '559', '595', '597') -- 28.8.23 - se agrega 552
	 --AND b2.liq_id = 14
	 AND b1.ageId = @ageid



-- AF
	 SELECT 
		SUM(cteImporte) AS AF
	FROM 
		ConceptoTemporal b1 
		INNER JOIN ConceptoExtensionDocente b2 on b1.cteCodigoConcepto = b2.conCodigo
		INNER JOIN Concepto b3 on b2.conCodigo = b3.conCodigo
	WHERE  
		 b1.ageId = @ageid
	AND	b3.conRemunerativoNoRemunerativo = '2'
	AND ((b1.cteCodigoConcepto >= '108' AND b1.cteCodigoConcepto <= '118')
	OR b1.cteCodigoConcepto in ('137', '202', '208'))
	

	-- NO PRESENTISMO
	SELECT cteImporte AS NOPRESENTISMO FROM ConceptoTemporal b2
			WHERE b2.ageId= @ageid
			AND cteCodigoConcepto = '199'
		

		-- 746
	SELECT cteImporte AS "746" FROM ConceptoTemporal b2
			WHERE b2.ageId= @ageid
			AND cteCodigoConcepto = '746'
		

	 SELECT 
		[Nopres/RiesgoVida] 
	FROM 
		PruebasAge
	WHERE  
		 NuevoAgeId1= @ageid