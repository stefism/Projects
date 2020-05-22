-- 16 Create SoftUni Database
-- 18 Basic Insert

CREATE DATABASE SoftUni

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY, 
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY, 
	AddressText NVARCHAR(100) NOT NULL, 
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY, 
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(50) NOT NULL, 
	MiddleName NVARCHAR(50), 
	LastName NVARCHAR(50) NOT NULL, 
	JobTitle NVARCHAR(30), 
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id), 
	HireDate DATETIME2 NOT NULL, 
	Salary DECIMAL(18,2), 
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Towns([Name])
VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')

INSERT INTO Departments([Name])
VALUES
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')

INSERT INTO Addresses(AddressText, TownId)
VALUES
	('bladasdasd', 2),
	('bladasdasd', 2),
	('bladasdasd', 2),
	('bladasdasd', 2)

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
VALUES
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00, 2),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00, 1),
	('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, 3),
	('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00, 1),
	('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88, 2)

SELECT * FROM Addresses
SELECT * FROM Departments
SELECT * FROM Employees
SELECT * FROM Towns