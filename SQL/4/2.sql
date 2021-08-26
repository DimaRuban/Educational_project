CREATE PROCEDURE Create_Id (@tableName VARCHAR(10), @ID NVARCHAR(50) OUTPUT)
AS
BEGIN
SELECT @ID = SUBSTRING (@tableName, 0, 2) + '_' + CAST(NEWID() AS VARCHAR(50))
END
--------------------------------------------------------------------------
DECLARE @IDi NVARCHAR(50)

EXECUTE Create_Id
   @tableName = 'Products'
  ,@ID = @IDi OUTPUT

INSERT INTO Products
VALUES 
--(@IDi, 'Margherita', 90),
--(@IDi, 'Carbonara', 100),
--(@IDi, 'Quattro Stagioni', 110);
(@IDi, 'Montanara', 120);
--------------------------------------------------------------------------
SELECT * FROM Products
