USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.BlanquearClave]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usuario.BlanquearClave]
(
@usuId int
)

as

update Usuario set 

usuClave = 'hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==',
usuCambiarClave = 1

where usuId = @usuId


GO
