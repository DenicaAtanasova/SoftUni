-- Problem 10
SELECT CountryName, IsoCode 
FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode

-- Problem 11
SELECT PeakName, 
       RiverName, 
	   LOWER(CONCAT(PeakName, RIGHT(RiverName, LEN(RiverName)-1))) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix ASC