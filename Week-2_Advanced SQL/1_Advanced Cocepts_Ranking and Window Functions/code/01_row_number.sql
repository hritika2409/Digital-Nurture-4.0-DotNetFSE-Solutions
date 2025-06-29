SELECT *
FROM (
    SELECT 
        Category,
        ProductName,
        Price,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
    FROM ProductCatalog
) AS Ranked
WHERE RowNum <= 3;