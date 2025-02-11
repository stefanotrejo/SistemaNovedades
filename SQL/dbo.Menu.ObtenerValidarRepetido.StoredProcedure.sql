USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Menu.ObtenerValidarRepetido]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Menu.ObtenerValidarRepetido]
(
@menId int,
@menNombre varchar(250)

)
as

declare @Existe int 

select @Existe = count(*)
from Menu
where 1 = 1
and menNombre = @menNombre
and ((menId <> @menId and @menId > 0)
or (menNombre = @menNombre and @menId = 0))

select @Existe = case when @Existe > 1 then 1 else @Existe end

select @Existe as Existe
GO
