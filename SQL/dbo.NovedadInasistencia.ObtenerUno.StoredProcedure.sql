USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.ObtenerUno]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[NovedadInasistencia.ObtenerUno]
@ninId int
as

SELECT NI.ninId, NI.ninCantidad, NI.ninFechaDesde, NC.ncoCod, NC.ncoId, NC.ncoNombre
FROM NovedadInasistencia NI 
INNER JOIN NovedadConcepto NC ON NI.ncoId=NC.ncoId
WHERE NI.ninId=@ninId 




GO
