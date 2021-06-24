SELECT * FROM [dbo].[Customers]
WHERE City ='Madrid'
UNION
SELECT * FROM [dbo].[Customers]
WHERE Region ='BC'