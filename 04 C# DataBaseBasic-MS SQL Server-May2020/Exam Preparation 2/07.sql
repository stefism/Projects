SELECT 
s.FirstName + ' ' + s.LastName AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsExams AS se ON se.StudentId = s.Id
LEFT JOIN Exams AS e ON se.ExamId = e.Id
LEFT JOIN Subjects AS sb ON e.SubjectId = sb.Id
WHERE sb.Lessons IS NULL
ORDER BY [Full Name]
