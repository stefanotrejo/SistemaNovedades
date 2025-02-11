USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Menu.Actualizar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Menu.Actualizar]
(
@menId int,
@menNombre varchar(250),
@menIdPadre int,
@menOrden int,
@menUrl varchar(500),
@menIcono varchar(500),
@menEsMenu tinyint,
@menActivo tinyint,
@usuIdCreacion int,
@usuIdUltimaModificacion int,
@menFechaHoraCreacion datetime,
@menFechaHoraUltimaModificacion datetime
)

as

update Menu set
menNombre = @menNombre,
menIdPadre = @menIdPadre,
menOrden = @menOrden,
menUrl = @menUrl,
menIcono = @menIcono,
menEsMenu = @menEsMenu,
menActivo = @menActivo,
usuIdCreacion = @usuIdCreacion,
usuIdUltimaModificacion = @usuIdUltimaModificacion,
menFechaHoraCreacion = @menFechaHoraCreacion,
menFechaHoraUltimaModificacion = @menFechaHoraUltimaModificacion

where 1 = 1
and menId = @menId
GO
