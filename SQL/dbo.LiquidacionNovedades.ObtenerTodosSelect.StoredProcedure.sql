USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[LiquidacionNovedades.ObtenerTodosSelect]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LiquidacionNovedades.ObtenerTodosSelect]
as

select liqId AS Id, liqDescripcion as Nombre
from Liquidacion
where liqActivo = 1
order by liqAnio,liqMes DESC


GO
