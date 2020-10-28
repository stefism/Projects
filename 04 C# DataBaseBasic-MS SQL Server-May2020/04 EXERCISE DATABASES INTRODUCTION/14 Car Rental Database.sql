CREATE DATABASE CarRental

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY, 
	CategoryName NVARCHAR(30), 
	DailyRate NVARCHAR(30), 
	WeeklyRate NVARCHAR(30), 
	MonthlyRate NVARCHAR(30), 
	WeekendRate NVARCHAR(30)
)

INSERT INTO Categories(CategoryName)
VALUES
	('Yaka'),
	('Yaka2'),
	('Yaka3')

CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY, 
	PlateNumber INT NOT NULL, 
	Manufacturer DATETIME2 NOT NULL, 
	Model NVARCHAR(30), 
	CarYear NVARCHAR(4), 
	CategoryId INT NOT NULL, 
	Doors INT, 
	Picture VARBINARY(MAX) CHECK(DATALENGTH(Picture) <= 2097152), 
	Condition NVARCHAR(20), 
	Available BINARY NOT NULL
)

INSERT INTO Cars(PlateNumber, Manufacturer, CategoryId, Available)
VALUES
	(12345, '1986-03-12', 1, 1),
	(123452, '1986-04-12', 2, 1),
	(123453, '1986-05-12', 1, 0)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	Title NVARCHAR(5), 
	Notes NVARCHAR(200)
)

INSERT INTO Employees(FirstName, LastName)
VALUES
	('edno1', 'dve1'),
	('edno2', 'dve2'),
	('edno3', 'dve3')

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY, 
	DriverLicenceNumber NVARCHAR(30) NOT NULL, 
	FullName NVARCHAR(30) NOT NULL, 
	[Address] NVARCHAR(100), 
	City NVARCHAR(30), 
	ZIPCode NVARCHAR(30), 
	Notes NVARCHAR(200)
)

INSERT INTO Customers(DriverLicenceNumber, FullName)
VALUES
	('CX-2020-BX-45', 'Prekrasnia Kara4-1'),
	('CX-2020-BX-47', 'Prekrasnia Kara4-2'),
	('CX-2020-BX-49', 'Prekrasnia Kara4-3')

CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL, 
	CustomerId INT NOT NULL, 
	CarId INT NOT NULL, 
	TankLevel NVARCHAR(30), 
	KilometrageStart INT, 
	KilometrageEnd INT, 
	TotalKilometrage INT, 
	StartDate DATETIME2, 
	EndDate DATETIME2, 
	TotalDays INT, 
	RateApplied DECIMAL(18, 2), 
	TaxRate DECIMAL(18, 2), 
	OrderStatus NVARCHAR(30), 
	Notes NVARCHAR(200)
)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId)
VALUES
	(1, 2, 3),
	(3, 2, 1),
	(2, 3, 2)