USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.InsertarAgenteRevision]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.InsertarAgenteRevision]
	@id int
AS 
INSERT INTO AgenteRevision (ageId) values (@id)
GO
