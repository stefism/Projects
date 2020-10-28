SELECT * FROM Flights

SELECT PlaneId FROM Flights
WHERE Destination = 'Ayn Halagim'

SELECT Id FROM Flights
WHERE Destination = 'Ayn Halagim'


---
DELETE FROM Tickets
WHERE FlightID IN (SELECT Id FROM Flights
WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'
---