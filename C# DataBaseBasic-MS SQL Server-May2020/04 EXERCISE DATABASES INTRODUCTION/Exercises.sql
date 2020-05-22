-- 01 Create Database
CREATE DATABASE Minions

GO

-- 02 Create Tables
CREATE TABLE Minions (
	Id INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Age TINYINT NOT NULL
)

GO
CREATE TABLE Towns (
	Id INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

GO
-- 03 Alter Minions Table
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

SELECT * FROM Minions

GO
-- 04 Insert Records in Both Tables
INSERT INTO Towns(Id, [Name])
VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

INSERT INTO Minions(Id, [Name], Age, TownId)
VALUES
	(1, 'Kevin', 22, 1),
	(2,'Bob', 15, 3),
	(3, 'Steward', NULL, 2)

SELECT * FROM Towns

GO
-- 07 Create Table People
CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) CHECK(DATALENGTH(Picture) <= 2097152),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People([Name], Gender, Birthdate)
VALUES
	('Pesho1', 'm', '1986-06-18'),
	('Pesho2', 'f', '1986-03-18'),
	('Pesho3', 'm', '1986-07-18'),
	('Pesho4', 'f', '1986-08-18'),
	('Pesho5', 'm', '1986-09-18')


GO
-- 08 Create Table Users
DROP TABLE Users

CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX)
	CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username, [Password], IsDeleted, LastLoginTime)
VALUES
	('edno', 'dve', 0, '2020-05-22'),
	('edno1', 'dve1', 0, '2020-05-22'),
	('edno2', 'dve2', 0, '2020-05-22'),
	('edno3', 'dve3', 0, '2020-05-22'),
	('edno4', 'dve4', 0, '2020-05-22')

SELECT * FROM Users

GO
-- 09 Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC075CDB813E

ALTER TABLE Users
ADD CONSTRAINT CompositeKey_Id_Username
PRIMARY KEY(Id, Username)

GO
-- 10 Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CK_PasswordLeast5Symbols
CHECK(LEN([Password]) >= 5) -- DATALENGTH -> Bytes Count

-- 11 Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

-- 12 Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT CompositeKey_Id_Username

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_UsernameLength
CHECK(LEN(Username) >= 3)

GO
-- 16 Create SoftUni Database