USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Perfil.ObtenerBuscador]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Perfil.ObtenerBuscador]
(
@ValorABuscar varchar(500)
)
as

select isnull(per.perNombre,' ') + '[' + convert(varchar(10),per.perId) + ']' as Resultado
from Perfil per
where per.perActivo = 1
and isnull(per.perNombre,' ') like '%' + @ValorABuscar + '%'
GO
