USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[UsuarioConectado.Actualizar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UsuarioConectado.Actualizar]
(
@ucoId int,
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

update UsuarioConectado set
usuId = @usuId,
ucoFechaHoraUltimaConexion = @ucoFechaHoraUltimaConexion,
ucoGuid = @ucoGuid,
ucoIpPublica = @ucoIpPublica,
ucoDesconectar = @ucoDesconectar,
ucoActivo = @ucoActivo,
usuIdCreacion = @usuIdCreacion,
usuIdUltimaModificacion = @usuIdUltimaModificacion,
ucoFechaHoraCreacion = @ucoFechaHoraCreacion,
ucoFechaHoraUltimaModificacion = @ucoFechaHoraUltimaModificacion

where 1 = 1
and ucoId = @ucoId
GO
