USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadesExtensionDocente.ValidarRepetido]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NovedadesExtensionDocente.ValidarRepetido]
@nro_control int,
@liq_id int
AS

DECLARE @Existe int 

SELECT 
	@Existe = COUNT(*)
FROM 
	NovedadesExtensionDocente 
WHERE 
	1 = 1
AND age_nrocontrol = @nro_control
AND liq_id = @liq_id
AND activo = 1

SELECT @Existe AS Existe

GO
