USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Menu.ObtenerTodasFechas]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Menu.ObtenerTodasFechas]
as
create table #Tabla(FechaCarga date)

insert into #Tabla select DIStinct ageFechaCarga from PagosEventuales order by ageFechaCarga DESC

--select FechaCarga from #Tabla
Select convert(varchar, #Tabla.FechaCarga, 103) as FechaCarga from #Tabla
drop table #Tabla
GO
