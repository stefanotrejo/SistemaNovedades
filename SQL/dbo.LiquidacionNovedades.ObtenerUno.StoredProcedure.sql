USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[LiquidacionNovedades.ObtenerUno]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LiquidacionNovedades.ObtenerUno]
@mes varchar(10),
@anio varchar(10),
@etapa varchar(10)

AS
BEGIN 
select * 
from Liquidacion
WHERE liqMes=@mes
AND liqAnio=@anio
AND liqEtapa=@etapa
END

GO
