SELECT * FROM Reports

SELECT [Description],
FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate1
FROM Reports
WHERE EmployeeID IS NULL
ORDER BY OpenDate, [Description]