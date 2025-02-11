USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Menu.ObtenerListaFechas]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Menu.ObtenerListaFechas]
as
create table #Tabla(FechaCarga date)

insert into #Tabla select DIStinct pevFechaCarga from PagosEventuales order by pevFechaCarga DESC

--select TOP 3 FechaCarga from #Tabla
Select TOP 5 convert(varchar, #Tabla.FechaCarga, 103) as FechaCarga from #Tabla
drop table #Tabla
GO
