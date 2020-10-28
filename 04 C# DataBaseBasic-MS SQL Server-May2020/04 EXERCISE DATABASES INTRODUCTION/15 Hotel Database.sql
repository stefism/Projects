CREATE DATABASE Hotel

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	Title NVARCHAR(10), 
	Notes NVARCHAR(200)
)

INSERT INTO Employees(FirstName, LastName)
VALUES
	('aaaa1', 'bbbb1'),
	('aaaa2', 'bbbb2'),
	('aaaa3', 'bbbb3')

CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY NOT NULL, 
	FirstName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	PhoneNumber NVARCHAR(50) NOT NULL, 
	EmergencyName NVARCHAR(50), 
	EmergencyNumber NVARCHAR(50), 
	Notes NVARCHAR(200)
)

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber)
VALUES
	(123, 'Ivan', 'Ivanov', '+359 98 56 88 79'),
	(124, 'Ivanka', 'Ivanova', '+359 98 56 89 79'),
	(125, 'Ivancho', 'Ivanovich', '+359 98 55 88 79')

CREATE TABLE RoomStatus(
	RoomStatus NVARCHAR(20) PRIMARY KEY NOT NULL, 
	Notes NVARCHAR(200)
)

INSERT INTO RoomStatus(RoomStatus)
VALUES
	('edno'),
	('dve'),
	('tri')

CREATE TABLE RoomTypes(
	RoomType NVARCHAR(20) PRIMARY KEY NOT NULL, 
	Notes NVARCHAR(200)
)

INSERT INTO RoomTypes(RoomType)
VALUES
	('edno'),
	('dve'),
	('tri')

CREATE TABLE BedTypes(
	BedType NVARCHAR(20) PRIMARY KEY NOT NULL, 
	Notes NVARCHAR(200)
)

INSERT INTO BedTypes(BedType)
VALUES
	('edno'),
	('dve'),
	('tri')

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY NOT NULL, 
	RoomType NVARCHAR(20) NOT NULL, 
	BedType NVARCHAR(20) NOT NULL, 
	Rate NVARCHAR(20), 
	RoomStatus NVARCHAR(20), 
	Notes NVARCHAR(200)
)

INSERT INTO Rooms(RoomNumber, RoomType, BedType)
VALUES
	(202, 'tri', 'dve'),
	(203, 'dve', 'tri'),
	(204, 'tri', 'dve')

CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL, 
	PaymentDate DATETIME2, 
	AccountNumber INT, 
	FirstDateOccupied DATETIME2 NOT NULL, 
	LastDateOccupied DATETIME2 NOT NULL, 
	TotalDays INT NOT NULL, 
	AmountCharged DECIMAL(18,2), 
	TaxRate DECIMAL(18,2), 
	TaxAmount DECIMAL(18,2), 
	PaymentTotal DECIMAL(18,2), 
	Notes NVARCHAR(200)
)

INSERT INTO Payments(EmployeeId, FirstDateOccupied, LastDateOccupied, TotalDays)
VALUES
	(1, '2020-04-23', '2020-05-12', 5),
	(2, '2020-04-24', '2020-05-12', 3),
	(3, '2020-04-26', '2020-05-12', 12)

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL, 
	DateOccupied DATETIME2, 
	AccountNumber INT NOT NULL, 
	RoomNumber INT, 
	RateApplied DECIMAL(18,2), 
	PhoneCharge NVARCHAR(5), 
	Notes NVARCHAR(200)
)

INSERT INTO Occupancies(EmployeeId, AccountNumber)
VALUES
	(1, 12),
	(2, 13),
	(3 ,14)