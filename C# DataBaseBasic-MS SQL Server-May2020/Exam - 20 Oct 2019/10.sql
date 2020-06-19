SELECT 
ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS [Employee]
, ISNULL(d.[Name], 'None') AS Department
, c.[Name] AS Category,
r.[Description]
, FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate
, s.[Label] AS [Status]
, u.[Name] AS [User Name]
FROM Reports AS r
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
LEFT JOIN Status AS s ON r.StatusId = s.Id
LEFT JOIN Users AS u ON r.UserId = u.Id
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
ORDER BY e.FirstName DESC, e.LastName DESC, d.[Name], c.[Name]
		 ,r.[Description], r.OpenDate, s.[Label], u.[Name]