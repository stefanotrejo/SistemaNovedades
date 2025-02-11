USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Liquidacion.ObtenerLiqPorAnio]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Liquidacion.ObtenerLiqPorAnio]
(
@anio INT
)
AS
BEGIN
SELECT 
DISTINCT 
convert(varchar, FechaLiquidacion, 103) 
as "Periodo de Liquidacion", MesAnioLiq as "Mes", 
FechaLiquidacion, 
--SUBSTRING(mesanioliq,0,3) as "MesLiq",
DATEPART(MONTH,FechaLiquidacion) as "MesLiq"
--DATEPART(YEAR,FechaLiquidacion) as "AnioLiq"
--'20'+SUBSTRING(mesanioliq,4,3) as "AnioLiq"
FROM PruebasAge 
WHERE DATEPART(YEAR,FechaLiquidacion)=@anio
order by FechaLiquidacion ASC
END
GO
