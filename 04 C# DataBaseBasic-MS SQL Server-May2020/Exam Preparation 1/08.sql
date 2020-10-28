SELECT FirstName, LastName, Age 
FROM Tickets AS t
RIGHT JOIN Passengers AS p ON t.PassengerId = p.Id
WHERE t.Id IS NULL
ORDER BY Age DESC, FirstName, LastName