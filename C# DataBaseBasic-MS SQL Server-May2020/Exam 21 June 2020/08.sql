SELECT * FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id



----
SELECT TOP 10 c. Id, c.[Name], c.CountryCode,
COUNT(c.[Name]) AS Counts
FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
GROUP BY c.[Name], c.CountryCode, c.Id
ORDER BY Counts DESC