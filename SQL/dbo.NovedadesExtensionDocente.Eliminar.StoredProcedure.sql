USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadesExtensionDocente.Eliminar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NovedadesExtensionDocente.Eliminar]
@id int,
@usu_id int
AS

UPDATE 
	NovedadesExtensionDocente 
SET
	activo = 0,
	usuElimina_id = @usu_id,
	fechaHoraElimina = (SELECT GETDATE())
WHERE 
	1 = 1
AND id = @id
AND activo = 1
GO
