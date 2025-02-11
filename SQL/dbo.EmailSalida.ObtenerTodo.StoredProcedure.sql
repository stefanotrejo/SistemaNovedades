USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[EmailSalida.ObtenerTodo]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EmailSalida.ObtenerTodo]

as

select EmailSalida.esaId as [Id], 
convert(varchar(10),EmailSalida.esaFecha,103) as [Fecha], 
isnull(EmailSalida.esaPara,' ') as [Para], 
isnull(EmailSalida.esaTipo,' ') as [Tipo], 
isnull(EmailSalida.esaTitulo,' ') as [Titulo], 
isnull(EmailSalida.esaCuerpo,' ') as [Cuerpo], 
isnull(EmailSalida.esaDescripcion,' ') as [Descripcion], 
case when EmailSalida.esaActivo = 0 then 'No' else 'Si' end as [Activo], 
Usuario_usuIdCreacion.usuNombre as [Usuario Creacion], 
Usuario_usuIdUltimaModificacion.usuNombre as [Usuario UltimaModificacion], 
convert(varchar(10),EmailSalida.esaFechaHoraCreacion,103) as [FechaHoraCreacion], 
convert(varchar(10),EmailSalida.esaFechaHoraUltimaModificacion,103) as [FechaHoraUltimaModificacion],
EmailSalida.esaId, 
EmailSalida.esaFecha, 
EmailSalida.esaPara, 
EmailSalida.esaTipo, 
EmailSalida.esaTitulo, 
EmailSalida.esaCuerpo, 
EmailSalida.esaDescripcion, 
EmailSalida.cuoId, 
EmailSalida.esaActivo, 
EmailSalida.usuIdCreacion, 
EmailSalida.usuIdUltimaModificacion, 
EmailSalida.esaFechaHoraCreacion, 
EmailSalida.esaFechaHoraUltimaModificacion

from EmailSalida
left outer join Cuota as Cuota_cuoId on EmailSalida.cuoId = Cuota_cuoId.cuoId
left outer join Usuario as Usuario_usuIdCreacion on EmailSalida.usuIdCreacion = Usuario_usuIdCreacion.usuId
left outer join Usuario as Usuario_usuIdUltimaModificacion on EmailSalida.usuIdUltimaModificacion = Usuario_usuIdUltimaModificacion.usuId

order by 1
GO
