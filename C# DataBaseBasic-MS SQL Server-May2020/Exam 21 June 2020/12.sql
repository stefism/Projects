CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @targetRoom INT = (SELECT TOP 1 r.Id FROM Trips AS t
							   JOIN Rooms AS r ON t.RoomId = r.Id
							   JOIN Hotels AS h ON r.HotelId = h.Id
							   WHERE r.Id = @TargetRoomId)

	DECLARE @currTripId INT = (SELECT TOP 1 t.Id FROM Trips AS t
							   JOIN Rooms AS r ON t.RoomId = r.Id
							   JOIN Hotels AS h ON r.HotelId = h.Id
							   WHERE r.Id = @TargetRoomId)

	UPDATE Trips
	SET RoomId = @TargetRoomId
	WHERE Id = @TripId
GO



SELECT * FROM Trips AS t
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id


---
SELECT * FROM Trips AS t
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
WHERE r.Id = 11

SELECT * FROM Trips AS t
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
WHERE t.Id = 10