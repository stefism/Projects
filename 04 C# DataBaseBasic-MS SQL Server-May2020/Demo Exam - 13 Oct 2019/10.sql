SELECT u.Username,
AVG(f.Size) As AvgSize
FROM Files AS f
JOIN Commits AS c ON f.CommitId = c.Id
JOIN Users AS u ON c.ContributorId = u.Id
GROUP BY Username
ORDER BY AvgSize DESC, u.Username