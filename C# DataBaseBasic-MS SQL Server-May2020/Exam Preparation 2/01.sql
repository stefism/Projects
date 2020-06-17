CREATE TABLE Subjects
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT NOT NULL
)

CREATE TABLE Teachers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT 
	CHECK (Age BETWEEN 5 AND 100),
	[Address] NVARCHAR(50),
	Phone NCHAR(10)
)

CREATE TABLE StudentsTeachers
(
	StudentId INT NOT NULL,
	TeacherId INT NOT NULL
)

ALTER TABLE StudentsTeachers
ADD CONSTRAINT PK_StudentId_TeacherId
PRIMARY KEY(StudentId, TeacherId)

ALTER TABLE StudentsTeachers
ADD CONSTRAINT FK_StudentId
FOREIGN KEY(StudentId) REFERENCES Students(Id)

ALTER TABLE StudentsTeachers
ADD CONSTRAINT FK_TeacherId
FOREIGN KEY(TeacherId) REFERENCES Teachers(Id)

CREATE TABLE StudentsSubjects
(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
	SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id),
	Grade DECIMAL(3,2) NOT NULL
	CHECK (Grade BETWEEN 2 AND 6)
)

CREATE TABLE Exams
(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME,
	SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE StudentsExams
(
	StudentId INT NOT NULL,
	ExamId INT NOT NULL,
	Grade DECIMAL(3,2) NOT NULL
	CHECK (Grade BETWEEN 2 AND 6)
)

ALTER TABLE StudentsExams
ADD CONSTRAINT PK_StudentId_ExamId
PRIMARY KEY(StudentId, ExamId)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_StudentId2
FOREIGN KEY(StudentId) REFERENCES Students(Id)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_ExamId
FOREIGN KEY(ExamId) REFERENCES Exams(Id)