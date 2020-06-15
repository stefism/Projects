-- 21. Employees with Three Projects
CREATE PROC usp_AssignProject(@emloyeeId int, @projectID int)
AS
	DECLARE @EmployeeCount int
	
	SET @EmployeeCount = (SELECT COUNT(*)
		FROM EmployeesProjects
		WHERE EmployeeID = @emloyeeId)
	
	IF(@EmployeeCount >= 3)
	THROW 50001, 'The employee has too many projects!', 1

	INSERT INTO EmployeesProjects
	VALUES
	(@emloyeeId, @projectID)
GO

EXEC usp_AssignProject 1, 21

SELECT * FROM EmployeesProjects

SELECT EmployeeID, COUNT(*) AS EmployeeProjects
FROM EmployeesProjects
GROUP BY EmployeeID
ORDER BY EmployeeProjects