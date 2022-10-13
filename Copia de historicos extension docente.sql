DECLARE @mes varchar(2)
DECLARE @anio varchar(2)

SELECT @mes = '09'
SELECT @anio = '22'


--------->> CONCEPTO EXT DOC HISTORICO <<---------
INSERT INTO 
	ConceptoExtensionDocente_historico 	  
       ([conId]
      ,[conCodigo]
	  , mes
	  , anio)

SELECT	 
       [conId]
      ,[conCodigo]
	  , @mes
	  ,@anio
FROM 
	ConceptoExtensionDocente 

--------->> FIN CONCEPTO EXT DOC HISTORICO <<---------