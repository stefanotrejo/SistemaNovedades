USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Perfil.ObtenerUno]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Perfil.ObtenerUno]
(
@perId int
)

as

select 
Perfil.perId as [Id], 
isnull(Perfil.perNombre,' ') as [Nombre], 
isnull(Perfil.perDescripcion,' ') as [Descripcion], 
case when Perfil.perEsAdministrador = 0 then 'No' else 'Si' end as [EsAdministrador], 
Usuario_usuIdCreacion.usuNombre as [Usuario Creacion], 
Usuario_usuIdUltimaModificacion.usuNombre as [Usuario UltimaModificacion], 
convert(varchar(10),Perfil.perFechaHoraCreacion,103) as [FechaHoraCreacion], 
convert(varchar(10),Perfil.perFechaHoraUltimaModificacion,103) as [FechaHoraUltimaModificacion], 
case when Perfil.perActivo = 0 then 'No' else 'Si' end as [Activo], Perfil.perId,
Perfil.perNombre,
Perfil.perDescripcion,
Perfil.perEsAdministrador,
Perfil.usuIdCreacion,
Perfil.usuIdUltimaModificacion,
Perfil.perFechaHoraCreacion,
Perfil.perFechaHoraUltimaModificacion,
Perfil.perActivo

from Perfil
left outer join Usuario as Usuario_usuIdCreacion on Perfil.usuIdCreacion = Usuario_usuIdCreacion.usuId
left outer join Usuario as Usuario_usuIdUltimaModificacion on Perfil.usuIdUltimaModificacion = Usuario_usuIdUltimaModificacion.usuId

where 1 = 1 
and Perfil.perId = @perId
GO
