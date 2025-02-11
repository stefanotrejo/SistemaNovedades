USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Menu.MenuXPerfil]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Menu.MenuXPerfil]
	@perId int
AS
SELECT        dbo.Usuario.usuNombre, dbo.Perfil.perId, dbo.Perfil.perNombre, dbo.Menu.menNombre, dbo.PerfilMenu.pmeId, dbo.Menu.menId
FROM            dbo.PerfilMenu INNER JOIN
                         dbo.Perfil ON dbo.PerfilMenu.perId = dbo.Perfil.perId INNER JOIN
                         dbo.Menu ON dbo.PerfilMenu.menId = dbo.Menu.menId INNER JOIN
                         dbo.Usuario ON dbo.Perfil.perId = dbo.Usuario.perId
WHERE perfilmenu.perId=@perId
GO
