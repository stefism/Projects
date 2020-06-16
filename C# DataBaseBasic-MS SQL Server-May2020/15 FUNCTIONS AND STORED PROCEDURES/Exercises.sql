-- Part 2. Queries for Bank Database
-- 09. Find Full Name
CREATE PROC usp_GetHoldersFullName
AS
	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders
GO

EXEC usp_GetHoldersFullName

-- 10. People with Balance Higher Than
GO

CREATE PROC usp_GetHoldersWithBalanceHigherThan(@TotalMoney MONEY)
AS
	SELECT FirstName, LastName
	FROM
	(SELECT AccountHolderId, 
		ac.FirstName, ac.LastName,
		SUM(Balance) AS [Total Balance]
		FROM Accounts AS a
		JOIN AccountHolders AS ac ON a.AccountHolderId = ac.Id
		GROUP BY a.AccountHolderId, ac.FirstName, ac.LastName) AS tmp
	WHERE [Total Balance] > @TotalMoney
	ORDER BY FirstName, LastName
GO

-- 11. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue(@InitialSum decimal(18, 4), @YearlyInterestRate float, @Years int)
RETURNS decimal(18, 4)
AS
BEGIN
	RETURN @InitialSum * (POWER(1 + @YearlyInterestRate, @Years))
END

GO
SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

-- Õ≈ ¡¿÷¿ *** 12. Calculating Interest
GO

CREATE PROC usp_CalculateFutureValueForAccount(@AccountId int, @InterestRate float)
AS
	SELECT ac.Id, ac.FirstName, ac.LastName,
	a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5)
	AS [Balance in 5 years]
	FROM AccountHolders AS ac
	JOIN Accounts AS a ON a.AccountHolderId = ac.Id
	WHERE a.Id = @AccountId
GO

SELECT * FROM Accounts

EXEC usp_CalculateFutureValueForAccount 1, 0.1

-- 13. *Scalar Function: Cash in User Games Odd Rows
SELECT *
FROM
(SELECT g.Id, ug.Cash, g.[Name],
ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS [Row Number]
FROM UsersGames AS ug
JOIN Games AS g ON ug.GameId = g.Id) AS tmp
WHERE [Row Number] % 2 = 1