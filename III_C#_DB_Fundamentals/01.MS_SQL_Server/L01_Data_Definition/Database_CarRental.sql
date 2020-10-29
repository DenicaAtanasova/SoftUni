CREATE DATABASE CarRental
GO
USE CarRental

CREATE TABLE Categories(
	Id INT IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate DECIMAL(10, 2),
	WeeklyRate DECIMAL(10, 2),
	MonthlyRate DECIMAL(10, 2),
	WeekendRate DECIMAL(10, 2),

	CONSTRAINT PK_Category PRIMARY KEY(Id)
);

CREATE TABLE Cars(
	Id INT IDENTITY,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	CarYear INT,
	CategoryId INT,
	Doors INT,
	Picture VARBINARY(MAX), 
	Condition VARCHAR(150),
	Available BIT NOT NULL,

	CONSTRAINT PK_Car PRIMARY KEY(Id),
	CONSTRAINT FK_CarCategory FOREIGN KEY(CategoryId) REFERENCES Categories(Id)
);

CREATE TABLE Employees(
	Id INT IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Title VARCHAR(20),
	Notes NVARCHAR(MAX),

	CONSTRAINT PK_Employee PRIMARY KEY(Id)
);

CREATE TABLE Customers(
	Id INT IDENTITY,
	DriverLicenceNumber INT UNIQUE NOT NULL,
	FullName VARCHAR(60) NOT NULL,
	[Address] VARCHAR(200),
	City VARCHAR(30),
	ZIPCode INT,
	Notes NVARCHAR(MAX),

	CONSTRAINT PK_Customer PRIMARY KEY(Id)
);

CREATE TABLE RentalOrders(
	Id INT IDENTITY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel DECIMAL(10,2),
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
	RateApplied DECIMAL(10,2),
	TaXRate DECIMAL(10,2),
	OrderStatus VARCHAR(20),
	Notes NVARCHAR(MAX),

	CONSTRAINT PK_RentalOrder PRIMARY KEY(Id),
	CONSTRAINT FK_RentalOrderEmployee FOREIGN KEY(EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_RentalOrderCustomer FOREIGN KEY(CustomerId) REFERENCES Customers(Id),
	CONSTRAINT FK_RentalOrderCar FOREIGN KEY(CarId) REFERENCES Cars(Id),
);