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
	AccountNumber INT PRIMARY KEY NOT NULL, 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	PhoneNumber INT, 
	EmergencyName NVARCHAR(30), 
	EmergencyNumber INT, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus 
(
	RoomStatus NVARCHAR(30) PRIMARY KEY NOT NULL, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomTypes 
(
	RoomType NVARCHAR(30) PRIMARY KEY NOT NULL, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE BedTypes
(
	BedType NVARCHAR(30) PRIMARY KEY NOT NULL, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Rooms 
(
	RoomNumber INT PRIMARY KEY NOT NULL, 
	RoomType NVARCHAR(20) NOT NULL, 
	BedType NVARCHAR(20) NOT NULL, 
	Rate  INT NOT NULL, 
	RoomStatus NVARCHAR(20) NOT NULL, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Payments 
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
	PaymentDate DATE NOT NULL, 
	AccountNumber INT NOT NULL, 
	FirstDateOccupied DATE NOT NULL, 
	LastDateOccupied DATE NOT NULL, 
	TotalDays INT NOT NULL, 
	AmountCharged INT, 
	TaxRate INT, 
	TaxAmount INT, 
	PaymentTotal INT, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Occupancies 
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
	DateOccupied DATE NOT NULL, 
	AccountNumber INT NOT NULL, 
	RoomNumber INT NOT NULL, 
	RateApplied INT, 
	PhoneCharge NVARCHAR(20), 
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
	('Ivan', 'Ivanov', NULL, NULL),
	('Super', 'Programist', NULL, NULL),
	('Yako', 'Dolari', NULL, NULL)

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
	(1, 'Milion', 'Dolara', 3591, 'Em', 4561, NULL),
	(2, 'Miliona', 'Dolara', 3592, 'Em', 4562, NULL),
	(3, 'Milion+', 'Dolara i Liri', 3593, 'Em', 4563, NULL)

INSERT INTO RoomStatus (RoomStatus, Notes) VALUES
	('da', 'ima pari'),
	('da2', 'ima pari2'),
	('da3', 'ima pari3')

INSERT INTO RoomTypes (RoomType, Notes) VALUES
	('gotina', 'ima pari'),
	('yaka', 'ima pari2'),
	('super yaka', 'ima pari3')

INSERT INTO BedTypes (BedType, Notes) VALUES
	('gotino', 'da2'),
	('yako', 'da3'),
	('super yako', 'da4')

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
	(203, 'Double', 'Double bed', 10, 'Free', 'Pink'),
	(204, 'Appartment', 'Double bed', 8, 'Free', 'Blue'),
	(205, 'Single', 'Double bed', 7, 'Ocuped', 'Green')

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
	(1, '2019-08-08', 1, '2019-08-08', '2019-08-11', 3, NULL, NULL, NULL, NULL, NULL),
	(2, '2019-08-08', 2, '2019-08-08', '2019-08-11', 3, NULL, NULL, NULL, NULL, NULL),
	(3, '2019-08-08', 3, '2019-08-08', '2019-08-11', 3, NULL, NULL, NULL, NULL, NULL)

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
	(1, '2019-08-08', 1, 203, 3, NULL, NULL),
	(2, '2019-08-08', 2, 203, 3, NULL, NULL),
	(3, '2019-08-08', 3, 203, 3, NULL, NULL)