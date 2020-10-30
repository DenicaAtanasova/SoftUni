-- Problem 1
SELECT FirstName, LastName 
FROM Employees
WHERE FirstName LIKE 'Sa%';

-- Problem 2
SELECT FirstName, LastName 
FROM Employees
WHERE LastName LIKE '%ei%';

-- Problem 3
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10)
AND YEAR(HireDate) BETWEEN 1995 AND 2005;

-- Problem 4
SELECT FirstName, LastName 
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%';

 -- Problem 5
SELECT [Name]
FROM Towns
WHERE LEN([Name]) BETWEEN 5 AND 6
ORDER BY [Name] ASC;

  -- Problem 6
SELECT [Name]
FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name] ASC;

 -- Problem 7
SELECT [Name]
FROM Towns
WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name] ASC;

 -- Problem 8
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName 
FROM Employees
WHERE YEAR(HireDate) > 2000;

SELECT * FROM V_EmployeesHiredAfter2000

-- Problem 9
SELECT FirstName, LastName 
FROM Employees
WHERE LEN(LastName) = 5;
