USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[InformeAgentesporLugarPagoporMesAnioLiq]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InformeAgentesporLugarPagoporMesAnioLiq]
@LugarPago varchar(5),
@MesAnioLiq varchar(5)
AS
BEGIN
select PruebasAge.*, lpaNombre, sirNombre 
from PruebasAge 
join LugarPago L on lpaCodigo = LugarPago
left join SituacionRevista on sirCod = SituRev
where LugarPago = @LugarPago and  MesAnioLiq = @MesAnioLiq and Nombre <> 'VACANTE'
order by Nombre
END




GO
