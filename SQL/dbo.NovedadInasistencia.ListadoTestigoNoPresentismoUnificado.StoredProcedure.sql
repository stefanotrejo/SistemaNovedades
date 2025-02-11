USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.ListadoTestigoNoPresentismoUnificado]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[NovedadInasistencia.ListadoTestigoNoPresentismoUnificado]
@liqId int
as

SELECT 
PA.NroCOntrol as control, 
PA.PlantaTipo as planta, 
(SELECT CASE
		 WHEN Liquidacion.liqMes < 12 and liqId=9 THEN CONCAT(REPLICATE('0', 2-len(CAST(Liquidacion.liqMes+1 AS int))), Liquidacion.liqMes+1)
		 WHEN Liquidacion.liqMes = 12 and liqId=9 THEN '01'
		 ELSE ''
		 END		 
from Liquidacion
where liqid=9) as mes,
SUBSTRING(PA.MesAnioLiq,4,2) as anio,
--PE.perNombre,
(SELECT CASE
		 WHEN PlantaTipo = 'C'  THEN PE.perNombre + ' - CONTRATADO'
		 WHEN PlantaTipo = 'P'  THEN PE.perNombre + ' - PERMANENTE'
		 ELSE ''
		 END) AS perNombre,
pe.perId,
UPPER(LIQ.liqDescripcion) as liqDescripcion
FROM NovedadInasistencia NI 
INNER JOIN NovedadConcepto NC	ON NI.ncoId=NC.ncoId
INNER JOIN PruebasAge PA		ON NI.NuevoAgeId1 = PA.NuevoAgeId1
INNER JOIN Liquidacion LIQ		ON NI.liqId = LIQ.liqId
INNER JOIN LugarPago LP			ON PA.LugarPago = LP.lpaCodigo
INNER JOIN Jurisdiccion JU		ON PA.Juris = JU.jurCodigo
INNER JOIN Perfil PE			ON NI.perEsAdministrador = PE.perEsAdministrador
WHERE 
NI.liqId = @liqId
and NI.ncoId = 11
and ninActivo = 1



GO
