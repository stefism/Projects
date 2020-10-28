SELECT * FROM Mountains
SELECT * FROM Peaks


-- Peaks in Rila. 
-- Use database "Geography". Report all peaks for "Rila" mountain. Report includes mountain's name, peak's name and also peak's elevation. Peaks should be sorted by elevation descending.

-- (1)
SELECT m.MountainRange, p.PeakName, p.Elevation 
FROM Peaks AS p
JOIN Mountains AS m ON m.Id = p.MountainId
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC

-- (2)
SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m
JOIN Peaks As p ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC
