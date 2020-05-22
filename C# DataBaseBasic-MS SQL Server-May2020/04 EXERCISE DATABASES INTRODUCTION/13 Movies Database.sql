-- 13 Movies Database
CREATE DATABASE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO Directors(DirectorName)
VALUES
	('Edno'),
	('Edno2'),
	('Edno3'),
	('Edno4'),
	('Edno5')

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO Genres(GenreName)
VALUES
	('Edno'),
	('Edno2'),
	('Edno3'),
	('Edno4'),
	('Edno5')

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO Categories(CategoryName)
VALUES
	('Edno'),
	('Edno2'),
	('Edno3'),
	('Edno4'),
	('Edno5')

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear VARCHAR(4),
	[Length] NVARCHAR(50),
	GenreId INT,
	CategoryId INT,
	Rating NVARCHAR(50),
	Notes NVARCHAR(200)
)

INSERT INTO Movies(Title, DirectorId)
VALUES
	('Edno', 1),
	('Edno2', 2),
	('Edno3', 3),
	('Edno4', 4),
	('Edno5', 5)
