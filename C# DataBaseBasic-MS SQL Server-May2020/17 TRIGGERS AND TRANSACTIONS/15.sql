-- 15. Create Table Emails
CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY, 
	Recipient INT NOT NULL, 
	[Subject] NVARCHAR(100), 
	Body NVARCHAR(300)
)
GO

CREATE TRIGGER tr_SendEmailOnNewRecord
ON Logs FOR INSERT
AS
	INSERT INTO NotificationEmails(Recipient, [Subject], Body)
	SELECT LogId, 
	CONCAT('Balance change for account: ', LogId) AS [Subject],
	CONCAT('On ', GETDATE(), ' your balance was changed from ', OldSum, ' to ', NewSum, '.') AS Body
	FROM inserted

GO

SELECT * FROM Logs

SELECT * FROM NotificationEmails