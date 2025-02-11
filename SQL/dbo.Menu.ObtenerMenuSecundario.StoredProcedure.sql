USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Menu.ObtenerMenuSecundario]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Menu.ObtenerMenuSecundario]
(
@menIdPadre int
)
as

select menId as Id, menNombre as Nombre, menUrl as Url, 
case when menActivo = 1 then 'Si' else 'No' end as Activo
from Menu 
where 1 = 1
and menIdPadre = @menIdPadre
order by menNombre


GO
