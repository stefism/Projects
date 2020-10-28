CREATE OR ALTER FUNCTION udf_GetEmployeesByYear(@Year int)
RETURNS TABLE
AS
RETURN
(
	SELECT *
	FROM Employees
	WHERE DATEPART(YEAR, HireDate) = @Year
)

GO
SELECT * FROM dbo.udf_GetEmployeesByYear(2000)