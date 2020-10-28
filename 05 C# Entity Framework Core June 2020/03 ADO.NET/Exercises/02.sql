-- 02 Villain Names
SELECT v.[Name],
COUNT(m.[Name]) AS MCount
FROM Villains AS v
JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
JOIN Minions AS m ON mv.MinionId = m.Id
GROUP BY v.[Name]
ORDER BY MCount DESC

SELECT *
FROM Villains AS v
LEFT JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
LEFT JOIN Minions AS m ON mv.MinionId = m.Id