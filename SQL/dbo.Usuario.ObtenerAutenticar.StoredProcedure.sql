USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.ObtenerAutenticar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Usuario.ObtenerAutenticar]
(
@usuNombreIngreso varchar(50), 
@usuClave varchar(500)
)

as

select 
usu.*, usu.usuApellido + ' ' + usu.usuNombre as Usuario, per.*, '' as PaginasPermitidas

from Usuario usu
left outer join Perfil per on per.perId = usu.perId
where 1 = 1
and usu.usuNombreIngreso = @usuNombreIngreso
and usu.usuActivo = 1
and per.perActivo = 1
and usu.usuClave = @usuClave

GO
