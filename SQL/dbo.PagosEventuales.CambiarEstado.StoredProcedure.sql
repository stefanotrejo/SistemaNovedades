USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PagosEventuales.CambiarEstado]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PagosEventuales.CambiarEstado]
@fecha datetime 
AS
BEGIN
	update PagosEventuales set pevGenerado = 1, pevUtlimaVezGenerado = SYSDATETIME() where [pevFechaCarga] >= @fecha
END



GO
