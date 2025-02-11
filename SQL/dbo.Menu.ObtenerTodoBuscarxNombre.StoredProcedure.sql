USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Menu.ObtenerTodoBuscarxNombre]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Menu.ObtenerTodoBuscarxNombre]
(
@Nombre varchar(50)
)
as

select Menu.menId as [Id], 
isnull(Menu.menNombre,' ') as [Nombre], 
Menu_menIdPadre.menNombre as [Menu Padre], 
Menu.menOrden as [Orden], 
isnull(Menu.menUrl,' ') as [Url], 
isnull(Menu.menIcono,' ') as [Icono], 
case when Menu.menEsMenu = 0 then 'No' else 'Si' end as [EsMenu], 
case when Menu.menActivo = 0 then 'No' else 'Si' end as [Activo], 
Usuario_usuIdCreacion.usuNombre as [Usuario Creacion], 
Usuario_usuIdUltimaModificacion.usuNombre as [Usuario UltimaModificacion], 
convert(varchar(10),Menu.menFechaHoraCreacion,103) as [FechaHoraCreacion], 
convert(varchar(10),Menu.menFechaHoraUltimaModificacion,103) as [FechaHoraUltimaModificacion],
Menu.menId, 
Menu.menNombre, 
Menu.menIdPadre, 
Menu.menOrden, 
Menu.menUrl, 
Menu.menIcono, 
Menu.menEsMenu, 
Menu.menActivo, 
Menu.usuIdCreacion, 
Menu.usuIdUltimaModificacion, 
Menu.menFechaHoraCreacion, 
Menu.menFechaHoraUltimaModificacion

from Menu
left outer join Menu as Menu_menIdPadre on Menu.menIdPadre = Menu_menIdPadre.menId
left outer join Usuario as Usuario_usuIdCreacion on Menu.usuIdCreacion = Usuario_usuIdCreacion.usuId
left outer join Usuario as Usuario_usuIdUltimaModificacion on Menu.usuIdUltimaModificacion = Usuario_usuIdUltimaModificacion.usuId
where isnull(Menu.menNombre,' ') like '%' + @Nombre + '%'
order by Menu.menNombre
GO
