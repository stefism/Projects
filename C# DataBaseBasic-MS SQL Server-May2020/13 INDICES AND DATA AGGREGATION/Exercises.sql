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

-- ??? 09. Age Groups ???
SELECT '[11-20]' AS AgeGroup,
COUNT(*) AS WizardCount
FROM WizzardDeposits WHERE Age >= 11 AND Age <= 20
---






SELECT * FROM WizzardDeposits