USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[EmailSalida.Actualizar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EmailSalida.Actualizar]
(
@esaId int,
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

update EmailSalida set
esaFecha = @esaFecha,
esaPara = @esaPara,
esaTipo = @esaTipo,
esaTitulo = @esaTitulo,
esaCuerpo = @esaCuerpo,
esaDescripcion = @esaDescripcion,
cuoId = @cuoId,
esaActivo = @esaActivo,
usuIdCreacion = @usuIdCreacion,
usuIdUltimaModificacion = @usuIdUltimaModificacion,
esaFechaHoraCreacion = @esaFechaHoraCreacion,
esaFechaHoraUltimaModificacion = @esaFechaHoraUltimaModificacion

where 1 = 1
and esaId = @esaId
GO
