USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[LiquidacionExtensionDocente.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LiquidacionExtensionDocente.Insertar] 
@descripcion varchar(100),
@mes varchar(50),
@anio varchar(50),
@etapa tinyint,
@estado varchar(1)
AS

BEGIN
insert into LiquidacionExtensionDocente
(
descripcion,
mes,
anio ,
etapa ,
estado ,
fechaInicio,
activo
) 
values 
(
@descripcion ,
@mes,
@anio,
@etapa,
@estado,
GETDATE(),
1
) 

select @@IDENTITY 
END

GO
