USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.Actualizar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NovedadInasistencia.Actualizar]
	@ninId int,  @ninCantidad int, @ninFechaDesde datetime, @usuActualizaID int
AS 
UPDATE NovedadInasistencia
set ninCantidad=@ninCantidad, ninFechaDesde = @ninFechaDesde, usuActualizaID=@usuActualizaID,
usuFechaHoraModifica = (select GETDATE())
WHERE ninId = @ninId


GO
