USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PagosEventuales.ArchivoInformaticaGenerar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PagosEventuales.ArchivoInformaticaGenerar]
(
@fecha datetime 
)
AS
Select 
RTRIM(LTRIM(CAST(UPPER(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(ageApellidoNombre, 'ñ', 'n'),'/',''),'á','a'),'é','e'),'í','i'),'ó','o'),'ú','u'),'Ñ','N'),'´',''),'''',''),'Á','A'),'É','E'),'Í','I'),'Ó','O'),'Ú','U')) AS VARCHAR(25))))+ 
REPLICATE(' ', 25-len(LTRIM(CAST(UPPER(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(ageApellidoNombre, 'ñ', 'n'),'/',''),'á','a'),'é','e'),'í','i'),'ó','o'),'ú','u'),'Ñ','N'),'´',''),'''',''),'Á','A'),'É','E'),'Í','I'),'Ó','O'),'Ú','U')) AS VARCHAR(25))))) +
+ REPLICATE('0', 8-len(ltrim(CAST(ageDNI AS VARCHAR(8)))))+ CAST(ageDNI AS VARCHAR(8))+ REPLICATE('0', 5-len(ltrim(CAST(pevLugarPagoCodigo AS VARCHAR(5)))))+ltrim(CAST(pevLugarPagoCodigo AS VARCHAR(5)))+'0000000000000000000000000000000000000000000000000000000'+' '+'000000000'+ REPLICATE('0', 9- len(ltrim(CAST(replace(cast(pevImporteTotal as decimal(18,2)),'.','') AS VARCHAR(9)))))+ CAST(replace(cast(pevImporteTotal as decimal(18,2)),'.','') AS VARCHAR(9)) + '000000' +  
REPLICATE('0', 11-len(ltrim(CAST(ageCUIT AS VARCHAR(11)))))+ CAST(ageCUIT AS VARCHAR(11))  + CAST(ageSexo AS VARCHAR(11)) 
as Columna 
from PagosEventuales WHERE [pevFechaCarga] >= @fecha
and pevGenerado = 0
order by ageApellidoNombre 
GO
