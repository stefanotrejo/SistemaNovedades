USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ConsultaRiegoNombre]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.ConsultaRiegoNombre]
@nombre varchar(50), @mesanioliq varchar(5)
as

-- VIALIDAD
SELECT  PA1.Cuil,PA1.NuevoAgeId1, PA1.Nombre,
PA1.MesAnioLiq as Periodo,PA1.Agru, PA1.tramo,
PA1.Apertura, PA1.NroCOntrol AS "Numero de Control", dbo.LugarPago.lpaNombre 
as "Lugar de Pago", 
cgosden.nombre as Cargo
FROM PruebasAge PA1
LEFT JOIN dbo.LugarPago 
ON dbo.LugarPago.lpaCodigo = PA1.LugarPago 
LEFT JOIN dbo.cgosden cgosden 
ON PA1.Agru=cgosden.Agrupamiento 
and PA1.tramo=cgosden.Tramo 
and PA1.Apertura=cgosden.apertura	

where MesAnioLiq=@mesanioliq 
and PA1.Activo=1
AND PA1.SituRev!='V'
AND PA1.SituRev!='N'
--AND PA1.cargarNovedades = 1 
AND PA1.Nombre like '%' + @nombre + '%' 
-- FILTRO RIEGO
and LugarPago='12063'
and not exists
-- Agentes a los que no se le puede cargar novedades
(select * from PruebasAge PA2
where MesAnioLiq=@mesanioliq
and (tramo=9 -- 2494
or Agru=01 -- 756
or Agru=04 -- 9
or Agru=05 -- 390
or Agru=23 -- 2
or (Agru=02 and tramo=3 and Apertura=083)
or ( Agru=02 and tramo=3 and Apertura=553)
or ( Agru=18 and tramo=1 and Apertura=0041)
or ( Agru=18 and tramo=1 and Apertura=005) --- 5
or (LugarPago=18013 and PlantaTipo='C' and Agru=02 and tramo=3 and apertura=547)) -- 3823
AND PA1.NuevoAgeId1=PA2.NuevoAgeId1 -- 172
)
order by FechaLiquidacion, Nombre ASC

GO
