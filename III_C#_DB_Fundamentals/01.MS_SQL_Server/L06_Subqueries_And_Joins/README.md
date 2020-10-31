# Exercises: Joins, Subqueries, CTE and Indices

### 1. Employee Address
Write a query that selects:
* EmployeeId
* JobTitle
* AddressId
* AddressText    
Return the first 5 rows sorted by AddressId in ascending order.

### 2. Addresses with Towns
Write a query that selects:
* FirstName
* LastName
* Town
* AddressText    
Sorted by FirstName in ascending order then by LastName. Select first 50 employees.

### 3. Sales Employee
Write a query that selects:
* EmployeeID
* FirstName
* LastName
* DepartmentName  
Sorted by EmployeeID in ascending order. Select only employees from “Sales” department.

### 4. Employee Departments
Write a query that selects:
* EmployeeID
* FirstName
* Salary
* DepartmentName
Filter only employees with salary higher than 15000. Return the first 5 rows sorted by DepartmentID in ascending order.

### 5. Employees Without Project
Write a query that selects:
* EmployeeID
* FirstName  
Filter only employees without a project. Return the first 3 rows sorted by EmployeeID in ascending order.

### 6. Employees Hired After
Write a query that selects:
* FirstName
* LastName
* HireDate
* DeptName  
Filter only employees hired after 1.1.1999 and are from either "Sales" or "Finance" departments, sorted by HireDate (ascending).

### 7. Employees with Project
Write a query that selects:
* EmployeeID
* FirstName
* ProjectName  
Filter only employees with a project which has started after 13.08.2002 and it is still ongoing (no end date). Return the first 5 rows sorted by EmployeeID in ascending order.

### 8. Employee 24
Write a query that selects:
* EmployeeID
* FirstName
* ProjectName  
Filter all the projects of employee with Id 24. If the project has started during or after 2005 the returned value should be NULL.

### 9. Employee Manager
Write a query that selects:
* EmployeeID
* FirstName
* ManagerID
* ManagerName  
Filter all employees with a manager who has ID equals to 3 or 7. Return all the rows, sorted by EmployeeID in ascending order.

### 10. Employee Summary
Write a query that selects:
* EmployeeID
* EmployeeName
* ManagerName
* DepartmentName  
Show first 50 employees with their managers and the departments they are in (show the departments of the employees). Order by EmployeeID.

### 11. Min Average Salary
Write a query that returns the value of the lowest average salary of all departments.

### 12. Highest Peaks in Bulgaria
Write a query that selects:
* CountryCode
* MountainRange
* PeakName
* Elevation  
Filter all peaks in Bulgaria with elevation over 2835. Return all the rows sorted by elevation in descending order.

### 13. Count Mountain Ranges
Write a query that selects:
* CountryCode
* MountainRanges  
Filter the count of the mountain ranges in the United States, Russia and Bulgaria.

### 14. Countries with Rivers
Write a query that selects:
* CountryName
* RiverName  
Find the first 5 countries with or without rivers in Africa. Sort them by CountryName in ascending order.

### 15. Continents and Currencies
Write a query that selects:
* ContinentCode
* CurrencyCode
* CurrencyUsage  
Find all continents and their most used currency. Filter any currency that is used in only one country. Sort your results by ContinentCode.

### 16. Countries without any Mountains
Write a query that selects CountryCode. Find all the count of all countries, which don’t have a mountain.

### 17. Highest Peak and Longest River by Country
For each country, find the elevation of the highest peak and the length of the longest river, sorted by the highest peak elevation (from highest to lowest), then by the longest river length (from longest to smallest), then by country name (alphabetically). Display NULL when no data is available in some of the columns. Limit only the first 5 rows.

### 18. Highest Peak Name and Elevation by Country
For each country, find the name and elevation of the highest peak, along with its mountain. When no peaks are available in some country, display elevation 0, "(no highest peak)" as peak name and "(no mountain)" as mountain name. When multiple peaks in some country have the same elevation, display all of them. Sort the results by country name alphabetically, then by highest peak name alphabetically. Limit only the first 5 rows.
