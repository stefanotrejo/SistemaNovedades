USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[LiquidacionNovedades.ValidarDuplicado]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LiquidacionNovedades.ValidarDuplicado]
@liqMes varchar(50),
@liqAnio varchar(50),
@liqEtapa int
as

declare @Existe int 
select @Existe = count(*)
from Liquidacion 
where 1 = 1
and liqMes = @liqMes
and liqAnio = @liqAnio
and liqEtapa = @liqEtapa

select @Existe = case when @Existe > 1 then 1 else @Existe end
select @Existe as Existe


GO
