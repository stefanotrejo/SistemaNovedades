USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadConceptos.ObtenerListaDescentralizados]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[NovedadConceptos.ObtenerListaDescentralizados]
as

select *
from NovedadConcepto
where NovedadConcepto.ncoActivo=1
and NovedadConcepto.ncoCod='11'


GO
