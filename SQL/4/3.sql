CREATE FUNCTION CreateIdFunc (@tableName NVARCHAR(10), @ID NVARCHAR(50))
RETURNS VARCHAR(50)
BEGIN
RETURN @ID
END
------------------------------------------------------------------------
INSERT INTO Products
VALUES 
--([dbo].CreateIdFunc('Products', NEWID()), 'Frutti di Mare', 70)
([dbo].CreateIdFunc('Products', NEWID()), 'Margherita', 60)
------------------------------------------------------------------------
SELECT * FROM Products
