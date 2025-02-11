USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PerfilMenu.EliminarPadresSinHijos]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[PerfilMenu.EliminarPadresSinHijos]
(
@perId int
)
as

delete 
from PerfilMenu 
where perId = @perId
and menId in
(
	select men.menId
	from PerfilMenu pme, Menu men
	where 1 = 1
	and pme.menId = men.menId
	and men.menIdPadre = 0
	and pme.perId = @perId
	and pme.menId not in
	(
	select men.menIdPadre
	from PerfilMenu pme, Menu men
	where 1 = 1
	and pme.menId = men.menId
	and men.menIdPadre <> 0
	and pme.perId = @perId
	)
)

GO
