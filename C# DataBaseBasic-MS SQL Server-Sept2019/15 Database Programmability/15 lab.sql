CREATE FUNCTION udf_ProcessText(@text NVARCHAR(50))
RETURNS NVARCHAR(50)
AS
BEGIN
	RETURN @text + ' Dopalnitelen Text'
END

GO
SELECT dbo.udf_ProcessText(e.FirstName)
FROM Employees e

-- Salary Level Function. Write a function ufn_GetSalaryLevel(@salary MONEY) that receives salary of an employee and returns the level of the salary.
-- If salary is < 30000 return "Low"
-- If salary is between 30000 and 50000 (inclusive) returns "Average"
-- If salary is > 50000 return "High"
GO
CREATE FUNCTION ufn_GetSalaryLevel(@salary MONEY)
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(10)

	IF(@Salary < 30000) RETURN 'Low'
	ELSE IF(@Salary BETWEEN 30000 AND 50000) SET @salaryLevel = 'Average'
	ELSE SET @salaryLevel = 'High'
	
	RETURN @salaryLevel
END

GO
SELECT FirstName, LastName, Salary,
dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel
FROM Employees

-- Create a procedure that assigns projects to an employee. If the employee has more than 3 projects, throw an exception.
CREATE  OR ALTER PROC udp_AssignProject(@employeeId INT, @projectId INT)
AS
BEGIN
	DECLARE @totalProjects INT
	SET @totalProjects =
		(SELECT COUNT(*) FROM EmployeesProjects ep
		 WHERE ep.EmployeeID = @employeeId)

	IF(@totalProjects > 3)
	THROW 50001, 'The employee has too many projects!', 1

	INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
	VALUES(@employeeId, @projectId)
END
--
SELECT * FROM EmployeesProjects

EXEC udp_AssignProject 2, 1