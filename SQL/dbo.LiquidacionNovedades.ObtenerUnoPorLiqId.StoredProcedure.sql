USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[LiquidacionNovedades.ObtenerUnoPorLiqId]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LiquidacionNovedades.ObtenerUnoPorLiqId]
@liqId int
AS
BEGIN 
select * 
from Liquidacion
WHERE
liqId=@liqId
END

GO
