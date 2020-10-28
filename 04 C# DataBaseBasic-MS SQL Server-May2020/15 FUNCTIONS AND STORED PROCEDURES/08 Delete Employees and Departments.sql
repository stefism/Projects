-- 08. * Delete Employees and Departments
GO

CREATE PROC usp_DeleteEmployeesFromDepartment(@departmentId INT)
AS
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL
	--
	ALTER TABLE Employees
	DROP CONSTRAINT FK_Employees_Departments

	ALTER TABLE Employees
	ADD CONSTRAINT FK_Employees_Departments
	FOREIGN KEY (DepartmentID)
	REFERENCES Departments(DepartmentID)
	ON DELETE CASCADE
	--
	ALTER TABLE EmployeesProjects
	DROP CONSTRAINT FK_EmployeesProjects_Employees

	ALTER TABLE EmployeesProjects
	DROP CONSTRAINT FK_EmployeesProjects_Projects
	--
	ALTER TABLE EmployeesProjects
	ADD CONSTRAINT FK_EmployeesProjects_Employees
	FOREIGN KEY(EmployeeID)
	REFERENCES Employees(EmployeeID)
	ON DELETE CASCADE

	ALTER TABLE EmployeesProjects
	ADD CONSTRAINT FK_EmployeesProjects_Projects
	FOREIGN KEY(ProjectID)
	REFERENCES Projects(ProjectID)
	ON DELETE CASCADE
	--
	ALTER TABLE Employees
	DROP CONSTRAINT FK_Employees_Employees

	ALTER TABLE Employees
	ADD CONSTRAINT FK_Employees_Employees
	FOREIGN KEY(ManagerID) REFERENCES Employees(EmployeeID)
	ON DELETE NO ACTION
	--
	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId
	
	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId
GO

SELECT * FROM Employees