-- Employee Summary
-- Find information about all employees, listing their full name, job title and salary
SELECT FirstName + ' ' + LastName AS [Full Name], JobTitle, Salary 
FROM Employees

SELECT DISTINCT JobTitle FROM Employees
-- DISTINCT - дава уникалните стойности в колоната. Връща стойностите сортирани по азбучен ред.

SELECT COUNT(DISTINCT JobTitle) FROM Employees
-- дава уникалните стойности в колоната като число

SELECT DISTINCT JobTitle, 
(SELECT COUNT(*) FROM Employees AS e2 WHERE e2.JobTitle = e1.JobTitle) AS [Count]
FROM Employees AS e1
-- Дава имената на професиите (JobTitle) и колко пъти се срещя всяка

SELECT JobTitle, COUNT(*) AS [Count]
FROM Employees
GROUP By JobTitle
-- Прави същото като горното (правилен начин)

SELECT JobTitle, MAX(Salary) AS MaxSalary, MIN(Salary) AS MinSalary, COUNT(*) AS [Count]
FROM Employees
GROUP BY JobTitle
-- MAX, MIN, AVG - агрегиращи функции. Работят само в комбинация GROUP BY 

---
-- Вюта или запаметяване на заявки. --
CREATE VIEW v_GetHireDateAndDayOfWeek AS
SELECT HireDate, DATENAME(dw, HireDate) AS [DayOfWeek]
FROM Employees
-- За да се направи вю, всички колони трябва да имат име.

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
