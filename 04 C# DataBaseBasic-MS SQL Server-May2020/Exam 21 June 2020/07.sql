SELECT * FROM Accounts AS a
JOIN AccountsTrips AS ac ON ac.AccountId = a.Id
JOIN Trips AS t ON ac.TripId = t.Id


SELECT 
a.Id
, a.FirstName + ' ' + a.LastName AS FullName
, DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS [LongestTrip]
, DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS [ShortestTrip]
FROM Accounts AS a
JOIN AccountsTrips AS ac ON ac.AccountId = a.Id
JOIN Trips AS t ON ac.TripId = t.Id


SELECT * FROM
(SELECT *
, DENSE_RANK() OVER(PARTITION BY FullName ORDER BY LongestTrip) AS [LongestRank]
, DENSE_RANK() OVER(PARTITION BY FullName ORDER BY ShortestTrip) AS [ShortestRank]
FROM
(SELECT
a.Id,
a.FirstName + ' ' + a.LastName AS FullName,
DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS [LongestTrip],
DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS [ShortestTrip]
FROM Accounts AS a
JOIN AccountsTrips AS ac ON ac.AccountId = a.Id
JOIN Trips AS t ON ac.TripId = t.Id
GROUP BY a.Id, a.FirstName + ' ' + a.LastName, 
DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS tmp) AS tmp2
WHERE LongestRank = MAX(LongestRank) OR ShortestRank = MIN(ShortestRank)