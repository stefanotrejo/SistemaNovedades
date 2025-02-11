USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[LiquidacionNovedades.Actualizar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LiquidacionNovedades.Actualizar] 
@liqId int,
@liqDescripcion varchar(100),
@liqMes varchar(50),
@liqAnio varchar(50),
@liqEtapa tinyint,
@liqEstado varchar(1),
@liqFechaInicio datetime,
@liqFechaCierre datetime,
@liqActivo int

AS

update Liquidacion set

liqDescripcion = @liqDescripcion,
liqMes = @liqMes,
liqAnio = @liqAnio,
liqEtapa = @liqEtapa,
liqEstado = @liqEstado,
liqFechaInicio = @liqFechaInicio,
liqFechaCierre = @liqFechaCierre,
liqActivo = @liqActivo

where 1 = 1
and liqId = @liqId

GO
