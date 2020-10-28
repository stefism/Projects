SELECT 
a.Id
, a.Email
, c.[Name] AS [CityName]
, COUNT(h.CityId) AS CountTrips
--, h.[Name] AS HotelName
--, h.CityId AS HotelCityId
FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
JOIN AccountsTrips AS atr ON atr.AccountID = a.Id
JOIN Trips AS t ON atr.TripId = t.Id
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
WHERE c.Id = h.CityId
GROUP BY a.Id, a.Email, c.[Name]
ORDER BY COUNT(h.CityId) DESC, a.Id