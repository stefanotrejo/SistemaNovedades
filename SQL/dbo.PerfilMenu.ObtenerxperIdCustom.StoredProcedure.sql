USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PerfilMenu.ObtenerxperIdCustom]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PerfilMenu.ObtenerxperIdCustom]
(
@perId int
)
as

select PerfilMenu.pmeId as Id, 
MenuPadre.menNombre + '/' + Menu.menNombre as Menu, MenuPadre.menOrden, Menu.menOrden,
case when Menu.menActivo = 1 then 'Si' else 'No' end as Activo
from PerfilMenu, Menu, Perfil, Menu MenuPadre
where 1 = 1
and PerfilMenu.menId = Menu.menId
and PerfilMenu.perId = @perId
--and Menu.menActivo = 1
and PerfilMenu.perId = Perfil.perId
and Perfil.perActivo = 1
and Menu.menIdPadre = MenuPadre.menId
order by 3,4



GO
