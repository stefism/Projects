SELECT TOP 10 FirstName, LastName, 
CAST(AVG(Grade) AS DECIMAL(3,2)) AS [Average Grade]
FROM Students AS s
JOIN StudentsExams AS se ON se.StudentId = s.Id
GROUP BY FirstName, LastName
ORDER BY [Average Grade] DESC, FirstName, LastName