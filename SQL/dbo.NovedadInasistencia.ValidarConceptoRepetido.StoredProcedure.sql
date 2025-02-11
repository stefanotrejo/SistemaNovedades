USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NovedadInasistencia.ValidarConceptoRepetido]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[NovedadInasistencia.ValidarConceptoRepetido]
@liqId int,
@NuevoAgeId1 int,
@ncoId int
as

declare @Existe int 

select @Existe = count(*)
from NovedadInasistencia 
where 1 = 1
and liqId = @liqId
and NuevoAgeId1=@NuevoAgeId1
and ncoId = @ncoId 
and ninActivo=1

/*
select @Existe = case when @Existe > 1 then 1 else @Existe end

select @Existe as Existe */

-- nueva version

if (@Existe != 0)	
	begin

	if (@ncoId <= 10) -- se permite novedad repetida
		select @Existe = 0
	else			-- no se permite novedad repetida
		select @Existe = 1

	end
else -- si no existe ninguna novedad con ese ncoId devuelvo 0 (OK)
	select @Existe = 0

select @Existe as Existe


GO
