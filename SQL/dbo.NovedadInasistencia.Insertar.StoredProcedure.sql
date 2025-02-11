USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[NovedadInasistencia.Insertar] 
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
[ninActivo]
      ) 
	  values 
(
@NuevoAgeId1,
@ncoId,
@ninFechaRegistro,
@ninFechaDesde,
@ninCantidad,
@liqId ,
@perEsAdministrador,
@usuCreaID,
@novActivo
) 

select @@IDENTITY 
END




GO
