USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.ObtenerTodoBuscarxNombre]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Usuario.ObtenerTodoBuscarxNombre]
(
@Nombre varchar(50)
)
as

select Usuario.usuId as [Id], 
isnull(Usuario.usuApellido,' ') as [Apellido], 
isnull(Usuario.usuNombre,' ') as [Nombre], 
isnull(Usuario.usuNombreIngreso,' ') as [NombreIngreso], 
isnull(Usuario.usuClave,' ') as [Clave], 
isnull(Usuario.usuClaveProvisoria,' ') as [ClaveProvisoria], 
case when Usuario.usuCambiarClave = 0 then 'No' else 'Si' end as [CambiarClave], 
isnull(Usuario.usuEmail,' ') as [Email], 
Perfil_perId.perNombre as [Perfil], 
Usuario_usuIdCreacion.usuNombre as [Usuario Creacion], 
Usuario_usuIdUltimaModificacion.usuNombre as [Usuario UltimaModificacion], 
convert(varchar(10),Usuario.usuFechaHoraCreacion,103) as [FechaHoraCreacion], 
convert(varchar(10),Usuario.usuFechaHoraUltimaModificacion,103) as [FechaHoraUltimaModificacion], 
case when Usuario.usuActivo = 0 then 'No' else 'Si' end as [Activo],
Usuario.usuId, 
Usuario.usuApellido, 
Usuario.usuNombre, 
Usuario.usuNombreIngreso, 
Usuario.usuClave, 
Usuario.usuClaveProvisoria, 
Usuario.usuCambiarClave, 
Usuario.usuEmail, 
Usuario.perId, 
Usuario.usuIdCreacion, 
Usuario.usuIdUltimaModificacion, 
Usuario.usuFechaHoraCreacion, 
Usuario.usuFechaHoraUltimaModificacion, 
Usuario.usuActivo

from Usuario
left outer join Perfil as Perfil_perId on Usuario.perId = Perfil_perId.perId
left outer join Usuario as Usuario_usuIdCreacion on Usuario.usuIdCreacion = Usuario_usuIdCreacion.usuId
left outer join Usuario as Usuario_usuIdUltimaModificacion on Usuario.usuIdUltimaModificacion = Usuario_usuIdUltimaModificacion.usuId
where isnull(Usuario.usuNombre,' ') like '%' + @Nombre + '%'
order by Usuario.usuNombre
GO
