USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Perfil.Eliminar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Perfil.Eliminar]
(
@perId int
)

as
delete from Perfil
where 1 = 1 
and Perfil.perId = @perId
GO
