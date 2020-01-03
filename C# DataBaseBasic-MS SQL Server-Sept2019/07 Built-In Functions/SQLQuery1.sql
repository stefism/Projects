SELECT CONCAT_WS(',', FirstName, MiddleName, LastName) AS [Full Name]
FROM Employees
-- ����� �� ����� ����������� � ������ �������� ���� �������� ���� ����������. ������ ��� NULL �� ������ � �����������?

SELECT CONCAT_WS('. ', SUBSTRING(FirstName, 1, 1),
SUBSTRING(LastName, 1, 1)) FROM Employees
-- SUBSTRING - ��� �� ������, �� ��� ������ �� �����, ����� ����� �� ����� �� �������. ���� ��������� ������ �� �� ����, � �� ����. ����� �� ����� �� �������, ��������� ����� �� �� ������ ���� � �����.