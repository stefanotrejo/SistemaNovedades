----------------------->>>>> INICIO GENERACION TXT PARA EL BANCO V2 <<<<<-----------------------
SELECT  				
	  CAST (dbo.RellenarTextoDerecha(t2.Nombre,' ',25) AS VARCHAR(25)) -- NOMBRE + RELLENO
    + CAST (dbo.RellenarTextoIzquierda(SUBSTRING(t1.cuil,3,8),'0',8) AS VARCHAR(8)) -- RELLENO + DNI
    + CAST (dbo.RellenarTextoIzquierda(t2.LugarPago,'0',5) AS VARCHAR(5)) -- RELLENO + LUGAR PAGO 	
    + CAST (dbo.RellenarTextoIzquierda(t2.Escuela,'0',5) AS VARCHAR(5)) -- RELLENO + ESCUELA	
    + CAST (dbo.RellenarTextoIzquierda(t2.NroCOntrol,'0',8) AS VARCHAR(8)) -- RELLENO + CONTROL		
    + CAST (dbo.RellenarTextoIzquierda(t2.Agru + t2.tramo + t2.Apertura,' ',6) AS VARCHAR(6)) -- RELLENO + CARGO
    + CAST (dbo.RellenarTextoIzquierda(replace(cast(t1.I02 AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9)) -- RELLENO + TOT. HAB. SIN APORTE
	+ CAST (dbo.RellenarTextoIzquierda(replace(cast(t1.I01 AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9)) -- RELLENO + TOT. HAB. CON APORTE
	+ CAST (dbo.RellenarTextoIzquierda(replace(cast(convert(decimal (18,2), t1.I01) 
		+ (convert(decimal (18,2),t1.I02)) AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9)) -- RELLENO + TOT. HAB.
	+ CAST (dbo.RellenarTextoIzquierda(replace(cast(convert(decimal (18,2), t1.I03)
			+ (convert(decimal (18,2),t1.I04)) + (convert(decimal (18,2),t1.I05)) + (convert(decimal (18,2),t1.I06)) 
			+ (convert(decimal (18,2),t1.I07)) + convert(decimal (18,2), t1.I08)  
			+ ISNULL(convert(decimal (18,2), I09),'000000000') 
			+ ISNULL(convert(decimal (18,2), I10), '000000000')
			AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9)) -- RELLENO + TOTAL DESCUENTOS	
	+ CAST(t2.PlantaTipo AS VARCHAR(1))  -- PLANTA
	+ '000000000' -- SALARIO	
	+ CAST (dbo.RellenarTextoIzquierda(replace(cast(
			  (convert(decimal (18,2), t1.I01) + (convert(decimal (18,2),t1.I02))) -- total hab.
			- (
					 ISNULL(convert(decimal (18,2), I09),'000000000') -- 601
					+ convert(decimal (18,2), t1.I03) 
					+ convert(decimal (18,2), t1.I04) 
					+ convert(decimal (18,2), t1.I05) 					
					+ convert(decimal (18,2), t1.I06) 
					+ convert(decimal (18,2), t1.I07)
					+ convert(decimal (18,2), t1.I08) 								
					+ ISNULL(convert(decimal (18,2), I10),'000000000') -- 746
				) 
				 -- tot desc. 
			AS decimal(18,2)),'.',''),'0',9) AS VARCHAR(9)) -- RELLENO + TOT LIQ.		
	+ CAST (dbo.RellenarTextoIzquierda(t2.FechaIngreso,'0',6) AS VARCHAR(6)) -- RELLENO + FECHA INGRESO			
	+ CAST (dbo.RellenarTextoIzquierda(t1.cuil ,'0',11) AS VARCHAR(11)) -- RELLENO + CUIL	
	+ CAST(t2.Sexo AS VARCHAR(1)) -- SEXO
	--+ '000000000' -- PORCENTAJE DE IMP DESCUENTO - 
AS Columna 
FROM  
	agentes_extension_docente_historico t1
	INNER JOIN PruebasAge t2	
	ON t1.age_id = t2.NuevoAgeId1		
	WHERE t1.mes = 04
	and t1.anio = 24

	select SUM(CONVERT(numeric (18,2), t1.total_liquido/100)) from agentes_extension_docente_historico t1
	where t1.mes = 01 and t1.anio = 24
	and not exists (
	select * from agentes_extension_docente_historico t2
	where mes = 04 and anio = 24
	and t1.NroCOntrol = t2.NroCOntrol	
	) 

