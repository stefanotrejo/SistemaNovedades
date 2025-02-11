USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ObtenerAgentesCasoCuatro]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ObtenerAgentesCasoCuatro]
	@MesAnioLiquidacion varchar(5)
AS 
SELECT PAG.NuevoAgeId1 as Id,PAG.NroCOntrol as "Control", PAG.SituRev, Cuil
  FROM [LiquidacionSueldos].[dbo].[PruebasAge] PAG
  where 
  PAG.MesAnioLiq=@MesAnioLiquidacion
  AND PAG.SituRev='5'
  AND EXISTS 
  (SELECT * FROM PruebasAge PAG2 WHERE 
  PAG2.NroCOntrol=PAG.NroCOntrol
  AND SUBSTRING(PAG2.Cuil,3,8)=SUBSTRING(PAG.Cuil,3,8)
  AND PAG2.SituRev='1' 
  AND PAG2.MesAnioLiq=@MesAnioLiquidacion)
  order by NuevoAgeId1

  --SELECT Nombre,SituRev, NroCOntrol 
  ----SELECT *
  --from PruebasAge where NroCOntrol=46002913 and MesAnioLiq='12/16'
GO
