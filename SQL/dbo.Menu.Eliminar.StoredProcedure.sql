USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Menu.Eliminar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Menu.Eliminar]
(
@menId int
)

as
delete from Menu
where 1 = 1 
and Menu.menId = @menId
GO
