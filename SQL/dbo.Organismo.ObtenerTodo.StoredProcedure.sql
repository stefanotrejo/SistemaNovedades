USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Organismo.ObtenerTodo]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Organismo.ObtenerTodo]
	
AS
BEGIN
	select * from LugarPago
END



GO
