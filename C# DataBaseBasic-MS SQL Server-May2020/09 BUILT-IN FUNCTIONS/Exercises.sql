-- Part I – Queries for SoftUni Database
-- 01. Find Names of All Employees by First Name
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'Sa%'

-- 02. Find Names of All employees by Last Name 
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

-- 03. Find First Names of All Employees
