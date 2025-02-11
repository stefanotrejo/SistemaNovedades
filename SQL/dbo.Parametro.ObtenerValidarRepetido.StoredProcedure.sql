USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Parametro.ObtenerValidarRepetido]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Parametro.ObtenerValidarRepetido]
(
@parId int,
@parNombre varchar(50)

)
as

declare @Existe int 

select @Existe = count(*)
from Parametro
where 1 = 1
and parNombre = @parNombre
and ((parId <> @parId and @parId > 0)
or (parNombre = @parNombre and @parId = 0))

select @Existe = case when @Existe > 1 then 1 else @Existe end

select @Existe as Existe
GO
