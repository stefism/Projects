CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATETIME2, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @roomId INT = (SELECT TOP 1 r.Id FROM Trips AS t
							JOIN Rooms AS r ON t.RoomId = r.Id
							JOIN Hotels AS h ON r.HotelId = h.Id
							WHERE @Date NOT BETWEEN ArrivalDate 
							AND ReturnDate AND h.Id = @HotelId AND Beds >= @People
							AND CancelDate IS NULL
							ORDER BY Price DESC)

	IF(@roomId IS NULL)
	RETURN 'No rooms available'

	DECLARE @hotelBaseRate DECIMAL(10,2) = (SELECT TOP 1 h.BaseRate FROM Trips AS t
							JOIN Rooms AS r ON t.RoomId = r.Id
							JOIN Hotels AS h ON r.HotelId = h.Id
							WHERE @Date NOT BETWEEN ArrivalDate 
							AND ReturnDate AND h.Id = @HotelId AND Beds >= @People
							AND CancelDate IS NULL
							ORDER BY Price DESC)

	DECLARE @roomType VARCHAR(200) = (SELECT [Type] FROM Rooms
									  WHERE Id = @roomId)

	DECLARE @roomPrice DECIMAL(10, 2) = (SELECT Price FROM Rooms
									  WHERE Id = @roomId)

	DECLARE @beds INT = (SELECT Beds FROM Rooms
									  WHERE Id = @roomId)

	DECLARE @totalPrice DECIMAL(10, 2) = (@hotelBaseRate + @roomPrice) * @People

	RETURN CONCAT('Room ', @roomId, ': ', @roomType, ' (', @beds, ' beds', ') - $', @totalPrice)
END

GO
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)
---
SELECT dbo.udf_GetAvailableRoom(1, '2015-07-26', 3) --- 4 OK
----
SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2) ---1 OK

----
SELECT * FROM Rooms
WHERE Id = 211

SELECT * FROM Trips AS t
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id

WHERE '2015-07-26' BETWEEN ArrivalDate AND ReturnDate AND h.Id = 94

----***
SELECT * FROM Trips AS t
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id

WHERE '2011-12-17' NOT BETWEEN ArrivalDate 
	  AND ReturnDate AND h.Id = 112 AND Beds >= 2
	  AND CancelDate IS NULL
ORDER BY Price DESC