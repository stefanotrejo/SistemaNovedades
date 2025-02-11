USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[UsuarioConectado.ObtenerUno]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UsuarioConectado.ObtenerUno]
(
@ucoId int
)

as

select 
UsuarioConectado.ucoId as [Id], 
Usuario_usuId.usuNombre as [Usuario], 
convert(varchar(10),UsuarioConectado.ucoFechaHoraUltimaConexion,103) as [FechaHoraUltimaConexion], 
isnull(UsuarioConectado.ucoGuid,' ') as [Guid], 
isnull(UsuarioConectado.ucoIpPublica,' ') as [IpPublica], 
case when UsuarioConectado.ucoDesconectar = 0 then 'No' else 'Si' end as [Desconectar], 
case when UsuarioConectado.ucoActivo = 0 then 'No' else 'Si' end as [Activo], 
Usuario_usuIdCreacion.usuNombre as [Usuario Creacion], 
Usuario_usuIdUltimaModificacion.usuNombre as [Usuario UltimaModificacion], 
convert(varchar(10),UsuarioConectado.ucoFechaHoraCreacion,103) as [FechaHoraCreacion], 
convert(varchar(10),UsuarioConectado.ucoFechaHoraUltimaModificacion,103) as [FechaHoraUltimaModificacion], UsuarioConectado.ucoId,
UsuarioConectado.usuId,
UsuarioConectado.ucoFechaHoraUltimaConexion,
UsuarioConectado.ucoGuid,
UsuarioConectado.ucoIpPublica,
UsuarioConectado.ucoDesconectar,
UsuarioConectado.ucoActivo,
UsuarioConectado.usuIdCreacion,
UsuarioConectado.usuIdUltimaModificacion,
UsuarioConectado.ucoFechaHoraCreacion,
UsuarioConectado.ucoFechaHoraUltimaModificacion

from UsuarioConectado
left outer join Usuario as Usuario_usuId on UsuarioConectado.usuId = Usuario_usuId.usuId
left outer join Usuario as Usuario_usuIdCreacion on UsuarioConectado.usuIdCreacion = Usuario_usuIdCreacion.usuId
left outer join Usuario as Usuario_usuIdUltimaModificacion on UsuarioConectado.usuIdUltimaModificacion = Usuario_usuIdUltimaModificacion.usuId

where 1 = 1 
and UsuarioConectado.ucoId = @ucoId
GO
