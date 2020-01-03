CREATE VIEW v_HihgtestPek AS
SELECT TOP(1) *  FROM Peaks
ORDER BY Elevation DESC

SELECT * FROM v_HihgtestPek

CREATE VIEW v_HihgtestPek1 AS -- “ова не работи след като е направено горното. »наче само селекта го показва.
SELECT Elevation  FROM Peaks
ORDER BY Elevation DESC