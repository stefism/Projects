SELECT TOP(5) r.Id, r.[Name], 
COUNT(c.RepositoryId) AS [Commits] FROM Repositories AS r
JOIN Commits AS c
ON c.RepositoryId = r.Id
LEFT JOIN RepositoriesContributors AS rc
ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.[Name]
ORDER BY [Commits] DESC, r.Id, r.[Name]