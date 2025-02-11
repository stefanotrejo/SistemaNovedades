USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.InsertarBajaCargoRetenido]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NovedadInasistencia.InsertarBajaCargoRetenido] 
@NuevoAgeId1 int,
@ncoId int,
@ninFechaRegistro datetime,
@ninFechaDesde datetime,
@ninCantidad int,
@liqId int,
@perEsAdministrador int,
@usuCreaID int,
@novActivo tinyint
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
BEGIN
-- si no existe el codigo 16
IF (@existe = 0)
BEGIN
	insert into NovedadInasistencia
	(
	[NuevoAgeId1],
	[ncoId],
	[ninFechaRegistro],
	[ninFechaDesde],
	[ninCantidad],
	[liqId],
	[perEsAdministrador],
	[usuCreaID],
	[ninActivo]) 
	values 
	(
	@NuevoAgeId1,
	@idBajaCargoRetenido,
	@ninFechaRegistro,
	@ninFechaDesde,
	@ninCantidad,
	@liqId ,
	@perEsAdministrador,
	@usuCreaID,
	@novActivo
	) 
END

select @@IDENTITY 
END

GO
