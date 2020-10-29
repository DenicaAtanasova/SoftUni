CREATE DATABASE Hotel
GO
USE Hotel

CREATE TABLE Employees(
	Id INT IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Title VARCHAR(20),
	Notes NVARCHAR(MAX),

	CONSTRAINT PK_Employee PRIMARY KEY(Id)
);

CREATE TABLE Customers(
	AccountNumber INT IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	PhoneNumber INT NOT NULL,
	EmergencyName VARCHAR(20),
	EmergencyNumber INT,
	Notes NVARCHAR(MAX),

	CONSTRAINT PK_Customer PRIMARY KEY(AccountNumber)
);

CREATE TABLE RoomStatus(
	RoomStatus VARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX),

	CONSTRAINT PK_RoomStatus PRIMARY KEY(RoomStatus)
);

CREATE TABLE RoomTypes(
	RoomType VARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX),

	CONSTRAINT PK_RoomType PRIMARY KEY(RoomType)
);

CREATE TABLE BedTypes(
	BedType VARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX),

	CONSTRAINT PK_BedType PRIMARY KEY(BedType)
);

CREATE TABLE Rooms(
	RoomNumber INT NOT NULL,
	RoomType VARCHAR(20) NOT NULL,
	BedType VARCHAR(20) NOT NULL,
	Rate DECIMAL(5,2),
	RoomStatus VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX),

	CONSTRAINT PK_Room PRIMARY KEY(RoomNumber),
	CONSTRAINT FK_RoomRoomType FOREIGN KEY(RoomType) REFERENCES RoomTypes(RoomType),
	CONSTRAINT FK_RoomBedType FOREIGN KEY(BedType) REFERENCES BedTypes(BedType),
);

CREATE TABLE Payments(
	Id INT IDENTITY,
	EmployeeId INT NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATE,
	LastDateOccupied DATE,
	TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
	AmountCharged DECIMAL(10, 2) NOT NULL,
	TaxRate DECIMAL(10, 2) NOT NULL,
	TaxAmount DECIMAL(10, 2) NOT NULL,
	PaymentTotal DECIMAL(10, 2) NOT NULL,
	Notes NVARCHAR(MAX),

	CONSTRAINT PK_Payment PRIMARY KEY(Id),
	CONSTRAINT FK_PaymentEmployee FOREIGN KEY(EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_PaymentAccountNumber FOREIGN KEY(AccountNumber) REFERENCES Customers(AccountNumber),
);

CREATE TABLE Occupancies(
	Id INT IDENTITY,
	EmployeeId INT,
	DateOccupied DATE,
	AccountNumber INT,
	RoomNumber INT NOT NULL,
	RateApplied DECIMAL(5, 2),
	PhoneCharge DECIMAL(10, 2),
	Notes NVARCHAR(MAX),

	CONSTRAINT PK_Occupancy PRIMARY KEY(Id),
	CONSTRAINT FK_OccupanciesEmployee FOREIGN KEY(EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_OccupanciesAccountNumber FOREIGN KEY(AccountNumber) REFERENCES Customers(AccountNumber),
	CONSTRAINT FK_OccupanciesRoomNumber FOREIGN KEY(RoomNumber) REFERENCES Rooms(RoomNumber)
);