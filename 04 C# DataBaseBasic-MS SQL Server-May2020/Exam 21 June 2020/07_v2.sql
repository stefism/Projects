SELECT a.Id AS AccountId, (a.FirstName + ' ' + a.LastName) AS FullName,
						  MAX(DATEDIFF(day, t.ArrivalDate, t.ReturnDate)) AS LongestTrip,
						  MIN(DATEDIFF(day, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip FROM Trips as t
JOIN AccountsTrips AS at ON t.Id = at.TripId
JOIN Accounts as a ON a.Id = at.AccountId
WHERE t.CancelDate IS NULL
AND a.MiddleName IS NULL
GROUP BY a.Id, a.FirstName, a.LastName
ORDER BY LongestTrip DESC, ShortestTrip