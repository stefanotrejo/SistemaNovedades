USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Organismo.ObtenerIdPorCodigo]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Organismo.ObtenerIdPorCodigo]
@orgCodigo varchar(50) 
AS
BEGIN
select orgId from Organismo where orgCodigo = @orgCodigo 
END


GO
