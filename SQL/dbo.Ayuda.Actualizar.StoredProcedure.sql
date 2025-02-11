USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Ayuda.Actualizar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Ayuda.Actualizar]
(
@ayuId int,
@ayuPaginaNombre varchar(max),
@ayuDescripcion varchar(max),
@ayuActivo tinyint,
@usuIdCreacion int,
@usuIdUltimaModificacion int,
@ayuFechaHoraCreacion datetime,
@ayuFechaHoraUltimaModificacion datetime
)

as

update Ayuda set
ayuPaginaNombre = @ayuPaginaNombre,
ayuDescripcion = @ayuDescripcion,
ayuActivo = @ayuActivo,
usuIdCreacion = @usuIdCreacion,
usuIdUltimaModificacion = @usuIdUltimaModificacion,
ayuFechaHoraCreacion = @ayuFechaHoraCreacion,
ayuFechaHoraUltimaModificacion = @ayuFechaHoraUltimaModificacion

where 1 = 1
and ayuId = @ayuId
GO
