SELECT CONCAT_WS(',', FirstName, MiddleName, LastName) AS [Full Name]
FROM Employees
-- ����� �� ����� ����������� � ������ �������� ���� �������� ���� ����������. ������ ��� NULL �� ������ � �����������?

SELECT CONCAT_WS('. ', SUBSTRING(FirstName, 1, 1),
SUBSTRING(LastName, 1, 1)) FROM Employees
-- SUBSTRING - ��� �� ������, �� ��� ������ �� �����, ����� ����� �� ����� �� �������. ���� ��������� ������ �� �� ����, � �� ����. ����� �� ����� �� �������, ��������� ����� �� �� ������ ���� � �����.

SELECT REPLACE('Target work text', 'work', 'worked') AS [Test Column]

SELECT REPLACE(FirstName, 'Roberto', 'Rob') AS [Test Column]
FROM Employees
-- ��� �� ������, ����� �� ��������, � ����� �� �� �������. ������ FROM - �� ��� �������. CaseInsensitive? Not work for NULL or empty string.

SELECT LTRIM('  Test  ') -- �������� ��������� �� ����.

SELECT RTRIM('  Test  ') -- �������� ��������� �� �����.

SELECT TRIM('  Test  ') -- �������� ��������� �� ������.

SELECT LEN('How many character is here.') --  ������� ����� ������� ��� � ������.

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
-- ��� ������� ��� ��������� ����� ����������� ����� �����!

SELECT CustomerID, FirstName, LastName, LEFT(PaymentNumber, 6) + '*********'
AS [PaymentNumber]
FROM Customers
-- ����� ������ ���� ������� �� �� ��-����� �����. �������� ����� � ������������ �� ���� �����.
-- ���� � �������� �� ������������ ��� ������� ���� ���� ���.

-- ��� ���� ������� �� �������
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
SELECT REVERSE('����� �����')

-- CHARINDEX - located a specific pattern (substring) in a string
-- CHARINDEX(Pattern, String, [StartIndex])

SELECT CHARINDEX('is', 'This is a long text')
-- ����� �����. �������� ������ �� ����� ������� �������� ������. ��� �� ������ ����� ������, ������� �� ����� �� ������. ��������� ���� �������� �� ����, � �� �� ����.

-- STUFF � inserts a substring at a specific position
-- STUFF(String, StartIndex, Length, Substring)
SELECT STUFF('This is a good idea', 11, 0, 'very ') 
-- Result -> This is a very good idea.

SELECT STUFF('This is a good idea', 11, 4, 'wonderfull')
-- ���� ��������� ��������� - Length ������ ����� ������� �� ������� �� ����� �������.
-- ��������� �� ���� ���� �� ���� 'This is a wonderfull idea'.

-- FORMAT ( value, format [, culture ] )
SELECT FORMAT(67.23, 'C', 'bg-BG') -- ��������� ������� ��������� (�������� ����) �� ��������� ����� � �� ���������� �������, ���� ���������� � ����� ����� � .NET. � ������ 'C' -> currency (������), �� ��.

SELECT FORMAT(CAST('2020-01-04' AS DATE), 'D', 'bg-BG')
-- Result -> '04 ������ 2020 �.'

-- TRANSLATE (inputString, characters, translations)
SELECT TRANSLATE('�����', '�����������������������',
'abvgdejziiklmnoprstufhc') --> proba

-- Math Functions
SELECT * FROM Triangles2
-- Example: find the area of triangles by the given side and height
SELECT Id, (A*H)/2 AS Area FROM Triangles2

SELECT PI() --> 3.14159265358979
SELECT ABS(-12) --> 12
SELECT SQRT(16) -- ����� ���������. �������� -> 4.
SELECT SQUARE(4) -- ����������� �� �����. ������� -> 16.

-- POWER(Value, Exponent)
SELECT POWER(4, 3) -- 4 �� ����� --> 64

SELECT * FROM dbo.Products p

-- Calculate the required number of pallets to ship each item
SELECT *,  CEILING((CAST(Quantity AS FLOAT)/BoxCapacity)/PalletCapacity) 
AS [Number of pallets]
FROM Products
-- �������� ������ � ���� �� �� �������, � ������ ��� FLOAT �� �� ����� ���� ����������� �����.
SELECT FLOOR(10/6)
SELECT CEILING(10/6)
SELECT RAND() * 6.3

-- Date function
SELECT DATEPART(DAY, '2019-01-21') --> 21
SELECT DATEPART(WEEKDAY, '2020-01-04') - 1 -- ���� ���� �� ��������� �� ���� �������� ���� ����� ���.

USE Orders
SELECT * FROM Orders

GO
--CREATE VIEW v_PartOfYearFromOrdersInOrders AS
SELECT Id, ProductName, OrderDate,
DATEPART(QUARTER, OrderDate) AS [Quarter], -- QUARTER-� ������ ���. ������ �� � � DATEPART-�.
MONTH(OrderDate) AS [Month], -- ���� � ���� � ���� �� ��-������.
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

-- DATEDIFF(Part, FirstDate, SecondDate) - ������� ����� ��� ����. Part ������ ���� ����� �� �� ������ ���������. ���� � ������, ������, ������� � �.�.
SELECT LEFT(DATEDIFF(MONTH, '2001-10-10', '2020-07-08') / 12.0, 4)
AS [Year in Service] --> 18.7

SELECT DATENAME(WEEKDAY, GETDATE()) --> Saturday (������� ���)

SELECT FORMAT(GETDATE(), 'dddd', 'bg-BG') --> ������ (������� ���)

-- Other Functions
-- CAST(Data AS NewType)
-- CONVERT(NewType, Data)

USE SoftUni
SELECT * FROM dbo.Employees e

-- ISNULL - swaps NULL values with a specified default value. ��� �� ���� � ���������� sql.
SELECT FirstName, EmployeeID,
	   ISNULL(MiddleName, 'No Middle name') AS [Middle name]
	   FROM Employees

SELECT FirstName, EmployeeID,
	   COALESCE(MiddleName, 'No Middle name') AS [Middle name]
	   FROM Employees
-- COALESCE - ����� �� �� ����� �����.

-- OFFSET & FETCH � get only specific rows from the result set
-- ��������� �� ������������ � ORDER BY. OFFSET � ���������� �� SKIP (��������) � C#, � FETCH �� TAKE (�����).

  SELECT EmployeeID, FirstName, LastName 
    FROM Employees
ORDER BY EmployeeID
OFFSET 10 ROWS
FETCH NEXT 5 ROWS ONLY

-- ROW_NUMBER � always generate unique values without any gaps, even if there are ties. ������ �������� �������� ��������� ��� ������� ��������, ���� ��� ��� ������.
SELECT EmployeeID, FirstName, LastName,
ROW_NUMBER() OVER (ORDER BY FirstName) AS [Row Number]
FROM Employees