USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ActivarDesactivarRegistro]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Agentes.ActivarDesactivarRegistro]
@id as int, @activo tinyint
as
UPDATE PruebasAge set Activo=@activo 
WHERE PruebasAge.NuevoAgeId1=@id
GO
