-- ** Part I – Queries for SoftUni Database
-- 1. Find Names of All Employees by First Name
SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'Sa%'

-- 2. Find Names of All employees by Last Name
SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'

SELECT * FROM Employees
SELECT * FROM Departments

-- 3. Find First Names of All Employees

--HireDate >= YEAR(1995)
--HireDate <= YEAR(2005)
--, DepartmentID, HireDate

---a)
SELECT FirstName FROM Employees
WHERE DepartmentID IN(3, 10) 
AND HireDate >= YEAR(1995)
OR HireDate <= YEAR(2005)

---b)
SELECT FirstName FROM Employees
WHERE DepartmentID IN(3, 10) 
AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

-- 4. Find All Employees Except Engineers
SELECT FirstName, LastName FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

SELECT * FROM Towns

-- 5. Find Towns with Name Length
SELECT [Name] FROM Towns
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name]

-- 6. Find Towns Starting 
SELECT TownID, [Name] FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

-- 7. Find Towns Not Starting With
SELECT TownID, [Name] FROM Towns
WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]

-- 8. Create View Employees Hired After 2000 Year
GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, lastName FROM Employees
WHERE YEAR(HireDate) > 2000
GO

-- 9. Length of Last Name
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5

-- 10. Rank Employees by Salary
SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER (PARTITION BY Salary
ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary >= 10000 AND Salary <= 50000
ORDER BY Salary DESC

-- 11. Find All Employees with Rank 2 *
SELECT * FROM (SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER (PARTITION BY Salary
ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary >= 10000 AND Salary <= 50000) AS Temp
WHERE Temp.[Rank] = 2
ORDER BY Temp.Salary DESC

--CREATE VIEW V_DenseRank AS
--SELECT * FROM V_DenseRank
--WHERE [Rank] = 2
--ORDER BY Salary DESC

-- ** Part II – Queries for Geography Database 
-- 12. Countries Holding ‘A’ 3 or More Times
SELECT * FROM Countries

SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

-- 13. Mix of Peak and River Names
-- a).
SELECT * FROM (SELECT PeakName, RiverName, LOWER(PeakName) + 
LOWER(SUBSTRING(RiverName, 2, LEN(RiverName))) AS Mix
FROM Peaks, Rivers
WHERE LOWER(SUBSTRING(PeakName, LEN(PeakName), 1)) = LOWER(LEFT(RiverName, 1))) AS temp
ORDER BY temp.Mix

-- b).
SELECT PeakName, RiverName,
LOWER(CONCAT(LEFT(PeakName, LEN(PeakName)-1), RiverName)) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

-- c).
SELECT PeakName, RiverName,
LOWER(CONCAT(LEFT(PeakName, LEN(PeakName)-1), RiverName)) AS Mix
FROM Peaks
JOIN Rivers ON RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

-- ** Part III – Queries for Diablo Database
-- 14. Games from 2011 and 2012 year
SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE YEAR([Start]) IN(2011, 2012)
ORDER BY [Start]

-- 15. User Email Providers
SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email)+1, LEN(Email))
AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username

-- 16. Get Users with IPAdress Like Pattern
SELECT Username, IpAddress FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

-- 17. Show All Games with Duration and Part of the Day
SELECT [Name] AS Game,
	CASE 
		WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
		WHEN DATEPART(HOUR, [Start]) BETWEEN 18 AND 23 THEN 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		WHEN Duration IS NULL THEN 'Extra Long'
	END AS Duration
FROM Games
ORDER BY Game, Duration, [Part of the Day]

-- ** Part IV – Date Functions Queries
-- 18. Orders Table
SELECT * FROM Orders