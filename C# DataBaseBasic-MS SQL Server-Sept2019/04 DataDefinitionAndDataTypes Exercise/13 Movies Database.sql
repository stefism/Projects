CREATE TABLE Directors
(
	Id INT NOT NULL UNIQUE IDENTITY(1, 1),
	DirectorName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres
(
	Id INT NOT NULL UNIQUE IDENTITY(1,1),
	GenreName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories
(
	Id INT NOT NULL UNIQUE IDENTITY(1,1),
	CategoryName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies
(
	Id INT NOT NULL UNIQUE IDENTITY(1,1),
	Title NVARCHAR(MAX) NOT NULL,
	DirectorId INT,
	CopyrightYear DATE,
	[Length] DECIMAL(5,2),
	GenreId INT,
	CategoryId INT,
	Rating TINYINT,
	Notes NVARCHAR(MAX)
)

ALTER TABLE Directors
ADD CONSTRAINT PK_DirectorsId
PRIMARY KEY(Id)

ALTER TABLE Genres
ADD CONSTRAINT PK_GenresId
PRIMARY KEY(Id)

ALTER TABLE Categories
ADD CONSTRAINT PK_CategoriesId
PRIMARY KEY(Id)

ALTER TABLE Movies
ADD CONSTRAINT PK_MoviesId
PRIMARY KEY(Id)

ALTER TABLE Movies
ADD CONSTRAINT FK_DirectorId
FOREIGN KEY(DirectorId) REFERENCES Directors(Id)

ALTER TABLE Movies
ADD CONSTRAINT FK_GenreId
FOREIGN KEY(GenreId) REFERENCES Genres(Id)

ALTER TABLE Movies
ADD CONSTRAINT FK_CategoryId
FOREIGN KEY(CategoryId) REFERENCES Categories(Id)

INSERT INTO Directors(DirectorName, Notes) VALUES
	('Pesho', 'blabla'),
	('fdfd', 'tri'),
	('aaa', 'sds'),
	('xcxc', 'vvv'),
	('werr', 'ooo')

INSERT INTO Genres(GenreName, Notes) VALUES
	('AAA', 'blabla'),
	('BBB', 'tri'),
	('CCC', 'sds'),
	('Dddddd', 'vvv'),
	('eeeeeee', 'ooo')

INSERT INTO Categories(CategoryName, Notes) VALUES
	('aaaaaa', 'blabla'),
	('sssss', 'tri'),
	('dfdfdfd', 'sds'),
	('vbvnvnv', 'vvv'),
	('kjkllklk', 'ooo')

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], Rating, Notes) VALUES
	('Title', 1, NULL, NULL, 1, 'Notes'),
	('Title2', 2, NULL, NULL, 1, 'Notes2'),
	('Title3', 3, NULL, NULL, 5, 'Notes3'),
	('Title4', 4, NULL, NULL, 1, 'Notes4'),
	('Title5', 5, NULL, NULL, 3, 'Notes5')