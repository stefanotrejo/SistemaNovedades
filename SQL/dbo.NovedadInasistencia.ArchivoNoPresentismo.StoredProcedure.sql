USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.ArchivoNoPresentismo]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NovedadInasistencia.ArchivoNoPresentismo]
	@liqId int,
	@perEsAdministrador int
AS
BEGIN

if (@perEsAdministrador != 99) 
begin
	Select 
	PA.NroCOntrol 
	+ PA.PlantaTipo 
	-- !!IMPORTANTE !! -> DEBE IR EL MES ACTUAL
	+ (SELECT CASE
			 WHEN Liquidacion.liqMes < 12 and liqId=@liqId THEN CONCAT(REPLICATE('0', 2-len(CAST(Liquidacion.liqMes+1 AS int))), Liquidacion.liqMes+1,liqAnio)
			 WHEN Liquidacion.liqMes = 12 and liqId=@liqId THEN CONCAT('01',(liqAnio+1))
			 ELSE ''
			 END		 
	from Liquidacion
	where liqid=@liqId)
	as Columna 
	from NovedadInasistencia  NI
	INNER JOIN PruebasAge PA ON NI.NuevoAgeId1 = PA.NuevoAgeId1
	INNER JOIN Liquidacion LIQ ON ni.liqId = liq.liqId
	where NI.ninActivo = 1
	AND NI.ncoId = 11
	AND NI.liqId = @liqId 
	AND NI.perEsAdministrador = @perEsAdministrador
end
else
begin
	Select 
	PA.NroCOntrol AS CONTROL,
	PA.PlantaTipo AS PLANTA,
	-- !!IMPORTANTE !! -> DEBE IR EL MES ACTUAL
	 (SELECT CASE
			 WHEN Liquidacion.liqMes < 12 and liqId=@liqId THEN CONCAT(REPLICATE('0', 2-len(CAST(Liquidacion.liqMes+1 AS int))), Liquidacion.liqMes+1)
			 WHEN Liquidacion.liqMes = 12 and liqId=@liqId THEN '01'
			 ELSE ''
			 END		 
	from Liquidacion
	where liqid=@liqId)
	as MES,
	(SELECT CASE
			 WHEN Liquidacion.liqMes < 12 and liqId=@liqId THEN liqAnio
			 WHEN Liquidacion.liqMes = 12 and liqId=@liqId THEN liqAnio+1
			 ELSE ''
			 END		 
	from Liquidacion
	where liqid=@liqId) AS ANIO
	 
	from NovedadInasistencia  NI
	INNER JOIN PruebasAge PA ON NI.NuevoAgeId1 = PA.NuevoAgeId1
	INNER JOIN Liquidacion LIQ ON ni.liqId = liq.liqId
	where NI.ninActivo = 1
	AND NI.ncoId = 11
	AND NI.liqId = @liqId 	
end
END
GO
