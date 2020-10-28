-- Addresses with Towns -- 02 from Exercises
SELECT TOP(50) FirstName, LastName, t.[Name] AS [Town], a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

-- Sales Employees -- 03 from Exercises
SELECT EmployeeID, FirstName, LastName, d.[Name] AS [DepartmentName]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

-- Employees Hired After -- 06 from Exercises
SELECT FirstName, LastName, HireDate, d.[Name] AS [Department Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales' OR d.[Name] = 'Finance'
	  AND e.HireDate > '1999-01-01'
ORDER BY e.HireDate

-- Employee Summary -- 10 from Exercises
SELECT TOP 50 e1.EmployeeID, 
e1.FirstName + ' ' + e1.LastName AS [Employee Name],
e2.FirstName + ' ' + e2.LastName AS [Manager Name],
d.[Name] AS [Department Name]
FROM Employees AS e1
JOIN Employees AS e2 ON e1.ManagerID = e2.EmployeeID
JOIN Departments AS d ON e1.DepartmentID = d.DepartmentID
ORDER BY e1.EmployeeID

-- Min Average Salary -- 11 from Exercises
SELECT * FROM Employees

SELECT TOP 1
AVG(e.Salary) AS AverageSalary
FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY AverageSalary