CREATE DATABASE Relations

USE Relations
GO

-- Problem 1
CREATE TABLE Passports(
	PassportID INT IDENTITY (100, 1),
	PassportNumber NVARCHAR(8) NOT NULL
);

CREATE TABLE Persons(
	PersonID INT IDENTITY,
	FirstName NVARCHAR(10) NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
	PassportID INT NOT NULL
);

ALTER TABLE Passports
ADD   CONSTRAINT PK_Passport PRIMARY KEY (PassportID);

ALTER TABLE Persons
ADD   CONSTRAINT PK_Person PRIMARY KEY (PersonID),
	  CONSTRAINT FK_Person_Passport FOREIGN KEY (PassportID) 
	  REFERENCES Passports(PassportID);

-- Problem 2
CREATE TABLE Manufacturers(
	ManufacturerID INT IDENTITY(100, 1),
	[Name] NVARCHAR(10) NOT NULL,
	EstablishedOn DATE
);

CREATE TABLE Models(
	ModelID INT IDENTITY,
	[Name] NVARCHAR(10) NOT NULL,
	ManufacturerID INT NOT NULL
);

ALTER TABLE Manufacturers
ADD	  CONSTRAINT PK_Manufacturer PRIMARY KEY(ManufacturerID);

ALTER TABLE Models
ADD	  CONSTRAINT PK_Model PRIMARY KEY(ModelID),
	  CONSTRAINT FK_Model_Manufacturer FOREIGN KEY (ManufacturerID)
	  REFERENCES Manufacturers(ManufacturerID);

-- Problem 3
CREATE TABLE Students(
	StudentID INT IDENTITY,
	[Name] NVARCHAR(10) NOT NULL,
);

CREATE TABLE Exams(
	ExamID INT IDENTITY(101,1),
	[Name] NVARCHAR(10) NOT NULL
);

CREATE TABLE StudentsExams(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL
);

ALTER TABLE Students
ADD	  CONSTRAINT PK_Student PRIMARY KEY(StudentID);

ALTER TABLE Exams
ADD	  CONSTRAINT PK_Exam PRIMARY KEY(ExamID);

ALTER TABLE StudentsExams
ADD	  CONSTRAINT PK_StudentExam PRIMARY KEY(StudentID, ExamID),
	  CONSTRAINT FK_StudentExam_Student FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	  CONSTRAINT FK_StudentExam_Exam FOREIGN KEY (ExamID) REFERENCES Exams(ExamID);

-- Problem 4
CREATE TABLE Teachers(
	TeacherID INT IDENTITY(101,1),
	Name NVARCHAR(10) NOT NULL,
	ManagerID INT,

	CONSTRAINT PK_Teacher PRIMARY KEY(TeacherID),
	CONSTRAINT FK_Manager_Teacher FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
);