USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.Actualizar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Usuario.Actualizar]
(
@usuId int,
@usuApellido varchar(500),
@usuNombre varchar(500),
@usuNombreIngreso varchar(50),
@usuClave varchar(500),
@usuClaveProvisoria varchar(max),
@usuCambiarClave tinyint,
@usuEmail varchar(500),
@perId int,
@usuIdCreacion int,
@usuIdUltimaModificacion int,
@usuFechaHoraCreacion datetime,
@usuFechaHoraUltimaModificacion datetime,
@usuActivo tinyint
)

as

update Usuario set
usuApellido = @usuApellido,
usuNombre = @usuNombre,
usuNombreIngreso = @usuNombreIngreso,
usuClave = @usuClave,
usuClaveProvisoria = @usuClaveProvisoria,
usuCambiarClave = @usuCambiarClave,
usuEmail = @usuEmail,
perId = @perId,
usuIdCreacion = @usuIdCreacion,
usuIdUltimaModificacion = @usuIdUltimaModificacion,
usuFechaHoraCreacion = @usuFechaHoraCreacion,
usuFechaHoraUltimaModificacion = @usuFechaHoraUltimaModificacion,
usuActivo = @usuActivo

where 1 = 1
and usuId = @usuId
GO
