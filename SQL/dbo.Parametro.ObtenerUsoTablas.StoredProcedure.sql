USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Parametro.ObtenerUsoTablas]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Parametro.ObtenerUsoTablas]
as

SELECT 
        t.NAME AS NombreTabla,
        s.Name AS Esquema,
        p.rows AS NumFilas,
        SUM(a.total_pages) * 8 AS EspacioTotal_KB, 
        SUM(a.used_pages) * 8 AS EspacioUsado_KB, 
        (SUM(a.total_pages) - SUM(a.used_pages)) * 8 AS EspacioNoUsado_KB
FROM 
        sys.tables t
INNER JOIN      
        sys.indexes i ON t.OBJECT_ID = i.object_id
INNER JOIN 
        sys.partitions p ON i.object_id = p.OBJECT_ID AND i.index_id = p.index_id
INNER JOIN 
        sys.allocation_units a ON p.partition_id = a.container_id
LEFT OUTER JOIN 
        sys.schemas s ON t.schema_id = s.schema_id
WHERE 
        t.NAME NOT LIKE 'dt%' 
        AND t.is_ms_shipped = 0
        AND i.OBJECT_ID > 255 
GROUP BY 
        t.Name, s.Name, p.Rows
ORDER BY 
        EspacioUsado_KB desc    
GO
