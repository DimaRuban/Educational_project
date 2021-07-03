CREATE PROCEDURE CreateId (@tableName VARCHAR(10), @ID NVARCHAR(50) OUTPUT)
AS
BEGIN
SELECT @ID = NEWID()
END
--------------------------------------------------------------------------
DECLARE @IDi NVARCHAR(50)

EXECUTE CreateId
   @tableName = 'Products'
  ,@ID = @IDi OUTPUT

INSERT INTO Products
VALUES 
(@IDi, 'Margherita', 90),
(@IDi, 'Carbonara', 100),
(@IDi, 'Quattro Stagioni', 110);
--------------------------------------------------------------------------
SELECT * FROM Products