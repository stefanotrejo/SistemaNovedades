USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Perfil.Actualizar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Perfil.Actualizar]
(
@perId int,
@perNombre varchar(50),
@perDescripcion varchar(250),
@perEsAdministrador tinyint,
@usuIdCreacion int,
@usuIdUltimaModificacion int,
@perFechaHoraCreacion datetime,
@perFechaHoraUltimaModificacion datetime,
@perActivo tinyint
)

as

update Perfil set
perNombre = @perNombre,
perDescripcion = @perDescripcion,
perEsAdministrador = @perEsAdministrador,
usuIdCreacion = @usuIdCreacion,
usuIdUltimaModificacion = @usuIdUltimaModificacion,
perFechaHoraCreacion = @perFechaHoraCreacion,
perFechaHoraUltimaModificacion = @perFechaHoraUltimaModificacion,
perActivo = @perActivo

where 1 = 1
and perId = @perId
GO
