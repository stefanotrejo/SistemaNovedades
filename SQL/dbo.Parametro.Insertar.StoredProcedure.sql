USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Parametro.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Parametro.Insertar]
(
@parNombre varchar(50),
@parValor varchar(max),
@parActivo tinyint,
@usuIdCreacion int,
@usuIdUltimaModificacion int,
@parFechaHoraCreacion datetime,
@parFechaHoraUltimaModificacion datetime
)

as

insert into Parametro
(
parNombre,
parValor,
parActivo,
usuIdCreacion,
usuIdUltimaModificacion,
parFechaHoraCreacion,
parFechaHoraUltimaModificacion
)

values
(
@parNombre,
@parValor,
@parActivo,
@usuIdCreacion,
@usuIdUltimaModificacion,
@parFechaHoraCreacion,
@parFechaHoraUltimaModificacion
)

select @@identity as IdMax
GO
