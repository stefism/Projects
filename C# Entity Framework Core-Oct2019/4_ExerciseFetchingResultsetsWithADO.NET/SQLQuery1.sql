-- Task 2
SELECT v.[Name], COUNT(m.[Name]) AS MinionsCount
FROM Villains v
JOIN MinionsVillains mv 
ON v.Id = mv.VillainId
JOIN Minions m
ON mv.MinionId = m.Id
GROUP BY v.[Name]
HAVING COUNT(m.[Name]) > 3
ORDER BY MinionsCount DESC

--
SELECT *
FROM Villains v
JOIN MinionsVillains mv 
ON v.Id = mv.VillainId
JOIN Minions m
ON mv.MinionId = m.Id
