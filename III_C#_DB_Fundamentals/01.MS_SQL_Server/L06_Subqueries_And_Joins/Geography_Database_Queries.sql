USE [Geography]
GO

-- Problem 12
SELECT mc.CountryCode,
	   m.MountainRange,
	   p.PeakName,
	   p.Elevation
FROM   Mountains AS m
INNER  JOIN MountainsCountries AS mc
ON	   m.Id = mc.MountainId
INNER  JOIN Peaks AS p
ON	   p.MountainId = m.Id
WHERE  mc.CountryCode = 'BG'
AND	   p.Elevation > 2835
ORDER  BY p.Elevation DESC;

-- Problem 13
SELECT mc.CountryCode,
	   COUNT(m.MountainRange) AS MountainRanges
FROM   Mountains AS m
INNER  JOIN MountainsCountries AS mc
ON	   m.Id = mc.MountainId
WHERE  mc.CountryCode IN ('US', 'RU', 'BG')
GROUP  BY mc.CountryCode;

-- Problem 14
SELECT TOP 5 c.CountryName,
	   r.RiverName
FROM   Countries AS c
INNER  JOIN Continents AS con
ON	   c.ContinentCode = con.ContinentCode
LEFT   JOIN CountriesRivers AS cr
ON	   c.CountryCode = cr.CountryCode
LEFT   JOIN Rivers AS r
ON	   cr.RiverId = r.Id
WHERE  con.ContinentName = 'Africa'
ORDER  BY c.CountryName ASC;

-- Problem 15
SELECT ContinentCode, 
       CurrencyCode, 
       CurrencyUsage 
FROM   (SELECT ContinentCode, 
               CurrencyCode, 
               CurrencyUsage, 
               Dense_rank() 
                 OVER ( 
                   partition BY ContinentCode 
                   ORDER BY CurrencyUsage DESC) AS CurrencyRank 
        FROM   (SELECT ContinentCode, 
                       CurrencyCode, 
                       Count(*) AS CurrencyUsage 
                FROM   Countries AS c 
                GROUP  BY ContinentCode, 
                          CurrencyCode) AS CurrencyCountQuery 
        WHERE  CurrencyUsage > 1) AS A 
WHERE  CurrencyRank = 1; 

-- Problem 16
SELECT COUNT(*) AS CountryCode
FROM  (SELECT mc.CountryCode
	   FROM   Countries AS c
	   LEFT   JOIN MountainsCountries AS mc
	   ON     c.CountryCode = mc.CountryCode
	   WHERE  mc.MountainId IS NULL) 
	   AS     CountriesWithoutMountains;

-- Problem 17
SELECT TOP 5 CountryName, 
	   HighestPeakElevation,
	   LongestRiverLength
FROM   (SELECT c.CountryName, 
			   MAX(p.Elevation) AS  HighestPeakElevation,
			   MAX(r.[Length]) AS LongestRiverLength
	   FROM    Countries AS c
	   LEFT    JOIN CountriesRivers AS cr
	   ON      c.CountryCode = cr.CountryCode
	   LEFT    JOIN Rivers AS r
	   ON      cr.RiverId = r.Id
	   LEFT    JOIN MountainsCountries AS mc
	   ON      c.CountryCode = mc.CountryCode
	   LEFT    JOIN Mountains AS m
	   ON      mc.MountainId = m.Id
	   LEFT    JOIN Peaks p
	   ON      m.Id = p.MountainId
	   GROUP   BY c.CountryName) AS GroupedByCountry
ORDER  BY HighestPeakElevation DESC, 
	   LongestRiverLength DESC;

-- Problem 18
SELECT TOP 5 Country,
	   ISNULL(PeakName, '(no highest peak)') AS [Highest Peak Name],
	   ISNULL(Elevation, 0) AS [Highest Peak Elevation],
	   ISNULL(MountainRange, '(no mountain)') AS Mountain
FROM   (SELECT *,
			   DENSE_RANK() OVER
				   (PARTITION BY Country
				   ORDER BY Elevation DESC) 
				   AS PeakRank
	   FROM   (SELECT c.CountryName AS Country,
				      p.PeakName,
				      p.Elevation,
				      m.MountainRange
			  FROM    Countries AS c
			  LEFT    JOIN MountainsCountries AS mc
			  ON      c.CountryCode = mc.CountryCode
			  LEFT    JOIN Mountains AS m
			  ON      mc.MountainId = m.Id
			  LEFT    JOIN Peaks p
			  ON      m.Id = p.MountainId) 
			  AS Info) 
	   AS     PeakElevetaionRank
WHERE  PeakRank = 1
ORDER  BY Country ASC, PeakName ASC;

