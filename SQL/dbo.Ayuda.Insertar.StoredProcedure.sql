USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Ayuda.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Ayuda.Insertar]
(
@ayuPaginaNombre varchar(max),
@ayuDescripcion varchar(max),
@ayuActivo tinyint,
@usuIdCreacion int,
@usuIdUltimaModificacion int,
@ayuFechaHoraCreacion datetime,
@ayuFechaHoraUltimaModificacion datetime
)

as

insert into Ayuda
(
ayuPaginaNombre,
ayuDescripcion,
ayuActivo,
usuIdCreacion,
usuIdUltimaModificacion,
ayuFechaHoraCreacion,
ayuFechaHoraUltimaModificacion
)

values
(
@ayuPaginaNombre,
@ayuDescripcion,
@ayuActivo,
@usuIdCreacion,
@usuIdUltimaModificacion,
@ayuFechaHoraCreacion,
@ayuFechaHoraUltimaModificacion
)

select @@identity as IdMax
GO
