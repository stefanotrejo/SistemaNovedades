USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.CambiarClave]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Usuario.CambiarClave]
(
@usuId int,
@usuClave varchar(5000)
)

as

update Usuario set usuClave = @usuClave where usuId = @usuId 

GO
