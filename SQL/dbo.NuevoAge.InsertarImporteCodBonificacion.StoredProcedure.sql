USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NuevoAge.InsertarImporteCodBonificacion]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[NuevoAge.InsertarImporteCodBonificacion]
@NuegoAgeId int, 
@codBonifDescto2  varchar(50),
@importe varchar(50)
as
BEGIN
insert into ConceptoTemporal (ageId,cteCodigoConcepto,cteImporte) values (@NuegoAgeId, @codBonifDescto2,@importe)
--UPDATE NuevoAge SET codBonifDescto=@codBonifDescto2, importe=@importe WHERE NuevoAgeId = @NuegoAgeId
END


GO
