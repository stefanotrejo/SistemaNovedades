USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.BlanquearClaveUsuarioEmail]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usuario.BlanquearClaveUsuarioEmail]
(
@Usuario varchar(50),
@Email varchar(50)
)

as

declare @usuId int

select top 1 @usuId = usuId from Usuario
where usuNombreIngreso = @Usuario
and usuEmail = @Email

update Usuario set usuClave = 'hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==' where usuId = @usuId


GO
