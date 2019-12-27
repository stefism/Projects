CREATE TABLE Categories 
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
	CategoryName NVARCHAR(30), 
	DailyRate INT, 
	WeeklyRate INT, 
	MonthlyRate INT, 
	WeekendRate INT
)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
	PlateNumber INT NOT NULL, 
	Manufacturer NVARCHAR(20) NOT NULL, 
	Model NVARCHAR(20) NOT NULL, 
	CarYear DATE, 
	CategoryId INT, 
	Doors INT, 
	Picture VARBINARY, 
	Condition NVARCHAR(20), 
	Available BIT
)

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	Title NVARCHAR(30), 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customers 
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
	DriverLicenceNumber INT NOT NULL, 
	FullName NVARCHAR(MAX) NOT NULL, 
	[Address] NVARCHAR(MAX) NOT NULL, 
	City NVARCHAR(30) NOT NULL, 
	ZIPCode INT, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders 
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL, 
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL, 
	TankLevel NVARCHAR(20), 
	KilometrageStart INT, 
	KilometrageEnd INT, 
	TotalKilometrage INT, 
	StartDate DATE, 
	EndDate DATE, 
	TotalDays INT, 
	RateApplied DECIMAL(8,2), 
	TaxRate DECIMAL(8,2), 
	OrderStatus NVARCHAR(20) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
	('edno', 3, 3, 3, 3),
	('dve', 3, 3, 3, 3),
	('tri', 3, 3, 3, 3)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
	(123, 'opel', 'astra', '1984-12-12', 1, 4, NULL, NULL, NULL),
	(124, 'opel2', 'astra2', '1984-12-12', 1, 4, NULL, NULL, NULL),
	(125, 'opel3', 'astra3', '1984-12-12', 1, 4, NULL, NULL, NULL)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
	('Ivan1', 'Ivanov1', NULL, NULL),
	('Ivan2', 'Ivanov2', NULL, NULL),
	('Ivan3', 'Ivanov3', NULL, NULL)

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
	(1234, 'Pepa Pepina', 'Adresa', 'Sofia', 1231, 'Notes'),
	(2234, 'Pepa Pepina2', 'Adresa2', 'Sofia2', 1231, 'Notes2'),
	(3234, 'Pepa Pepina3', 'Adresa3', 'Sofia3', 1231, 'Notes3')

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
	(1, 1, 1, 'edno', 123, 456, 789, NULL, NULL, NULL, NULL, NULL, 'c-t', NULL),
	(2, 2, 2, '2', 123, 456, 789, NULL, NULL, NULL, NULL, NULL, 'c-t', NULL),
	(3, 3, 3, '3', 123, 456, 789, NULL, NULL, NULL, NULL, NULL, 'c-t', NULL)