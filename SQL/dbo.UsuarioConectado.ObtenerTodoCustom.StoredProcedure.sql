USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[UsuarioConectado.ObtenerTodoCustom]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UsuarioConectado.ObtenerTodoCustom]
as

set dateformat dmy

select usu.usuNombreIngreso as Usuario, usu.usuApellido as Apellido, usu.usuNombre as Nombre, per.perNombre as Perfil,
convert(varchar(10),uco.ucoFechaHoraUltimaConexion,103) as Fecha, convert(varchar(5),uco.ucoFechaHoraUltimaConexion,108) as Hora,
case when uco.ucoDesconectar = 1 then 'Si' else 'No' end as Desconectar
from UsuarioConectado uco, Usuario usu, Perfil per
where 1 = 1
and per.perId = usu.perId
and usu.usuId = uco.usuId
order by 2,3


GO
