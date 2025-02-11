USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarClave.Actualizar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RecuperarClave.Actualizar]
(
@rclId int,
@rclFecha datetime,
@rclUsuario varchar(max),
@rclEmailRecuperacion varchar(max),
@rclUsuarioEncriptado varchar(max),
@rclEmailRecuperacionEncriptado varchar(max),
@rclActivo tinyint,
@usuIdCreacion int,
@usuIdUltimaModificacion int,
@rclFechaHoraCreacion datetime,
@rclFechaHoraUltimaModificacion datetime
)

as

update RecuperarClave set
rclFecha = @rclFecha,
rclUsuario = @rclUsuario,
rclEmailRecuperacion = @rclEmailRecuperacion,
rclUsuarioEncriptado = @rclUsuarioEncriptado,
rclEmailRecuperacionEncriptado = @rclEmailRecuperacionEncriptado,
rclActivo = @rclActivo,
usuIdCreacion = @usuIdCreacion,
usuIdUltimaModificacion = @usuIdUltimaModificacion,
rclFechaHoraCreacion = @rclFechaHoraCreacion,
rclFechaHoraUltimaModificacion = @rclFechaHoraUltimaModificacion

where 1 = 1
and rclId = @rclId
GO
