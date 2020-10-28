SELECT * FROM Flights AS f
JOIN Tickets AS t ON t.FlightId = f.Id

SELECT Id FROM Flights
WHERE Destination = 'Carlsbad'

SELECT * FROM Flights
SELECT * FROM Tickets
---
UPDATE Tickets
SET Price = Price * 1.13
WHERE FlightID IN (SELECT Id FROM Flights
WHERE Destination = 'Carlsbad')
---