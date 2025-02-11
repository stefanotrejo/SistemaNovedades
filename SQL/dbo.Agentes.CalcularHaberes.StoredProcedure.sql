USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.CalcularHaberes]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.CalcularHaberes]
	@id int
AS
declare @SalarioFamiliar numeric(18,2)
declare @TotalHaberes numeric (18,2)
declare @CargosAlHaber numeric (18,2)
declare @TotalSinCargosAlHaber numeric(18,2)
declare @RemuneracionOit numeric(18,2)
declare @NuevoTotalHaberes numeric (18,2)

--SALARIO FAMILIAR
set @SalarioFamiliar = 
(select ISNULL(
(SELECT 
SUM(cteImporte) as Total
FROM [LiquidacionSueldos].[dbo].[ConceptoTemporal] 
where (
(cteCodigoConcepto >= 108 
and cteCodigoConcepto <=118 and ageId=@id) 
OR (cteCodigoConcepto=137 and ageId=@id) 
or (cteCodigoConcepto=202 and ageId=@id) 
OR (cteCodigoConcepto=208 and ageId=@id)))
,0))

--if (@SalarioFamiliar is null)
--set @SalarioFamiliar = 0

--TOTAL HABERES
--SET @TotalHaberes = (SELECT PruebasAge.TotalHaberes FROM PruebasAge WHERE NuevoAgeId1=@id)


--TOTAL HABERES
SET @TotalHaberes= (select ISNULL(
(SELECT PruebasAge.TotalHaberes FROM PruebasAge WHERE NuevoAgeId1=@id),0))

--TOTAL HABERES CON DECRETO 561/19
--SET @TotalHaberes = (SELECT (SELECT PruebasAge.TotalHaberes FROM PruebasAge WHERE NuevoAgeId1=@id) 
--- (SELECT conceptotemporal.cteImporte FROM ConceptoTemporal where ageId=@id and cteCodigoConcepto='540'))  
--ESTO DE ARRIBA FUNCIONA PERO HAY CASOS QUE DA NULL

--PRUEBA PARA SACAR EL NULL
SET @TotalHaberes = @TotalHaberes - (SELECT ISNULL((SELECT conceptotemporal.cteImporte FROM ConceptoTemporal where ageId=@id and cteCodigoConcepto='540'),0))  


--CARGOS AL HABER
SET @CargosAlHaber= (select ISNULL(
(SELECT
SUM(cteImporte)
FROM [LiquidacionSueldos].[dbo].[ConceptoTemporal] 
where ((cteCodigoConcepto = 601 and ageId=@id)  
OR (cteCodigoConcepto=746 and ageId=@id))),0))

--if (@CargosAlHaber is null)
--set @CargosAlHaber = 0

SET @TotalSinCargosAlHaber = @TotalHaberes - @CargosAlHaber - @SalarioFamiliar
SET @RemuneracionOit = @TotalHaberes - @SalarioFamiliar

--NuevoTotalHaberes
--VERSIO NUEVA

SET @NuevoTotalHaberes = @Totalhaberes - 

(select ISNULL((select SUM(cteImporte) as Total
	FROM [LiquidacionSueldos].[dbo].[ConceptoTemporal] 
	where 
	cteCodigoConcepto=601 and ageId=@id
	OR cteCodigoConcepto=746 and ageId=@id
	OR cteCodigoConcepto=747 and ageId=@id),0)	
	+ @SalarioFamiliar)



--VERSION VIEJA
--set @NuevoTotalHaberes = @TotalHaberes -
--((select SUM(cteImporte) as Total
--FROM [LiquidacionSueldos].[dbo].[ConceptoTemporal] 
--where 
--cteCodigoConcepto=601 and ageId=@id
--OR cteCodigoConcepto=746 and ageId=@id 
--OR cteCodigoConcepto=747 and ageId=@id)+ @SalarioFamiliar)

--if (@NuevoTotalHaberes is null)
--set @NuevoTotalHaberes = @TotalHaberes+@SalarioFamiliar

UPDATE PruebasAge SET PruebasAge.SalarioFamiliar = @SalarioFamiliar, 
PruebasAge.TotalSinCargosAlHaber = @TotalSinCargosAlHaber, 
PruebasAge.RemuneracionOit = @RemuneracionOit, 
PruebasAge.NuevoTotalHaberes=@NuevoTotalHaberes,
PruebasAge.TotalHaberes=@TotalHaberes --Total haberes con decreto 561/19
WHERE PruebasAge.NuevoAgeId1=@id


--SELECT @TotalHaberes as "Total Haberes", @CargosAlHaber as "Cargos al haber", @SalarioFamiliar as "Salario Familiar"
--SELECT @TotalSinCargosAlHaber as "Total sin cargos al haber",@RemuneracionOit as "Remuneracion OIT"



--SELECT @TotalSinCargosAlHaber as "Total sin cargos al haber", @CargosAlHaber as "Cargos al Haber",
--@SalarioFamiliar as "Salario Familiar", @TotalHaberes as "Total haberes" from PruebasAge
--WHERE PruebasAge.NuevoAgeId1=@id
GO
