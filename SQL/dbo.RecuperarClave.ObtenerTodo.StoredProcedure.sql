USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarClave.ObtenerTodo]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RecuperarClave.ObtenerTodo]

as

select RecuperarClave.rclId as [Id], 
convert(varchar(10),RecuperarClave.rclFecha,103) as [Fecha], 
isnull(RecuperarClave.rclUsuario,' ') as [Usuario], 
isnull(RecuperarClave.rclEmailRecuperacion,' ') as [EmailRecuperacion], 
isnull(RecuperarClave.rclUsuarioEncriptado,' ') as [UsuarioEncriptado], 
isnull(RecuperarClave.rclEmailRecuperacionEncriptado,' ') as [EmailRecuperacionEncriptado], 
case when RecuperarClave.rclActivo = 0 then 'No' else 'Si' end as [Activo], 
Usuario_usuIdCreacion.usuNombre as [Usuario Creacion], 
Usuario_usuIdUltimaModificacion.usuNombre as [Usuario UltimaModificacion], 
convert(varchar(10),RecuperarClave.rclFechaHoraCreacion,103) as [FechaHoraCreacion], 
convert(varchar(10),RecuperarClave.rclFechaHoraUltimaModificacion,103) as [FechaHoraUltimaModificacion],
RecuperarClave.rclId, 
RecuperarClave.rclFecha, 
RecuperarClave.rclUsuario, 
RecuperarClave.rclEmailRecuperacion, 
RecuperarClave.rclUsuarioEncriptado, 
RecuperarClave.rclEmailRecuperacionEncriptado, 
RecuperarClave.rclActivo, 
RecuperarClave.usuIdCreacion, 
RecuperarClave.usuIdUltimaModificacion, 
RecuperarClave.rclFechaHoraCreacion, 
RecuperarClave.rclFechaHoraUltimaModificacion

from RecuperarClave
left outer join Usuario as Usuario_usuIdCreacion on RecuperarClave.usuIdCreacion = Usuario_usuIdCreacion.usuId
left outer join Usuario as Usuario_usuIdUltimaModificacion on RecuperarClave.usuIdUltimaModificacion = Usuario_usuIdUltimaModificacion.usuId

order by 1
GO
