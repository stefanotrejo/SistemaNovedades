USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[LiquidacionNovedades.hayLiquidacionesAbiertas]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[LiquidacionNovedades.hayLiquidacionesAbiertas]
as
   select COUNT(liqid) FROM Liquidacion
   WHERE liqEstado='A'
GO
