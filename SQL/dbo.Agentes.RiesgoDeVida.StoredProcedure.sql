USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.RiesgoDeVida]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.RiesgoDeVida]
@id int, @RiesgoDeVida int
as
UPDATE PruebasAge set RiesgoDeVida=@RiesgoDeVida 
WHERE PruebasAge.NuevoAgeId1=@id
GO
