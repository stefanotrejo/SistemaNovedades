USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Ayuda.ObtenerUno]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Ayuda.ObtenerUno]
(
@ayuId int
)

as

select 
Ayuda.ayuId as [Id], 
isnull(Ayuda.ayuPaginaNombre,' ') as [PaginaNombre], 
isnull(Ayuda.ayuDescripcion,' ') as [Descripcion], 
case when Ayuda.ayuActivo = 0 then 'No' else 'Si' end as [Activo], 
Usuario_usuIdCreacion.usuNombre as [Usuario Creacion], 
Usuario_usuIdUltimaModificacion.usuNombre as [Usuario UltimaModificacion], 
convert(varchar(10),Ayuda.ayuFechaHoraCreacion,103) as [FechaHoraCreacion], 
convert(varchar(10),Ayuda.ayuFechaHoraUltimaModificacion,103) as [FechaHoraUltimaModificacion], Ayuda.ayuId,
Ayuda.ayuPaginaNombre,
Ayuda.ayuDescripcion,
Ayuda.ayuActivo,
Ayuda.usuIdCreacion,
Ayuda.usuIdUltimaModificacion,
Ayuda.ayuFechaHoraCreacion,
Ayuda.ayuFechaHoraUltimaModificacion

from Ayuda
left outer join Usuario as Usuario_usuIdCreacion on Ayuda.usuIdCreacion = Usuario_usuIdCreacion.usuId
left outer join Usuario as Usuario_usuIdUltimaModificacion on Ayuda.usuIdUltimaModificacion = Usuario_usuIdUltimaModificacion.usuId

where 1 = 1 
and Ayuda.ayuId = @ayuId
GO
