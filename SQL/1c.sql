CREATE TABLE Products_duplicate(
	[ProductId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [numeric](18, 2) NOT NULL,
	[ImageName] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL);

INSERT INTO Products_duplicate ([ProductId], [Name], [Description], [Price], [ImageName], [CategoryId])
SELECT [ProductId], [Name], [Description], [Price], [ImageName], [CategoryId]
FROM Products