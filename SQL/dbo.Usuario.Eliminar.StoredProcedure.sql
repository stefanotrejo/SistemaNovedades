USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.Eliminar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Usuario.Eliminar]
(
@usuId int
)

as
delete from Usuario
where 1 = 1 
and Usuario.usuId = @usuId
GO
