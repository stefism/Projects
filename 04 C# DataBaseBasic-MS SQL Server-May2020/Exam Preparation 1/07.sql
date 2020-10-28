SELECT  
p.FirstName + ' ' + p.LastName AS [Full Name],
f.Origin, f.Destination
FROM Tickets AS t
JOIN Passengers AS p ON t.PassengerId = p.Id
JOIN Flights AS f ON t.FlightId = f.Id
ORDER BY [Full Name], Origin, Destination