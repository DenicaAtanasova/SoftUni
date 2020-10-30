-- Problem 12
SELECT TOP(50) [Name], CONVERT(varchar, [Start], 23) AS [Start]
FROM Games
WHERE YEAR([Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name];

-- Problem 13
SELECT Username, 
SUBSTRING(Email, CHARINDEX('@', Email)+1, LEN(Email) - CHARINDEX('@', Email)+1) AS [Email Provider]
FROM Users
ORDER BY [Email Provider] ASC, Username ASC;

-- Problem 14
SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username;

-- Problem 15
SELECT [Name], 
	CASE 
		WHEN  DATEPART(HOUR, Start) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN  DATEPART(HOUR, Start) BETWEEN 12 AND 17 THEN 'Afternoon'
		ELSE 'Evening'
	END AS [Part of the Day],
	CASE 
		WHEN Duration <= 3 THEN 'Extra short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS Duration
FROM Games
ORDER BY [Name] ASC, Duration ASC, [Part of the Day] ASC;