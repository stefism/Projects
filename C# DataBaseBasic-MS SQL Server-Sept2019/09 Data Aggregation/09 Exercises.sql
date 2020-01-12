SELECT * FROM WizzardDeposits

-- *** Exercises: Data Aggregation
-- 1. Records’ Count
SELECT COUNT(Id) AS [Count]
FROM WizzardDeposits

-- 2. Longest Magic Wand
SELECT MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits

-- 3. Longest Magic Wand per Deposit Groups
SELECT DepositGroup,
MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup

SELECT * FROM WizzardDeposits

-- 4. * Smallest Deposit Group per Magic Wand Size
-- a).
SELECT TOP(2) DepositGroup FROM
(SELECT DepositGroup,
AVG(MagicWandSize) AS Proba
FROM WizzardDeposits wd
GROUP BY DepositGroup) AS TEMP
ORDER BY Proba

-- b).
SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize) -- Може да се подрежда и по агрегиращи функции.

-- 5. Deposits Sum
SELECT DepositGroup,
SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

SELECT * FROM WizzardDeposits

-- 6. Deposits Sum for Ollivander Family
SELECT DepositGroup,
SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits wd
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

-- 7. Deposits Filter
SELECT DepositGroup,
SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits wd
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

-- 8. Deposit Charge
SELECT * FROM WizzardDeposits

SELECT DepositGroup, MagicWandCreator,
MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

-- 9. Age Groups
SELECT 
	CASE
	WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	ELSE '[61+]'
	END AS AgeGroup, Count(Id) AS WizardCount
FROM WizzardDeposits
GROUP BY 
CASE
	WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	ELSE '[61+]'
END -- Сюрюйозно??? Яко!

-- 10. First Letter
SELECT DISTINCT LEFT(FirstName, 1) AS [FirstLetter]
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY FirstName
ORDER BY FirstLetter

-- 11. Average Interest
SELECT * FROM WizzardDeposits

SELECT DepositGroup, IsDepositExpired,
AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

-- 12. * Rich Wizard, Poor Wizard
SELECT * FROM WizzardDeposits
-- LEAD - Избутва или взима следващата по ред стойност в колоната, като му се казва по какво да определи коя е следващата стойност в колоната OVER(ORDER BY Id) - в случая по Id.
SELECT SUM([Difference]) AS [SumDifference] 
FROM (SELECT FirstName AS [Host Wizard],
	   DepositAmount AS [Host Wizard Deposit],
	   LEAD(FirstName) OVER(ORDER BY Id) AS [Guest Wizard],
	   LEAD(DepositAmount) OVER(ORDER BY Id) AS [Guest Wizard Deposit],
	   DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id) AS [Difference]
FROM WizzardDeposits) AS YakataRabota

-- 13. Departments Total Salaries
SELECT DepartmentID, SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

-- 14. Employees Minimum Salaries
SELECT DepartmentID, MIN(Salary) AS MinimumSalary
FROM Employees
WHERE DepartmentID IN (2, 5, 7) AND HireDate > '01/01/2000'
GROUP BY DepartmentID

-- 15. Employees Average Salaries
SELECT * 
INTO EmpOver30000
FROM Employees 
WHERE Salary > 30000

DELETE FROM EmpOver30000
WHERE ManagerID = 42

UPDATE EmpOver30000
SET SALARY += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM EmpOver30000
GROUP BY DepartmentID

-- 16. Employees Maximum Salaries
SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) < 30000 OR MAX(Salary) > 70000

-- 17. Employees Count Salaries
SELECT COUNT(EmployeeID) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

-- 18. *3rd Highest Salary
SELECT DISTINCT DepartmentID, ThirdHighestSalary 
FROM (SELECT DepartmentID,
DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS RankSalary,
Salary AS ThirdHighestSalary
FROM Employees) AS tempTable
WHERE RankSalary = 3

-- 19. **Salary Challenge
SELECT TOP(10) FirstName, LastName, DepartmentID
FROM Employees AS e1
WHERE Salary > (
				SELECT
				AVG(Salary) AS [AvgSalary]
				FROM Employees AS e2
				WHERE e2.DepartmentID = e1.DepartmentID -- Е без тоя ред не работи.
				GROUP BY DepartmentID
				)
ORDER BY e1.DepartmentID
