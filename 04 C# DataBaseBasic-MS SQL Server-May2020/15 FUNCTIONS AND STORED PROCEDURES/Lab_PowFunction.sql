-- кустом функция за вдигане на степен
CREATE OR ALTER FUNCTION udf_Pow(@Number int, @Power int)
RETURNS bigint
AS
BEGIN
	DECLARE @result bigint = 1
	
	WHILE(@Power > 0)
	BEGIN
	SET @result = @result * @Number
	SET @Power = @Power - 1
	END
	
	RETURN @result
END

GO
SELECT dbo.udf_Pow(2, 10)