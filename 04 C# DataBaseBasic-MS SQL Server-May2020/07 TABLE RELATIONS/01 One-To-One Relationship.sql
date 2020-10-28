-- 01.	One-To-One Relationship
CREATE TABLE Passports
(
	PassportID INT NOT NULL PRIMARY KEY,
	PassportNumber VARCHAR(10) NOT NULL
)

CREATE TABLE Persons
(
	PersonId INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(7,2),
	PassportID INT NOT NULL UNIQUE
	FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Passports(PassportID, PassportNumber)
VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons(FirstName, Salary, PassportID)
VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)