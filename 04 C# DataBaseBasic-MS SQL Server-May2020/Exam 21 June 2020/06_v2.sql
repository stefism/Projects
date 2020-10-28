SELECT c.Name, COUNT(c.Name) as Hotels FROM Cities as c
RIGHT JOIN Hotels as h on c.Id = h.CityId
GROUP BY c.Name
ORDER BY Hotels DESC, c.Name