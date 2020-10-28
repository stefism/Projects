CREATE PROC sp_GetEmployeesByExperience
AS
	SELECT * 
	FROM Employees
	WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > 19
GO

EXEC sp_GetEmployeesByExperience

--- 
GO
CREATE OR ALTER PROC sp_GetEmployeesByExperience(@Year int)
AS
	SELECT * 
	FROM Employees
	WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > @Year
GO

EXEC sp_GetEmployeesByExperience 15

--- Процедурата може да връща параметри. Горните не връщат.
GO
CREATE OR ALTER PROC sp_GetEmployeesByExperience
(@Count int OUTPUT, @Year int = 19, @MinSalary money = 12000)
AS
	SET @Count = (SELECT COUNT(*) 
	FROM Employees
	WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > @Year 
	AND Salary > @MinSalary) 
GO

DECLARE @Count int
EXEC sp_GetEmployeesByExperience @Count OUTPUT
SELECT @Count