USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.CalcularNuevoTotalHaberes]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.CalcularNuevoTotalHaberes]
@mesanioliq as varchar(5)
as

UPDATE PruebasAge 
SET NuevoTotalHaberes = Totalhaberes - 

(select ISNULL((select SUM(cteImporte) as Total
	FROM [LiquidacionSueldos].[dbo].[ConceptoTemporal] 
	where 
	cteCodigoConcepto=601 and ageId=PruebasAge.NuevoAgeId1
	OR cteCodigoConcepto=746 and ageId=PruebasAge.NuevoAgeId1 
	OR cteCodigoConcepto=747 and ageId=PruebasAge.NuevoAgeId1),0)	
	+ SalarioFamiliar)

where MesAnioLiq=@mesanioliq 
GO
