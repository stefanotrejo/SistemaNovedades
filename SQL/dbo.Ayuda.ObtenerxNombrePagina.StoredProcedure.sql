USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Ayuda.ObtenerxNombrePagina]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Ayuda.ObtenerxNombrePagina]
(
@ayuPaginaNombre varchar(max),
@usuId int
)
as

set dateformat dmy

declare @ayuId int
select @ayuId = 0

select @ayuId = ayuId from Ayuda where ayuPaginaNombre = @ayuPaginaNombre
select @ayuId = isnull(@ayuId,0)

if @ayuId = 0
	begin
	begin tran
	insert into Ayuda select @ayuPaginaNombre, '', 1, @usuId, @usuId, getdate(), getdate()
	select @@IDENTITY as ayuId
	commit tran
	end
else
	begin
	select @ayuId as ayuId
end


GO
