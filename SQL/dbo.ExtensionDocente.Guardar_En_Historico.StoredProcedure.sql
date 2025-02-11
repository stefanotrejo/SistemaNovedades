USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[ExtensionDocente.Guardar_En_Historico]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExtensionDocente.Guardar_En_Historico]
( 
@mes varchar(2),
@anio varchar(2)
)
AS

--DECLARE @mes varchar(2)
--DECLARE @anio varchar(2)

--SELECT @mes = '09'
--SELECT @anio = '22'

 --DELETE FROM ConceptoExtensionDocente_historico
 --DELETE FROM EscuelaExtensionDocente_historico
 --DELETE FROM CargosExtensionDocente_historico
 --DELETE FROM NovedadesExtensionDocente_historico


--------->> CARGOS EXT DOC HISTORICO <<---------
INSERT INTO 
	CargosExtensionDocente_historico 	  
    ([agrupamiento]
    ,[tramo]
    ,[apertura]
    ,[mes]
    ,[anio])
SELECT	 
    agrupamiento
    ,tramo
	,apertura
	,@mes
	,@anio
FROM 
	CargosExtensionDocente 

--------->> FIN - CARGOS EXT DOC HISTORICO <<---------

--------->> CONCEPTO EXT DOC HISTORICO <<---------
INSERT INTO 
	ConceptoExtensionDocente_historico 	  
    ([conId]
    ,[conCodigo]
	,mes
	,anio)
SELECT	 
     [conId]
    ,[conCodigo]
	,@mes
	,@anio
FROM 
	ConceptoExtensionDocente 

--------->> FIN - CONCEPTO EXT DOC HISTORICO <<---------


--------->> ESCUELA EXT DOC HISTORICO <<---------

INSERT INTO 
	EscuelaExtensionDocente_historico 	  
    ([CAT]
    ,[CUISE]
    ,[Organizaciones]
    ,[mes]
    ,[anio]
    ,[activo])
SELECT	 
     [CAT]
    ,[CUISE]
    ,[Organizaciones]
	 ,@mes
	 ,@anio
	 ,1
FROM 
	EscuelaExtensionDocente 

--------->> FIN - ESCUELA EXT DOC HISTORICO <<---------



--------->> NOVEDADES EXT DOC HISTORICO <<---------

INSERT INTO 
	NovedadesExtensionDocente_historico 	  
    (
	[age_id]
    ,[age_nrocontrol]
    ,[dias_descontar]
    ,[liq_id]
    ,[usu_id]
    ,[fechaHoraCrea]
    ,[fechaHoraActualiza]
    ,[fechaHoraElimina]
    ,[usuCrea_id]
    ,[usuActualiza_id]
    ,[usuElimina_id]
    ,[mes]
    ,[anio]
    ,[activo]
	)
SELECT	 
	 [age_id]
    ,[age_nrocontrol]
    ,[dias_descontar]
    ,[liq_id]
    ,[usu_id]
    ,[fechaHoraCrea]
    ,[fechaHoraActualiza]
    ,[fechaHoraElimina]
    ,[usuCrea_id]
    ,[usuActualiza_id]
    ,[usuElimina_id]     
	,@mes
	,@anio
	,1
FROM 
	NovedadesExtensionDocente 

--------->> FIN - NOVEDADES EXT DOC HISTORICO <<---------
GO
