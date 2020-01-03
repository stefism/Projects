SELECT * FROM Employees AS e
INNER JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE d.[Name] IN ('Engineering', 'Tool Design', 
'Marketing', 'Information Services')