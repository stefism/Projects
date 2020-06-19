CREATE PROC usp_TransferMoney
(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(22, 4))
AS
	BEGIN TRANSACTION

	IF((SELECT COUNT(*) Id FROM Accounts
		WHERE Id = @SenderId) != 1)
	THROW 50001, 'Invalid Sender.', 1

	IF((SELECT COUNT(*) Id FROM Accounts
		WHERE Id = @ReceiverId) != 1)
	THROW 50001, 'Invalid Receiver.', 1

	EXEC usp_WithdrawMoney @SenderId, @Amount

	EXEC usp_DepositMoney @ReceiverId, @Amount

	COMMIT

GO