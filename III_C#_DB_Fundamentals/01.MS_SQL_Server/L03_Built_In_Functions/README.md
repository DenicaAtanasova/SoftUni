# Exercises: Built-in Functions:

## Part I - Queries for SoftUni Database  

### 1. Find Names of All Employees by First Name
Write a SQL query to find first and last names of all employees whose first name starts with “SA”.

### 2. Find Names of All employees by Last Name
Write a SQL query to find first and last names of all employees whose last name contains “ei”.

### 3. Find First Names of All Employees
Write a SQL query to find the first names of all employees in the departments with ID 3 or 10 and whose hire year is between 1995 and 2005 inclusive.

### 4. Find All Employees Except Engineers
Write a SQL query to find the first and last names of all employees whose job titles does not contain “engineer”.

### 5. Find Towns with Name Length
Write a SQL query to find town names that are 5 or 6 symbols long and order them alphabetically by town name.

### 6. Find Towns Starting With
Write a SQL query to find all towns that start with letters M, K, B or E. Order them alphabetically by town name.

### 7. Find Towns Not Starting With
Write a SQL query to find all towns that does not start with letters R, B or D. Order them alphabetically by name.

### 8. Create View Employees Hired After 2000 Year
Write a SQL query to create view V_EmployeesHiredAfter2000 with first and last name to all employees hired after 2000 year.

### 9. Length of Last Name
Write a SQL query to find the names of all employees whose last name is exactly 5 characters long.

## Part II - Queries for Geography Database  

### 10. Countries Holding ‘A’ 3 or More Times
Find all countries that holds the letter 'A' in their name at least 3 times (case insensitively), sorted by ISO code. Display the country name and ISO code.

### 11. Mix of Peak and River Names
Combine all peak names with all river names, so that the last letter of each peak name is the same as the first letter of its corresponding river name. Display the peak names, river names, and the obtained mix (mix should be in lowercase). Sort the results by the obtained mix.

## Part III - Queries for Diablo Database 

### 12. Games from 2011 and 2012 year
Find the top 50 games ordered by start date, then by name of the game. Display only games from 2011 and 2012 year. Display start date in the format “yyyy-MM-dd”.

### 13. User Email Providers
Find all users along with information about their email providers. Display the username and email provider. Sort the results by email provider alphabetically, then by username.

### 14. Get Users with IPAdress Like Pattern
Find all users along with their IP addresses sorted by username alphabetically. Display only rows that IP address matches the pattern: “***.1^.^.***”. 
Legend: [* - one symbol], [^ - one or more symbols]  

### 15. Show All Games with Duration and Part of the Day
Find all games with part of the day and duration sorted by game name alphabetically then by duration (alphabetically, not by the timespan) and part of the day (all ascending). Parts of the day should be Morning (time is >= 0 and < 12), Afternoon (time is >= 12 and < 18), Evening (time is >= 18 and < 24). Duration should be Extra Short (smaller or equal to 3), Short (between 4 and 6 including), Long (greater than 6) and Extra Long (without duration).

## Part IV - Date Functions Queries

### 16. Orders Table
You are given a table Orders(Id, ProductName, OrderDate) filled with data. Consider that the payment for that order must be accomplished within 3 days after the order date. Also the delivery date is up to 1 month. Write a query to show each product’s name, order date, pay and deliver due dates. 

### 17. People Table
Create a table People(Id, Name, Birthdate). Write a query to find age in years, months, days and minutes for each person for the current time of executing the query.