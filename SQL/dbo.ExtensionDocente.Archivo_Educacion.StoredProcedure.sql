USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[ExtensionDocente.Archivo_Educacion]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExtensionDocente.Archivo_Educacion]
AS

SELECT 	 	 		
	-- encabezado
	   [NroCOntrol]
      ,[PlantaTipo]
      ,[LugarPago]
      ,[Escuela]
      ,[Juris]
      ,[Prog]
      ,[SubP]
      ,[Actividad]
      ,[fuente]
      ,[dias_trabajados]
      ,[haberSinAporte]
      ,[haberConAporte]	  
      ,[total_haberes]	  
      ,[total_descuentos]	  
      ,[total_liquido]
	  ,[NroCOntrol]
      +[PlantaTipo]
      +[LugarPago]
      +[Escuela]
      +[Juris]
      +[Prog]
      +'0' + [SubP]
      +'0' + [Actividad]
      +[fuente]
      +[dias_trabajados]
	  --+ REPLICATE('0', 9- len(ltrim(CAST(replace(cast( [haberSinAporte] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [haberSinAporte]
	  --+ CAST(replace(cast(([haberSinAporte]) as decimal(18,2)),'.','') AS VARCHAR(9))             
	  +haberSinAporte
	  --+ REPLICATE('0', 9- len(ltrim(CAST(replace(cast( [haberConAporte] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [[haberConAporte]]
	  --+ CAST(replace(cast(([haberConAporte]) as decimal(18,2)),'.','') AS VARCHAR(9))    
	  + haberConAporte
	  --+ REPLICATE('0', 9- len(ltrim(CAST(replace(cast( [total_haberes] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [total_haberes]
	  --+ CAST(replace(cast(([total_haberes]) as decimal(18,2)),'.','') AS VARCHAR(9))       
	  +total_haberes
      + REPLICATE('0', 9- len(ltrim(CAST(replace(cast( [total_descuentos] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [total_descuentos]
	  + CAST(replace(cast(([total_descuentos]) as decimal(18,2)),'.','') AS VARCHAR(9))  -- [total_descuentos]	  
	  +  REPLICATE('0', 9- len(ltrim(CAST(replace(total_liquido,'.','') AS VARCHAR(9))))) -- RELLENO [total_liquido]
	  + CAST(replace(total_liquido,'.','') AS VARCHAR(9)) -- total_liquido
       as encabezado
      ,[C01]
      --,[I01]
	  , REPLICATE('0', 9- len(ltrim(CAST(replace(cast( [I01] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [I01]
	  + CAST(replace(cast(([I01]) as decimal(18,2)),'.','') AS VARCHAR(9)) AS [I01]                 
      ,[C02]	  
      --,[I02]
	  , REPLICATE('0', 9- len(ltrim(CAST(replace(cast( I02 as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [I02]
	  + CAST(replace(cast((I02) as decimal(18,2)),'.','') AS VARCHAR(9)) AS [I02]                 
      ,[C03]
      --,[I03]
	  , REPLICATE('0', 9- len(ltrim(CAST(replace(cast( [I03] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [[I03]]
	  + CAST(replace(cast(([I03]) as decimal(18,2)),'.','') AS VARCHAR(9)) AS [I03]             
      ,[C04]
      --,[I04]
	  , REPLICATE('0', 9- len(ltrim(CAST(replace(cast( [I04] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [[[I04]]]
	  + CAST(replace(cast(([I04]) as decimal(18,2)),'.','') AS VARCHAR(9)) AS [I04]                 
      ,[C05]
      --,[I05]
	  , REPLICATE('0', 9- len(ltrim(CAST(replace(cast( [I05] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [[[[I05]]]]
	  + CAST(replace(cast(([I05]) as decimal(18,2)),'.','') AS VARCHAR(9)) AS [I05]             
      ,[C06]
      --,[I06]
	  , REPLICATE('0', 9- len(ltrim(CAST(replace(cast( [I06] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [[[[[I06]]]]]
	  + CAST(replace(cast(([I06]) as decimal(18,2)),'.','') AS VARCHAR(9)) AS [I06]    
      ,[C07]
      --,[I07]
	   , REPLICATE('0', 9- len(ltrim(CAST(replace(cast( [I07] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [[[[[[I07]]]]]]
	  + CAST(replace(cast(([I07]) as decimal(18,2)),'.','') AS VARCHAR(9)) AS [I07]    
      ,[C08]
      --,[I08]
	   ,REPLICATE('0', 9- len(ltrim(CAST(replace(cast( [I08] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [[[[[[I08]]]]]]
	  + CAST(replace(cast(([I08]) as decimal(18,2)),'.','') AS VARCHAR(9)) AS [I08]    
FROM 
	agentes_extension_docente



GO
