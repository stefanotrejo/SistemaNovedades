USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[EmailSalida.Eliminar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EmailSalida.Eliminar]
(
@esaId int
)

as
delete from EmailSalida
where 1 = 1 
and EmailSalida.esaId = @esaId
GO
