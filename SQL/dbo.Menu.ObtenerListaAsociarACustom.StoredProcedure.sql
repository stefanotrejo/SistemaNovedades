USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Menu.ObtenerListaAsociarACustom]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Menu.ObtenerListaAsociarACustom]
(
@perId int
)
as

select 0 as Valor, '[Seleccionar...]' as Texto, -1 as MenuPadreOrden, -1 as MenuOrden, '' as menNombrePadre, '' as menNombreHijo
union all
select men.menId as Valor, menPadre.menNombre + '/' + men.menNombre as Texto, menPadre.menOrden, men.menOrden, menPadre.menNombre, men.menNombre
from Menu men, Menu menPadre 
where men.menActivo = 1 
and men.menIdPadre = menPadre.menId
and men.menId not in (select pme.menId from PerfilMenu pme where pme.perId = @perId)
union all

select men.menId as Valor, men.menNombre as Texto, men.menOrden, men.menOrden, '', men.menNombre
from Menu men
where men.menActivo = 1 
and men.menIdPadre = 0
and men.menId not in (select pme.menId from PerfilMenu pme where pme.perId = @perId)

order by 2,4


GO
