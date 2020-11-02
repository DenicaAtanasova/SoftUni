-- Problem 6
CREATE DATABASE University

USE University
GO

CREATE TABLE Majors(
	MajorID INT IDENTITY,
	[Name] VARCHAR(50) NOT NULL,

	CONSTRAINT PK_Major PRIMARY KEY (MajorID)
);

CREATE TABLE Students(
	StudentID INT IDENTITY,
	StudentNumber INT NOT NULL,
	StudentName VARCHAR(50) NOT NULL,
	MajorID INT NOT NULL,

	CONSTRAINT PK_Student PRIMARY KEY (StudentID),
	CONSTRAINT FK_Student_Major FOREIGN KEY (MajorID)
	REFERENCES Majors (MajorID)
);

CREATE TABLE Subjects(
	SubjectID INT IDENTITY,
	SubjectName VARCHAR(50) NOT NULL,

	CONSTRAINT PK_Subject PRIMARY KEY (SubjectID),
);

CREATE TABLE Payments(
	PaymentID INT IDENTITY,
	PaymentDate Date NOT NULL,
	PaymentAmount DECIMAL (10, 2) NOT NULL,
	StudentID INT NOT NULL,

	CONSTRAINT PK_Payment PRIMARY KEY (PaymentID),
	CONSTRAINT FK_Payment_Student FOREIGN KEY (StudentID)
	REFERENCES Students (StudentID)
);

CREATE TABLE Agenda(
	StudentID INT NOT NULL,
	SubjectID INT NOT NULL,

	CONSTRAINT PK_OrderItem PRIMARY KEY(StudentID, SubjectID),
	CONSTRAINT FK_OrderItem_Student FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_OrderItem_Subject FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
);