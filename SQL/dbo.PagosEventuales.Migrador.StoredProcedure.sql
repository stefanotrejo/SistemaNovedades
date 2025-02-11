USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PagosEventuales.Migrador]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PagosEventuales.Migrador]
as

Declare 
@ageApellidoNombre   nvarchar (255)  ,
@ageDNI   nvarchar(255)  ,
@ageCUIT   nvarchar(255)  ,
@ageSexo   nvarchar(255)  ,
@ageJurisdiccion   varchar (3)  ,
@agePrograma   varchar (3)  ,
@ageNroControl   nvarchar (255)  ,
@pevLugarPagoCodigo   varchar(50)  ,
@pevImporteTotal   float ,
@pevFechaCarga   date ,
@pevGenerado   tinyint ,
@pevPagoAcumulado   tinyint ,
@pevUtlimaVezGenerado   datetime ,
@pevNroLote   varchar (50),
@pevId int ,
@dpeMes int ,
@dpeAnio int ,
@dpeConcepto varchar(50) 

DECLARE CursorPagosEventuales CURSOR FOR
-- CONSULTA A GUARDAR EN EL CURSOR
select [ageApellidoNombre]
      ,[ageDNI]
      ,[ageCUIT]
      ,[ageSexo]
      ,[ageJurisdiccion]
      ,[agePrograma]
      ,[ageNroControl]
      ,[pevLugarPagoCodigo]
      ,[pevImporteTotal]
      ,[pevFechaCarga]
      ,[pevGenerado]
      ,[pevPagoAcumulado]
      ,[pevUtlimaVezGenerado]
      ,[pevNroLote]
	  ,[dpeMes]
      ,[dpeAnio]
      ,[dpeConcepto]
from PagosEventuales t1
inner join DetallePagoEventual t2
on t1.pevId = t2.pevId


OPEN CursorPagosEventuales
FETCH CursorPagosEventuales 
into 
@ageApellidoNombre   ,
@ageDNI  			 ,
@ageCUIT   			 ,
@ageSexo   			 ,
@ageJurisdiccion   	 ,
@agePrograma   		 ,
@ageNroControl  	 ,
@pevLugarPagoCodigo  ,
@pevImporteTotal   	 ,
@pevFechaCarga  	 ,
@pevGenerado  		 ,
@pevPagoAcumulado    ,
@pevUtlimaVezGenerado,
@pevNroLote, 
@dpeMes  ,
@dpeAnio  ,
@dpeConcepto 
WHILE (@@FETCH_STATUS = 0)
BEGIN

-- INSERTAR EN PAGOS EVENTUALES Y GUARDAR ULTIMO ID REGISTRADO PEVID
insert into PagosEventuales_test 
(ageApellidoNombre, ageDNI, ageCUIT,ageSexo, ageJurisdiccion, agePrograma, ageNroControl, pevLugarPagoCodigo, pevImporteTotal, pevFechaCarga, pevGenerado, pevPagoAcumulado, pevUtlimaVezGenerado, pevNroLote)
values
(@ageApellidoNombre,@ageDNI,@ageCUIT,@ageSexo,@ageJurisdiccion,@agePrograma,@ageNroControl,@pevLugarPagoCodigo,@pevImporteTotal,@pevFechaCarga,@pevGenerado,@pevPagoAcumulado,@pevUtlimaVezGenerado,@pevNroLote)

select @pevId = @@identity 

-- INSERTAR EN DETALLE PAGOS EVENTUALES
insert into DetallePagoEventual_test 
(pevId, dpeMes, dpeAnio, dpeConcepto)
values
(@pevId, @dpeMes, @dpeAnio, @dpeConcepto)


FETCH NEXT FROM CursorPagosEventuales 
into 
@ageApellidoNombre   ,
@ageDNI  			 ,
@ageCUIT   			 ,
@ageSexo   			 ,
@ageJurisdiccion   	 ,
@agePrograma   		 ,
@ageNroControl  	 ,
@pevLugarPagoCodigo  ,
@pevImporteTotal   	 ,
@pevFechaCarga  	 ,
@pevGenerado  		 ,
@pevPagoAcumulado    ,
@pevUtlimaVezGenerado,
@pevNroLote, 
@dpeMes  ,
@dpeAnio  ,
@dpeConcepto 
END
CLOSE CursorPagosEventuales
DEALLOCATE CursorPagosEventuales



-- HACER TABLAS CON EL MISMO DISEÑO DE PAGOS EVENTUALES Y DETALLE PAGOS EVENTUALES PARA PROBAR
GO
