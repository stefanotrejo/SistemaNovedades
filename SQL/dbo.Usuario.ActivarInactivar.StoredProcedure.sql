USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.ActivarInactivar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[Usuario.ActivarInactivar]
(@usuId int)
as

update Usuario set usuActivo = case when usuActivo = 1 then 0 else 1 end where usuId = @usuId

GO
