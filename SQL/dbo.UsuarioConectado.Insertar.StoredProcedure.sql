USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[UsuarioConectado.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UsuarioConectado.Insertar]
(
@usuId int,
@ucoFechaHoraUltimaConexion datetime,
@ucoGuid varchar(max),
@ucoIpPublica varchar(50),
@ucoDesconectar tinyint,
@ucoActivo tinyint,
@usuIdCreacion int,
@usuIdUltimaModificacion int,
@ucoFechaHoraCreacion datetime,
@ucoFechaHoraUltimaModificacion datetime
)

as

insert into UsuarioConectado
(
usuId,
ucoFechaHoraUltimaConexion,
ucoGuid,
ucoIpPublica,
ucoDesconectar,
ucoActivo,
usuIdCreacion,
usuIdUltimaModificacion,
ucoFechaHoraCreacion,
ucoFechaHoraUltimaModificacion
)

values
(
@usuId,
@ucoFechaHoraUltimaConexion,
@ucoGuid,
@ucoIpPublica,
@ucoDesconectar,
@ucoActivo,
@usuIdCreacion,
@usuIdUltimaModificacion,
@ucoFechaHoraCreacion,
@ucoFechaHoraUltimaModificacion
)

select @@identity as IdMax
GO
