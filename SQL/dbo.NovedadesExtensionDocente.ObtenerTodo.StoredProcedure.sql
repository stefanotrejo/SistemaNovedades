USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadesExtensionDocente.ObtenerTodo]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script para el comando SelectTopNRows de SSMS  ******/
CREATE PROCEDURE [dbo].[NovedadesExtensionDocente.ObtenerTodo] 
(
	@liq_id int
)
AS

SELECT 
	 [id]
    ,[age_id]
    ,[age_nrocontrol]
    ,[dias_descontar]
    ,[liq_id]
    ,[usu_id]
    ,[fechaHoraCrea]
    ,[fechaHoraActualiza]
    ,[fechaHoraElimina]
    ,[usuCrea_id]
    ,[usuActualiza_id]
    ,[usuElimina_id]
    ,[activo]
FROM
	NovedadesExtensionDocente
WHERE
	liq_id = @liq_id
GO
