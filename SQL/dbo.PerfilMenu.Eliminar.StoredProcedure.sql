USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PerfilMenu.Eliminar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PerfilMenu.Eliminar]
(
@pmeId int
)

as
delete from PerfilMenu
where 1 = 1 
and PerfilMenu.pmeId = @pmeId
GO
