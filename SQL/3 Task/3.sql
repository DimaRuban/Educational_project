select E.FirstName, E.LastName, T.TerritoryDescription, R.RegionDescription
from [dbo].[Employees] E
	left join [dbo].[EmployeeTerritories]  ET on ET.EmployeeID = E.EmployeeID
	left join [dbo].[Territories] T on T.TerritoryID = ET.TerritoryID
	left join [dbo].[Region] R on R.RegionID = T.RegionID;