USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.ObtenerListaCustom]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usuario.ObtenerListaCustom] 
(
@PrimerItem varchar(500)
)
as

select 0 as Valor, @PrimerItem as Texto 
union all
select Usuario.usuId as Valor, 
ltrim(rtrim(isnull(Usuario.usuApellido,'') + isnull(' ' + Usuario.usuNombre,'') + ' (' + Usuario.usuNombreIngreso + ')')) as Texto 
from Usuario 
where Usuario.usuActivo = 1 
order by 2

GO
