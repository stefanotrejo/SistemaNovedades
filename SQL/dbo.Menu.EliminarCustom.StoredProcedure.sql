USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Menu.EliminarCustom]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Menu.EliminarCustom]
(
@menId int
)
as

begin tran

delete from Menu where menIdPadre = @menId
delete from Menu where menId = @menId

commit tran
GO
