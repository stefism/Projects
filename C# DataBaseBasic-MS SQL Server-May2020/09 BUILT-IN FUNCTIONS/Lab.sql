-- ��������� ������ ������ ���� ���� ��������, �� ����� �� ���� ������ �� ���� ���������.
-- ����������. ������� ���� ������ � �� ��� ������ ���� ���������� ��������. - AVG, COUNT, MIN, MAX, SUM

-- Ranking Functions --- ***
-- ROW_NUMBER - ���� �������� ��������� �� ��������.
-- RANK - ��� ����������� � �������� �� �������, ��������� ������� � ������ �� �����.
-- ��� ����, ��� ��� ����� � ����� 6, ��������� �� � ����� 8.
-- ��� ���� ����, ��� ����� � ����� 6, ��������� �� � ����� 7.
-- NTILE - ������� �� (���������� ��) �� �����. ��� ����� 100 ������ � �� ����� NTILE(10), �� ������� 10 ����� �� 10 ������. ��� ����� 200 ������, �� ������� 10 ����� �� �� 20 ������ � ��������� �� ����� ������� �� �������.
SELECT FirstName, LastName, Salary, 
ROW_NUMBER() OVER(ORDER BY Salary DESC) AS [Row Number],
RANK() OVER(ORDER BY Salary DESC) AS [Rank],
DENSE_RANK() OVER(ORDER BY Salary DESC) AS [Dense Rank],
NTILE(10) OVER(ORDER BY Salary DESC) AS [Groups]
FROM Employees -- ��� �� �� �������� �� ����, �� ������� �� �����.
--ORDER BY EmployeeID

 -- String Functions --- ***

-- Concatenation � combines strings
-- CONCAT replaces NULL values with empty string
-- CONCAT_WS combines strings with separator

SELECT CONCAT(FirstName, ' ', LastName)
AS [Full Name]
FROM Employees

SELECT CONCAT_WS(' ' , FirstName, LastName) -- �� ����� ��� ��������� ������ � NULL -> string.Join() from C#
AS [Full Name]
FROM Employees

-- SUBSTRING � extracts a part of a string
-- SUBSTRING(String, StartIndex, Length)
SELECT SUBSTRING(FirstName, 1, 1)
FROM Employees AS FirstLetter

-- REPLACE � replaces a specific string with another
-- REPLACE(String, Pattern, Replacement)
SELECT REPLACE('SoftUni', 'Soft', 'Hard') --> HardUni

-- LTRIM & RTRIM � remove spaces from either side of string
-- LTRIM(String) - left trim
-- RTRIM(String) - right trim
-- TRIM(String) - left and right trim
SELECT TRIM('   Az    ') --> 'Az'

SELECT LEN('Stefan') --> 6

-- DATALENGTH � gets the number of used bytes
-- DATALENGTH(String)

-- LEFT & RIGHT � get characters from the beginning or the end of a string
SELECT LEFT('Stefan', 3) --> Ste
SELECT RIGHT('Stefan', 3) --> fan

-- LOWER & UPPER � change letter casing
SELECT LOWER('SteFan') --> stefan

SELECT REVERSE('SteFan') --> naFetS

-- REPLICATE � repeats a string
-- REPLICATE(String, Count)

-- FORMAT � format a value with a valid .NET format string
SELECT FORMAT(0.15, 'p') --> 15.00%
SELECT FORMAT(GETDATE(), 'MMMM', 'bg-BG') --> � ������ - ���

-- Obfuscate CC Numbers
-- Our database contains credit card details for customers. Provide a summary without revealing the serial numbers.
SELECT CustomerID, FirstName, LastName, 
LEFT(PaymentNumber, 6) + REPLICATE('*', LEN(PaymentNumber) - 6) AS PaymentNumber
FROM Customers

-- CHARINDEX � locates a specific pattern (substring) in a string
-- CHARINDEX(Pattern, String, [StartIndex])

-- STUFF � inserts a substring at a specific position
-- STUFF(String, StartIndex, Length, Substring) -> Length - number of chars to delete.
SELECT STUFF('Stefan is good.', 11, 0, 'super ') --> Stefan is super good.

-- Pallets
-- Calculate the required number of pallets to ship each item
SELECT *, CEILING(CEILING(CAST(Quantity AS FLOAT) / BoxCapacity) / PalletCapacity)
AS [Number of pallets]
FROM Products