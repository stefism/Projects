CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3, 2))
RETURNS VARCHAR(200)
AS
BEGIN
	DECLARE @isStudentExist INT
	SET @isStudentExist = (SELECT COUNT(*) FROM Students
						   WHERE Id = @studentId)

	IF(@isStudentExist = 0)
	RETURN 'The student with provided id does not exist in the school!'

	IF(@grade > 6.00)
	RETURN 'Grade cannot be above 6.00!'

	DECLARE @studentName VARCHAR(50) = (SELECT TOP 1 FirstName
										FROM Students
										WHERE Id = @studentId)

	DECLARE @gradesToUpgrade INT = (SELECT COUNT(Grade)
							FROM
							(SELECT FirstName, ss.Grade
							FROM Students AS s
							JOIN StudentsSubjects AS ss 
							ON ss.StudentId = s.Id
							WHERE ss.Grade BETWEEN @grade 
							AND @grade + 0.50 AND s.Id = @studentId
							GROUP BY FirstName, ss.Grade) AS tmp
							WHERE Grade < 6.00)

	DECLARE @output VARCHAR(200) = CONCAT('You have to update ', @gradesToUpgrade, ' grades for the student ', @studentName)

	RETURN @output
END

GO

SELECT COUNT(Grade)
FROM
(SELECT FirstName, ss.Grade
FROM Students AS s
JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
WHERE ss.Grade BETWEEN 5.50 AND 6.00 AND s.Id = 12
GROUP BY FirstName, ss.Grade) AS tmp
WHERE Grade < 6.00


SELECT COUNT(*) FROM Students
