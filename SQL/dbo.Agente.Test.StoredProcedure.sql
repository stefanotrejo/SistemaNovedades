USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agente.Test]    Script Date: 24/10/2022 18:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Agente.Test]
(
@ageCuil varchar(50),
@ageTipoDocumento varchar(50),
@ageApellidoyNombre varchar(100),
@ageFechaNacimiento datetime,
@ageSexo varchar(50),
--@ageEstadoCivil varchar(50),
--@ageNumeroObraSocial varchar(50),
--@ageCantidadAdherente int,
@ageActivo tinyint
--@usuIdCreacion int,
--@usuIdUltimaModificacion int,
--@ageFechaHoraCreacion datetime,
--@ageFechaHoraUltimaModificacion datetime
)

as

insert into Agente
(
ageCuil,
ageTipoDocumento,
ageApellidoyNombre,
ageFechaNacimiento,
ageSexo,
--ageEstadoCivil,
--ageNumeroObraSocial,
--ageCantidadAdherente,
ageActivo
--usuIdCreacion,
--usuIdUltimaModificacion,
--ageFechaHoraCreacion,
--ageFechaHoraUltimaModificacion
)

values
(
@ageCuil,
@ageTipoDocumento,
@ageApellidoyNombre,
@ageFechaNacimiento,
@ageSexo,
--@ageEstadoCivil,
--@ageNumeroObraSocial,
--@ageCantidadAdherente,
@ageActivo
--@usuIdCreacion,
--@usuIdUltimaModificacion,
--@ageFechaHoraCreacion,
--@ageFechaHoraUltimaModificacion
)

select @@identity as IdMax

GO
