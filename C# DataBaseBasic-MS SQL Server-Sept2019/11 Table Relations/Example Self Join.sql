SELECT e.EmployeeID, CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
e.JobTitle, e.ManagerID, 
CONCAT(e2.FirstName, ' ', e2.LastName) AS ManagerName
FROM Employees AS e
INNER JOIN Employees AS e2
ON e.ManagerID = e2.EmployeeID
ORDER BY e.EmployeeID

SELECT * FROM dbo.Employees e