USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Menu.ObtenerBuscador]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Menu.ObtenerBuscador]
(
@ValorABuscar varchar(500)
)
as

select isnull(men.menNombre,' ') + '[' + convert(varchar(10),men.menId) + ']' as Resultado
from Menu men
where men.menActivo = 1
and isnull(men.menNombre,' ') like '%' + @ValorABuscar + '%'
GO
