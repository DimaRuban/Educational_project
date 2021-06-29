SELECT R.RegionID, R.RegionDescription 
FROM [dbo].[Territories] T
INNER JOIN [dbo].[EmployeeTerritories] ET ON T.TerritoryID = ET.TerritoryID
RIGHT OUTER JOIN [dbo].[Region] R ON R.RegionID = T.RegionID
WHERE T.TerritoryID IS NULL;