-- CREATE DATABASE TripService

CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	BirthDate DATETIME2,
	Email VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(10, 2)
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(16, 2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	BookDate DATETIME2 NOT NULL,
	ArrivalDate DATETIME2 NOT NULL,
	ReturnDate DATETIME2 NOT NULL,
	CancelDate DATETIME2
)
-- *** ���������� ����!
ALTER TABLE Trips
ADD CONSTRAINT CK_BookDate
CHECK (BookDate < ArrivalDate)

ALTER TABLE Trips
ADD CONSTRAINT CK_ArrivalDate
CHECK (ArrivalDate < ReturnDate)
--- ***

CREATE TABLE AccountsTrips
(
	AccountId INT NOT NULL,
	TripId INT NOT NULL,
	Luggage INT NOT NULL CHECK (Luggage >= 0)
)

ALTER TABLE AccountsTrips
ADD CONSTRAINT PK_AccountId_TripId
PRIMARY KEY(AccountId, TripId)

ALTER TABLE AccountsTrips
ADD CONSTRAINT FK_AccountId
FOREIGN KEY(AccountId) REFERENCES Accounts(Id)

ALTER TABLE AccountsTrips
ADD CONSTRAINT FK_TripId
FOREIGN KEY(TripId) REFERENCES Trips(Id)