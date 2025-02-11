USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.ObtenerGrupo]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Usuario.ObtenerGrupo]
(
@usuId int
)
as

declare @pgrId int
select @pgrId = 0

if 
(
select COUNT(*) from Perfil per, Usuario usu 
where usu.perId = per.perId and usu.usuId = @usuId
and per.perId = (select convert(int,parValor) from Parametro where parNombre = 'Perfil_Inmobiliaria')
) > 0
begin
	select @pgrId = CONVERT(int, parValor) from Parametro where parNombre = 'ProveedorGrupo_Inmobiliaria'
	end
else
	begin
	select @pgrId = CONVERT(int, parValor) from Parametro where parNombre = 'ProveedorGrupo_Sanatorio'
end

select @pgrId as pgrId



GO
