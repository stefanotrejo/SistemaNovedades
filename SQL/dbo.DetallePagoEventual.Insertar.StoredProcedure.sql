USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[DetallePagoEventual.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DetallePagoEventual.Insertar] 
@pevId int,
@mes int,
@anio int,
@dpeConcepto varchar(50) 	
AS
BEGIN
	insert into DetallePagoEventual (pevId,dpeMes,dpeAnio,dpeConcepto) values (@pevId,@mes,@anio,@dpeConcepto)
END

GO
