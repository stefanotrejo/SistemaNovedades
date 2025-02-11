USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarClave.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RecuperarClave.Insertar]
(
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

insert into RecuperarClave
(
rclFecha,
rclUsuario,
rclEmailRecuperacion,
rclUsuarioEncriptado,
rclEmailRecuperacionEncriptado,
rclActivo,
usuIdCreacion,
usuIdUltimaModificacion,
rclFechaHoraCreacion,
rclFechaHoraUltimaModificacion
)

values
(
@rclFecha,
@rclUsuario,
@rclEmailRecuperacion,
@rclUsuarioEncriptado,
@rclEmailRecuperacionEncriptado,
@rclActivo,
@usuIdCreacion,
@usuIdUltimaModificacion,
@rclFechaHoraCreacion,
@rclFechaHoraUltimaModificacion
)

select @@identity as IdMax
GO
