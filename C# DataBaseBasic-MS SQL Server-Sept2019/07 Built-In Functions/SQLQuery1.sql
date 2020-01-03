SELECT CONCAT_WS(',', FirstName, MiddleName, LastName) AS [Full Name]
FROM Employees
-- Първо се слага разделителя и събира колоните като използва този разделител. Където има NULL го заменя с разделителя?

SELECT CONCAT_WS('. ', SUBSTRING(FirstName, 1, 1),
SUBSTRING(LastName, 1, 1)) FROM Employees
-- SUBSTRING - име на колона, от кой индекс да почне, колко знака да вземе от стринга. Тука индексите почват не от нула, а от едно. Както се вижда от примера, функциите могат да се влагат една в друга.