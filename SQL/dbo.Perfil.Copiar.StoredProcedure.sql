USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Perfil.Copiar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Perfil.Copiar]
(
@perNombre varchar(50),
@perDescripcion varchar(250),
@perEsAdministrador tinyint,
@usuIdCreacion int,
@usuIdUltimaModificacion int,
@perFechaHoraCreacion datetime,
@perFechaHoraUltimaModificacion datetime,
@perActivo tinyint
)

as

insert into Perfil
(
perNombre,
perDescripcion,
perEsAdministrador,
usuIdCreacion,
usuIdUltimaModificacion,
perFechaHoraCreacion,
perFechaHoraUltimaModificacion,
perActivo
)

values
(
'Copia de ' + @perNombre,
@perDescripcion,
@perEsAdministrador,
@usuIdCreacion,
@usuIdUltimaModificacion,
@perFechaHoraCreacion,
@perFechaHoraUltimaModificacion,
@perActivo
)

select @@identity as IdMax
GO
