USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarClave.Eliminar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RecuperarClave.Eliminar]
(
@rclId int
)

as
delete from RecuperarClave
where 1 = 1 
and RecuperarClave.rclId = @rclId
GO
