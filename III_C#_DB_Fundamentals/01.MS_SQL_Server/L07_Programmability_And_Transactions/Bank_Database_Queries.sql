USE Bank
GO

-- Problem 9
CREATE PROC usp_GetHoldersFullName 
AS
SELECT FirstName + ' ' + LastName AS [Full Name] 
FROM   AccountHolders
GO;

-- Problem 10
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@minBalance MONEY)
AS
SELECT ah.FirstName AS [First Name],
	   ah.LastName AS [Last Name]
FROM   AccountHolders AS ah
INNER  JOIN Accounts AS a
ON     ah.Id = a.AccountHolderId
GROUP  BY ah.FirstName, ah.LastName
HAVING SUM(a.Balance) > @minBalance
GO;

-- Problem 11
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(10,2), @yearlyInterestRate FLOAT, @numberOfYears INT)
	RETURNS DECIMAL (10,4)
AS
BEGIN
	RETURN @sum * POWER((1 + @yearlyInterestRate), @numberOfYears);
END
GO;

-- Problem 12
CREATE PROC usp_CalculateFutureValueForAccount (@accountId INT, @interestRate FLOAT)
AS
BEGIN
	DECLARE @Years INT = 5;
	SELECT  ah.Id AS [Account Id],
			ah.FirstName AS [First Name],
			ah.LastName AS [Last Name],
			a.Balance AS [Current Balance],
			dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, @Years) AS [Balance in 5 years]
	FROM    AccountHolders AS ah
	INNER   JOIN Accounts AS a
	ON      ah.Id = a.AccountHolderId
	WHERE   a.Id = @accountId;
END
GO;