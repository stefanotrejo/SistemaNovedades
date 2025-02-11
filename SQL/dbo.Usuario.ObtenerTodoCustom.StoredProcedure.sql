USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.ObtenerTodoCustom]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usuario.ObtenerTodoCustom]
(
@Nombre varchar(50),
@Apellido varchar(50),
@Usuario varchar(50),
@perId int,
@MostrarAlumnos tinyint
)

as

select 
Usuario.usuId as Id,Usuario.usuApellido as Apellido,Usuario.usuNombre as Nombre,
Usuario.usuNombreIngreso as NombreIngreso,
Usuario.usuEmail as Email,
isnull(Perfil_perId.perNombre,'') as Perfil,
case when Usuario.usuActivo = 1 then 'Si' else 'No' end as Activo 
from Usuario 
left outer join Perfil as Perfil_perId on Usuario.perId = Perfil_perId.perId 
where 1 = 1
and ((@Nombre <> '' and Usuario.usuNombre like '%' + @Nombre + '%') or @Nombre = '')
and ((@Apellido <> '' and Usuario.usuApellido like '%' + @Apellido + '%') or @Apellido = '')
and ((@Usuario <> '' and Usuario.usuNombreIngreso like '%' + @Usuario + '%') or @Usuario = '')
and ((@perId > 0 and Usuario.perId = @perId) or @perId = 0)
and ((@MostrarAlumnos = 0 and Usuario.perId <> 23) or @MostrarAlumnos = 1)
order by 2,3,4

GO
