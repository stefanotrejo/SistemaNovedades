USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Parametro.Actualizar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Parametro.Actualizar]
(
@parId int,
@parNombre varchar(50),
@parValor varchar(max),
@parActivo tinyint,
@usuIdCreacion int,
@usuIdUltimaModificacion int,
@parFechaHoraCreacion datetime,
@parFechaHoraUltimaModificacion datetime
)

as

update Parametro set
parNombre = @parNombre,
parValor = @parValor,
parActivo = @parActivo,
usuIdCreacion = @usuIdCreacion,
usuIdUltimaModificacion = @usuIdUltimaModificacion,
parFechaHoraCreacion = @parFechaHoraCreacion,
parFechaHoraUltimaModificacion = @parFechaHoraUltimaModificacion

where 1 = 1
and parId = @parId
GO
