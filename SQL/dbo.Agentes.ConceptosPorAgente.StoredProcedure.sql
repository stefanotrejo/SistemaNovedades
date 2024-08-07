USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ConceptosPorAgente]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ConceptosPorAgente]
@ageId int
as
SELECT        
dbo.ConceptoTemporal.cteCodigoConcepto as Codigo, 
dbo.ConceptoTemporal.cteImporte as Importe,
dbo.Concepto.conNombre as Nombre
FROM  dbo.ConceptoTemporal 
INNER JOIN dbo.concepto 
ON dbo.ConceptoTemporal.cteCodigoConcepto=dbo.Concepto.conCodigo
WHERE ageId=@ageId
AND CONCEPTO.conVisible=1		
--CONCEPTO 540 SE ELIMINA "PROGRAMA APRENDER" Y SE REEMPLAZA POR "DEV. ANSES DECRETO 561/19"			
GO
