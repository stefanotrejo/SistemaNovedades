USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Menu.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Menu.Insertar]
(
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

insert into Menu
(
menNombre,
menIdPadre,
menOrden,
menUrl,
menIcono,
menEsMenu,
menActivo,
usuIdCreacion,
usuIdUltimaModificacion,
menFechaHoraCreacion,
menFechaHoraUltimaModificacion
)

values
(
@menNombre,
@menIdPadre,
@menOrden,
@menUrl,
@menIcono,
@menEsMenu,
@menActivo,
@usuIdCreacion,
@usuIdUltimaModificacion,
@menFechaHoraCreacion,
@menFechaHoraUltimaModificacion
)

select @@identity as IdMax
GO
