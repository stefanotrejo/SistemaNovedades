USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.ObtenerLista]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Usuario.ObtenerLista]
(
@PrimerItem varchar(500)
)
as

select '0' as Valor, @PrimerItem as Texto 
union all
select convert(varchar(50),usuId) as Valor, usuNombre as Texto
from Usuario
where 1 = 1
and usuActivo = 1
order by 2
GO
