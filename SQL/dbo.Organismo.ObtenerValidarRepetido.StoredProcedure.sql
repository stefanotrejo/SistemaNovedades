USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Organismo.ObtenerValidarRepetido]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Organismo.ObtenerValidarRepetido]
(

@orgCodigo varchar(50)

)
as

declare @Existe int 

select @Existe = count(*)
from Organismo 
where 1 = 1
and orgCodigo = @orgCodigo

select @Existe = case when @Existe > 1 then 1 else @Existe end

select @Existe as Existe


GO
