/****** Script para el comando SelectTopNRows de SSMS  ******/

delete from Concepto
where liq_id = 26
SELECT COUNT(1) from Concepto_historico
where liq_id = 26

select 
	*, 
	SUBSTRING(columna0, 1,3),
	SUBSTRING(columna0, 4,20),
	SUBSTRING(columna0, 24,1)
FROM bondesc2309

delete from Concepto

INSERT INTO Concepto  (conCodigo, conNombre, conRemunerativoNoRemunerativo)
SELECT 
	SUBSTRING(columna0, 1,3),
	SUBSTRING(columna0, 4,20),
	SUBSTRING(columna0, 24,1)
FROM bondesc2309


update Concepto
set liq_id_extdoc = 33

select * from LiquidacionExtensionDocente

select * from Concepto
where conCodigo < 600
