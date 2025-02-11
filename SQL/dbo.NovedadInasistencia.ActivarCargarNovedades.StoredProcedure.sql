USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.ActivarCargarNovedades]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NovedadInasistencia.ActivarCargarNovedades]
@mesanio as varchar(5)
as

-- Al cargar liquidacion nueva
UPDATE PruebasAge
set cargarNovedades = 1
WHERE 
--MesAnioLiq='06/20'
MesAnioLiq=@mesanio

UPDATE PruebasAge
set cargarNovedades = 0
WHERE 
MesAnioLiq=@mesanio
and (SituRev='V' 
or SituRev='N' -- NUEVO
or ((
	LugarPago > '23020'
	and LugarPago < '24000')
	or LugarPago = '93092'
	or (SUBSTRING(LugarPago,1,2)='92')
	or (SUBSTRING(LugarPago,1,2)='17') -- NUEVO
	) 
)



GO
