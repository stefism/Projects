SELECT * FROM Villains -- 11

SELECT * FROM MinionsVillains

DELETE FROM MinionsVillains
WHERE VillainId = 11

DELETE FROM Villains
WHERE Id = 11


SELECT
COUNT(m.[Name]) AS MCount
FROM Villains AS v
LEFT JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
LEFT JOIN Minions AS m ON mv.MinionId = m.Id
WHERE v.[Name] = 'Dobromir'
--GROUP BY v.[Name]
--ORDER BY MCount DESC