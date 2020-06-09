-- 01. Records’ Count
SELECT COUNT(*) FROM WizzardDeposits

-- 02. Longest Magic Wand
SELECT MAX(MagicWandSize) FROM WizzardDeposits

-- 03. Longest Magic Wand per Deposit Groups
SELECT DepositGroup, MAX(MagicWandSize)
FROM WizzardDeposits
GROUP BY DepositGroup

-- 04. * Smallest Deposit Group per Magic Wand Size
SELECT TOP 2 DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

-- 05. Deposits Sum
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

--  06. Deposits Sum for Ollivander Family
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

-- 07. Deposits Filter
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

-- 08. Deposit Charge
SELECT DepositGroup, MagicWandCreator, 
MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

-- 09. Age Groups
SELECT AgeGroup, 
COUNT(*) AS WizardCount
FROM
(SELECT CASE
	WHEN Age >= 0 AND Age <= 10 THEN '[0-10]'
	WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
	WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
	WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
	WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
	WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
	WHEN Age >= 61  THEN '[61+]'
END AS AgeGroup
FROM WizzardDeposits) AS AgeGroups
GROUP BY AgeGroup

-- 10. First Letter
SELECT DISTINCT LEFT(FirstName, 1)
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'

-- 11. Average Interest 
SELECT DepositGroup, IsDepositExpired,
AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01-01-1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

-- 12. * Rich Wizard, Poor Wizard
SELECT SUM(Diff) AS SumDifference FROM
(SELECT *, DepositAmount - GuestDeposit AS Diff
FROM
(SELECT FirstName, DepositAmount,
LEAD(FirstName) OVER(ORDER BY Id) AS GuestWizzard,
LEAD(DepositAmount) OVER(ORDER BY Id) AS GuestDeposit
FROM WizzardDeposits) AS tmp) AS tmp2

--  14. Employees Minimum Salaries
SELECT DepartmentID,
MIN(Salary) AS MinSalary
FROM Employees
WHERE DepartmentID IN (2, 5, 7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID

-- 15. Employees Average Salaries
SELECT *
INTO Empl_With_Salary_More_30000
FROM Employees
WHERE Salary > 30000

DELETE FROM Empl_With_Salary_More_30000
WHERE ManagerID = 42

UPDATE Empl_With_Salary_More_30000
SET Salary = Salary + 5000
WHERE DepartmentId = 1

SELECT DepartmentID, AVG(Salary) AS AvgSalary
FROM Empl_With_Salary_More_30000
GROUP BY DepartmentID

-- 16. Employees Maximum Salaries
SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--  17.	Employees Count Salaries
SELECT COUNT(Salary) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

-- 18. *3rd Highest Salary
SELECT DISTINCT DepartmentID, Salary
FROM
(SELECT DepartmentID, Salary,
DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
FROM Employees) AS tmp
WHERE SalaryRank = 3

-- 19. **Salary Challenge
SELECT FirstName, LastName, e.DepartmentID, 
Salary, AvgSalary
FROM Employees AS e
JOIN (SELECT DepartmentID,
AVG(Salary) AS AvgSalary
FROM Employees
GROUP BY DepartmentID) AS tmp ON tmp.DepartmentID = e.DepartmentID
WHERE Salary > AvgSalary

SELECT DepartmentID,
AVG(Salary) AS AvgSalary
FROM Employees
GROUP BY DepartmentID


SELECT * FROM Employees