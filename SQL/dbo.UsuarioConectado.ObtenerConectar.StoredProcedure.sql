USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[UsuarioConectado.ObtenerConectar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UsuarioConectado.ObtenerConectar]
(
@usuId int,
@ucoGuid varchar(max),
@ucoIpPublica varchar(50)
)
as

set dateformat dmy

begin tran

/*BORRA TODOS LOS REGISTROS QUE TENGAN MAS DE UN MINUTO DE ANTIGUEDAD*/
delete from UsuarioConectado where datediff(ss, ucoFechaHoraUltimaConexion, getdate()) > 60

declare @ucoId int
select @ucoId = 0

select @ucoId = ucoId 
from UsuarioConectado 
where 1 = 1
and usuId = @usuId 
and ucoGuid = @ucoGuid 
and ucoIpPublica = @ucoIpPublica

select @ucoId = isnull(@ucoId,0)

if @ucoId = 0
	begin
	insert into UsuarioConectado select @usuId, getdate(), @ucoGuid, @ucoIpPublica, 0, 1, @usuId, @usuId, getdate(), getdate()
	end
else
	begin
	update UsuarioConectado set ucoFechaHoraUltimaConexion = getdate() where ucoId = @ucoId
end

select isnull(ucoDesconectar,0) as Desconectar from UsuarioConectado where ucoId = @ucoId

commit tran
GO
