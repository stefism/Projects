SELECT CONCAT_WS(',', FirstName, MiddleName, LastName) AS [Full Name]
FROM Employees
-- Първо се слага разделителя и събира колоните като използва този разделител. Където има NULL го заменя с разделителя?

SELECT CONCAT_WS('. ', SUBSTRING(FirstName, 1, 1),
SUBSTRING(LastName, 1, 1)) FROM Employees
-- SUBSTRING - име на колона, от кой индекс да почне, колко знака да вземе от стринга. Тука индексите почват не от нула, а от едно. Както се вижда от примера, функциите могат да се влагат една в друга.

SELECT REPLACE('Target work text', 'work', 'worked') AS [Test Column]

SELECT REPLACE(FirstName, 'Roberto', 'Rob') AS [Test Column]
FROM Employees
-- Име на колона, какво ще замества, с какво ще го замести. Накрая FROM - от коя таблица. CaseInsensitive? Not work for NULL or empty string.

SELECT LTRIM('  Test  ') -- Премахма интервали от ляво.

SELECT RTRIM('  Test  ') -- Премахма интервали от дясно.

SELECT TRIM('  Test  ') -- Премахма интервали от секъде.

SELECT LEN('How many character is here.') --  Показва колко символа има в текста.

SELECT LEFT('Very long string', 4) -- Result - Very

SELECT RIGHT('Very long string', 6) -- Result - string

SELECT FirstName, LastName, LEFT(FirstName, 3) AS [Short Name]
FROM Employees

-- Demo Database - Customers
-- Our database contains credit card details for customers. Provide a summary without revealing the serial numbers.

-- Change
-- ID FirstName LastName PaymentNumber
-- 1  Guy		Gilbert	 5645322227179083
-- With
-- ID FirstName LastName PaymentNumber
-- 1  Guy		Gilbert	 564532***********

SELECT FirstName, LastName,
CONCAT(LEFT(PaymentNumber, 6), +
REPLACE(PaymentNumber, (RIGHT(PaymentNumber, 16)), '********'))
AS [PaymentNUmber]
FROM Customers
-- При конката има запетайка между стойностите преди плюса!

SELECT CustomerID, FirstName, LastName, LEFT(PaymentNumber, 6) + '*********'
AS [PaymentNumber]
FROM Customers
-- Прави същото като горното но по по-лесен начин. Директно прави и конкатенация по този начин.
-- Може и директно да конкатенираш при селекта горе един вид.

-- Още един вариант на горното
GO
CREATE VIEW v_PublicPaymentsInfo AS
SELECT CustomerID, FirstName, LastName,
CONCAT(SUBSTRING(PaymentNumber, 1, 6), 
REPLICATE('*', LEN(PaymentNumber) - 6))
AS [Payment Number] FROM Customers
GO

SELECT * FROM v_PublicPaymentsInfo

-- Change letter casing
SELECT LOWER('String')
SELECT UPPER('String')
SELECT REVERSE('Дебел лебед')

-- CHARINDEX - located a specific pattern (substring) in a string
-- CHARINDEX(Pattern, String, [StartIndex])

SELECT CHARINDEX('is', 'This is a long text')
-- Връща число. Началния индекс от който започва търсения стринг. Ако не укажем старт индекс, започва да търси от първия. Индексите тука започват от едно, а не от нула.

-- STUFF – inserts a substring at a specific position
-- STUFF(String, StartIndex, Length, Substring)
SELECT STUFF('This is a good idea', 11, 0, 'very ') 
-- Result -> This is a very good idea.

SELECT STUFF('This is a good idea', 11, 4, 'wonderfull')
-- Пред последния параметър - Length указва колко символа от стринга да бъдат изтрити.
-- Резултата от това нещо ще бъде 'This is a wonderfull idea'.

-- FORMAT ( value, format [, culture ] )
SELECT FORMAT(67.23, 'C', 'bg-BG') -- Форматира числови стойности (например дата) по определен начин и за определена култура, като синтаксиса е същия както в .NET. В случая 'C' -> currency (валута), за бг.

SELECT FORMAT(CAST('2020-01-04' AS DATE), 'D', 'bg-BG')
-- Result -> '04 Януари 2020 г.'

-- TRANSLATE (inputString, characters, translations)
SELECT TRANSLATE('проба', 'абвгдежзийклмнопрстуфхч',
'abvgdejziiklmnoprstufhc') --> proba

-- Math Functions
SELECT * FROM Triangles2
-- Example: find the area of triangles by the given side and height
SELECT Id, (A*H)/2 AS Area FROM Triangles2

SELECT PI() --> 3.14159265358979
SELECT ABS(-12) --> 12
SELECT SQRT(16) -- корен квадратен. Резултат -> 4.
SELECT SQUARE(4) -- степенуване на втора. Рзултат -> 16.

-- POWER(Value, Exponent)
SELECT POWER(4, 3) -- 4 на трета --> 64

SELECT * FROM dbo.Products p

-- Calculate the required number of pallets to ship each item
SELECT *,  CEILING((CAST(Quantity AS FLOAT)/BoxCapacity)/PalletCapacity) 
AS [Number of pallets]
FROM Products
-- Интовете трябва и тука да се кастват, в случая към FLOAT за да хваща след десетичната точка.
SELECT FLOOR(10/6)
SELECT CEILING(10/6)
SELECT RAND() * 6.3

-- Date function
SELECT DATEPART(DAY, '2019-01-21') --> 21
SELECT DATEPART(WEEKDAY, '2020-01-04') - 1 -- дава деня от седмицата но брои неделята като първи ден.

USE Orders
SELECT * FROM Orders

GO
--CREATE VIEW v_PartOfYearFromOrdersInOrders AS
SELECT Id, ProductName, OrderDate,
DATEPART(QUARTER, OrderDate) AS [Quarter], -- QUARTER-а неможе сам. Трябва да е в DATEPART-а.
MONTH(OrderDate) AS [Month], -- Може и така с тези за по-кратко.
DATEPART(YEAR, OrderDate) AS [Year],
DATEPART(DAY, OrderDate) AS [Day],
CASE
	WHEN DATEPART(WEEKDAY, OrderDate) = 1 THEN 'Sunday'
	WHEN DATEPART(WEEKDAY, OrderDate) = 2 THEN 'Monday'
	WHEN DATEPART(WEEKDAY, OrderDate) = 3 THEN 'Tuesday'
	WHEN DATEPART(WEEKDAY, OrderDate) = 4 THEN 'Wednesday'
	WHEN DATEPART(WEEKDAY, OrderDate) = 5 THEN 'Thursday'
	WHEN DATEPART(WEEKDAY, OrderDate) = 6 THEN 'Friday'
	WHEN DATEPART(WEEKDAY, OrderDate) = 7 THEN 'Saturday'
END AS [Day of week]
FROM Orders

SELECT * FROM v_PartOfYearFromOrdersInOrders

-- DATEDIFF(Part, FirstDate, SecondDate) - Разлика между две дати. Part указва като какво да се покаже разликата. Може в години, месеци, секунди и т.н.
SELECT LEFT(DATEDIFF(MONTH, '2001-10-10', '2020-07-08') / 12.0, 4)
AS [Year in Service] --> 18.7

SELECT DATENAME(WEEKDAY, GETDATE()) --> Saturday (текущия ден)

SELECT FORMAT(GETDATE(), 'dddd', 'bg-BG') --> събота (текущия ден)

-- Other Functions
-- CAST(Data AS NewType)
-- CONVERT(NewType, Data)

USE SoftUni
SELECT * FROM dbo.Employees e

-- ISNULL - swaps NULL values with a specified default value. Има го само в Майкрософт sql.
SELECT FirstName, EmployeeID,
	   ISNULL(MiddleName, 'No Middle name') AS [Middle name]
	   FROM Employees

SELECT FirstName, EmployeeID,
	   COALESCE(MiddleName, 'No Middle name') AS [Middle name]
	   FROM Employees
-- COALESCE - държи се по същия начин.

-- OFFSET & FETCH – get only specific rows from the result set
-- Използват се задължително с ORDER BY. OFFSET е еквивалент на SKIP (пропусни) в C#, а FETCH на TAKE (вземи).

  SELECT EmployeeID, FirstName, LastName 
    FROM Employees
ORDER BY EmployeeID
OFFSET 10 ROWS
FETCH NEXT 5 ROWS ONLY

-- ROW_NUMBER – always generate unique values without any gaps, even if there are ties. Винаги генерира уникални стойности без никакви пропуски, дори ако има връзки.
SELECT EmployeeID, FirstName, LastName,
ROW_NUMBER() OVER (ORDER BY FirstName) AS [Row Number]
FROM Employees