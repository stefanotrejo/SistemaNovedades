USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Parametro.ActualizarPorparNombre]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Parametro.ActualizarPorparNombre]
(
@parNombre varchar(50),
@parValor varchar(max),
@usuId int
)

as

update Parametro set 
parValor = @parValor,
usuIdUltimaModificacion = @usuId,
parFechaHoraUltimaModificacion = getdate()
where parNombre = @parNombre

GO
