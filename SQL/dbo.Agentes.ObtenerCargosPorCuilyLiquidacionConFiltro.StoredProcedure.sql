USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ObtenerCargosPorCuilyLiquidacionConFiltro]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ObtenerCargosPorCuilyLiquidacionConFiltro]
	@dni varchar(50), @periodo date, @periodo2 date, @ageId int
AS
BEGIN
SELECT PruebasAge.NuevoAgeId1 as Id, PruebasAge.MesAnioLiq as "Fecha Liquidacion"
FROM PruebasAge
WHERE  Substring(PruebasAge.Cuil,3,8)= @dni and PruebasAge.FechaLiquidacion>=@periodo 
and PruebasAge.FechaLiquidacion<=@periodo2 and PruebasAge.NuevoAgeId1!=@ageId
and PruebasAge.Activo=1
--AGREGADAS
AND PruebasAge.SituRev!='V'
AND PruebasAge.SituRev!='N'
--
order by FechaLiquidacion
END
GO
