USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.InformeNovedadesCargadasJurisdiccion]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[NovedadInasistencia.InformeNovedadesCargadasJurisdiccion]
@liqId int,
@jurId int
as

SELECT NI.ninId, NI.ninCantidad , NI.ninFechaDesde, 
NC.ncoCod, NC.ncoId, NC.ncoNombre, 
PA.Nombre, PA.Cuil, PA.NroCOntrol, PA.LugarPago, PA.PlantaTipo, JU.jurNombre,
LIQ.liqDescripcion,
LP.lpaNombre,
'liqEstado' =
      CASE 
		 WHEN LIQ.liqEstado='A' THEN 'LIQUIDACION ABIERTA'
		 WHEN LIQ.liqEstado='P' THEN 'LIQUIDACION CERRADA PARA PERSONAL'
		 WHEN LIQ.liqEstado='C' THEN 'LIQUIDACION CERRADA'
         ELSE ''
		 END
FROM NovedadInasistencia NI 
INNER JOIN NovedadConcepto NC ON NI.ncoId=NC.ncoId
INNER JOIN PruebasAge PA ON NI.NuevoAgeId1 = PA.NuevoAgeId1
INNER JOIN Liquidacion LIQ ON NI.liqId = LIQ.liqId
INNER JOIN LugarPago LP  ON PA.LugarPago = LP.lpaCodigo
INNER JOIN Jurisdiccion JU ON PA.Juris = JU.jurCodigo
WHERE NI.liqId=@liqId
--AND Pa.Juris  = @jurCodigo
AND Pa.Juris  = (select jurCodigo from Jurisdiccion where jurId=@jurId)
AND ninActivo=1

order by LP.lpaNombre,PA.Nombre,NC.ncoCod


GO
