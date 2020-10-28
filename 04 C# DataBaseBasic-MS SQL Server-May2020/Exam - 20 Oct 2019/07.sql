SELECT TOP 5
c.[Name]
, COUNT(r.CategoryId) AS ReportsNumber
FROM Reports AS r
JOIN Categories AS c ON r.CategoryId = c.Id
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC, c.[Name]

----
SELECT TOP 5 
[Name],
(SELECT COUNT(*) FROM Reports WHERE CategoryId = c.Id) AS ReportsNumber
FROM Categories AS c
ORDER BY ReportsNumber DESC, [Name]

---
SELECT  
*,
(SELECT COUNT(*) FROM Reports WHERE CategoryId = c.Id) AS ReportsNumber
FROM Categories AS c
ORDER BY ReportsNumber DESC, [Name]