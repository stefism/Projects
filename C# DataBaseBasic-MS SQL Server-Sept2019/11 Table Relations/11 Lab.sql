-- Peaks in Rila.
-- Use database "Geography". Report all peaks for "Rila" mountain. Report includes mountain's name, peak's name and also peak's elevation. Peaks should be sorted by elevation descending.

SELECT MountainRange, PeakName, Elevation
FROM Mountains m
JOIN Peaks p ON p.MountainId = m.Id
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC