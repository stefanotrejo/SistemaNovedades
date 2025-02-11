USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Parametro.EliminarBloqueos]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Parametro.EliminarBloqueos]
(
@BaseDatos varchar(50)
)
as

set dateformat dmy

if @BaseDatos = '' begin select @BaseDatos = 'IDES2016' end

create table #Tabla(spid int, ecid int, status varchar(max), loginame varchar(max), hostname varchar(max), blk int,
dbname varchar(max), cmd varchar(max), request_id int)

insert into #Tabla exec sp_who

declare cTabla cursor for 
select spid 
from #Tabla 
where dbname = @BaseDatos 
and loginame <> 'sa'
and blk = 1

declare @spid int, @Cadena varchar(max)
open cTabla
fetch next from cTabla into @spid
while @@FETCH_STATUS = 0
begin
	select @Cadena = 'kill ' + convert(varchar(50),@spid)
	exec(@Cadena)

	fetch next from cTabla into @spid
end
close cTabla
deallocate cTabla

drop table #Tabla


GO
