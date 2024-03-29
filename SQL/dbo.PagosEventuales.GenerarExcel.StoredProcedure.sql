USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PagosEventuales.GenerarExcel]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[PagosEventuales.GenerarExcel]
(
@fecha datetime 
)
AS
SELECT 
dbo.PagosEventuales.ageApellidoNombre as NOMBRE, 
dbo.PagosEventuales.ageCUIT as CUIT, 
dbo.LugarPago.lpaNombre as "LUG. PAGO", 
dbo.LugarPago.lpaCodigo as "COD. DE LUGAR DE PAGO", 
dbo.PagosEventuales.pevImporteTotal as "IMP.", 
dbo.PagosEventuales.ageSexo as "SEXO", 
dbo.PagosEventuales.ageNroControl as "Nº DE CONTROL",
dpe.dpeConcepto as "CONCEPTO"
FROM dbo.PagosEventuales INNER JOIN
dbo.LugarPago ON dbo.PagosEventuales.lpaId = dbo.LugarPago.lpaId
JOIN DetallePagoEventual DPE
ON PagosEventuales.pevId=dpe.pevId
WHERE pevFechaCarga >= @fecha
ORDER BY dbo.PagosEventuales.ageApellidoNombre

GO
