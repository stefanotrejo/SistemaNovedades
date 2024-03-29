USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[EmailSalida.ObtenerTodoCustom]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmailSalida.ObtenerTodoCustom]
as

set dateformat dmy

select esa.esaId as Id, 
esa.esaTipo as Tipo, isnull(esa.esaDescripcion,'') as Descripcion
from EmailSalida esa
where 1 = 1
and esa.esaActivo = 1
order by 1

GO
