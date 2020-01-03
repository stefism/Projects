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
		   FROM Employees -- ������� ���� ���������� ���������.

SELECT * FROM Employees
WHERE DepartmentID = 1

SELECT * FROM Employees
WHERE Salary >= 30000 AND Salary <= 80000

-- ���
SELECT * FROM Employees
WHERE Salary BETWEEN 30000 AND 80000 -- ����� ������ ���� �������.

SELECT * FROM Employees
WHERE Salary = 30000 OR Salary = 80000

SELECT * FROM Employees
WHERE  NOT Salary BETWEEN 30000 AND 80000
-- ������ ����� �� � � ���� ��������.

SELECT * FROM Employees
WHERE DepartmentID IN (1, 2, 3)
-- ������ ��������� � ����������� 1, 2 � 3.

SELECT * FROM Employees
WHERE DepartmentID NOT IN (1, 2, 3)
-- ������ ����� �� � 1, 2 ��� 3.

-- ��������� �� ����.
CREATE VIEW v_EmployeesSalaryInfo AS
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
  FROM Employees

SELECT * FROM v_EmployeesSalaryInfo -- ���������� �� ����.

-- �������� �� ������ �� ���� ������� � �����.
INSERT INTO Projects (Name, StartDate)
SELECT Name, GETDATE() FROM Departments
-- ����� ������ ����� �� �������� Name �� Departments, ������ �� � �������� Name �� Projects, � �������� StartDate �� Projects ����� �������� ���� � GETDATE() � � �������.

SELECT * FROM Projects

SELECT FirstName, LastName, JobTitle
  INTO MyFireEmployees
  FROM Employees
-- ����� ������ ����� �� ���������� ������ ���������� ������������ �������, ����� ���� ������� � �������� ��� � ������ � ��� ������������.

SELECT * FROM dbo.MyFireEmployees mfe

-- ��������� �� ����������������.
CREATE SEQUENCE sq_MySequence
		 AS INT
	 START WITH 1
   INCREMENT BY 1

SELECT NEXT VALUE FOR sq_MySequence -- ����� ���� �� �� ��������� ��������������.

CREATE SEQUENCE sq_MySequence10_50Cycle
		 AS INT
	 START WITH 10
   INCREMENT BY 10
       MINVALUE 10
	   MAXVALUE 50
			 CYCLE
-- ��������� �� 10, ���� 10, � ���� ������ �� ���� ������ �� ����� ��� �� 10. ����� ����� ���� ���.

SELECT NEXT VALUE FOR sq_MySequence10_50Cycle

UPDATE Projects
   SET EndDate = GETDATE()
 WHERE EndDate IS NULL -- ! �� ����� "= NULL", � "IS NULL" ! ����� �� �� ������ � �� ������ ��������.
 -- ������� ��������� Projects � ��� ������ ��� ������ � ����, � ����� �� ��������� ����.
