USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarClave.ObtenerConValoresEncriptados]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RecuperarClave.ObtenerConValoresEncriptados]
(
@UsuarioEncriptado varchar(max),
@EmailEncriptado varchar(max)
)

as

delete from RecuperarClave where DATEADD(mm,20,rclFecha) < GETDATE()

select * 
from RecuperarClave
where rclUsuarioEncriptado = @UsuarioEncriptado 
and rclEmailRecuperacionEncriptado = @EmailEncriptado


GO
