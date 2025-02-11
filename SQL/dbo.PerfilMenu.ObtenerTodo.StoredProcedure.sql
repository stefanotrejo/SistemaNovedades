USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PerfilMenu.ObtenerTodo]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PerfilMenu.ObtenerTodo]

as

select PerfilMenu.pmeId as [Id], 
Perfil_perId.perNombre as [Perfil], 
Menu_menId.menNombre as [Menu], 
case when PerfilMenu.pmeActivo = 0 then 'No' else 'Si' end as [Activo], 
Usuario_usuIdCreacion.usuNombre as [Usuario Creacion], 
Usuario_usuIdUltimaModificacion.usuNombre as [Usuario UltimaModificacion], 
convert(varchar(10),PerfilMenu.pmeFechaHoraCreacion,103) as [FechaHoraCreacion], 
convert(varchar(10),PerfilMenu.pmeFechaHoraUltimaModificacion,103) as [FechaHoraUltimaModificacion],
PerfilMenu.pmeId, 
PerfilMenu.perId, 
PerfilMenu.menId, 
PerfilMenu.pmeActivo, 
PerfilMenu.usuIdCreacion, 
PerfilMenu.usuIdUltimaModificacion, 
PerfilMenu.pmeFechaHoraCreacion, 
PerfilMenu.pmeFechaHoraUltimaModificacion

from PerfilMenu
left outer join Perfil as Perfil_perId on PerfilMenu.perId = Perfil_perId.perId
left outer join Menu as Menu_menId on PerfilMenu.menId = Menu_menId.menId
left outer join Usuario as Usuario_usuIdCreacion on PerfilMenu.usuIdCreacion = Usuario_usuIdCreacion.usuId
left outer join Usuario as Usuario_usuIdUltimaModificacion on PerfilMenu.usuIdUltimaModificacion = Usuario_usuIdUltimaModificacion.usuId

order by 1
GO
