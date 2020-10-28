-- 03.	Many-To-Many Relationship
CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL
)

ALTER TABLE StudentsExams
ADD CONSTRAINT KK_StudentID_ExamId
PRIMARY KEY(StudentID, ExamID)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_StudentsID
FOREIGN KEY (StudentID) REFERENCES Students(StudentID)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_ExamID
FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)

INSERT INTO Students([Name])
VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams([Name])
VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO StudentsExams
VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)