USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.Eliminar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NovedadInasistencia.Eliminar]
	@ninId int, @usuEliminaID int
AS 
UPDATE NovedadInasistencia
set ninActivo=0, usuEliminaID = @usuEliminaID
WHERE 
ninId = 
@ninId


GO
