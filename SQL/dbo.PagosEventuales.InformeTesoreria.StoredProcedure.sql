USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PagosEventuales.InformeTesoreria]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script para el comando SelectTopNRows de SSMS  ******/
CREATE PROCEDURE [dbo].[PagosEventuales.InformeTesoreria]
	@Fechacarga date
AS
SELECT   
      [ageJurisdiccion]
  +  [agePrograma]      
	 ,LP.lpaNombre
	 ,COUNT(lpaNombre) as Cantidad	 
      ,SUM([pevImporteTotal]) as Importe	  
  FROM [LiquidacionSueldos].[dbo].[PagosEventuales] PE
  JOIN LugarPago LP ON Pe.lpaId=LP.lpaId
  --where pevFechaCarga>='2019-07-11'
  where pevFechaCarga>=@Fechacarga
  and pevGenerado = 1
  group by lpaNombre, ageJurisdiccion,agePrograma

 






GO
