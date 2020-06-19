-- 14. Create Table Logs
CREATE OR ALTER TRIGGER tr_InserToLogsOnUpdate
ON Accounts FOR UPDATE
AS
	INSERT INTO Logs
	(AccountID, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance
	FROM inserted AS i
	JOIN deleted AS d ON i.Id = d.Id
	WHERE i.Balance != d.Balance
GO