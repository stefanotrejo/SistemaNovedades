USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.ObtenerUnoUsuarioEmail]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usuario.ObtenerUnoUsuarioEmail]
(
@Usuario varchar(50),
@Email varchar(max)
)
as

select 
usu.*, usu.usuApellido + ' ' + usu.usuNombre as Usuario, 
per.*, 
ISNULL(alu.aluId,0) as aluId, 
ISNULL(emp.empId,0) as empId,
'' as PaginasPermitidas

from Usuario usu
left outer join Perfil per on per.perId = usu.perId
left outer join Alumno alu on alu.usuId = usu.usuId
left outer join Empleado emp on emp.usuId = usu.usuId
where 1 = 1
and usu.usuActivo = 1
and per.perActivo = 1
and usu.usuNombreIngreso = @Usuario
and usu.usuEmail = @Email
GO
