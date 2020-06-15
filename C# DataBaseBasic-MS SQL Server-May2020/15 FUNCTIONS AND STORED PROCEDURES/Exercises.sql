-- 01. Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000
GO

-- 02. Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@Salary DECIMAL(18,4))
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @Salary
GO

-- 03. Town Names Starting With
CREATE PROC usp_GetTownsStartingWith(@StartString NVARCHAR(50))
AS
	SELECT [Name]
	FROM Towns
	WHERE [Name] LIKE @StartString + '%'
GO

EXEC usp_GetTownsStartingWith 'b'

-- 04. Employees from Town
GO
CREATE PROC usp_GetEmployeesFromTown (@Town NVARCHAR(50))
AS
	SELECT FirstName, LastName
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	WHERE t.[Name] = @Town
GO

-- 06. Employees by Salary Level
CREATE PROC usp_EmployeesBySalaryLevel(@SalaryLevel NVARCHAR(10))
AS
	SELECT FirstName, LastName
	FROM
	(SELECT FirstName, LastName,
	dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel
	FROM Employees) AS tmp
	WHERE SalaryLevel = @SalaryLevel
GO

EXEC usp_EmployeesBySalaryLevel 'High'

-- 07. Define Function
GO

CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters NVARCHAR(MAX), @Word NVARCHAR(MAX))
RETURNS SMALLINT
AS
BEGIN
	DECLARE @index INT 
	SET @index = LEN(@Word)
	
	WHILE(@index > 0)
	BEGIN
		DECLARE @currChar NCHAR(1) = SUBSTRING(@Word, @index, 1)

		IF(CHARINDEX(@currChar, @SetOfLetters) > 0)
		BEGIN
			SET @index -= 1
			CONTINUE
		END
		ELSE RETURN 0
	END

	RETURN 1
END

GO
SELECT LEN('Proba')

SELECT dbo.ufn_IsWordComprised('bobr', 'Rob')

-- 08. * Delete Employees and Departments