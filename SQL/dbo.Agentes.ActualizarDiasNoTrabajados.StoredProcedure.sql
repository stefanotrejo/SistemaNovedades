USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ActualizarDiasNoTrabajados]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ActualizarDiasNoTrabajados]
@id as int, @diasnotrabajados varchar(5)
as
UPDATE PruebasAge set DiasNoTrabajados=@diasnotrabajados 
WHERE PruebasAge.NuevoAgeId1=@id
GO
