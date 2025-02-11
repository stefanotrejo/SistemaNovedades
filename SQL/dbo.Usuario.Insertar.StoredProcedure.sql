USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Usuario.Insertar]
(
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

insert into Usuario
(
usuApellido,
usuNombre,
usuNombreIngreso,
usuClave,
usuClaveProvisoria,
usuCambiarClave,
usuEmail,
perId,
usuIdCreacion,
usuIdUltimaModificacion,
usuFechaHoraCreacion,
usuFechaHoraUltimaModificacion,
usuActivo
)

values
(
@usuApellido,
@usuNombre,
@usuNombreIngreso,
@usuClave,
@usuClaveProvisoria,
@usuCambiarClave,
@usuEmail,
@perId,
@usuIdCreacion,
@usuIdUltimaModificacion,
@usuFechaHoraCreacion,
@usuFechaHoraUltimaModificacion,
@usuActivo
)

select @@identity as IdMax
GO
