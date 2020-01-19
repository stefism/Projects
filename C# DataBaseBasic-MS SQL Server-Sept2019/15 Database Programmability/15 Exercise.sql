-- Section I. Functions and Procedures
-- Part 1. Queries for SoftUni Database

-- 1. Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000
END

-- Problem 2. Employees with Salary Above Number
GO
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@salary DECIMAL(18,4))
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @salary
END

-- 3. Town Names Starting With
GO
CREATE PROC usp_GetTownsStartingWith (@startWith VARCHAR(50))
AS
BEGIN
	DECLARE @startString VARCHAR(50)
	SET @startString = @startWith + '%'

	SELECT [Name] FROM Towns AS Town
	WHERE [Name] LIKE @startString
END
-- 
SELECT * FROM Towns

-- 4. Employees from Town
GO
CREATE PROC usp_GetEmployeesFromTown(@town NVARCHAR(50))
AS
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	WHERE t.[Name] = @town
END

-- 5. Salary Level Function
GO
-- a).
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(10)

	IF(@Salary < 30000) RETURN 'Low'
	ELSE IF(@Salary BETWEEN 30000 AND 50000) SET @salaryLevel = 'Average'
	ELSE SET @salaryLevel = 'High'
	
	RETURN @salaryLevel
END

-- b).
GO
CREATE FUNCTION ufn_GetSalaryLevel2(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(10) = CASE -- РАВНО трябва да има за да работи.
		WHEN @Salary < 30000 THEN 'Low'
		WHEN @Salary BETWEEN 30000 AND 50000 THEN 'Average'
		ELSE 'High'
	END
	
	RETURN @salaryLevel
END

-- 6. Employees by Salary Level
GO
-- a).
CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(10))
AS
BEGIN
	IF(@salaryLevel = 'Low')
	BEGIN
		SELECT FirstName, LastName
		FROM Employees
		WHERE Salary < 3000
	END

	ELSE IF(@salaryLevel = 'Average')
	BEGIN
		SELECT FirstName, LastName
		FROM Employees
		WHERE Salary BETWEEN 30000 AND 50000
	END

	ELSE
	BEGIN
		SELECT FirstName, LastName
		FROM Employees
		WHERE Salary > 50000
	END
END

-- b).
GO
CREATE PROC usp_EmployeesBySalaryLevel2(@salaryLevel VARCHAR(10))
AS
BEGIN
SELECT e.FirstName, e.LastName
		FROM Employees AS e
		WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @salaryLevel
END

EXEC dbo.usp_EmployeesBySalaryLevel2 'High' -- High не трябва да е в скоби тука. На процедурите, аргументите не се подават в скоби.

-- 7. Define Function
GO
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @counter INT = 1
	DECLARE @currentLetter CHAR

	WHILE(@counter <= LEN(@word))
	BEGIN
		SET @currentLetter = SUBSTRING(@word, @counter, 1)
		DECLARE @charIndex INT = CHARINDEX(@currentLetter, @setOfLetters)

		IF(@charIndex <= 0) RETURN 0

		SET @counter += 1
	END

	RETURN 1
END

-- 8. * Delete Employees and Departments
GO
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	-- Delete all working on projects by people that are intended to be deleted.
	-- Изтривам, че работят по проекти, тези хора, които искам да изтрия.
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @departmentId)
	-- Set ManagerID to NULL on all the people which manager is beign deleted.
	-- Сетвам ManagerID на NULL на всички хора, чиито мениджър ще бъде изтрит.
	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
		-- People i want to delete.
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @departmentId)
	-- Set column ManagerId(Departments) to be nullable.
	ALTER TABLE Departments
	ALTER COLUMN ManagerId INT
	-- Set ManagerId to NULL for all departments whose manager was deleted.
	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @departmentId
	-- As Employees doesn't have any more relations, we can safely deleted all employees in wanted department.
	DELETE FROM Employees
	WHERE DepartmentID = @departmentID
	-- As Departments doesn't any more relations we can safely delete the whole department.
	DELETE FROM Departments
	WHERE DepartmentID = @departmentID

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentID
END -- *** Тука може да се реши и като му се каже - NOCHECK CONSTRAINT - отпадат проблемите с foreign keys и всичко минава 100 от 100 *** --

-- Part 2. Queries for Bank Database
-- 9. Find Full Name
GO
CREATE PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders
END

-- 10. People with Balance Higher Than
SELECT * FROM Accounts AS a
JOIN AccountHolders AS ah ON a.Id = ah.ID
GO
-- ** Правилно решение.
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@amount MONEY)
AS
BEGIN
	SELECT ah.FirstName, ah.LastName
	FROM Accounts as a
	JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @amount
	ORDER BY ah.FirstName, ah.LastName
END

---** -- примерен тест. 
SELECT ah.FirstName, ah.LastName, SUM(a.Balance)
	FROM Accounts as a
	JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > 10000
	ORDER BY ah.FirstName, ah.LastName

-- Грешно решение **
GO
CREATE PROC usp_GetHoldersWithBalanceHigherThanError(@amount MONEY)
AS
BEGIN
	SELECT ah.FirstName, ah.LastName,
	SUM(a.Balance) AS TotalBalance
	FROM Accounts as a
	JOIN AccountHolders AS ah ON a.Id = ah.Id
	GROUP BY a.AccountHolderId, ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @amount
	ORDER BY ah.FirstName, ah.LastName
END
-- **

-- 11. Future Value Function
GO
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,4), @yearly FLOAT, @years INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
	DECLARE @result DECIMAL(18, 4)
	SET @result = @sum * (POWER((1 + @yearly), @years))
	return @result
END

GO
SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

-- 12. Calculating Interest
SELECT *
FROM AccountHolders ah
JOIN dbo.Accounts a ON a.AccountHolderId =ah.Id
--
GO
CREATE PROC usp_CalculateFutureValueForAccount(@accountID INT, @interestRate FLOAT)
AS
BEGIN
	SELECT a.Id AS [Account Id], ah.FirstName, ah.LastName,
	a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders ah
	JOIN dbo.Accounts a ON a.AccountHolderId =ah.Id
	WHERE a.Id = @accountId
END

-- Part 3. Queries for Diablo Database
-- 13. *Scalar Function: Cash in User Games Odd Rows

SELECT *
FROM Games g
JOIN UsersGames ug ON ug.GameId = g.Id
--
GO
CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(MAX))
RETURNS TABLE
AS
	RETURN
	SELECT SUM(temp.Cash) AS SumCash
	FROM
	(SELECT ug.Cash, g.[Name], 
	ROW_NUMBER() OVER (PARTITION BY g.Name ORDER BY ug.Cash DESC) AS RowNumber
	FROM Games g
	JOIN UsersGames ug ON ug.GameId = g.Id) AS temp
	WHERE temp.[Name] = @gameName AND temp.RowNumber % 2 = 1
	
GO
--
