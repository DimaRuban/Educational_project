CREATE PROC InsertDataXML @Request XML
AS
BEGIN TRANSACTION
	BEGIN TRY
	   DECLARE @ProductsXML TABLE
 	   (
 		[ProductID] [nvarchar](50) NOT NULL,
		[Name] [nvarchar](50) NULL,
		[Price] [numeric](18, 2) NULL
 	   ) 
 	   INSERT @ProductsXML(
 			[ProductID],
			[Name],
			[Price])
 	   SELECT     
 			 Product.value('ProductID[1]','NVARCHAR(50)') AS [ProductID],
 			 Product.value('Name[1]','NVARCHAR(50)') AS [Name],
 			 Product.value('Price[1]','NUMERIC(18, 2)') AS [Price]
 		 FROM @Request.nodes('Products/Product') Products(Product)

		 MERGE Products AS Product
		 USING @ProductsXML AS Source 
		 ON (Product.ProductID = Source.ProductID)
		 WHEN MATCHED THEN
			UPDATE SET  [ProductID] = Source.[ProductID], 
						[Name] = Source.[Name], 	
						[Price] = Source.[Price]
		WHEN NOT MATCHED THEN
			INSERT ([ProductID], [Name], [Price])
			VALUES (Source.[ProductID], Source.[Name], Source.[Price]);
	END TRY
	BEGIN CATCH
		ROLLBACK
		EXEC sp_XML_removedocument @Request
	END CATCH
COMMIT