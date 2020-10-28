SELECT FirstName + ' ' + LastName AS [Full Name],
Planes.[Name],
f.Origin + ' - ' + f.Destination AS Trip,
lt.[Type]
FROM Passengers AS p
JOIN Tickets AS t ON t.PassengerId = p.Id
JOIN Flights AS f ON t.FlightId = f.Id
JOIN Luggages AS l ON t.LuggageId = l.Id
JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
JOIN Planes ON f.PlaneId = Planes.Id
ORDER BY [Full Name], Planes.[Name], f.Origin, f.Destination, lt.[Type]