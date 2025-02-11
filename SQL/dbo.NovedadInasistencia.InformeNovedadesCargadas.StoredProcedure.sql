USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.InformeNovedadesCargadas]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[NovedadInasistencia.InformeNovedadesCargadas]
@liqId int,
@perEsAdministrador int
as

SELECT 
		NI.ninId,'ninCantidad' =
        CASE 
		WHEN ninCantidad='-1' THEN '0'		 
        ELSE ninCantidad
		END,
		NI.ninFechaDesde, 
		NC.ncoCod, NC.ncoId, NC.ncoNombre, 
		PA.Nombre, PA.Cuil, PA.NroCOntrol, PA.LugarPago, PA.PlantaTipo, PA.Juris, JU.jurNombre,
		LIQ.liqDescripcion,
		LP.lpaNombre,
		'liqEstado' =
			  CASE 
				 WHEN LIQ.liqEstado='A' THEN 'LIQUIDACION ABIERTA'
				 WHEN LIQ.liqEstado='P' THEN 'LIQUIDACION CERRADA PARA PERSONAL'
				 WHEN LIQ.liqEstado='C' THEN 'LIQUIDACION CERRADA'
				 ELSE ''
				 END,
				 usuCrea = UPPER(Usu.usuApellido + ' ' + uSU.usuNombre),
				 usuModifica = ISNULL(UPPER((SELECT usuario.usuApellido + ' ' + usuario.usuNombre from Usuario
								WHERE Ni.usuActualizaID = usuario.usuId)),''),		
				usuCreaId = Usu.usuid
											 				 
FROM 
	NovedadInasistencia NI 
	INNER JOIN NovedadConcepto NC	ON NI.ncoId=NC.ncoId
	INNER JOIN PruebasAge PA		ON NI.NuevoAgeId1 = PA.NuevoAgeId1
	INNER JOIN Liquidacion LIQ		ON NI.liqId = LIQ.liqId
	INNER JOIN LugarPago LP			ON PA.LugarPago = LP.lpaCodigo
	INNER JOIN Jurisdiccion JU	    ON PA.Juris = JU.jurCodigo
	INNER JOIN Usuario USU			ON NI.usuCreaID = Usu.usuId	
WHERE 
	NI.liqId = @liqId
	and ninActivo=1
	and NI.perEsAdministrador=2
order by LP.lpaNombre,PA.Nombre,NC.ncoCod

GO
