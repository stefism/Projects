CREATE OR ALTER FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATETIME2, @People INT) 
RETURNS nvarchar(MAX)
AS   

BEGIN  
	DECLARE @result NVARCHAR(100)
	DECLARE @availableRoom TABLE (RoomId INT, RoomType NVARCHAR(20), Beds INT, RateAndPrice DECIMAL(10,2), Arrive DATETIME2, ReturnHome DATETIME2)
			INSERT INTO @availableRoom (RoomId, RoomType, Beds, RateAndPrice, Arrive, ReturnHome)
					  SELECT r.Id, r.[Type], r.Beds,(h.BaseRate + r.Price), t.ArrivalDate, t.ReturnDate AS RateAndPrice FROM Rooms AS r
					  JOIN Hotels AS h ON r.HotelId = h.Id
					  JOIN Trips AS t ON r.Id = t.RoomId
					  WHERE h.Id = @HotelId
					  AND t.CancelDate IS NULL
					  AND r.Beds >= @People
	
	IF(NOT EXISTS(SELECT 1 FROM @availableRoom))
		BEGIN
			SET @result = 'No rooms available'
		END
	ELSE IF (EXISTS(SELECT TOP 1 RoomId FROM @availableRoom WHERE @Date >= Arrive AND @Date <= ReturnHome))
		BEGIN
			SET @result = 'No rooms available'
		END
	ELSE
	BEGIN
		DECLARE @roomId INT = (SELECT TOP 1 RoomId FROM @availableRoom ORDER BY RateAndPrice DESC)
		DECLARE @RoomType NVARCHAR(20) = (SELECT TOP 1 RoomType FROM @availableRoom ORDER BY RateAndPrice DESC)
		DECLARE @Beds INT = (SELECT TOP 1 Beds FROM @availableRoom ORDER BY RateAndPrice DESC)
		DECLARE @TotalPrice DECIMAL(10,2) = (SELECT TOP 1 RateAndPrice FROM @availableRoom ORDER BY RateAndPrice DESC) * @People
		SET @result = 'Room ' + CAST(@roomId AS NVARCHAR(MAX)) + ': ' + @RoomType + ' (' + CAST(@Beds AS NVARCHAR(MAX)) + ' beds) - $' + CAST(@TotalPrice AS NVARCHAR(MAX))
	END
	RETURN @result
END

SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

