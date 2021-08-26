SELECT C.CategoryName, MAX(P.UnitPrice) AS Price
FROM [dbo].[Categories] C
JOIN [dbo].[Products] P
ON C.CategoryID = P.CategoryID
GROUP BY C.CategoryName
ORDER BY Price desc;