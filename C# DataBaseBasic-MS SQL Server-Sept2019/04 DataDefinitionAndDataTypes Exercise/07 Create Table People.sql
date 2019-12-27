CREATE TABLE People
(
	Id INT NOT NULL UNIQUE IDENTITY(1, 1),
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX), --2097152
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

ALTER TABLE dbo.People
ADD CONSTRAINT PK_PeopleId
PRIMARY KEY(Id)

INSERT INTO People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES
	('Ivan', NULL, NULL, NULL, 'm', '1970-12-15', NULL),
	('Dragan', NULL, NULL, NULL, 'm', '1972-12-15', NULL),
	('Mimi', NULL, NULL, NULL, 'f', '1975-12-15', NULL),
	('Lili', NULL, NULL, NULL, 'f', '1976-12-15', NULL),
	('Pesho', NULL, NULL, NULL, 'm', '1977-12-15', NULL)

