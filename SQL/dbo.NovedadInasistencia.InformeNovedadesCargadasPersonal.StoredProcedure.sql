USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.InformeNovedadesCargadasPersonal]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Devuelve cantidad de novedades para usuarios con Perfil Personal y Personal Ext

CREATE procedure [dbo].[NovedadInasistencia.InformeNovedadesCargadasPersonal]
@liqId int
as

DECLARE @perEsAdministrador int
SELECT @perEsAdministrador = 2

DECLARE @perEsAdministrador2 int
SELECT @perEsAdministrador2 =  5

DECLARE @perId int
SELECT @perId = (SELECT perId FROM Perfil 
				 WHERE perEsAdministrador = @perEsAdministrador)

DECLARE @perId2 int
SELECT @perId2 = (SELECT perId FROM Perfil 
				 WHERE perEsAdministrador = @perEsAdministrador2)

SELECT 
	UPPER(Usu.usuApellido + ' ' + uSU.usuNombre) as USUARIO,
	(SELECT count(1) 
	 FROM NovedadInasistencia NI
	 WHERE  NI.usuCreaID = USU.usuId 
	 AND	NI.liqId = @liqId
	 AND    NI.perEsAdministrador IN (@perEsAdministrador,@perEsAdministrador2)
	 ) as Altas,
	 (SELECT count(1) 
	 FROM NovedadInasistencia NI
	 WHERE NI.usuActualizaID = USU.usuId 
	  AND	NI.liqId = @liqId
	 AND    NI.perEsAdministrador IN (@perEsAdministrador,@perEsAdministrador2)
	 ) as Actualizaciones,
	 (SELECT count(1) 
	 FROM NovedadInasistencia NI
	 WHERE NI.usuEliminaID = USU.usuId 
	 AND	NI.liqId = @liqId
	 AND    NI.perEsAdministrador IN (@perEsAdministrador,@perEsAdministrador2)
	 ) as Eliminaciones,
	 (SELECT UPPER(liqDescripcion) 
	  FROM Liquidacion
	  WHERE liqId = @liqId) as liqDescripcion	 	 
 
 FROM Usuario USU 
 WHERE 	
	 (USU.perId = @perId
	  OR	USU.perId = @perId2)
	  AND USU.usuInterno is null
	  AND usu.usuActivo = 1
 ORDER BY Usuario
 


GO
