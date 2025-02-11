USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[LiquidacionNovedades.AbrirEtapa]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LiquidacionNovedades.AbrirEtapa]
-- Las variables recibidas contienen los datos de la nueva etapa a abrir
-- Ejemplo si estoy abriendo la etapa 2 del mes de marzo 2020, enviar:
-- liqIdRecibido = liqId de la etapa 2 de marzo/2020, mesanioliqRecibido = '3/20',
-- etapaRecibida = 2

-- PARAMETROS
@liqIdDestino int--, -- Es el liqId Destino (el liqId de la etapa a abrir)


/*@mesAnioLiquidaciones varchar(50), -- mes y año actual de las etapas 
@etapaDestino int*/
as

Declare 
@NuevoAgeId1 varchar(50), 
@ncoId int, 
@ninFechaRegistro varchar(50), 
@ninFechaDesde varchar(50), 
@ninCantidad int, 
@liqId int, 
@perEsAdministrador int, 
@ninActivo int, 
@mesAnioLiq varchar(50),
@usuCreaID int, 
@usuActualizaID int, 
@usuEliminaID int,
@mesAnioLiquidaciones varchar(50),
@etapaDestino int

-- buscar la ultima liquidacion abierta y sacar etapa y mesanio
SELECT @mesAnioLiquidaciones = liqMes + '/' + liqAnio,
		@etapaDestino = liqEtapa
FROM
	Liquidacion 
WHERE 
	liqId = @liqIdDestino


DECLARE CursorNovedades CURSOR FOR
-- CONSULTA A GUARDAR EN EL CURSOR
SELECT NI.NuevoAgeId1, NI.ncoId, NI.ninFechaRegistro, NI.ninFechaDesde, NI.ninCantidad, @liqIdDestino,Ni.perEsAdministrador, NI.ninActivo,
NI.usuCreaID, NI.usuActualizaID, NI.usuEliminaID 
FROM NovedadInasistencia NI
INNER JOIN Liquidacion LIQ ON NI.liqId=LIQ.liqId
WHERE LIQ.liqMes+'/'+LIQ.liqAnio = @mesAnioLiquidaciones
AND LIQ.liqEtapa=@etapaDestino-1
AND ninActivo=1 
-- Hace referencia a la etapa anterior a la que se esta abriendo. 
--Ejemplo: abriendo etapa 2, esto será etapa 1. 

OPEN CursorNovedades
FETCH CursorNovedades 
into @NuevoAgeId1, @ncoId, @ninFechaRegistro, @ninFechaDesde, @ninCantidad, @liqId, @perEsAdministrador, @ninActivo, @usuCreaID,
@usuActualizaID,@usuEliminaID
WHILE (@@FETCH_STATUS = 0)
BEGIN

insert into NovedadInasistencia 
(NuevoAgeId1,ncoId,ninFechaRegistro,ninFechaDesde,ninCantidad,liqId,perEsAdministrador,ninActivo,usuCreaID,usuActualizaID,usuEliminaID)
values
(@NuevoAgeId1, @ncoId, @ninFechaRegistro, @ninFechaDesde, @ninCantidad, @liqId,@perEsAdministrador, @ninActivo,@usuCreaID,@usuActualizaID,
@usuEliminaID)

FETCH NEXT FROM CursorNovedades 
into @NuevoAgeId1, @ncoId, @ninFechaRegistro, @ninFechaDesde, @ninCantidad, @liqId, @perEsAdministrador, @ninActivo, @usuCreaID,
@usuActualizaID,@usuEliminaID
END
CLOSE CursorNovedades
DEALLOCATE CursorNovedades


GO
