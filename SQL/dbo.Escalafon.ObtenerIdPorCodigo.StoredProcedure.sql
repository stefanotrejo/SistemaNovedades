USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Escalafon.ObtenerIdPorCodigo]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Escalafon.ObtenerIdPorCodigo]
@escCodigo varchar(50)
AS
BEGIN

  declare @escId int 
  set @escId = ISNULL((select escId   
  from Escalafon 
  where escCodigo = @escCodigo),0)  
  select @escId as escId




--select escId from Escalafon where escCodigo = @escCodigo 
END


GO
