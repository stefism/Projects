CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
	DECLARE @isStudentExist INT
	SET @isStudentExist = (SELECT COUNT(*) FROM Students
						   WHERE Id = @studentId)

	IF(@isStudentExist = 0)
	THROW 50001, 'This school has no student with the provided id!', 1

	DELETE FROM StudentsTeachers
	WHERE StudentId = @studentId

	DELETE FROM StudentsExams
	WHERE StudentId = @studentId

	DELETE FROM StudentsSubjects
	WHERE StudentId = @studentId

	DELETE FROM Students
	WHERE Id = @studentId

GO

EXEC usp_ExcludeFromSchool 301

SELECT COUNT(*) FROM Students