USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PerfilMenu.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PerfilMenu.Insertar]
(
@perId int,
@menId int,
@pmeActivo tinyint,
@usuIdCreacion int,
@usuIdUltimaModificacion int,
@pmeFechaHoraCreacion datetime,
@pmeFechaHoraUltimaModificacion datetime
)

as

insert into PerfilMenu
(
perId,
menId,
pmeActivo,
usuIdCreacion,
usuIdUltimaModificacion,
pmeFechaHoraCreacion,
pmeFechaHoraUltimaModificacion
)

values
(
@perId,
@menId,
@pmeActivo,
@usuIdCreacion,
@usuIdUltimaModificacion,
@pmeFechaHoraCreacion,
@pmeFechaHoraUltimaModificacion
)

select @@identity as IdMax
GO
