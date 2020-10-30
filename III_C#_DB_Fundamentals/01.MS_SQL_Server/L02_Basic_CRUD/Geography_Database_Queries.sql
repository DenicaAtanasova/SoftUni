USE Geography
GO

-- Problem 21
SELECT PeakName FROM Peaks
ORDER BY PeakName;

-- Problem 22
SELECT top(30) CountryName, [Population] 
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC;

-- Problem 21
SELECT CountryName, ContinentCode, 
	CASE [CurrencyCode]  
	WHEN 'EUR' THEN 'Euro'
	ELSE 'Not Euro'
	END AS [Currency]
FROM Countries
ORDER BY CountryName ASC;