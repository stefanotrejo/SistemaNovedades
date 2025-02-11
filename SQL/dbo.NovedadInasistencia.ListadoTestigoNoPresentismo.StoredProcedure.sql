USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.ListadoTestigoNoPresentismo]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[NovedadInasistencia.ListadoTestigoNoPresentismo]
@liqId int,
@perEsAdministrador int
as

SELECT 
PA.NroCOntrol as control, PA.PlantaTipo as planta, 
(SELECT CASE
		 WHEN Liquidacion.liqMes < 12 and liqId=@liqId THEN CONCAT(REPLICATE('0', 2-len(CAST(Liquidacion.liqMes+1 AS int))), Liquidacion.liqMes+1)
		 WHEN Liquidacion.liqMes = 12 and liqId=@liqId THEN '01'
		 ELSE ''
		 END		 
from Liquidacion
where liqid=@liqId)
as mes,
SUBSTRING(PA.MesAnioLiq,4,2) as anio
FROM NovedadInasistencia NI 
INNER JOIN NovedadConcepto NC ON NI.ncoId=NC.ncoId
INNER JOIN PruebasAge PA ON NI.NuevoAgeId1 = PA.NuevoAgeId1
INNER JOIN Liquidacion LIQ ON NI.liqId = LIQ.liqId
INNER JOIN LugarPago LP  ON PA.LugarPago = LP.lpaCodigo
INNER JOIN Jurisdiccion JU ON PA.Juris = JU.jurCodigo
WHERE 
NI.liqId=@liqId
and NI.perEsAdministrador=@perEsAdministrador
and NI.ncoId = 11
and ninActivo=1



GO
