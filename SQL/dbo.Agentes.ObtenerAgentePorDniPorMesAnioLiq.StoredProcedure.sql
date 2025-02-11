USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ObtenerAgentePorDniPorMesAnioLiq]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ObtenerAgentePorDniPorMesAnioLiq]
	@dni varchar(50), @mesanioliq varchar(5), @jurId int
AS

-- Funcion: Devuelve los Agentes que coincidan con el dni ingresado y el mesanioliq ingresado
-- cuya situacion de revista sea distinta de Vacantes y Nacion y esten activos.

BEGIN
SELECT  dbo.PruebasAge.Cuil,PruebasAge.NuevoAgeId1, dbo.PruebasAge.Nombre, dbo.LugarPago.lpaNombre 
as "Lugar de Pago", cgosden.nombre as Cargo,PruebasAge.MesAnioLiq as Periodo, PruebasAge.Agru, 
PruebasAge.tramo,PruebasAge.Apertura, 
PruebasAge.NroCOntrol AS "Numero de Control"

FROM dbo.PruebasAge 
LEFT JOIN dbo.LugarPago 
ON dbo.LugarPago.lpaCodigo = dbo.PruebasAge.LugarPago 
LEFT JOIN dbo.cgosden cgosden 
ON PruebasAge.Agru=cgosden.Agrupamiento 
and PruebasAge.tramo=cgosden.Tramo 
and PruebasAge.Apertura=cgosden.apertura
  	  
WHERE Substring(PruebasAge.Cuil,3,8)= @dni 
AND PruebasAge.MesAnioLiq=@mesanioliq
AND PruebasAge.SituRev!='V'
AND PruebasAge.SituRev!='N'
AND PruebasAge.Activo=1
AND PruebasAge.Juris = CASE 
        WHEN (@jurId!=0)
        THEN  (SELECT jurCodigo From jurisdiccion where jurId=@jurId)
        ELSE PruebasAge.Juris 
    END
--AND PruebasAge.cargarNovedades = 1 -- Nuevo filtro
order by FechaLiquidacion, Nombre ASC
END
GO
