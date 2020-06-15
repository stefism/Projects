CREATE FUNCTION udf_CreateDiffInWeeks(@StartDate datetime2, @EndDate datetime2)
RETURNS int
AS
BEGIN
	IF (@EndDate IS NULL)
		SET @EndDate = GETDATE()

	RETURN DATEDIFF(WEEK, @StartDate, @EndDate)
END

GO
SELECT *,
dbo.udf_CreateDiffInWeeks(StartDate, EndDate) AS Weeks
FROM Projects
