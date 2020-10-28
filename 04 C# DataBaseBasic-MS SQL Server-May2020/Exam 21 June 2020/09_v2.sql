select a.Id, a.Email, c.Name as City, COUNT(c.Name) as 'Trips' from Trips as t
JOIN Rooms as r on t.RoomId = r.Id
JOIN Hotels as h on r.HotelId = h.Id
JOIN Cities as c on h.CityId = c.Id
JOIN AccountsTrips as at on t.Id = at.TripId
JOIN Accounts as a on at.AccountId = a.Id
WHERE a.CityId = h.CityId
GROUP BY c.Name, a.id, a.Email
ORDER BY 'Trips' DESC, a.Id