# Exercises: Data Definition and Data Types:

### 1. Create Database
You now know how to create database using the GUI of the SSMS. Now it’s time to create it using SQL queries. In that task (and the several following it) you will be required to create the database from the previous exercise using only SQL queries. Firstly, just create new database named Minions.

### 2. Create Table
In the newly created database Minions add table Minions (Id, Name, Age). Then add new table Towns (Id, Name). Set Id columns of both tables to be primary key as constraint.

### 3. Alter Minions Table
Change the structure of the Minions table to have new column TownId that would be of the same type as the Id column of Towns table. Add new constraint that makes TownId foreign key and references to Id column of Towns table.

### 4. Insert Records in Both Tables
Populate both tables with sample records given in the table below. Use only SQL queries. Insert the Id manually (don’t use identity).

### 5. Truncate Table Minions
Delete all the data from the Minions table using SQL query.

### 6. Drop All Tables
Delete all tables from the Minions database using SQL query.

### 7. Create Table People
* [Id] – unique number for every person there will be no more than 231-1 people. (Auto incremented);
* [Name] – full name of the person will be no more than 200 Unicode characters. (Not null);
* [Picture] - image with size up to 2 MB. (Allow nulls);
* [Height] – In meters. Real number precise up to 2 digits after floating point. (Allow nulls);
* [Weight] - In kilograms. Real number precise up to 2 digits after floating point. (Allow nulls);
* [Gender] - Possible states are m or f. (Not null);
* [Birthdate] - (Not null);
* [Biography] - detailed biography of the person it can contain max allowed Unicode characters. (Allow nulls).

### 8. Create Table Users
* [Id] – unique number for every user. There will be no more than 263-1 users. (Auto incremented);
* [Username] – unique identifier of the user will be no more than 30 characters (non Unicode). (Required);
* [Password] - password will be no longer than 26 characters (non Unicode). (Required);
* [ProfilePicture] – image with size up to 900 KB;
* [LastLoginTime]
* [IsDeleted] - shows if the user deleted his/her profile. Possible states are true or false.

### 9. Change Primary Key
Using SQL queries modify table Users from the previous task. First remove current primary key then create new primary key that would be the combination of fields Id and Username.

### 10. Add Check Constraint
Using SQL queries modify table Users. Add check constraint to ensure that the values in the Password field are at least 5 symbols long.

### 11. Set Default Value of a Field
Using SQL queries modify table Users. Make the default value of LastLoginTime field to be the current time.

### 12. Set Unique Filed
Using SQL queries modify table Users. Remove Username field from the primary key so only the field Id would be primary key. Now add unique constraint to the Username field to ensure that the values there are at least 3 symbols long.
