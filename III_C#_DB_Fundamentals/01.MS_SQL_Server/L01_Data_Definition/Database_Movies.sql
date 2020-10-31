CREATE DATABASE Movies
GO
USE Movies

CREATE TABLE Directors(
	Id INT IDENTITY,
	DirecotorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX),

	CONSTRAINT PK_Director PRIMARY KEY(Id)
);

CREATE TABLE Genres(
	Id INT IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX),

	CONSTRAINT PK_Genre PRIMARY KEY(Id)
);

CREATE TABLE Categories(
	Id INT IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX),

	CONSTRAINT PK_Category PRIMARY KEY(Id)
);

CREATE TABLE Movies(
	Id INT IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrigthYear DATE NOT NULL,
	[Length] DECIMAL(15,2),
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating DECIMAL(10, 2),
	Notes NVARCHAR(MAX),

	CONSTRAINT PK_Movie PRIMARY KEY(Id),
	CONSTRAINT FK_MovieDirector FOREIGN KEY(DirectorId) REFERENCES Directors(Id),
	CONSTRAINT FK_MovieGenre FOREIGN KEY(GenreId) REFERENCES Genres(Id),
	CONSTRAINT FK_MovieCategory FOREIGN KEY(CategoryId) REFERENCES Categories(Id),
);