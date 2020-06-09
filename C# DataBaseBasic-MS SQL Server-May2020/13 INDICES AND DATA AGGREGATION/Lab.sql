-- Departments Total Salaries -- 13 from Exercises
SELECT DepartmentID, SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID