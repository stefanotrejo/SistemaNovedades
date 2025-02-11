USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.ObtenerTodoLiquidacionJurisdiccion]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[NovedadInasistencia.ObtenerTodoLiquidacionJurisdiccion]
@liqId int,
@jurId int
as

SELECT NI.ninId, NI.ninCantidad , NI.ninFechaDesde, NC.ncoCod, NC.ncoId, NC.ncoNombre
FROM NovedadInasistencia NI 
INNER JOIN NovedadConcepto NC ON NI.ncoId=NC.ncoId
INNER JOIN PruebasAge PA ON NI.NuevoAgeId1 = PA.NuevoAgeId1
WHERE liqId=@liqId 
and PA.Juris = (SELECT jurCodigo from Jurisdiccion where jurId=@jurId)
and ninActivo=1




GO
