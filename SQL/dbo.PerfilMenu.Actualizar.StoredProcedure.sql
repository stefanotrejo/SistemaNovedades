USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PerfilMenu.Actualizar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PerfilMenu.Actualizar]
(
@pmeId int,
@perId int,
@menId int,
@pmeActivo tinyint,
@usuIdCreacion int,
@usuIdUltimaModificacion int,
@pmeFechaHoraCreacion datetime,
@pmeFechaHoraUltimaModificacion datetime
)

as

update PerfilMenu set
perId = @perId,
menId = @menId,
pmeActivo = @pmeActivo,
usuIdCreacion = @usuIdCreacion,
usuIdUltimaModificacion = @usuIdUltimaModificacion,
pmeFechaHoraCreacion = @pmeFechaHoraCreacion,
pmeFechaHoraUltimaModificacion = @pmeFechaHoraUltimaModificacion

where 1 = 1
and pmeId = @pmeId
GO
