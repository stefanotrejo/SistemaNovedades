USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Liquidacion.Eliminar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Liquidacion.Eliminar]
	@MesAnioLiquidacion varchar(5)
AS 


delete
from ConceptoTemporal
where ConceptoTemporal.ageId in
(SELECT NuevoAgeId1 
from PruebasAge 
where MesAnioLiq=@MesAnioLiquidacion)

delete from PruebasAge
where MesAnioLiq=@MesAnioLiquidacion


GO
