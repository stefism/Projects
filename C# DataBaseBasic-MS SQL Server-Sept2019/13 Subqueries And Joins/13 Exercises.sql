-- 1. Employee Address
SELECT * FROM Employees

SELECT TOP 5 e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY e.AddressID

-- 2 and 3 - see Lab

-- 4. Employee Departments
SELECT TOP 5 e.EmployeeID, e.FirstName, e.Salary,
d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

-- 5. Employees Without Project
SELECT * FROM Employees
SELECT * FROM Projects

SELECT TOP 3 e.EmployeeID, e.FirstName
FROM Employees as e
LEFT JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE p.[Name] IS NULL
ORDER BY e.EmployeeID

-- 6. See Lab

-- 7. Employees with Project
SELECT TOP 5 e.EmployeeID, e.FirstName, p.[Name] AS ProjectName
FROM Employees as e
LEFT JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

-- 8. Employee 24
SELECT e.EmployeeID, e.FirstName, 
CASE
	WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
	ELSE p.[Name]
	END AS ProjectName
--p.[Name] AS ProjectName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

-- 9. Employee Manager
SELECT TOP 50 e.EmployeeID, e.FirstName,
m.EmployeeID AS ManagerID, m.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE m.EmployeeID IN(3, 7)
ORDER BY e.EmployeeID

-- 10 and 11. See Lab

-- 12. Highest Peaks in Bulgaria
SELECT c.CountryCode, m.MountainRange, p.Peakname, p.Elevation
FROM Peaks AS p
JOIN Mountains AS m
ON p.MountainID = m.Id
JOIN MountainsCountries AS mc
ON m.Id = mc.MountainID
JOIN Countries AS c
ON mc.CountryCode = c.CountryCode
WHERE p.Elevation > 2835 AND c.CountryCode = 'BG'
ORDER BY p.Elevation DESC

-- 13. Count Mountain Ranges
SELECT * FROM Peaks
SELECT * FROM Mountains
SELECT * FROM Countries
SELECT * FROM MountainsCountries
-- 
SELECT CountryCode,
COUNT(CountryCode) AS MountainRanges
FROM MountainsCountries
WHERE CountryCode IN('US', 'RU', 'BG')
GROUP BY CountryCode
---------------
SELECT * FROM Countries AS c
JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m
ON mc.MountainID = m.Id

-- 14. Countries with Rivers
SELECT TOP 5 c.CountryName, r.RiverName 
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
ON cr.RiverID = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

-- 15. *Continents and Currencies
SELECT k.ContinentCode, k.CurrencyCode, k.[Count]
FROM (
SELECT c.ContinentCode, c.CurrencyCode,
COUNT(c.CurrencyCode) AS [Count],
DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS DenseRank
FROM Countries AS c
GROUP BY c.ContinentCode, c.CurrencyCode
HAVING COUNT(c.CurrencyCode) > 1) AS k
WHERE k.DenseRank = 1
ORDER BY k.ContinentCode

-- 16. Countries without any Mountains
SELECT * FROM Peaks
SELECT * FROM Mountains
SELECT * FROM Countries
SELECT * FROM MountainsCountries

SELECT COUNT(c.CountryName) AS [Count]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m
ON mc.MountainID = m.Id
WHERE mc.MountainId IS NULL

-- 17. Highest Peak and Longest River by Country
SELECT TOP 5 c.CountryName, 
MAX(p.Elevation) AS HighestPeakElevation, 
MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainID = m.Id
LEFT JOIN Peaks AS p ON p.MountainId = m.Id
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName
-- Начи като има агрегираща функция, после долу в ордера за да има ордер и да не дава грешка, приема името на колоната, което е дадено горе след агрегиращата функция!!!

-- 18. * Highest Peak Name and Elevation by Country
SELECT TOP 5 c.CountryName, 
IIF(p.PeakName IS NULL, '(no highest peak)', p.PeakName),
IIF(MAX(p.Elevation) IS NULL, 0, MAX(p.Elevation)) AS Hpe,
IIF(m.MountainRange IS NULL, '(no mountain)', m.MountainRange) AS Mountain
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainID = m.Id
LEFT JOIN Peaks AS p ON p.MountainId = m.Id
GROUP BY c.CountryName, p.PeakName, m.MountainRange
ORDER BY c.CountryName, Hpe

