USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[LugarPago.ObtenerPorCodigo]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LugarPago.ObtenerPorCodigo]
@LugarPagoCodigo int
AS
BEGIN
select [lpaId],[lpaNombre] from LugarPago where lpaCodigo = @LugarPagoCodigo
END

GO
