CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*) AS counts
			FROM Commits AS c
			LEFT JOIN Users As u ON c.ContributorId = u.Id
			WHERE u.Username = @username)
			-- ������ � ���� ���� ���������� �������, ���� � ��� ���������.
END

GO


SELECT COUNT(*)
FROM Commits AS c
FULL JOIN Users As u ON c.ContributorId = u.Id
WHERE u.Username = 'UnderSinduxrein'

SELECT *
FROM Commits AS c
FULL JOIN Users As u ON c.ContributorId = u.Id
--WHERE u.Username = 'UnderSinduxrein'

