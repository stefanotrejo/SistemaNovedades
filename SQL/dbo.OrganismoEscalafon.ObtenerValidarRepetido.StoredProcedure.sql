USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[OrganismoEscalafon.ObtenerValidarRepetido]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[OrganismoEscalafon.ObtenerValidarRepetido]
(
@orgId int,
@escId int

)
as

declare @Existe int 

select @Existe = count(*)
from OrganismoEscalafon 
where 1 = 1
and orgId = @orgId
and escId = @escId

select @Existe = case when @Existe > 1 then 1 else @Existe end

select @Existe as Existe


GO
