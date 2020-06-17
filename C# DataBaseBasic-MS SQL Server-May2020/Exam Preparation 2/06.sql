SELECT s.FirstName AS [Student First Name], 
s.LastName AS [Student Last Name], 
COUNT(t.Id) AS TeachersCount
FROM Students AS s
JOIN StudentsTeachers AS st ON st.StudentId = s.Id
JOIN Teachers AS t ON st.TeacherId = t.Id
GROUP BY s.FirstName, s.LastName