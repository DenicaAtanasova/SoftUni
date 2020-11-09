USE SoftUni
GO

-- Problem 1
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
SELECT FirstName, LastName
FROM   Employees 
WHERE  Salary > 35000
GO;

-- Problem 2
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@MinSalary DECIMAL(18,4))
AS
SELECT FirstName, LastName
FROM   Employees 
WHERE  Salary > @MinSalary
GO;

-- Problem 3
CREATE PROC usp_GetTownsStartingWith (@TownNamePrefix NVARCHAR(10))
AS
SELECT [Name] AS Town 
FROM   Towns
WHERE  [Name] LIKE CONCAT(@TownNamePrefix,'%')
GO;

-- Problem 4
CREATE PROC usp_GetEmployeesFromTown 
	(@Town NVARCHAR(10))
AS
SELECT e.FirstName, e.LastName
FROM   Employees AS e
INNER  JOIN Addresses AS a 
ON     e.AddressID = a.AddressID
INNER  JOIN Towns AS t
ON     a.TownID = t.TownID
WHERE  t.[Name] = @Town
GO;

-- Problem 5
CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18, 4))
	RETURNS NVARCHAR(7)
AS
BEGIN
    DECLARE @SalaryLevel NVARCHAR(7);

	IF (@salary < 30000)
		BEGIN
			SET @SalaryLevel = 'Low'
		END
	ELSE IF (@salary BETWEEN 30000 AND 50000)
		BEGIN
			SET @SalaryLevel = 'Average'
		END
	ELSE
		BEGIN
			SET @SalaryLevel = 'High'
		END

	RETURN @SalaryLevel
END
GO;

-- Problem 6
CREATE PROC usp_EmployeesBySalaryLevel (@SalaryLevel VARCHAR(7))
AS
SELECT FirstName, 
		LastName
FROM   Employees
WHERE  @SalaryLevel = dbo.ufn_GetSalaryLevel(Salary)
GO;

-- Problem 7
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
	RETURNS BIT
AS
BEGIN
	DECLARE @result BIT = 0;
	DECLARE @index INT = 1;
	DECLARE @char CHAR;

	WHILE (@index <= LEN(@word))
	BEGIN
		SET @char = SUBSTRING(@word, @index, 1);
		IF(CHARINDEX(@char, @setOfLetters) = 0)
			BEGIN
				RETURN @result;
			END
		SET @index += 1;
	END
	RETURN @result + 1;
END
GO;

-- Problem 8
CREATE FUNCTION ufn_getDepartmentEmployees(@departmentId INT)
	RETURNS @result TABLE (
			EmployeeID INT)
AS
BEGIN
	INSERT INTO @result SELECT EmployeeID
						FROM   Employees
						WHERE  DepartmentID = @departmentId
	RETURN
END
GO;

CREATE PROC usp_DeleteEmployeesFromDepartment @departmentId INT
AS
	ALTER TABLE Departments
	ALTER COLUMN ManagerId INT NULL;
	
	UPDATE Employees
	SET    ManagerID = NULL
	WHERE  ManagerID IN (SELECT *
						 FROM   dbo.ufn_getDepartmentEmployees(@departmentId));

	UPDATE Departments
	SET    ManagerID = NULL
	WHERE  ManagerID IN (SELECT *
						 FROM   dbo.ufn_getDepartmentEmployees(@departmentId));
					 
	DELETE FROM EmployeesProjects
	WHERE  EmployeeID IN (SELECT *
						 FROM   dbo.ufn_getDepartmentEmployees(@departmentId));

	DELETE FROM Employees
	WHERE  DepartmentID = @departmentId;

	DELETE FROM Departments
	WHERE  DepartmentID = @departmentId;

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId;
GO;