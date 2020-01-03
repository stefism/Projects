CREATE TABLE Towns 
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Addresses 
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
	AddressText NVARCHAR(MAX), 
	TownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id),
)

CREATE TABLE Departments 
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
	[Name] NVARCHAR(30)
)

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
	FirstName NVARCHAR(30) NOT NULL, 
	MiddleName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	JobTitle NVARCHAR(30) NOT NULL, 
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id), 
	HireDate DATE, 
	Salary DECIMAL(10,2), 
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Towns([Name]) VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')

INSERT INTO Departments([Name]) VALUES
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
	('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
	('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
	('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)
