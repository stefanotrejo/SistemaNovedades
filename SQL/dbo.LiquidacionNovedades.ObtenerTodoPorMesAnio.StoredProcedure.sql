USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[LiquidacionNovedades.ObtenerTodoPorMesAnio]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LiquidacionNovedades.ObtenerTodoPorMesAnio]
(
@liqMes varchar(2),
@liqAnio varchar(2),
@liqEtapa int
)
AS
BEGIN
select *
from Liquidacion
WHERE
liqMes>=@liqMes
AND liqAnio>=@liqAnio
AND Liquidacion.liqEtapa = CASE 
        WHEN (@liqEtapa != 0)
        THEN  @liqEtapa
        ELSE Liquidacion.liqEtapa
    END
END


GO
