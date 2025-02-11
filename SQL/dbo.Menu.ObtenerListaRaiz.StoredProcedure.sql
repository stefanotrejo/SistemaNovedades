USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Menu.ObtenerListaRaiz]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Menu.ObtenerListaRaiz]
(
@PrimerItem varchar(500)
)
as

select 0 as Valor, @PrimerItem as Texto, -1 as menOrden
union all
select menId as Valor, menNombre as Texto, menOrden
from Menu
where 1 = 1
and menActivo = 1
and menIdPadre = 0
order by 3
GO
