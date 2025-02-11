USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[LiquidacionNovedades.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LiquidacionNovedades.Insertar] 
@liqDescripcion varchar(100),
@liqMes varchar(50),
@liqAnio varchar(50),
@liqEtapa tinyint,
@liqEstado varchar(1),
@liqFechaInicio datetime
AS
BEGIN
insert into Liquidacion
(
liqDescripcion,
liqMes,
liqAnio ,
liqEtapa ,
liqEstado ,
liqFechaInicio,
liqActivo
) 
values 
(
@liqDescripcion ,
@liqMes,
@liqAnio,
@liqEtapa,
@liqEstado,
@liqFechaInicio,
1
) 

select @@IDENTITY 
END



GO
