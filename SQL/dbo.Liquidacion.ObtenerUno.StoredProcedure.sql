USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Liquidacion.ObtenerUno]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Liquidacion.ObtenerUno]
@periodo varchar(10)
AS
BEGIN 
SELECT DISTINCT MesAnioLiq as "Periodo de Liquidacion"
FROM PruebasAge
WHERE MesAnioLiq=@periodo
END
GO
