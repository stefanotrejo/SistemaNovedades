USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[LiquidacionNovedades.ActualizarEstado]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LiquidacionNovedades.ActualizarEstado]
(
@liqId int,
@liqEstado varchar(1)
)

as

update Liquidacion 
set 
	liqEstado = @liqEstado,
	liqFechaCierre = case when @liqEstado != 'A' then getdate() else null end
where 1 = 1
and liqId = @liqId

GO
