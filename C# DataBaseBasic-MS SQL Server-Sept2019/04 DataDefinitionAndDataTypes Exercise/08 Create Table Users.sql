CREATE TABLE Users
(
	Id INT NOT NULL UNIQUE IDENTITY(1,1),
	Username NVARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY,
	LastLoginTime DATETIME,
	IsDeleted BIT
)

ALTER TABLE Users
ADD CONSTRAINT PK_UsersId
PRIMARY KEY(Id)

INSERT INTO Users(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) VALUES
	('Ivan', '123', NULL, NULL, NULL),
	('Gosho', '888', NULL, NULL, NULL),
	('Petar', '434', NULL, NULL, NULL),
	('Ivanka', 'Nula', NULL, NULL, NULL),
	('Pepa', 'dve', NULL, NULL, NULL)