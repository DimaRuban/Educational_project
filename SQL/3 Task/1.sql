SELECT *
  FROM [dbo].[Products]
WHERE [UnitPrice] > (select AVG(UnitPrice) from [dbo].[Products])
ORDER BY UnitPrice;