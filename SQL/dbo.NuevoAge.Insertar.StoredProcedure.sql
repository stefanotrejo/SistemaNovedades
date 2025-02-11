USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[NuevoAge.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[NuevoAge.Insertar] 
@PlantaTipo varchar(50),
@NroCOntrol  varchar(50),
@LugarPago varchar(50),
@Escuela varchar(50),
@Escalafon varchar(50),
@Agru varchar(50),
@tramo varchar(50),
@Apertura varchar(50),
@Categoria varchar(50),
@HsCat varchar(50),
@Juris varchar(50),
@Prog varchar(50),
@SubP varchar(50),
@Actividad varchar(50),
@Nombre varchar(50),
@Cuil varchar(50),
@TipoDOc varchar(50),
@FechaNac varchar(50),
@Sexo varchar(50),
@EstadoCivil varchar(50),
@FechaIngreso varchar(50),
@Anios varchar(50),
@Meses varchar(50),
@DiasMultaAntig varchar(50),
@AniosAntig varchar(50),
@AdProfPermcgo varchar(50),
@NumeroCarnet varchar(50),
@AporteIOSEP varchar(50),
@AporteOsocNac varchar(50),
@Jubilado varchar(50),
@AportePrevisional varchar(50),
@SituRev varchar(50),
@Interinato varchar(50),
@SituRevDoc varchar(50),
@NopresRiesgoVida varchar(50),
@FechaBaja varchar(50),
@MesAnioLiq varchar(50),
@DiasTrabajados varchar(50),
@ImponibleANSES varchar(50),
@Imponible varchar(50),
@HaberSaporte varchar(50),
@HaberCaporte varchar(50),
@TotalHaberes varchar(50),
@TotalDescuentos varchar(50),
@Liquido varchar(50),
@CantItemsOcupados varchar(50),
@FechaLiquidacion datetime,
@activo tinyint,
@Legajo varchar(50),
@Bloqueo varchar(50)
AS
BEGIN
insert into [dbo].[PruebasAge] 
	  ([PlantaTipo]
      ,[NroCOntrol]
      ,[LugarPago]
      ,[Escuela]
      ,[Escalafon]
      ,[Agru]
      ,[tramo]
      ,[Apertura]
      ,[Categoria]
      ,[HsCat]
      ,[Juris]
      ,[Prog]
      ,[SubP]
      ,[Actividad]
      ,[Nombre]
      ,[Cuil]
      ,[TipoDOc]
      ,[FechaNac]
      ,[Sexo]
      ,[EstadoCivil]
      ,[FechaIngreso]
      ,[Anios]
      ,[Meses]
      ,[DiasMultaAntig]
      ,[AniosAntig]
      ,[Ad.Prof/Perm.cgo]
      ,[NumeroCarnet]
      ,[AporteIOSEP]
      ,[AporteOsocNac]
      ,[Jubilado]
      ,[AportePrevisional]
      ,[SituRev]
      ,[Interinato]
      ,[SituRevDoc]
      ,[Nopres/RiesgoVida]
      ,[FechaBaja]
      ,[MesAnioLiq]
      ,[DiasTrabajados]
      ,[ImponibleANSES]
      ,[Imponible]
      ,[HaberS/aporte]
      ,[HaberC/aporte]
      ,[TotalHaberes]
      ,[TotalDescuentos]
      ,[Liquido]
      ,[CantItemsOcupados]
	  ,[FechaLiquidacion]
	  ,[Activo]
	  ,[Legajo]
	  ,[Bloqueo]
      ) 
	  values 
(@PlantaTipo,
@NroCOntrol,
@LugarPago,
@Escuela,
@Escalafon,
@Agru,
@tramo,
@Apertura  ,
@Categoria  ,
@HsCat  ,
@Juris  ,
@Prog  ,
@SubP  ,
@Actividad  ,
@Nombre  ,
@Cuil  ,
@TipoDOc  ,
@FechaNac  ,
@Sexo  ,
@EstadoCivil  ,
@FechaIngreso  ,
@Anios  ,
@Meses  ,
@DiasMultaAntig  ,
@AniosAntig  ,
@AdProfPermcgo  ,
@NumeroCarnet  ,
@AporteIOSEP  ,
@AporteOsocNac  ,
@Jubilado  ,
@AportePrevisional  ,
@SituRev  ,
@Interinato  ,
@SituRevDoc  ,
@NopresRiesgoVida  ,
@FechaBaja  ,
@MesAnioLiq  ,
@DiasTrabajados  ,
@ImponibleANSES  ,
@Imponible  ,
@HaberSaporte  ,
@HaberCaporte  ,
@TotalHaberes  ,
@TotalDescuentos  ,
@Liquido  ,
@CantItemsOcupados,
@FechaLiquidacion,
@activo,  
@Legajo,
@Bloqueo
) 

select @@IDENTITY 
END

GO
