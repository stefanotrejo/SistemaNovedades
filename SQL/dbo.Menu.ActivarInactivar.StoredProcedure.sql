USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Menu.ActivarInactivar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Menu.ActivarInactivar]
(
@menId int
)

as

update Menu set menActivo = case when menActivo = 0 then 1 else 0 end where menId = @menId
GO
