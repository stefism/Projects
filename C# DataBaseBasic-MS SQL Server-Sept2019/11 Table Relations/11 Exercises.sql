-- Exercises: Table Relations
-- 1. One-To-One Relationship
CREATE TABLE Persons
(
	PersonID INT NOT NULL,
	FirstName NVARCHAR(20) NOT NULL,
	Salary DECIMAL(10, 2),
	PassportID INT NOT NULL -- Тука трябва да се добави UNIQUE при изнесения ключ, за да не може двама човека да имат един и същи паспорт. Иначе става едно към много, а не едно към едно връзка.
)

CREATE TABLE Passports
(
	PassportID INT NOT NULL, 
	PassportNumber NVARCHAR(20) NOT NULL
)

INSERT INTO Persons(PersonID,	FirstName,	Salary,	PassportID)
VALUES
	(1, 'Roberto', 43300.00, 102),
	(2, 'Tom', 56100.00, 103),
	(3, 'Yana', 60200.00, 101)

INSERT INTO Passports(PassportID, PassportNumber)
VALUES
	(101, 'N34FG21B'),
	(102, 'K65LO4R7'),
	(103, 'ZE657QP2')

ALTER TABLE Persons
ADD CONSTRAINT PK_PersonID
PRIMARY KEY(PersonID)

ALTER TABLE Passports
ADD CONSTRAINT PK_PassportID
PRIMARY KEY(PassportID)

ALTER TABLE Persons
ADD CONSTRAINT FK_PassportID
FOREIGN KEY(PassportID) REFERENCES Passports(PassportID)

-- 2. One-To-Many Relationship
CREATE TABLE Models
(
	ModelID INT NOT NULL,
	[Name] NVARCHAR(20),
	ManufacturerID INT NOT NULL
)

CREATE TABLE Manufacturers
(
	ManufacturerID INT NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
	EstablishedOn DATE
)

INSERT INTO Models(ModelID, [Name], ManufacturerID)
VALUES
	(101, 'X1', 1),
	(102, 'i6', 1),
	(103, 'Model S', 2),
	(104, 'Model X', 2),
	(105, 'Model 3', 2),
	(106, 'Nova	  ', 3)

INSERT INTO Manufacturers(ManufacturerID, [Name], EstablishedOn)
VALUES
	(1, 'BMW', '07/03/1916'),
	(2, 'Tesla', '01/01/2003'),
	(3, 'Lada', '01/05/1966')

ALTER TABLE Models
ADD CONSTRAINT PK_ModelID
PRIMARY KEY(ModelID)

ALTER TABLE Manufacturers
ADD CONSTRAINT PK_ManufacturerID
PRIMARY KEY(ManufacturerID)

ALTER TABLE dbo.Models
ADD CONSTRAINT FK_ManufacturerID
FOREIGN KEY(ManufacturerID) 
REFERENCES Manufacturers(ManufacturerID)

-- 3. Many-To-Many Relationship
CREATE TABLE Students
(
	StudentID INT NOT NULL,
	[Name] NVARCHAR(30)
)

CREATE TABLE Exams
(
	ExamID INT NOT NULL,
	[Name] NVARCHAR(30)
)

CREATE TABLE StudentsExams
(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL
)

INSERT INTO Students(StudentID,	[Name])
VALUES
	(1, 'Mila'),
	(2, 'Toni'),
	(3, 'Ron')

INSERT INTO Exams(ExamID, [Name])
VALUES
	(101, 'SpringMVC'),
	(102, 'Neo4j'),
	(103, 'Oracle 11g')

INSERT INTO StudentsExams
VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)

ALTER TABLE Students
ADD CONSTRAINT PK_StudentID
PRIMARY KEY(StudentID)

ALTER TABLE Exams
ADD CONSTRAINT PK_ExamsID
PRIMARY KEY(ExamID)

ALTER TABLE StudentsExams
ADD CONSTRAINT KK_StudentID_ExamID
PRIMARY KEY(StudentID, ExamID)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_StudentID
FOREIGN KEY(StudentID) REFERENCES Students(StudentID)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_ExamID
FOREIGN KEY(ExamID) REFERENCES Exams(ExamID)

-- 4. Self-Referencing
CREATE TABLE Teachers
(
	TeacherID INT NOT NULL,
	[Name] NVARCHAR(30),
	ManagerID INT
)

INSERT INTO Teachers(TeacherID, [Name], ManagerID)
VALUES
	(101, 'John', NULL),
	(102, 'Maya' ,106 ),
	(103, 'Silvia' ,106),
	(104, 'Ted', 105),
	(105, 'Mark', 101),
	(106, 'Greta', 101)

ALTER TABLE Teachers
ADD CONSTRAINT PK_TeacherID
PRIMARY KEY(TeacherID)

ALTER TABLE Teachers
ADD CONSTRAINT FK_TeacherID
FOREIGN KEY(ManagerID) REFERENCES Teachers(TeacherID)

--  5. Online Store Database