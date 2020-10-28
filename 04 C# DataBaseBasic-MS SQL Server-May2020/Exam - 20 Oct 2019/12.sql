CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
	DECLARE @EmployeeDepartmentId 
				INT = (SELECT TOP 1 DepartmentId FROM Employees
				WHERE Id = @EmployeeId)

	DECLARE @CategoryId 
				INT = (SELECT TOP 1 CategoryId FROM Reports
				WHERE Id = @ReportId)

	DECLARE @ReportCategoryId
				INT = (SELECT TOP 1 c.DepartmentId FROM Reports AS r
				JOIN Categories AS c ON r.CategoryId = c.Id
				WHERE c.Id = @CategoryId)
	
	IF(@EmployeeDepartmentId != @ReportCategoryId)
	THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1

	UPDATE Reports
	SET EmployeeId = @EmployeeId
	WHERE Id = @ReportId