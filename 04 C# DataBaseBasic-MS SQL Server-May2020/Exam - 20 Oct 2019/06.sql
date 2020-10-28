SELECT * FROM Reports

SELECT CategoryId, [Description]
FROM Reports
GROUP BY CategoryId, [Description]
ORDER BY [Description], CategoryId

SELECT [Description], [Name]
FROM Reports AS r
JOIN Categories AS c ON r.CategoryId = c.Id
ORDER BY [Description], [Name]