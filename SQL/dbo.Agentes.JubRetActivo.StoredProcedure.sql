USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.JubRetActivo]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.JubRetActivo]
@id int, @JubRetActivo int
as
UPDATE PruebasAge set JubRetActivo=@JubRetActivo 
WHERE PruebasAge.NuevoAgeId1=@id
GO
