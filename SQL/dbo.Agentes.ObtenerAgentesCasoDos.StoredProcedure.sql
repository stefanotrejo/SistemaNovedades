USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ObtenerAgentesCasoDos]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ObtenerAgentesCasoDos]
	@MesAnioLiquidacion varchar(5)
AS 

SELECT PAG.NuevoAgeId1 as Id,PAG.NroCOntrol as "Control", PAG.SituRev, Cuil
--, SUBSTRING(Cuil,3,8)
  FROM [LiquidacionSueldos].[dbo].[PruebasAge] PAG
  where 
  PAG.MesAnioLiq=@MesAnioLiquidacion
  AND PAG.SituRev='1'
  AND PAG.Liquido!=0
  AND PAG.Nombre!='VACANTE'
  AND EXISTS 
  (SELECT * FROM PruebasAge PAG2 WHERE 
  PAG2.NroCOntrol=PAG.NroCOntrol
  AND SUBSTRING(PAG2.Cuil,3,8)=SUBSTRING(PAG.Cuil,3,8)
  AND PAG2.SituRev='1' 
  AND PAG2.Liquido=0
  AND PAG2.MesAnioLiq=@MesAnioLiquidacion)
  order by NuevoAgeId1
GO
