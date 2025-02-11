USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PagosEventuales.ObtenerAgentePorCuilyLugarDePago]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PagosEventuales.ObtenerAgentePorCuilyLugarDePago]
@Cuil varchar(11),
@LugarPagoCodigo varchar(5)
AS
SELECT PAG.Cuil,PAG.NroCOntrol,LPA.lpaNombre
from DBO.PruebasAge PAG INNER JOIN Dbo.LugarPago LPA
ON PAG.LugarPago = LPA.lpaCodigo
WHERE PAG.Cuil=@Cuil AND LPA.lpaCodigo=@LugarPagoCodigo
GO
