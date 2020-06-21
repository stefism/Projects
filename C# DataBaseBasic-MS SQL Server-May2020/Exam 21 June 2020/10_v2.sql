select t.Id, CASE
				WHEN a.MiddleName IS NULL THEN a.FirstName + ' ' + a.LastName
				WHEN a.MiddleName IS NOT NULL THEN a.FirstName + ' ' + a.MiddleName + ' ' + a.LastName
					END as FullName,
			ac.Name as 'From', c.Name as 'To',
	(SELECT CASE
		 WHEN trip.CancelDate IS NOT NULL THEN 'Canceled'
		 WHEN trip.CancelDate IS NULL THEN CAST(DATEDIFF(day, trip.ArrivalDate, trip.ReturnDate) AS nvarchar(MAX)) + ' days'
			END AS Duration
		 FROM Trips as trip
	WHERE trip.Id = t.Id) as Duration
	from Trips as t
JOIN Rooms as r on t.RoomId = r.Id
JOIN Hotels as h on r.HotelId = h.Id
JOIN Cities as c on h.CityId = c.Id
JOIN AccountsTrips as at on t.Id = at.TripId
JOIN Accounts as a on at.AccountId = a.Id
JOIN Cities as ac on a.CityId = ac.Id
ORDER BY FullName, t.Id