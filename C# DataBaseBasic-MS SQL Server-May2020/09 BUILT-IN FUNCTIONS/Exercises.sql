-- Part I – Queries for SoftUni Database
-- 01. Find Names of All Employees by First Name
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'Sa%'

-- 02. Find Names of All employees by Last Name 
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

-- 03. Find First Names of All Employees
SELECT FirstName
FROM Employees
WHERE DepartmentID IN(3, 10) 
AND HireDate BETWEEN '1995-01-01' AND '2005-12-31'

-- 04. Find All Employees Except Engineers
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

-- 05. Find Towns with Name Length
SELECT [Name]
FROM Towns
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name]

-- 06. Find Towns Starting With
SELECT *
FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

-- 07. Find Towns Not Starting With
SELECT *
FROM Towns
WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]

-- 08. Create View Employees Hired After 2000 Year
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE YEAR(HireDate) > 2000 

-- 09. Length of Last Name
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

-- 10. Rank Employees by Salary
SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

-- 11. Find All Employees with Rank 2 *
SELECT * FROM
	(SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000) AS tmp
WHERE [Rank] = 2
ORDER BY Salary DESC

-- Part II – Queries for Geography Database 
-- 12. Countries Holding ‘A’ 3 or More Times
SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

-- 13. Mix of Peak and River Names
SELECT p.PeakName, r.RiverName,
LOWER(PeakName + RIGHT(RiverName, LEN(RiverName) - 1)) AS Mix
FROM Peaks AS p
JOIN Rivers AS r ON RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

-- Part III – Queries for Diablo Database
-- 14. Games from 2011 and 2012 year
SELECT TOP 50 [Name], 
FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE YEAR(Start) IN(2011, 2012)
ORDER BY [Start]

-- 15. User Email Providers
SELECT Username,
RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider] ASC, Username

-- 16. Get Users with IPAdress Like Pattern
SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username

-- 17. Show All Games with Duration and Part of the Day


SELECT * FROM Users