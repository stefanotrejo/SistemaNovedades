USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[UsuarioConectado.Eliminar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UsuarioConectado.Eliminar]
(
@ucoId int
)

as
delete from UsuarioConectado
where 1 = 1 
and UsuarioConectado.ucoId = @ucoId
GO
