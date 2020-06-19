CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(100))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(u.Username) 
			FROM Commits AS c
			JOIN Users As u ON c.ContributorId = u.Id
			WHERE u.Username = @username
			GROUP BY u.Username)
END

GO

SELECT dbo.udf_UserTotalCommits('AryaDenotehow')

SELECT * 
FROM Commits AS c
FULL JOIN Users As u ON c.ContributorId = u.Id
--WHERE u.Username = 'UnderSinduxrein'
--GROUP BY u.Username

