UPDATE [dbo].[Products]
SET [Price] = [Price] / 2
WHERE [Name] = 'Marinara'

SELECT [Name], [Price] FROM [dbo].[Products] WHERE [Name] = 'Marinara'