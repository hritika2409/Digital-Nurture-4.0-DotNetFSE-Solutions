SELECT *
FROM (
    SELECT 
        Category,
        ProductName,
        Price,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankInCategory
    FROM ProductCatalog
) AS Ranked
WHERE DenseRankInCategory <= 3;