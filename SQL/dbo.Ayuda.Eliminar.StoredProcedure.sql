USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Ayuda.Eliminar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Ayuda.Eliminar]
(
@ayuId int
)

as
delete from Ayuda
where 1 = 1 
and Ayuda.ayuId = @ayuId
GO
