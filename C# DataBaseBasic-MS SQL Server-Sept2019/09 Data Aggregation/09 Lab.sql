-- ���������.
-- �� ���� �� �� ������ ������ ��� * �� �������. ������ �� �� ���������� �� ������� ������������� �������� ����� �������. �������� ������ �� ��������� �� ������ ������������ � ������� ID.
SELECT DepartmentID, SUM(Salary) AS [Salary sum] 
FROM Employees
GROUP BY DepartmentID

SELECT DepartmentID, COUNT(DepartmentID) AS [Count] 
FROM Employees
GROUP BY DepartmentID
-- ������� ����� ���� ��� ����� ����� �� ����� DepartmentID. ��� ��� ���� ����� ���� ������� ��� ����� �����������.

-- DISTINCT - ������� ���������� ��������� �� ����, ����� ������.
SELECT DISTINCT DepartmentID FROM Employees

-- ������ ���������� �������.
SELECT 
DepartmentID,
Count(e.DepartmentID) AS [Count],
AVG(e.Salary) AS [Avg Salary],
MAX(e.Salary) AS [Max Salary],
MIN(e.Salary) AS [Min Salary],
SUM(e.Salary) AS [Sum Salary],
STRING_AGG(e.FirstName, ', ') AS Employees -- ������� ��� ���������� ����, ����� ��� � ����������� ������. ������� �� ���� �� �����.
FROM dbo.Employees e
GROUP BY DepartmentID
HAVING SUM(e.Salary) > 200000 -- �������� �� �� ����� ������ � ���������� �������. � WHERE �� ����� ����.