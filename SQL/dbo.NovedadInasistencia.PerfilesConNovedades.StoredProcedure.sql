USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.PerfilesConNovedades]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[NovedadInasistencia.PerfilesConNovedades]
(
@liqId int
)

as

select 
distinct NI.perEsAdministrador
from NovedadInasistencia NI
where liqId=@liqId


GO
