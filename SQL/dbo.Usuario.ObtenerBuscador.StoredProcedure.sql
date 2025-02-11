USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.ObtenerBuscador]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Usuario.ObtenerBuscador]
(
@ValorABuscar varchar(500)
)
as

select isnull(usu.usuNombre,' ') + '[' + convert(varchar(10),usu.usuId) + ']' as Resultado
from Usuario usu
where usu.usuActivo = 1
and isnull(usu.usuNombre,' ') like '%' + @ValorABuscar + '%'
GO
