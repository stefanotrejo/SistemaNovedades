USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ActualizarFonid]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ActualizarFonid]
@id int, @fonid numeric(18,2)
as
UPDATE PruebasAge set Fonid=@fonid 
WHERE PruebasAge.NuevoAgeId1=@id
GO
