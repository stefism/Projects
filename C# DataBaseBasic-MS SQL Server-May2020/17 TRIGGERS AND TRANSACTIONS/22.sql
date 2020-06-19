CREATE TABLE Deleted_Employees
(
	[EmployeeID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[JobTitle] [varchar](50) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[Salary] [money] NOT NULL
)
GO

CREATE TRIGGER tr_SaveTo_Deleted_Employees
ON Employees FOR DELETE
AS
	INSERT INTO Deleted_Employees
	([FirstName], [LastName], [MiddleName], 
	 [JobTitle], [DepartmentID], [Salary])
	SELECT [FirstName], [LastName], [MiddleName], 
	[JobTitle], [DepartmentID], [Salary]
	FROM deleted

GO