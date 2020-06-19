CREATE PROC usp_WithdrawMoney
			(@AccountId INT, @MoneyAmount DECIMAL(22, 4))
AS
	BEGIN TRANSACTION

	IF((SELECT COUNT(*) Id FROM Accounts
		WHERE Id = @AccountId) != 1)
	THROW 50001, 'Invalid user account.', 1

	UPDATE Accounts
	SET Balance = Balance - @MoneyAmount
	WHERE Id = @AccountId
	
	COMMIT

GO