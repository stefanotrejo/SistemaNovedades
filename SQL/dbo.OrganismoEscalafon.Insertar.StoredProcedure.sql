USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[OrganismoEscalafon.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[OrganismoEscalafon.Insertar]
@orgId int,
@escId int
AS
BEGIN
insert into OrganismoEscalafon 
(orgId,escId)
values
(@orgId,@escId)
select @@IDENTITY 
END



GO
