USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.ValidarBajaCargoRetenido]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NovedadInasistencia.ValidarBajaCargoRetenido] 
@NuevoAgeId1 int,
@liqId int
AS

-- DECLARACION DE VARIABLES
DECLARE @idBajaCargoRetenido int
DECLARE @existe int 

-- INICIALIZACION DE VARIABLES
SELECT @idBajaCargoRetenido = 16

-- Busca si existe el codigo 16
SELECT @existe = (select count(1)
				from NovedadInasistencia 
				where 1 = 1
				and liqId = @liqId
				and NuevoAgeId1=@NuevoAgeId1	
				and ncoId = @idBajaCargoRetenido			
				and ninActivo=1)

-- si no existe el codigo 16
--IF (@existe = 0)

/*
Retorna:
0- NO existe el codigo 16
1- SI existe el codigo 16
*/

SELECT @existe 


--select @@IDENTITY 


GO
