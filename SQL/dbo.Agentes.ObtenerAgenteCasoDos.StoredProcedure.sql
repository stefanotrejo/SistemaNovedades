USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ObtenerAgenteCasoDos]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ObtenerAgenteCasoDos]
	@MesAnioLiquidacion varchar(5), @nrocontrol varchar(50)
AS 

SELECT PAG.NuevoAgeId1 as Id,PAG.NroCOntrol as "Control", pag.DiasTrabajados as "DiasNoTrabajados"
  FROM [LiquidacionSueldos].[dbo].[PruebasAge] PAG
  where 
  PAG.MesAnioLiq=@MesAnioLiquidacion
  AND PAG.NroCOntrol=@nrocontrol
  AND PAG.SituRev='1'
  AND PAG.Liquido=0

GO
