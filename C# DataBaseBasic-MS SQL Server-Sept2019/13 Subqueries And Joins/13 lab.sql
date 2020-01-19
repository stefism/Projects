-- Addresses with Towns
-- Display address information of all employees in "SoftUni" database. Select first 50 employees.
-- Това е и задача 2 от упражненията.
SELECT TOP(50) e.FirstName, e.LastName, t.[Name] AS Town, a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

-- Find all employees that are in the "Sales" department. Use "SoftUni" database.
-- Задача 3 от упражненията.
SELECT EmployeeID, FirstName, LastName, d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'

-- Show all employees that: Are hired after 1/1/1999, Are either in "Sales" or "Finance" department, Sorted by HireDate (ascending).
-- Задача 6 от упражненията.
SELECT FirstName, LastName, HireDate, d.[Name] AS DeptName
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] IN ('Sales', 'Finance') 
AND e.HireDate > '1/1/1999'
ORDER BY e.HireDate

-- Display information about employee's manager and employee's department. Show only the first 50 employees. The exact format is shown below: ... 
-- Sort by EmployeeID (ascending).
-- Задача 10 от упражненията.
SELECT TOP 50 e.EmployeeID, 
CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
CONCAT(m. FirstName, ' ', m.LastName) AS ManagerName,
d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

-- Display lowest average salary of all departments. Calculate average salary for each department. Then show the value of smallest one.
-- Задача 11 от упражненията.
-- a).
SELECT TOP 1 * FROM (SELECT AVG(Salary) AS MinAverageSalary
FROM dbo.Employees e
GROUP BY DepartmentID) as [avg]
ORDER BY [avg].MinAverageSalary

-- b).
SELECT MIN([avg].MinAverage) AS MinAverageSalary
FROM (SELECT AVG(e.Salary) AS MinAverage
FROM dbo.Employees e
GROUP BY e.DepartmentID) as [avg]

--***
WITH Employees_CTE
(FirstName, LastName, DepartmentName)
AS
(
	SELECT e.FirstName, e.LastName, d.Name
	FROM Employees AS e
	LEFT JOIN Departments AS d ON
	d.DepartmentID = e.DepartmentID
)

SELECT FirstName, LastName, DepartmentName
FROM Employees_CTE
--***

SELECT * FROM Employees e
ORDER BY e.FirstName, e.LastName