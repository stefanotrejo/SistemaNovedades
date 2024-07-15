
----------------------->>>>> INICIO - ORDEN DE PAGO <<<<<-----------------------
SELECT 
	-- LIQUIDO
		SUM(
		CONVERT(numeric (18) ,replace(I01,'.','')) + CONVERT(numeric (18) ,replace(I02,'.',''))
			- ( 				
				+ CONVERT(numeric (18) ,replace(I03,'.','')) + CONVERT(numeric (18) ,replace(I04,'.','')) 
				+ CONVERT(numeric (18) ,replace(I05,'.',''))
				+ CONVERT(numeric (18) ,replace(I06,'.','')) + CONVERT(numeric (18) ,replace(I07,'.',''))
				+ CONVERT(numeric (18) ,replace(I08,'.',''))
				+ CONVERT(numeric (18) ,replace(I09,'.',''))
				+ CONVERT(numeric (18) ,replace(I10,'.',''))								 							 							
		)) AS liquido,
	
	-- AP EMPLEADO ANSES
	SUM (
		CONVERT(numeric (18) ,replace(I03,'.','')) + CONVERT(numeric (18) ,replace(I08,'.',''))
		) AS aporteAnsesEmpleado, 
	-- AP PATRONAL ANSES
	SUM (
		 t1.AP_ANSES
		 ) 
		 AS aporteAnsesPatronal, 
	-- TOTAL APORTE ANSES
	SUM (
		CONVERT(numeric (18) ,replace(I03,'.','')) + CONVERT(numeric (18) ,replace(I08,'.','')) + t1.AP_ANSES
		) AS ANSES,

	-- AP EMPLEADO IOSEP
	SUM (
		CONVERT(numeric (18) ,replace(I04,'.','')) + CONVERT(numeric (18) ,replace(I05,'.',''))
		) AS aporteIosepEmpleado, 
	-- AP PATRONAL IOSEP
	SUM (
		 t1.AP_IOSEP
		 ) 
		 AS aporteIosepPatronal, 
	-- TOTAL APORTE IOSEP
	SUM (
		CONVERT(numeric (18) ,replace(I04,'.','')) + CONVERT(numeric (18) ,replace(I05,'.','')) + t1.AP_IOSEP
		) AS IOSEP ,

		-- AP EMPLEADO OSPLAD
	SUM (
		CONVERT(numeric (18) ,replace(I06,'.','')) + CONVERT(numeric (18) ,replace(I07,'.',''))
		) AS aporteOspladEmpleado, 
	-- AP PATRONAL OSPLAD
	SUM (
		 t1.AP_OSPLAD
		 ) 
		 AS aporteOspladPatronal, 
	-- TOTAL APORTE OSPLAD
	SUM (
		CONVERT(numeric (18) ,replace(I06,'.','')) + CONVERT(numeric (18) ,replace(I07,'.','')) +  t1.AP_OSPLAD
		) AS OSPLAD		
FROM  
	agentes_extension_docente_historico t1	
WHERE 
	liq_id = @liq_id	
	and t1.tipo_planta_OP = 'PC'
	and t1.tipo_planta_OP = 'PP'