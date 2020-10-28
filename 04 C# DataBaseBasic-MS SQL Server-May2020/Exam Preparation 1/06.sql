SELECT FlightId,
SUM(Price) AS Price
FROM Tickets AS t
JOIN Flights AS f ON t.FlightId = f.Id
GROUP BY FlightId
ORDER BY Price DESC
---

SELECT *
FROM Tickets AS t
JOIN Flights AS f ON t.FlightId = f.Id
