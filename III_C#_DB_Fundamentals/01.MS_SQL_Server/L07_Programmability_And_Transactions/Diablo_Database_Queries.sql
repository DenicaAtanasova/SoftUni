USE Diablo
GO

--Problem 13
CREATE FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(50))
	RETURNS TABLE
AS
RETURN	SELECT SUM(Cash) AS SumCash 
		FROM   (SELECT ug.Cash,
					   ROW_NUMBER() OVER (
						ORDER BY ug.Cash DESC) AS RowNumber
			   FROM    Games AS g
			   INNER   JOIN UsersGames AS ug
			   ON      g.Id = ug.GameId
			   WHERE   g.[Name] = @gameName) AS CashList
		WHERE  RowNumber % 2 = 1;
GO;

-- Section II. Triggers and Transactions
-- Problem 19
CREATE TRIGGER	trg_RestrictItems
ON UserGameItems
INSTEAD OF INSERT
AS
DECLARE @ItemId INT = (SELECT ItemId 
					   FROM   inserted);
DECLARE @UserGameId INT = (SELECT UserGameId
						   FROM   inserted);
DECLARE @ItemLevel INT = (SELECT MinLevel 
						  FROM   Items
						  WHERE  Id = @ItemId);
DECLARE @UserGameLevel INT = (SELECT [Level]
							  FROM   UsersGames
							  WHERE Id = @UserGameId);

IF (@UserGameLevel >= @ItemLevel)
BEGIN
	INSERT INTO UserGameItems (ItemId, UserGameId)
	VALUES (@ItemId, @UserGameId);
END
GO;

UPDATE UsersGames
SET	   Cash += 50000
WHERE  GameId IN (SELECT Id 
				  FROM   Games
				  WHERE  [Name] = 'Bali')
AND	   UserId IN (SELECT Id 
				  FROM   Users
				  WHERE  Username IN ('baleremuda', 
									  'loosenoise', 
									  'inguinalself', 
									  'buildingdeltoid', 
									  'monoxidecos'));

EXEC dbo.usp_BuyItemsForBaliUsers 251, 299;
EXEC dbo.usp_BuyItemsForBaliUsers 501, 539;

CREATE PROC usp_BuyItemsForBaliUsers @firstItemId INT, @lastItemId INT
AS
WHILE (@firstItemId <= @lastItemId)
BEGIN
	EXEC dbo.usp_BuyItem 12, @firstItemId, 212;
	EXEC dbo.usp_BuyItem 22, @firstItemId, 212;
	EXEC dbo.usp_BuyItem 37, @firstItemId, 212;
	EXEC dbo.usp_BuyItem 52, @firstItemId, 212;
	EXEC dbo.usp_BuyItem 61, @firstItemId, 212;
	SET @firstItemId += 1;
END
GO;

CREATE or alter PROC usp_BuyItem @userId INT, @itemId INT, @gameId INT
AS
BEGIN TRANSACTION
	DECLARE @user INT = (SELECT Id
						 FROM   Users
						 WHERE  Id = @userId);
	DECLARE @item INT = (SELECT Id
						 FROM   Items
						 WHERE  Id = @itemId);
	IF @user IS NULL OR @item IS NULL
	BEGIN
		ROLLBACK
		RAISERROR('Invalid user or item', 16, 1);
		RETURN
	END

	DECLARE @itemPrice DECIMAL(15,2) = (SELECT Price 
										FROM Items
										WHERE Id = @itemId);
	DECLARE @userCash DECIMAL(15,2) = (SELECT Cash
									   FROM UsersGames
									   WHERE UserId = @userId
									   AND   GameId = @gameId);
	IF (@userCash < @itemPrice)
	BEGIN
		ROLLBACK
		RAISERROR('Insufficient funds', 16, 1);
		RETURN
	END

	UPDATE UsersGames
	SET    Cash -= @itemPrice
	WHERE  UserId = @userId
	AND    GameId = @gameId;

	DECLARE @userGameId INT = (SELECT Id 
							   FROM   UsersGames
							   WHERE  UserId = @userId 
							   AND    GameId = @gameId);

	DECLARE @userGameItemId INT = (SELECT ItemId
								  FROM   UserGameItems 
								  WHERE  ItemId = @itemId 
								  AND    UserGameId = @userGameId);
	IF @userGameItemId IS NOT NULL
	BEGIN
		ROLLBACK;
		RAISERROR('Current user have already bought this item.', 16, 1);
		RETURN
	END

	INSERT INTO UserGameItems (ItemId, UserGameId)
	VALUES (@itemId, @userGameId);
COMMIT
GO;

SELECT u.Username,
	   g.[Name],
	   ug.Cash,
	   i.[Name]
FROM   Users AS u
INNER  JOIN UsersGames AS ug
ON     u.Id = ug.UserId
INNER  JOIN Games AS g
ON	   ug.GameId = g.Id
INNER  JOIN UserGameItems AS ugi
ON	   ug.Id = ugi.UserGameId
INNER  JOIN Items AS i
ON	   ugi.ItemId = i.Id
WHERE  g.[Name] = 'Bali'
ORDER  BY u.Username, i.[Name];