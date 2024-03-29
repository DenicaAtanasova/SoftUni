CREATE DATABASE Minions
GO 
USE Minions

CREATE TABLE Minions (
	Id INT NOT NULL,
	[Name] VARCHAR(50),
	Age INT,

	CONSTRAINT PK_Minion PRIMARY KEY(Id)
);

CREATE TABLE Towns (
	Id INT NOT NULL,
	[Name] VARCHAR(50)

	CONSTRAINT PK_Town PRIMARY KEY(Id)
);

ALTER TABLE Minions
ADD TownId INT,
CONSTRAINT FK_MinionTown FOREIGN KEY (TownId) REFERENCES Towns(Id);

INSERT INTO Towns (Id, [Name])
VALUES(1, 'Sofia'), (2, 'Plovdiv'), (3, 'Varna');

INSERT INTO Minions (Id, [Name], Age, TownId)
VALUES(1, 'Kevin', 22, 1), (2, 'Bob', 15, 3), (3, 'Steward', NULL, 2);

TRUNCATE TABLE Minions;

DROP TABLE Minions;

DROP TABLE Towns;

CREATE TABLE People(
	Id INT IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(2000),
	Height DECIMAL(15, 2),
	[Weight] DECIMAL (15,2),
	Gender CHAR(1) NOT NULL,
	CHECK (Gender in ('m', 'f')),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX),

	CONSTRAINT PK_People PRIMARY KEY(Id)
);

CREATE TABLE Users(
	Id INT IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(900),
	LastLoginTime DATETIME2,
	IsDeleted BIT DEFAULT('False')

	CONSTRAINT PK_User PRIMARY KEY (Id)
);

ALTER TABLE Users
DROP CONSTRAINT PK_User;

ALTER TABLE Users
ADD CONSTRAINT PK_User PRIMARY KEY (Id, Username);

ALTER TABLE Users
ADD CONSTRAINT CK_Password CHECK (LEN(Password) >= 5);

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime;

ALTER TABLE Users
DROP CONSTRAINT PK_User;

ALTER TABLE Users
ADD CONSTRAINT PK_User PRIMARY KEY (Id);

ALTER TABLE Users
ADD CONSTRAINT CK_Username CHECK (LEN(Username) >= 3);

