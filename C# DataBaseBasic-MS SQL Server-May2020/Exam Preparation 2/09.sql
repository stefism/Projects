SELECT 
CASE
WHEN MiddleName IS NULL THEN FirstName + ' ' + LastName
ELSE FirstName + ' ' + MiddleName + ' ' + LastName
END AS FullName
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
WHERE ss.SubjectId IS NULL
ORDER BY FullName
