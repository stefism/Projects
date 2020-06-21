SELECT [FirstName], [LastName], 
FORMAT([BirthDate], 'MM-dd-yyyy') AS BirthDate,
c.[Name] AS Hometown, [Email]
FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
WHERE Email LIKE 'e%'
ORDER BY c.[Name]