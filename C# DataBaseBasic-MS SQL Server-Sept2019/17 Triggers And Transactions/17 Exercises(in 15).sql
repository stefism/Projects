-- Part 1. Queries for Bank Database
-- 14. Create Table Logs
-- https://github.com/aguzelov/SoftUni/commit/d254e4bee5676f5b95613effbf0f28e69dc776f8#diff-a31f02cc5cbcfb776d29f53d7bef8afa

CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
	OldSum MONEY,
	NewSum MONEY
)

GO
CREATE TRIGGER tr_InsertNewEntryIntoLogs
ON Accounts AFTER UPDATE
AS
INSERT INTO Logs VALUES 
  (
    (SELECT Id FROM inserted),
    (SELECT Balance FROM deleted),
    (SELECT Balance FROM inserted)
  )

-- 15. Create Table Emails
CREATE TABLE NotificationEmails
(
	ID INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
	[Subject] VARCHAR(100),
	Body VARCHAR(MAX)
)

GO
CREATE TRIGGER tr_CreateNewNotificationEmail
ON Logs AFTER INSERT
AS
BEGIN
INSERT INTO NotificationEmails
VALUES 
(
    (SELECT AccountId FROM inserted),
    (CONCAT('Balance change for account: ', (SELECT AccountId FROM inserted))),
    (CONCAT('On ', (SELECT GETDATE() FROM inserted), 'your balance was changed from ', (SELECT OldSum FROM inserted), 'to ', (SELECT NewSum FROM inserted), '.'))
)
END

-- 