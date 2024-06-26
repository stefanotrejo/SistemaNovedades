USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Agentes.CalcularNuevoTotalHaberesPorLiquidacion]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agentes.CalcularNuevoTotalHaberesPorLiquidacion]
@MesAnioLiquidacion varchar(5)
AS

-- DECLARACION TABLA TEMPORAL
declare @tabla table 
(id int, 
SalarioFamiliar numeric (18,2), 
TotalHaberes numeric (18,2))

-- LLENO TABLA TEMPORAL
insert into @tabla (id,SalarioFamiliar,TotalHaberes) 
select NuevoAgeId1,SalarioFamiliar,TotalHaberes 
from PruebasAge 
where MesAnioLiq=@MesAnioLiquidacion

-- DECLARACION DE VARIABLES
declare @CantidadDeRegistros int = (select count(*) from @tabla)
declare @Id int
declare @SalarioFamiliar numeric (18,2)
declare @TotalHaberes numeric (18,2)
declare @NuevoTotalHaberes numeric (18,2)

--Recorre todos los registros uno a uno y actualiza el NuevoTotalHaberes
while @CantidadDeRegistros>0
begin
	
	set @Id = (select top (1) id from  @tabla order by id)
	set @SalarioFamiliar = (select top (1) SalarioFamiliar from  @tabla order by id)
	set @TotalHaberes = (select top (1) TotalHaberes from  @tabla order by id)

	set @NuevoTotalHaberes = @TotalHaberes -
	((select SUM(cteImporte) as Total
	FROM [LiquidacionSueldos].[dbo].[ConceptoTemporal] 
	where 
	cteCodigoConcepto=601 and ageId=@id
	OR cteCodigoConcepto=746 and ageId=@id 
	OR cteCodigoConcepto=747 and ageId=@id)
	+ @SalarioFamiliar)

	if (@NuevoTotalHaberes is null)
	--set @NuevoTotalHaberes = 0
	set @NuevoTotalHaberes = @TotalHaberes-@SalarioFamiliar

	UPDATE PruebasAge SET PruebasAge.NuevoTotalHaberes=@NuevoTotalHaberes
	WHERE PruebasAge.NuevoAgeId1=@Id

	DELETE @tabla WHERE id=@Id
	SET @CantidadDeRegistros=@CantidadDeRegistros-1

end
GO
