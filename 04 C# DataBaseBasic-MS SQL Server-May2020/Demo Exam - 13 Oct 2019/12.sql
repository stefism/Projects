CREATE PROC usp_FindByExtension(@extension VARCHAR(10))
AS
	SELECT Id, 
	[Name],
	CONCAT(Size, 'KB') AS Size
	FROM Files
	WHERE [Name] LIKE '%.' + @extension
	ORDER BY Id, [Name], Size
GO

EXEC usp_FindByExtension 'txt'