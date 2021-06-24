UPDATE [dbo].[Products]
SET [Price] = [Price] - 5
FROM [dbo].[Products]
JOIN [dbo].[Categories] ON [Categories].[CategoryId] = [Products].[CategoryId]
WHERE [Categories].[Name] = 'pizza'; 

SELECT * FROM [dbo].[Products];