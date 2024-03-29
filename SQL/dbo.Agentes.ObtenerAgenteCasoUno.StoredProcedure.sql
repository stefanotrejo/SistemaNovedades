USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ObtenerAgenteCasoUno]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ObtenerAgenteCasoUno]
	@mesaniol varchar(5), @nrocontrol varchar(50)
AS 

SELECT PAG.NuevoAgeId1 as Id, pag.[HaberS/aporte] as HaberSinAporte
  FROM [LiquidacionSueldos].[dbo].[PruebasAge] PAG
  where 
  PAG.MesAnioLiq=@mesaniol
  AND Pag.NroCOntrol=@nrocontrol
  AND PAG.SituRev='N'
 

GO
