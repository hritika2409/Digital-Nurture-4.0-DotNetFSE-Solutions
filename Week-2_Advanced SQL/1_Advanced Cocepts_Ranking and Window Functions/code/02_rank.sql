SELECT *
FROM (
    SELECT 
        Category,
        ProductName,
        Price,
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankInCategory
    FROM ProductCatalog
) AS Ranked
WHERE RankInCategory <= 3;