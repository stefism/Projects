SELECT d.Name AS DepartmentName FROM Departments AS d

SELECT *
  FROM Employees

SELECT FirstName, LastName
  FROM Employees

SELECT FirstName + ' ' + LastName AS [Full Name]
  FROM Employees

SELECT FirstName + ' ' + LastName AS [Full Name], JobTitle, Salary
  FROM Employees

SELECT DISTINCT DepartmentID
		   FROM Employees -- Изкарва само уникалните стойности.

SELECT * FROM Employees
WHERE DepartmentID = 1

SELECT * FROM Employees
WHERE Salary >= 30000 AND Salary <= 80000

-- Или
SELECT * FROM Employees
WHERE Salary BETWEEN 30000 AND 80000 -- Прави същото като горното.

SELECT * FROM Employees
WHERE Salary = 30000 OR Salary = 80000

SELECT * FROM Employees
WHERE  NOT Salary BETWEEN 30000 AND 80000
-- Всичко което не е в този интервал.

SELECT * FROM Employees
WHERE DepartmentID IN (1, 2, 3)
-- Всички служители в департамент 1, 2 и 3.

SELECT * FROM Employees
WHERE DepartmentID NOT IN (1, 2, 3)
-- Всичко което не е 1, 2 или 3.

-- Създаване на вюта.
CREATE VIEW v_EmployeesSalaryInfo AS
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
  FROM Employees

SELECT * FROM v_EmployeesSalaryInfo -- Използване на вюто.

-- Вмъкване на редове от една таблица в друга.
INSERT INTO Projects (Name, StartDate)
SELECT Name, GETDATE() FROM Departments
-- Взима всички имена от колоната Name от Departments, вмъква ги в колоната Name на Projects, в колоната StartDate на Projects взима днешната дата с GETDATE() и я поставя.

SELECT * FROM Projects

SELECT FirstName, LastName, JobTitle
  INTO MyFireEmployees
  FROM Employees
-- Взима всички данни от въпросните колони зададената съществуваща таблица, прави нова таблица с даденото име и налива в нея информацията.

SELECT * FROM dbo.MyFireEmployees mfe

-- Създаване на последователност.
CREATE SEQUENCE sq_MySequence
		 AS INT
	 START WITH 1
   INCREMENT BY 1

SELECT NEXT VALUE FOR sq_MySequence -- После може да се селектира последователно.

CREATE SEQUENCE sq_MySequence10_50Cycle
		 AS INT
	 START WITH 10
   INCREMENT BY 10
       MINVALUE 10
	   MAXVALUE 50
			 CYCLE
-- Страртира от 10, през 10, и като стигне до макс валюто се връща пак на 10. Прави цикъл един вид.

SELECT NEXT VALUE FOR sq_MySequence10_50Cycle

UPDATE Projects
   SET EndDate = GETDATE()
 WHERE EndDate IS NULL -- ! Не равно "= NULL", а "IS NULL" ! Иначе не ги намира и не работи правилно.
 -- Променя таблицата Projects и там където енд датата е нулл, я слага на сегащната дата.
