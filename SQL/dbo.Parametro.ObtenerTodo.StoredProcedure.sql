USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Parametro.ObtenerTodo]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Parametro.ObtenerTodo]

as

select Parametro.parId as [Id], 
isnull(Parametro.parNombre,' ') as [Nombre], 
isnull(Parametro.parValor,' ') as [Valor], 
case when Parametro.parActivo = 0 then 'No' else 'Si' end as [Activo], 
Usuario_usuIdCreacion.usuNombre as [Usuario Creacion], 
Usuario_usuIdUltimaModificacion.usuNombre as [Usuario UltimaModificacion], 
convert(varchar(10),Parametro.parFechaHoraCreacion,103) as [FechaHoraCreacion], 
convert(varchar(10),Parametro.parFechaHoraUltimaModificacion,103) as [FechaHoraUltimaModificacion],
Parametro.parId, 
Parametro.parNombre, 
Parametro.parValor, 
Parametro.parActivo, 
Parametro.usuIdCreacion, 
Parametro.usuIdUltimaModificacion, 
Parametro.parFechaHoraCreacion, 
Parametro.parFechaHoraUltimaModificacion

from Parametro
left outer join Usuario as Usuario_usuIdCreacion on Parametro.usuIdCreacion = Usuario_usuIdCreacion.usuId
left outer join Usuario as Usuario_usuIdUltimaModificacion on Parametro.usuIdUltimaModificacion = Usuario_usuIdUltimaModificacion.usuId

order by 2
GO
