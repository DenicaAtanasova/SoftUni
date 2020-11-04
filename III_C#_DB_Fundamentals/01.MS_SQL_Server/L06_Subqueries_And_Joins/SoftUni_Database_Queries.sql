USE SoftUni
GO

-- Problem 1
SELECT TOP 5 e.EmployeeID, 
	   e.JobTitle, 
	   e.AddressID,
	   a.AddressText
FROM   Employees AS e
INNER  JOIN Addresses AS a
ON	   e.AddressID = a.AddressID
ORDER  BY e.AddressID ASC; 

-- Problem 2
SELECT TOP 50 e.FirstName, 
	   e.LastName,
	   t.[Name] AS Town,
	   a.AddressText
FROM   Employees AS e
INNER  JOIN Addresses AS a
ON	   e.AddressID = a.AddressID
INNER  JOIN Towns AS t
ON	   a.TownID = t.TownID
ORDER  BY e.FirstName ASC, e.LastName ASC;

-- Problem 3
SELECT e.EmployeeID, 
	   e.FirstName, 
	   e.LastName,
	   d.[Name] AS DepartmentName
FROM   Employees AS e
INNER  JOIN Departments AS d
ON	   e.DepartmentID = d.DepartmentID
WHERE  d.[Name] = 'Sales'
ORDER  BY e.EmployeeID ASC; 

-- Problem 4
SELECT TOP 5 e.EmployeeID, 
	   e.FirstName, 
	   e.Salary,
	   d.[Name] AS DepartmentName
FROM   Employees AS e
INNER  JOIN Departments AS d
ON	   e.DepartmentID = d.DepartmentID
WHERE  e.Salary > 15000
ORDER  BY e.DepartmentID ASC; 

-- Problem 5
SELECT TOP 3 e.EmployeeID, 
	   e.FirstName
FROM   Employees AS e
LEFT   JOIN EmployeesProjects AS ep
ON	   e.EmployeeID = ep.EmployeeID
WHERE  ep.EmployeeID IS NULL
ORDER  BY e.EmployeeID ASC; 

-- Problem 6
SELECT e.FirstName, 
	   e.LastName,
	   e.HireDate,
	   d.[Name] AS DeptName
FROM   Employees AS e
INNER  JOIN Departments AS d
ON	   e.DepartmentID = d.DepartmentID
WHERE  e.HireDate > '1.1.1999' 
AND    d.[Name] IN ('Sales', 'Finance')
ORDER  BY e.HireDate ASC; 

-- Problem 7
SELECT TOP 5 e.EmployeeID, 
	   e.FirstName,
	   p.[Name] AS ProjectName
FROM   Employees AS e
INNER  JOIN EmployeesProjects AS ep
ON	   e.EmployeeID = ep.EmployeeID
INNER  JOIN Projects AS p
ON     ep.ProjectID = p.ProjectID
WHERE  p.StartDate > '08.13.2002'
AND	   p.EndDate IS NULL
ORDER  BY e.EmployeeID ASC; 

-- Problem 8
SELECT e.EmployeeID, 
	   e.FirstName,
	   CASE 
		   WHEN YEAR(p.StartDate) >= '2005' THEN 'NULL'
		   ELSE p.[Name] 
	   END AS ProjectName
FROM   Employees AS e
INNER  JOIN EmployeesProjects AS ep
ON	   e.EmployeeID = ep.EmployeeID
INNER  JOIN Projects AS p
ON     ep.ProjectID = p.ProjectID
WHERE  e.EmployeeID = 24;

-- Problem 9
SELECT e.EmployeeID, 
	   e.FirstName,
	   e.ManagerID,
	   m.FirstName AS ManagerName
FROM   Employees AS e
INNER  JOIN Employees AS m
ON	   e.ManagerID = m.EmployeeID
WHERE  e.ManagerID IN (3, 7)
ORDER  BY e.EmployeeID ASC; 

-- Problem 10
SELECT TOP 50 e.EmployeeID, 
	   CONCAT_WS(' ', e.FirstName, e.LastName) AS EmployeeName,
	   CONCAT_WS(' ', m.FirstName, m.LastName) AS ManagerName,
	   d.[Name] AS DepartmentName
FROM   Employees AS e
INNER  JOIN Employees AS m
ON	   e.ManagerID = m.EmployeeID
INNER  JOIN Departments AS d
ON     e.DepartmentID = d.DepartmentID
ORDER  BY e.EmployeeID ASC; 

-- Problem 11
SELECT MIN(Salary) AS MinAvarageSalary 
FROM   (SELECT AVG(Salary) AS Salary 
        FROM   Employees 
        GROUP  BY DepartmentID) A;