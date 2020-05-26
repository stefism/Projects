-- Employee Summary
-- Find information about all employees, listing their full name, job title and salary
SELECT FirstName + ' ' + LastName AS [Full Name], JobTitle, Salary 
FROM Employees

SELECT DISTINCT JobTitle FROM Employees
-- DISTINCT - ���� ���������� ��������� � ��������. ����� ����������� ��������� �� ������� ���.

SELECT COUNT(DISTINCT JobTitle) FROM Employees
-- ���� ���������� ��������� � �������� ���� �����

SELECT DISTINCT JobTitle, 
(SELECT COUNT(*) FROM Employees AS e2 WHERE e2.JobTitle = e1.JobTitle) AS [Count]
FROM Employees AS e1
-- ���� ������� �� ���������� (JobTitle) � ����� ���� �� ����� �����

SELECT JobTitle, COUNT(*) AS [Count]
FROM Employees
GROUP By JobTitle
-- ����� ������ ���� ������� (�������� �����)

SELECT JobTitle, MAX(Salary) AS MaxSalary, MIN(Salary) AS MinSalary, COUNT(*) AS [Count]
FROM Employees
GROUP BY JobTitle
-- MAX, MIN, AVG - ���������� �������. ������� ���� � ���������� GROUP BY 

---
-- ���� ��� ������������ �� ������. --
CREATE VIEW v_GetHireDateAndDayOfWeek AS
SELECT HireDate, DATENAME(dw, HireDate) AS [DayOfWeek]
FROM Employees
-- �� �� �� ������� ��, ������ ������ ������ �� ���� ���.

-- Create a view that selects all information about the highest peak from Geography database
CREATE VIEW v_HighestPeak AS
SELECT TOP 1 *
FROM Peaks
ORDER BY Elevation DESC

-- Using existing records to create a new table:
SELECT FirstName + ' ' + LastName AS FullName, Salary
INTO Names
FROM Employees

-- Mark all unfinished Projects as being completed today
SELECT * FROM Projects

UPDATE Projects
SET EndDate = GETDATE()
WHERE EndDate IS NULL
