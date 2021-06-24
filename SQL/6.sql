SELECT [Region]
      ,[Country]
	  ,COUNT(*) AS [number of companies in the region]
  FROM [dbo].[Suppliers]
GROUP BY [Region], [Country]
HAVING COUNT(*) > 1 AND [Region] IS NOT NULL