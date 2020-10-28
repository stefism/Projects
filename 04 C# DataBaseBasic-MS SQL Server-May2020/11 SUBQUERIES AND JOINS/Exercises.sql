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

-- 09. Employee Manager
SElECT e.EmployeeID, e.FirstName,
e.ManagerID, m.FirstName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

-- 12. Highest Peaks in Bulgaria
SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation 
FROM MountainsCountries AS mc
JOIN Mountains AS m ON mc.MountainId = m.Id
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

-- 13. Count Mountain Ranges
SELECT mc.CountryCode, COUNT(m.MountainRange) AS [MountainRanges]
FROM MountainsCountries AS mc
JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE mc.CountryCode IN ('US', 'RU', 'BG')
GROUP BY mc.CountryCode

--  14.	Countries with Rivers
SELECT TOP 5 c.CountryName, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

-- 15. *Continents and Currencies
SELECT ContinentCode, CurrencyCode, CurrencyUsage
FROM
	(SELECT ContinentCode, CurrencyCode,
	COUNT(CurrencyCode) AS CurrencyUsage,
	DENSE_RANK() OVER(PARTITION BY ContinentCode 
	ORDER BY COUNT(CurrencyCode) DESC) AS [Rank]
	FROM Countries AS c
	GROUP BY ContinentCode, CurrencyCode
	HAVING COUNT(CurrencyCode) > 1) AS tmp
WHERE [Rank] = 1
ORDER BY ContinentCode

-- 16. Countries without any Mountains
SELECT COUNT(*) AS [Count] 
FROM
	(SELECT c.CountryCode, m.MountainRange
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	WHERE m.MountainRange IS NULL) AS tmp

-- 17. Highest Peak and Longest River by Country
SELECT TOP 5 CountryName, [Peak Elevation], [River Lenght]
FROM
	(SELECT CountryName, p.Elevation AS [Peak Elevation], 
	r.[Length] AS [River Lenght],
	DENSE_RANK() OVER(PARTITION BY CountryName 
		ORDER BY p.Elevation DESC) AS [Peak Rank],
	DENSE_RANK() OVER(PARTITION BY CountryName 
		ORDER BY r.[Length] DESC) AS [River Rank]
	FROM Countries AS c
	JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	JOIN Mountains AS m ON mc.MountainId = m.Id
	JOIN Peaks AS p ON p.MountainId = m.Id
	JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
	JOIN Rivers AS r ON cr.RiverId = r.Id) AS tmp
WHERE [Peak Rank] = 1 AND [River Rank] = 1
ORDER BY [Peak Elevation] DESC, [River Lenght] DESC, CountryName

-- 18. * Highest Peak Name and Elevation by Country
SELECT TOP 5 CountryName, [Highest Peak Name], [Highest Peak Elevation], Mountain
FROM
	(SELECT CountryName, 
	ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name], 
	ISNULL(p.Elevation, 0) AS [Highest Peak Elevation], 
	ISNULL(m.MountainRange, '(no mountain)') AS [Mountain],
	DENSE_RANK() OVER(PARTITION BY CountryName 
			ORDER BY p.Elevation DESC) AS [Peak Rank]
	FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p ON p.MountainId = m.Id) AS tmp
WHERE [Peak Rank] = 1
ORDER BY CountryName, [Highest Peak Name]