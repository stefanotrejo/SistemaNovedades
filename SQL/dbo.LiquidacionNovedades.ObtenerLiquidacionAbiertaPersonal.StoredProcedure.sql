USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[LiquidacionNovedades.ObtenerLiquidacionAbiertaPersonal]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LiquidacionNovedades.ObtenerLiquidacionAbiertaPersonal]
as

select * from Liquidacion where 1 = 1  
and Liquidacion.liqEstado='P'
and Liquidacion.liqActivo=1
order by liqFechaInicio DESC


--declare @Existe int
--select @Existe = ( select liqId from Liquidacion where 1 = 1  and Liquidacion.liqEstado='A')
--select isnull(@Existe, 0) AS Existe
--select @Existe = count(*)

GO
