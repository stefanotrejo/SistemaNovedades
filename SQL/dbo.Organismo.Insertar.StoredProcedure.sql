USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Organismo.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Organismo.Insertar]
@orgCodigo varchar(50),
@orgNombre varchar(50),
@jurId int
AS
BEGIN
insert into Organismo
(orgCodigo,orgNombre,jurId)
values
(@orgCodigo,@orgNombre,@jurId)
select @@IDENTITY 
END



GO
