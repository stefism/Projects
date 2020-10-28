SELECT *
FROM Villains AS v
LEFT JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
LEFT JOIN Minions AS m ON mv.MinionId = m.Id

SELECT m.[Name], m.Age
FROM Villains AS v
LEFT JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
LEFT JOIN Minions AS m ON mv.MinionId = m.Id
WHERE v.Id = 8
ORDER BY m.[Name]

INSERT INTO Villains
VALUES
('MinionaProba', 3)

SELECT * FROM Villains