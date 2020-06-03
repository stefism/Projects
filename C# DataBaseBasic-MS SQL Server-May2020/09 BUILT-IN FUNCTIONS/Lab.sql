-- Функциите връщат винаги само един резултат, но могат да имат повече от един параметър.
-- Агрегиращи. Приемат цяла колона и от нея връщат една единствена стойност. - AVG, COUNT, MIN, MAX, SUM

-- Ranking Functions --- ***
-- ROW_NUMBER - дава уникални стойности на редовете.
-- RANK - ако стойностите в клетките са еднакви, съответно повтаря и номера на ранга.
-- при ранк, ако има двата с номер 6, следващия ще е номер 8.
-- при денс ранк, при двама с номер 6, следващия ще е номер 7.
-- NTILE - ранкира ги (разпределя ги) по групи. Ако имаме 100 записа и му кажем NTILE(10), ще направи 10 групи по 10 човека. Ако имаме 200 записа, ще направи 10 групи от по 20 човека и съответно ще сложи номерче на групите.
SELECT FirstName, LastName, Salary, 
ROW_NUMBER() OVER(ORDER BY Salary DESC) AS [Row Number],
RANK() OVER(ORDER BY Salary DESC) AS [Rank],
DENSE_RANK() OVER(ORDER BY Salary DESC) AS [Dense Rank],
NTILE(10) OVER(ORDER BY Salary DESC) AS [Groups]
FROM Employees -- ако не ги сортираш от долу, ги сортира по ранга.
--ORDER BY EmployeeID

 -- String Functions --- ***

-- Concatenation – combines strings
-- CONCAT replaces NULL values with empty string
-- CONCAT_WS combines strings with separator

SELECT CONCAT(FirstName, ' ', LastName)
AS [Full Name]
FROM Employees

SELECT CONCAT_WS(' ' , FirstName, LastName) -- Не слага два интервала където е NULL -> string.Join() from C#
AS [Full Name]
FROM Employees

-- SUBSTRING – extracts a part of a string
-- SUBSTRING(String, StartIndex, Length)
SELECT SUBSTRING(FirstName, 1, 1)
FROM Employees AS FirstLetter

-- REPLACE – replaces a specific string with another
-- REPLACE(String, Pattern, Replacement)
SELECT REPLACE('SoftUni', 'Soft', 'Hard') --> HardUni

-- LTRIM & RTRIM – remove spaces from either side of string
-- LTRIM(String) - left trim
-- RTRIM(String) - right trim
-- TRIM(String) - left and right trim
SELECT TRIM('   Az    ') --> 'Az'

SELECT LEN('Stefan') --> 6

-- DATALENGTH – gets the number of used bytes
-- DATALENGTH(String)

-- LEFT & RIGHT – get characters from the beginning or the end of a string
SELECT LEFT('Stefan', 3) --> Ste
SELECT RIGHT('Stefan', 3) --> fan

-- LOWER & UPPER – change letter casing
SELECT LOWER('SteFan') --> stefan

SELECT REVERSE('SteFan') --> naFetS

-- REPLICATE – repeats a string
-- REPLICATE(String, Count)

-- FORMAT – format a value with a valid .NET format string
SELECT FORMAT(0.15, 'p') --> 15.00%
SELECT FORMAT(GETDATE(), 'MMMM', 'bg-BG') --> в случая - юни

-- Obfuscate CC Numbers
-- Our database contains credit card details for customers. Provide a summary without revealing the serial numbers.
SELECT CustomerID, FirstName, LastName, 
LEFT(PaymentNumber, 6) + REPLICATE('*', LEN(PaymentNumber) - 6) AS PaymentNumber
FROM Customers

-- CHARINDEX – locates a specific pattern (substring) in a string
-- CHARINDEX(Pattern, String, [StartIndex])

-- STUFF – inserts a substring at a specific position
-- STUFF(String, StartIndex, Length, Substring) -> Length - number of chars to delete.
SELECT STUFF('Stefan is good.', 11, 0, 'super ') --> Stefan is super good.

-- Pallets
-- Calculate the required number of pallets to ship each item
SELECT *, CEILING(CEILING(CAST(Quantity AS FLOAT) / BoxCapacity) / PalletCapacity)
AS [Number of pallets]
FROM Products