SELECT p.[Name] AS [Plane Name], 
p.Seats,
COUNT(ps.FirstName) AS [Passengers Count]
FROM Planes AS p
LEFT JOIN Flights AS f ON f.PlaneId = p.Id
LEFT JOIN Tickets AS t ON t.FlightId = f.Id
LEFT JOIN Passengers AS ps ON t.PassengerId = ps.Id
GROUP BY p.[Name], p.Seats
ORDER BY [Passengers Count] DESC, p.[Name], p.Seats