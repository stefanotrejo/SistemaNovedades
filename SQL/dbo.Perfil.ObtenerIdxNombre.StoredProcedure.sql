USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Perfil.ObtenerIdxNombre]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Perfil.ObtenerIdxNombre]
(
@perNombre varchar(50)
)
as

select perId
from Perfil
where perNombre=@perNombre



GO
