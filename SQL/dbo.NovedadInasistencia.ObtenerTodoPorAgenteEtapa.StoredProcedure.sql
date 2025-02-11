USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.ObtenerTodoPorAgenteEtapa]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[NovedadInasistencia.ObtenerTodoPorAgenteEtapa]
@liqEtapa int,
@NuevoAgeId1 int
as

SELECT NI.ninId, NI.ninCantidad , NI.ninFechaDesde, NC.ncoCod, NC.ncoId, NC.ncoNombre,
US.usuNombre, (select usuNombre from Usuario where usuId=NI.usuEliminaID) as usuElimina,
(select usuNombre from Usuario where usuId=NI.usuActualizaID) as usuActualiza
FROM NovedadInasistencia NI 
LEFT JOIN NovedadConcepto NC ON NI.ncoId=NC.ncoId
LEFT JOIN Usuario US ON NI.usuCreaID=US.usuId
WHERE liqId=@liqEtapa 
and NuevoAgeId1=@NuevoAgeId1
and ninActivo=1



GO
