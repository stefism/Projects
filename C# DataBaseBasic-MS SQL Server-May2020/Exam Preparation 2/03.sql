SELECT * FROM StudentsSubjects
WHERE SubjectId IN (1 ,2) AND Grade >= 5.50
---

UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN (1 ,2) AND Grade >= 5.50
---

SELECT * FROM StudentsExams