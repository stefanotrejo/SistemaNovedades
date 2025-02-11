USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Error.InsertarError]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Error.InsertarError]
	@usuId int,
	@Message varchar(max),
	@StackTrace varchar(max),	
	@TargetSite varchar (max)
AS 
INSERT INTO Error(usuId,errMessage,errStackTrace,errTargetSite,errFechaHoraCreacion,errActivo) 
values (@usuId,@Message,@StackTrace,@TargetSite,GETDATE(),1)
GO
