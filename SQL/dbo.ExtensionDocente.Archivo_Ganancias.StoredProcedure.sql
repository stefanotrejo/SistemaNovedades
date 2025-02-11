USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[ExtensionDocente.Archivo_Ganancias]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExtensionDocente.Archivo_Ganancias]
AS

DECLARE @mesanio varchar(5)
SELECT @mesanio = ( 
					SELECT 
						mesanioliq 
					FROM 
						PruebasAge 
					WHERE 
						FechaLiquidacion = (SELECT MAX(fechaliquidacion) FROM PruebasAge) 
					GROUP BY 
						MesAnioLiq)

SELECT  			
		-- inicio encabezado
	    t1.NroCOntrol
	   +REPLICATE(' ',7) -- legajo
	   +t1.LugarPago
	   +t1.Escuela
	   +t2.Agru
	   +t2.tramo
	   +t2.Apertura
	   +t2.Categoria
	   +t2.[Nopres/RiesgoVida]
	   +t2.Juris
	   +t2.Prog
	   +'0' + t2.SubP
	   +'0' + t2.Actividad
	   --+t2.Nombre
	   +RTRIM(LTRIM(CAST(UPPER(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(t2.Nombre, 'ñ', 'n'),'/',''),'á','a'),'é','e'),'í','i'),'ó','o'),'ú','u'),'Ñ','N'),'´',''),'''',''),'Á','A'),'É','E'),'Í','I'),'Ó','O'),'Ú','U'),'¥','N')) AS VARCHAR(25)))) + 
	   +REPLICATE(' ', 25-len(LTRIM(CAST(UPPER(replace((replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(t2.Nombre, 'ñ', 'n'),'/',''),'á','a'),'é','e'),'í','i'),'ó','o'),'ú','u'),'Ñ','N'),'´',''),'''',''),'Á','A'),'É','E'),'Í','I'),'Ó','O'),'Ú','U')),'¥','N')) AS VARCHAR(25)))))
	   +t2.TipoDOc
	   +SUBSTRING(t2.Cuil,3,8) -- DNI
	   +REPLICATE(' ',7) -- nro carnet IOSEP
	   +t2.FechaIngreso
	   +t2.AniosAntig
	   +SUBSTRING(t2.AportePrevisional,2,1) -- aporte jubilatorio
	   +t2.AporteOsocNac -- aporte OSPLAD  !!VALIDAR!!
	   +t2.AporteIOSEP
	   +t2.Cuil
	   +t2.Sexo
	   +REPLICATE(' ',1) -- punto 24 a 34-- t2.Jubilado
	   +REPLICATE(' ',1)-- elim bonificacion punto 20
	   +REPLICATE(' ',1) -- punto 21 obra social nac.   punto 21
	   +t2.SituRev -- punto 22
	   +'R' -- fuente financiamiento punto 23
	   +REPLICATE(' ',11) -- punto 24 a 27
	   +t2.PlantaTipo -- punto 28
	   +REPLICATE(' ',6)-- punto 29
	   +REPLICATE(' ',1) -- punto 30 hamburgo
	   +REPLICATE(' ',1) -- punto 31 cat obra publica
	   +REPLICATE(' ',2) -- punto 32 ad prof perm cargo
	   +REPLICATE(' ',1) -- punto 33 aporte AESYA
	   +REPLICATE(' ',2) -- punto 34 hs catedra
	   +SUBSTRING(MesAnioLiq, 1,2) -- mes 
	   +SUBSTRING(MesAnioLiq, 4,2) -- anio
	   +'030' -- dias trabajados
	   +REPLICATE(' ',1) -- punto 38 planta p/t	  
	   +SUBSTRING(t1.haberConAporte,2, LEN(t1.haberconaporte))  --  punto 39 (6,2)
	   +t1.haberSinAporte -- punto 40 (7,2)
	   +t1.haberConAporte  --  punto 41 (7,2)
	   +t1.haberConAporte --  punto 42 (7,2)
	   +t1.total_haberes -- punto 43 (7,2)	
	   +REPLICATE('0', 9- len(ltrim(CAST(replace(cast( [total_descuentos] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [total_descuentos]
	    + CAST(replace(cast(([total_descuentos]) as decimal(18,2)),'.','') AS VARCHAR(9))  -- [total_descuentos]	  -- punto 44 (7,2)
	   +  REPLICATE('0', 9- len(ltrim(CAST(replace(t1.total_liquido,'.','') AS VARCHAR(9))))) -- RELLENO [total_liquido]
	    + CAST(replace(t1.total_liquido,'.','') AS VARCHAR(9)) -- total_liquido -- punto 45 (7,2)    
	   as encabezado
      ,t1.[C01]     
	  , REPLICATE('0', 9- len(ltrim(CAST(replace(cast( t1.[I01] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [I01]
	  + CAST(replace(cast((t1.[I01]) as decimal(18,2)),'.','') AS VARCHAR(9)) AS [I01]                 
      ,t1.[C02]	        
	  , REPLICATE('0', 9- len(ltrim(CAST(replace(cast( t1.I02 as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [I02]
	  + CAST(replace(cast((t1.I02) as decimal(18,2)),'.','') AS VARCHAR(9)) AS [I02]                 
      ,t1.[C03]      
	  , REPLICATE('0', 9- len(ltrim(CAST(replace(cast( t1.[I03] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [[I03]]
	  + CAST(replace(cast((t1.[I03]) as decimal(18,2)),'.','') AS VARCHAR(9)) AS [I03]             
      ,t1.[C04]      
	  , REPLICATE('0', 9- len(ltrim(CAST(replace(cast( t1.[I04] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [[[I04]]]
	  + CAST(replace(cast((t1.[I04]) as decimal(18,2)),'.','') AS VARCHAR(9)) AS [I04]                 
      ,t1.[C05]      
	  , REPLICATE('0', 9- len(ltrim(CAST(replace(cast( t1.[I05] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [[[[I05]]]]
	  + CAST(replace(cast((t1.[I05]) as decimal(18,2)),'.','') AS VARCHAR(9)) AS [I05]             
      ,t1.[C06]      
	  , REPLICATE('0', 9- len(ltrim(CAST(replace(cast( t1.[I06] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [[[[[I06]]]]]
	  + CAST(replace(cast((t1.[I06]) as decimal(18,2)),'.','') AS VARCHAR(9)) AS [I06]    
      ,t1.[C07]
	   , REPLICATE('0', 9- len(ltrim(CAST(replace(cast( t1.[I07] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [[[[[[I07]]]]]]
	  + CAST(replace(cast((t1.[I07]) as decimal(18,2)),'.','') AS VARCHAR(9)) AS [I07]    
      ,t1.[C08]      
	   ,REPLICATE('0', 9- len(ltrim(CAST(replace(cast( t1.[I08] as decimal(18,2)),'.','') AS VARCHAR(9))))) -- RELLENO [[[[[[I08]]]]]]
	  + CAST(replace(cast((t1.[I08]) as decimal(18,2)),'.','') AS VARCHAR(9)) AS [I08],
	   '00' AS numero_cuota,
	   '00' AS total_cuota
FROM 
	agentes_extension_docente t1
INNER JOIN PruebasAge t2
ON 
	t1.NroCOntrol = t2.NroCOntrol 
AND	t1.LugarPago = t2.LugarPago 
AND	t1.Escuela = t2.Escuela
AND	t1.Juris = t2.Juris
AND	t1.Prog = t2.Prog
AND	t1.SubP = t2.SubP
AND t2.Liquido > 0

WHERE t2.MesAnioLiq = @mesanio


GO
