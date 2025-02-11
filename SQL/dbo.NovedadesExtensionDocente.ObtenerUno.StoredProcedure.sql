USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadesExtensionDocente.ObtenerUno]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NovedadesExtensionDocente.ObtenerUno] 
(
	@id int
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
	id = @id
GO
