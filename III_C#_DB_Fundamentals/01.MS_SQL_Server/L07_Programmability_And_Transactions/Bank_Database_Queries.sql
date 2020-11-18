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


-- Section II. Triggers and Transactions
-- Problem 14
CREATE TABLE Logs (
	LogId INT IDENTITY,
	AccountId INT NOT NULL,
	OldSum DECIMAL(15, 2),
	NewSum DECIMAL(15, 2)

CONSTRAINT PK_Log PRIMARY KEY (LogId));

CREATE TRIGGER LogsSumUpdate
ON Accounts
AFTER UPDATE
AS 
INSERT INTO Logs
VALUES ((SELECT Id
	   FROM inserted),
	   (SELECT Balance
	   FROM deleted),
	   (SELECT Balance
	   FROM inserted));
GO

-- Problem 15
CREATE TABLE NotificationEmails (
	Id INT IDENTITY,
	Recipient INT NOT NULL,
	[Subject] VARCHAR(MAX),
	Body VARCHAR(MAX)

CONSTRAINT PK_NotificationEmail PRIMARY KEY (Id)
CONSTRAINT FK_NotificationEmail_Recipinet FOREIGN KEY (Recipient) REFERENCES Accounts (Id)); 

CREATE TRIGGER CreateNotificationEmail
ON Logs
AFTER INSERT
AS
INSERT INTO NotificationEmails
VALUES ((SELECT AccountId
		FROM    inserted),
		(CONCAT_WS(' ',
			       'Balance change for account:',
				   (SELECT AccountId
					FROM   inserted))),
		(CONCAT_WS(' ',
				   'On', 
				   GETDATE(), 
				   'your balance was changed from', 
				   (SELECT OldSum 
					FROM   inserted),
				   'to',
				   (CONCAT((SELECT NewSum
							FROM   inserted),'.')))));
GO

-- Problem 16
CREATE PROC usp_DepositMoney (@accountId INT, @moneyAmount DECIMAL(15, 4))
AS
BEGIN  TRANSACTION
	DECLARE @account INT = (SELECT Id
							FROM   Accounts
							WHERE  Id = @accountId)
	IF @account IS NULL
	BEGIN 
		ROLLBACK
		RAISERROR('Invalid account', 16, 1)
	END

	UPDATE Accounts
	SET    Balance += @moneyAmount
	WHERE  Id = @accountId;
	IF @MoneyAmount < 0
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount of money', 16, 1)
	END
COMMIT
GO;

-- Problem 17
CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(15, 4))
AS
BEGIN TRANSACTION
	DECLARE @account INT = (SELECT Id
							FROM   Accounts
							WHERE  Id = @accountId)
	IF @account IS NULL
	BEGIN 
		ROLLBACK
		RAISERROR('Invalid account', 16, 1)
	END

	UPDATE Accounts
	SET Balance -= @moneyAmount
	WHERE Id = @accountId;

	IF @moneyAmount < 0
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount of money', 16, 1)
	END
	
	DECLARE @CurrentBalance DECIMAL(15, 4) = (SELECT SUM(Balance) 
											  FROM Accounts 
											  WHERE Id = @accountId);
	IF @CurrentBalance < 0
	BEGIN
		ROLLBACK
		RAISERROR('Insufficient Funds', 16, 1)
	END
COMMIT
GO;

-- Problem 18
CREATE OR ALTER PROC usp_TransferMoney(@senderId INT, @receiverId int, @amount DECIMAL(15, 4))
AS
BEGIN TRANSACTION
		EXEC dbo.usp_WithdrawMoney @senderId, @amount;
		EXEC dbo.usp_DepositMoney @receiverId, @amount;

		IF ERROR_MESSAGE() IS NOT NULL
			ROLLBACK;
COMMIT TRANSACTION;
GO;