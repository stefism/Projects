-- 01. Employee Address
SELECT TOP 5 EmployeeID, JobTitle, e.AddressID, a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY a.AddressID

-- 04. Employee Departments
SELECT TOP 5 EmployeeID, FirstName, Salary, d.[Name] AS DeptName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE Salary > 15000
ORDER BY e.DepartmentID

-- 05. Employees Without Project
SELECT TOP 3 e.EmployeeID, e.FirstName
FROM EmployeesProjects AS ep
RIGHT JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
LEFT JOIN Projects AS p ON  ep.ProjectID = p.ProjectID
WHERE p.[Name] IS NULL
ORDER BY e.EmployeeID

-- 07. Employees with Project
---
SELECT TOP 5 e.EmployeeID, e.FirstName, p.[Name] AS [ProjectName]
FROM EmployeesProjects AS ep
LEFT JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
LEFT JOIN Projects AS p ON  ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID
--- Нещо не минава!
---
select top 5 e.EmployeeID, e.FirstName, p.Name as ProjectName from Employees as e
join EmployeesProjects as ep
on e.EmployeeID = ep.EmployeeID
join Projects as p
on ep.ProjectID = p.ProjectID
where p.StartDate > '2002-08-13' and p.EndDate is null
order by e.EmployeeID
--- явно иска да е написано така.

SELECT * FROM Projects
SELECT * FROM Employees

-- 08. Employee 24
SELECT e.EmployeeID, e.FirstName,
CASE
	WHEN DATEPART(YEAR, StartDate) >= 2005 THEN NULL
	ELSE p.[Name]
END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

