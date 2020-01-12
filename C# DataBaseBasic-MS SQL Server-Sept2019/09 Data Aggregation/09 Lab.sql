-- Групиране.
-- Не може да се извати всички със * от групите. Ползва се за извършване на някакви математически операции върху групите. Примерно сумите от заплатите от всички департаменти с еднакво ID.
SELECT DepartmentID, SUM(Salary) AS [Salary sum] 
FROM Employees
GROUP BY DepartmentID

SELECT DepartmentID, COUNT(DepartmentID) AS [Count] 
FROM Employees
GROUP BY DepartmentID
-- Преброй колко пъти във всяка група се среща DepartmentID. Или все едно колко хора работят във всеки департамент.

-- DISTINCT - показва уникалните стойности за това, което търсим.
SELECT DISTINCT DepartmentID FROM Employees

-- Всички агрегиращи функции.
SELECT 
DepartmentID,
Count(e.DepartmentID) AS [Count],
AVG(e.Salary) AS [Avg Salary],
MAX(e.Salary) AS [Max Salary],
MIN(e.Salary) AS [Min Salary],
SUM(e.Salary) AS [Sum Salary],
STRING_AGG(e.FirstName, ', ') AS Employees -- Изрежда със сепаратора това, което има в съответната колона. Показва ги едно до друго.
FROM dbo.Employees e
GROUP BY DepartmentID
HAVING SUM(e.Salary) > 200000 -- Използва се за групи заедно с агрегиращи функции. С WHERE не става тука.