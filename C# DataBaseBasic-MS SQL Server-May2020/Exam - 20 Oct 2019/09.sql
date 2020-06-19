SELECT 
e.FirstName + ' ' + LastName AS [Employee Full Name]
, COUNT(r.UserId) AS [User Count]
FROM Reports As r
RIGHT JOIN Employees AS e ON r.EmployeeId = e.Id
GROUP BY e.FirstName + ' ' + LastName
ORDER BY [User Count] DESC, [Employee Full Name]