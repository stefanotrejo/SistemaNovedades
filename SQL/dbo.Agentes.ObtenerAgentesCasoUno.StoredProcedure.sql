USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ObtenerAgentesCasoUno]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ObtenerAgentesCasoUno]
	@MesAnioLiquidacion varchar(5)
AS 

--SELECT PAG.NuevoAgeId1 as Id,PAG.NroCOntrol as "Control", PAG.SituRev, Cuil
----, SUBSTRING(Cuil,3,8)
--  FROM [LiquidacionSueldos].[dbo].[PruebasAge] PAG
--  where 
--  PAG.MesAnioLiq=@MesAnioLiquidacion
--  AND PAG.SituRev='R'
--  --PRUEBA
--  AND PAG.Nombre!='VACANTE'
--  AND EXISTS 
--  (SELECT * FROM PruebasAge PAG2 WHERE 
--  PAG2.NroCOntrol=PAG.NroCOntrol
--  AND SUBSTRING(PAG2.Cuil,3,8)=SUBSTRING(PAG.Cuil,3,8)
--  AND PAG2.SituRev='N' 
--  AND PAG2.MesAnioLiq=@MesAnioLiquidacion)

SELECT PAG.NuevoAgeId1 as Id,PAG.NroCOntrol as "Control", 
PAG.SituRev, Cuil
--, SUBSTRING(Cuil,3,8)
  FROM [LiquidacionSueldos].[dbo].[PruebasAge] PAG
  where 
  PAG.MesAnioLiq=@MesAnioLiquidacion
  AND PAG.SituRev='R'
  --PRUEBA
  --AND PAG.Nombre!='VACANTE'
  AND EXISTS 
  (SELECT * FROM PruebasAge PAG2 WHERE 
  PAG2.MesAnioLiq=@MesAnioLiquidacion 
  AND PAG2.NroCOntrol=PAG.NroCOntrol
  AND SUBSTRING(PAG2.Cuil,3,8)=SUBSTRING(PAG.Cuil,3,8)
  AND PAG2.SituRev='N')

  
  -- HACE DEMORAR LA CONSULTA
  --order by NuevoAgeId1
GO
