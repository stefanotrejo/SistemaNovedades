USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Parametro.Eliminar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Parametro.Eliminar]
(
@parId int
)

as
delete from Parametro
where 1 = 1 
and Parametro.parId = @parId
GO
