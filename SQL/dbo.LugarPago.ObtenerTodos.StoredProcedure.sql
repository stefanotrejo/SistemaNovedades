USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[LugarPago.ObtenerTodos]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LugarPago.ObtenerTodos]
AS
BEGIN
select [lpaId],[lpaNombre], [lpaCodigo] from LugarPago
END

GO
