CREATE FUNCTION Create_Func (@tableName NVARCHAR(10), @ID NVARCHAR(50))
RETURNS VARCHAR(50)
BEGIN
RETURN SUBSTRING (@tableName, 0, 2) + '_' + @ID
END
------------------------------------------------------------------------
INSERT INTO Products
VALUES 
--([dbo].CreateIdFunc('Products', NEWID()), 'Frutti di Mare', 70)
--([dbo].Create_Func('Products', NEWID()), 'Margherita', 60)
([dbo].Create_Func('Products', NEWID()), 'Napoletana', 80)
------------------------------------------------------------------------
SELECT * FROM Products

