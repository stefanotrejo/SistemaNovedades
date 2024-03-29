USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.ObtenerValidarRepetido]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Usuario.ObtenerValidarRepetido]
(
@usuId int,
@usuNombre varchar(500)

)
as

declare @Existe int 

select @Existe = count(*)
from Usuario
where 1 = 1
and usuNombre = @usuNombre
and ((usuId <> @usuId and @usuId > 0)
or (usuNombre = @usuNombre and @usuId = 0))

select @Existe = case when @Existe > 1 then 1 else @Existe end

select @Existe as Existe
GO
