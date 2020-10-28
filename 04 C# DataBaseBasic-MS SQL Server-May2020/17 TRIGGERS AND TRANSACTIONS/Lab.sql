CREATE TRIGGER tr_SetIsDeletedOnDelete ON AccountHolders
INSTEAD OF DELETE
AS
	UPDATE AccountHolders
	SET IsDeleted = 1
	WHERE Id IN (SElECT Id FROM deleted)
GO

SELECT * FROM AccountHolders

DELETE FROM AccountHolders
WHERE FirstName LIKE 'M%'

---
CREATE TABLE Logs
(
	Id INT PRIMARY KEY IDENTITY,
	AcoountID INT FOREIGN KEY REFERENCES Accounts(Id),
	OldAmount DECIMAL(18, 2) NOT NULL,
	NewAmount DECIMAL(18, 2) NOT NULL,
	UpdateOn DATETIME2,
	UpdatetBy NVARCHAR(100)
)
GO
CREATE TRIGGER tr_InserToLogsOnUpdate
ON Accounts FOR UPDATE
AS
	INSERT INTO Logs
	([AcoountID], [OldAmount], [NewAmount], [UpdateOn], [UpdatetBy])
	SELECT i.Id, d.Balance, i.Balance, GETDATE(), CURRENT_USER
	FROM inserted AS i
	JOIN deleted AS d ON i.Id = d.Id
	WHERE i.Balance != d.Balance
GO
-- С послединя ред казваме, че искаме да записваме в лога само при промяна на баланса. При други ъпдейти в лога няма да се запише нищо.
-- В служебната таблица deleted се намират записите преди ъпдейта, защото тези, които се променят, първо се изтриват и после на тяхно място се вкарват новите записи, които пък нови записи преди да се запишат в таблицата се намират в служебната таблица inserted.

SELECT * FROM Logs

UPDATE Accounts
SET Balance = 12345
WHERE Id IN (2, 5)

SELECT * FROM Logs