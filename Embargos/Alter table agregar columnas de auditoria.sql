ALTER TABLE oficio_encabezado
ADD [created_at]  date,
[updated_at]  date null,
[deleted_at]  date null



ALTER TABLE oficio_encabezado
DROP COLUMN activo;