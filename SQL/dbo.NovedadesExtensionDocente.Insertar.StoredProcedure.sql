USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadesExtensionDocente.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NovedadesExtensionDocente.Insertar] 

@age_id int,
@age_nrocontrol int,
@dias_descontar int,
@liq_id int,
@usu_id int,
@fechaHoraCrea datetime,
@fechaHoraActualiza datetime,
@fechaHoraElimina datetime,
@usuCrea_id int,
@usuActualiza_id int,
@usuElimina_id int,
@activo tinyint

AS
BEGIN

INSERT INTO 
	NovedadesExtensionDocente
(
	age_id,
	age_nrocontrol,
	dias_descontar,
	liq_id,
	usu_id,
	fechaHoraCrea,
	fechaHoraActualiza,
	fechaHoraElimina,
	usuCrea_id,
	usuActualiza_id,
	usuElimina_id,
	activo
) 
VALUES 
(
	@age_id ,
	@age_nrocontrol ,
	@dias_descontar ,
	@liq_id ,
	@usu_id ,
	@fechaHoraCrea ,
	@fechaHoraActualiza ,
	@fechaHoraElimina ,
	@usuCrea_id ,
	@usuActualiza_id ,
	@usuElimina_id ,
	1
) 

SELECT @@IDENTITY 
END
GO
