CREATE PROC usp_AddProjectToEmployee(@employeeId INT, @projectId INT)
AS
BEGIN TRANSACTION
	INSERT INTO EmployeesProjects
	VALUES (@employeeId, @projectId)

	DECLARE @projectForEmployee INT
	SET @projectForEmployee =
	(
		SELECT COUNT(*) FROM EmployeesProjects
		WHERE EmployeeID = @employeeId
	)

	IF (@projectForEmployee > 5)
	BEGIN
		ROLLBACK
		RAISERROR('Too many projects for employee', 16, 1)
		RETURN
	END
COMMIT

EXEC dbo.usp_AddProjectToEmployee 1, 4

--
GO
CREATE TRIGGER tr_NoEmptyTownNames ON Towns FOR UPDATE
AS
BEGIN
	IF (EXISTS(SELECT * FROM inserted
		WHERE [Name] IS NULL OR LEN([Name]) < 2))
	BEGIN
		ROLLBACK
		RAISERROR('Town names must have at least 2 symbols.', 16, 1)
		RETURN
	END
END