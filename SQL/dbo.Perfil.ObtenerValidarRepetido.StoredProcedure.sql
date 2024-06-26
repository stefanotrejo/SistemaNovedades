USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Perfil.ObtenerValidarRepetido]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Perfil.ObtenerValidarRepetido]
(
@perId int,
@perNombre varchar(50)

)
as

declare @Existe int 

select @Existe = count(*)
from Perfil
where 1 = 1
and perNombre = @perNombre
and ((perId <> @perId and @perId > 0)
or (perNombre = @perNombre and @perId = 0))

select @Existe = case when @Existe > 1 then 1 else @Existe end

select @Existe as Existe
GO
