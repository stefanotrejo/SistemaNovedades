USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarClave.InsertarCustom]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RecuperarClave.InsertarCustom]
(
@Usuario varchar(50),
@Email varchar(50),
@UsuarioEncriptado varchar(max),
@EmailEncriptado varchar(max)
)

as

declare @Existe int
select @Existe = COUNT(*) from RecuperarClave where rclUsuario = @Usuario and rclEmailRecuperacion = @Email

if @Existe = 0
	begin
	insert into RecuperarClave select GETDATE(), @Usuario, @Email,
	@UsuarioEncriptado, @EmailEncriptado,
	1,1,1,null,null
	end
else
	begin
	update RecuperarClave set rclFecha = GETDATE() 
	where rclUsuario = @Usuario and rclEmailRecuperacion = @Email
end
GO
