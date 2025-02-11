USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Perfil.ObtenerNovedad]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Perfil.ObtenerNovedad]
(
@novId int
)

as

select distinct per.perId as Id, per.perNombre as Nombre, 
case when ISNULL(nde.perId,0) = 0 then 0 else 1 end as Seleccionado
from Perfil per
left outer join NovedadDetalle nde on nde.perId = per.perId and nde.novId = @novId 
where 1 = 1
and per.perActivo = 1
order by per.perNombre


GO
