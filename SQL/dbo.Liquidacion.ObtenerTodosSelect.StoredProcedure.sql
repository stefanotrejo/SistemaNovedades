USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Liquidacion.ObtenerTodosSelect]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Liquidacion.ObtenerTodosSelect]
as

select liqId, liqDescripcion
from Liquidacion
where liqActivo = 1
order by liqId DESC

GO
