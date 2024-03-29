USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[EmailSalida.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EmailSalida.Insertar]
(
@esaFecha datetime,
@esaPara varchar(max),
@esaTipo varchar(50),
@esaTitulo varchar(max),
@esaCuerpo varchar(max),
@esaDescripcion varchar(max),
@cuoId int,
@esaActivo tinyint,
@usuIdCreacion int,
@usuIdUltimaModificacion int,
@esaFechaHoraCreacion datetime,
@esaFechaHoraUltimaModificacion datetime
)

as

insert into EmailSalida
(
esaFecha,
esaPara,
esaTipo,
esaTitulo,
esaCuerpo,
esaDescripcion,
cuoId,
esaActivo,
usuIdCreacion,
usuIdUltimaModificacion,
esaFechaHoraCreacion,
esaFechaHoraUltimaModificacion
)

values
(
@esaFecha,
@esaPara,
@esaTipo,
@esaTitulo,
@esaCuerpo,
@esaDescripcion,
@cuoId,
@esaActivo,
@usuIdCreacion,
@usuIdUltimaModificacion,
@esaFechaHoraCreacion,
@esaFechaHoraUltimaModificacion
)

select @@identity as IdMax
GO
