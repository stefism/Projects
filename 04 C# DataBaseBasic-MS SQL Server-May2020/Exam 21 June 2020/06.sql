SELECT --h.[Name],
COUNT(h.[Name]) AS [Count]
FROM Hotels AS h




SELECT c.[Name],
COUNT(h.[Name]) AS [Count]
FROM Hotels AS h
LEFT JOIN Cities AS c ON h.CityId = c.Id
GROUP BY c.[Name]
ORDER BY [Count] DESC
