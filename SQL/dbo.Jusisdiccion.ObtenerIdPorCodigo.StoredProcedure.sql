USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Jusisdiccion.ObtenerIdPorCodigo]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  CREATE procedure [dbo].[Jusisdiccion.ObtenerIdPorCodigo]
  @jurCodigo varchar(50)
  as 
  begin 
  declare @jurId int 
  set @jurId = ISNULL((select jurId   
  from Jurisdiccion 
  where jurCodigo = @jurCodigo),0)  
  select @jurId as jurId
  end 

GO
