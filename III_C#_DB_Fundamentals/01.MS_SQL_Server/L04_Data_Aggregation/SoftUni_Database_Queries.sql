USE SoftUni
GO

-- Problem 13
SELECT DepartmentID,
	   SUM(Salary) AS TotalSalary
FROM   Employees
GROUP  BY DepartmentID
ORDER  BY DepartmentID;

-- Problem 14
SELECT DepartmentID,
	   MIN(Salary) AS MinimumSalary
FROM   Employees
WHERE  DepartmentID IN (2, 5, 7)
AND    HireDate > '01/01/2000'
GROUP  BY DepartmentID;

-- Problem 15
SELECT * INTO AvgSalaryTable 
FROM   Employees
WHERE  Salary > 30000; 

DELETE FROM AvgSalaryTable
WHERE  ManagerID = 42;

UPDATE AvgSalaryTable
SET    Salary += 5000
WHERE  DepartmentID = 1;

SELECT DepartmentID, 
	   AVG(Salary) AS [AverageSalary]
FROM   AvgSalaryTable
GROUP  BY DepartmentID;

-- Problem 16
SELECT DepartmentID,
	   MAX(Salary) AS MaxSalary
FROM   Employees
GROUP  BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000;

-- Problem 17
SELECT COUNT(*) AS [Count]
FROM   Employees
WHERE  ManagerID IS NULL;

--Problem 18
SELECT DepartmentID, 
	   Salary AS ThirdHighestSalary 
FROM   (
	   SELECT DepartmentID,
	            MAX(Salary) AS Salary,
	            DENSE_RANK() OVER (
					PARTITION BY DepartmentId 
					ORDER BY Salary DESC
				) AS [Rank]
	   FROM   Employees
	   GROUP  BY DepartmentID, Salary
	   )
	   AS OrderedSalaries
WHERE [Rank]=3;

-- Problem 19
SELECT FirstName, 
	   LastName, 
	   DepartmentID
FROM   Employees AS E1
WHERE  Salary > (
	   SELECT AVG(Salary)
	   FROM   Employees AS E2
	   WHERE  E1.DepartmentID = E2.DepartmentID
	   GROUP  BY DepartmentID)
ORDER  BY DepartmentID;