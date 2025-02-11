USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Parametro.ObtenerBuscador]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Parametro.ObtenerBuscador]
(
@ValorABuscar varchar(500)
)
as

select isnull(par.parNombre,' ') + '[' + convert(varchar(10),par.parId) + ']' as Resultado
from Parametro par
where par.parActivo = 1
and isnull(par.parNombre,' ') like '%' + @ValorABuscar + '%'
GO
