SELECT 
a.FirstName + ' ' + ISNULL(a.MiddleName, '') + ' ' + a.LastName AS FullName
, c.[Name] AS [From-AccountCityName]
, c.Id AS AccountCItyId
FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
JOIN AccountsTrips AS atr ON atr.AccountId = a.Id
JOIN Trips AS t ON atr.TripId = t.Id
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id


ORDER BY FullName
