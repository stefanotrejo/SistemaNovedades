USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.ImportarArchivoPersonal]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Agentes.ImportarArchivoPersonal]
@numeroControl int,
@dni int,
@mesanio varchar(5)
as

declare @id int = (
SELECT NuevoAgeId1
FROM PruebasAge  
WHERE NroCOntrol=@numeroControl 
and SUBSTRING(PruebasAge.Cuil, 3, 8)=@dni
and MesAnioLiq=@mesanio
and Activo=1 )

--SELECT @id
--if (@id != NULL)

if (@id IS NOT NULL)
UPDATE PruebasAge SET cargarNovedades=1
WHERE NuevoAgeId1=@id




GO
