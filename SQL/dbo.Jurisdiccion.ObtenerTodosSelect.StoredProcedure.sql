USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Jurisdiccion.ObtenerTodosSelect]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Jurisdiccion.ObtenerTodosSelect]
as

--select 0 as jurId, 'TODAS LAS JURISDICCIONES' as jurNombre
--union all
select jurId, jurNombre
from Jurisdiccion
where jurActivo = 1
order by jurNombre


GO
