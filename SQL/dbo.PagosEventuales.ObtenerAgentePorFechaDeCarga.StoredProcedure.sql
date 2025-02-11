USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PagosEventuales.ObtenerAgentePorFechaDeCarga]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PagosEventuales.ObtenerAgentePorFechaDeCarga]
(
@ageFechaCarga datetime
)
as
SELECT pev.ageApellidoNombre, pev.ageDNI, lpa.lpaNombre, pev.pevImporteTotal, pev.ageCUIT, pev.ageSexo, pev.ageNroControl, pev.pevFechaCarga , pev.pevGenerado 
FROM PagosEventuales pev 
LEFT JOIN LugarPago lpa ON lpa.lpaId = pev.lpaId 
WHERE pev.pevFechaCarga >=@ageFechaCarga
and pev.pevGenerado = 0
--where pev.ageFechaCarga = '2017-12-12'


GO
