SELECT  *
--Id, [Name], CONCAT(Size, 'KB') AS Size
FROM Files
WHERE Id = CommitId
ORDER BY Id, [Name], Size DESC
---
SELECT --*
f1.Id, f1.[Name], CONCAT(f1.Size, 'KB') AS Size
FROM Files AS f1 -- 16 се набутва
LEFT JOIN Files AS f2 ON f2.ParentId = f1.Id
WHERE f2.Id IS NULL
----

SELECT *
--f1.Id, f1.[Name], CONCAT(f1.Size, 'KB') AS Size
FROM Files AS f1 -- 16 се набутва
LEFT JOIN Files AS f2 ON f2.ParentId = f1.Id
--WHERE f2.Id IS NULL

