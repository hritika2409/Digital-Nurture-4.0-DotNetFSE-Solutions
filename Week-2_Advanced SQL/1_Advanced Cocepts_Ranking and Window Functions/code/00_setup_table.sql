
CREATE TABLE ProductCatalog (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);


INSERT INTO ProductCatalog (ProductID, ProductName, Category, Price) VALUES
(1, 'Red Gaming Mouse',       'Accessories', 1299.99),
(2, 'Wireless Keyboard',      'Accessories', 1799.50),
(3, 'USB-C Hub',              'Accessories', 1299.99),
(4, '4K Monitor',             'Displays',    21999.00),
(5, 'HD Monitor',             'Displays',    9999.00),
(6, 'Curved Monitor',         'Displays',    21999.00),
(7, 'Intel Core i7',          'Processors',  28999.00),
(8, 'Intel Core i5',          'Processors',  20999.00),
(9, 'Ryzen 7 5800X',          'Processors',  28999.00),
(10,'Ryzen 5 5600',           'Processors',  18999.00);