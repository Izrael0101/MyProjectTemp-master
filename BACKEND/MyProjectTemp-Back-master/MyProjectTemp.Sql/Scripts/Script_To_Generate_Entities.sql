-- Preparar el entorno
IF OBJECT_ID('tempdb..#Tables') IS NOT NULL DROP TABLE #Tables;
CREATE TABLE #Tables (ID INT IDENTITY(1,1), TableName NVARCHAR(256));

-- Insertar nombres de tablas en la tabla temporal
INSERT INTO #Tables (TableName)
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';

DECLARE @MaxID INT, @CurrentID INT = 1, @TableName NVARCHAR(256), @Namespace NVARCHAR(128) = 'MyProjectTemp.Core.Entities';
SELECT @MaxID = MAX(ID) FROM #Tables;

-- Iterar sobre las tablas
WHILE @CurrentID <= @MaxID
BEGIN
    SELECT @TableName = TableName FROM #Tables WHERE ID = @CurrentID;

    DECLARE @ClassDefinition NVARCHAR(MAX) = 'using System;' + CHAR(13) +
                                             'namespace ' + @Namespace + '
{
    public class ' + @TableName + '
    {' + CHAR(13);

    SELECT @ClassDefinition = @ClassDefinition + 
        '        public ' + 
        CASE DATA_TYPE 
            WHEN 'int' THEN 'int?'
            WHEN 'bigint' THEN 'long?'
            WHEN 'varchar' THEN 'string'
            WHEN 'nvarchar' THEN 'string'
            WHEN 'date' THEN 'DateTime?'
            WHEN 'datetime' THEN 'DateTime?'
            -- Añade más mapeos de tipos de datos según sea necesario
            ELSE 'object'
        END + ' ' + COLUMN_NAME + ' { get; set; }' + CHAR(13)
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = @TableName
    ORDER BY ORDINAL_POSITION;

    SET @ClassDefinition = @ClassDefinition + '    }
}';

    -- Imprimir la definición de la clase
    PRINT @ClassDefinition;

    SET @CurrentID = @CurrentID + 1;
END;