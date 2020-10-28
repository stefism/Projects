CREATE FUNCTION udf_CalculateTickets
(@origin VARCHAR(MAX), 
@destination VARCHAR(MAX), 
@peopleCount INT)
RETURNS VARCHAR(100)
AS
BEGIN
	DECLARE @isFilghtValid INT
	SET @isFilghtValid = (SELECT COUNT(*) FROM Flights
						  WHERE Origin = @origin 
						  AND Destination = @destination)

	IF(@peopleCount <= 0)
	RETURN 'Invalid people count!'

	IF(@isFilghtValid = 0)
	RETURN 'Invalid flight!'

	DECLARE @destinationPrice DECIMAL(10, 2)
	DECLARE @totalPrice DECIMAL(10, 2)

	SET @destinationPrice = (SELECT t.Price FROM Flights AS f
							JOIN Tickets AS t ON t.FlightId = f.Id
							WHERE Origin = @origin 
							AND Destination = @destination)

	SET @totalPrice = @destinationPrice * @peopleCount

	RETURN 'Total price ' + CONVERT(VARCHAR(20), @totalPrice)
END
----
GO
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)

SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

GO
SELECT * FROM Flights

SELECT COUNT(*) FROM Flights
WHERE Origin = 'Kolyshley' AND Destination = 'Rancabolang'

SELECT Origin, Destination, t.Price
FROM Flights AS f
JOIN Tickets AS t ON t.FlightId = f.Id
WHERE Origin = 'Kolyshley' AND Destination = 'Rancabolang'