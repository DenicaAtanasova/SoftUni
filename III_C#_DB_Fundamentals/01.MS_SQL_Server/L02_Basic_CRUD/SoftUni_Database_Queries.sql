USE SoftUni
GO

-- Problem 1
SELECT * FROM Departments;

-- Problem 2
SELECT [Name] 
FROM Departments;

-- Problem 3
SELECT FirstName, LastName, Salary 
FROM Employees;

-- Problem 4
SELECT FirstName, MiddleName, LastName 
FROM Employees;

-- Problem 5
SELECT CONCAT(FirstName, '.', LastName, '@softuni.bg') AS [Full Email Address] 
FROM Employees;

-- Problem 6
SELECT DISTINCT Salary 
FROM Employees;

-- Problem 7
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative';

-- Problem 8
SELECT FirstName, LastName, JobTitle
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000;

-- Problem 9
SELECT CONCAT_WS(' ', FirstName, MiddleName, LastName) AS FullName
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600);

-- Problem 10
SELECT FirstName, LastName
FROM Employees
WHERE ManagerID IS NULL

-- Problem 11
SELECT FirstName, LastName, Salary 
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC;

-- Problem 12
SELECT TOP(5) FirstName, LastName
FROM Employees
ORDER BY Salary DESC;

-- Problem 13
SELECT FirstName, LastName 
FROM Employees
WHERE DepartmentID <> 4;

-- Problem 14
SELECT * FROM Employees
ORDER BY Salary DESC, FirstName ASC, LastName DESC, MiddleName ASC;

-- Problem 15
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary
FROM Employees;

SELECT * FROM V_EmployeesSalaries;

-- Problem 16
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT CONCAT_WS(' ', FirstName, MiddleName, LastName) AS [Full Name], JobTitle AS [Job Title]
FROM Employees;

SELECT * FROM V_EmployeeNameJobTitle;

-- Problem 17
SELECT DISTINCT JobTitle
FROM Employees;

-- Problem 18
SELECT TOP(10) * FROM Projects
ORDER BY StartDate, Name;

-- Problem 19
SELECT TOP(7) FirstName, LastName, HireDate 
FROM Employees
ORDER BY HireDate DESC

-- Problem 20
UPDATE Employees
SET Salary = Salary * 1.12
WHERE DepartmentID IN(
	SELECT DepartmentID FROM Departments
	WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
);

SELECT Salary FROM Employees;