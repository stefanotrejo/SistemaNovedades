USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PagosEventuales.ObtenerDuplicados]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PagosEventuales.ObtenerDuplicados]
@cuil varchar(50)
AS
BEGIN
SELECT *
FROM dbo.PagosEventuales PEV 
INNER JOIN dbo.DetallePagoEventual DPA ON PEV.pevId = DPA.pevId  		  				  
where PEV.ageCUIT = @cuil
END
GO
