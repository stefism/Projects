CREATE PROC usp_CancelFlights
AS
UPDATE Flights
SET DepartureTime = NULL
WHERE ArrivalTime > DepartureTime

UPDATE Flights
SET ArrivalTime = NULL
WHERE DepartureTime IS NULL
GO

EXEC usp_CancelFlights

SELECT * FROM Flights
WHERE ArrivalTime > DepartureTime