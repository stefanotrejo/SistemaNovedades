USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.AsistenciaPerfecta]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.AsistenciaPerfecta]
@id int, @asistenciaperfecta int
as
UPDATE PruebasAge set AsistenciaPerfecta=@asistenciaperfecta 
WHERE PruebasAge.NuevoAgeId1=@id
GO
