# Exercises: Table Relations

### 1. One-To-One Relationship
Create two tables as follows. Use appropriate data types.
* **Persons** - (PersonID, FristName, Salary, PassportID)
* **Passports** - (PassportID, PassportNumber)   
Alter the customers table and make PersonID a primary key. Create a foreign key between Persons and Passports by using PassportID column.

### 2. One-To-Many Relationship
Create two tables as follows. Use appropriate data types.
* **Models** - (ModelID, Name, ManufacturerID)
* **Manufacturers** - (ManufacturerID, Name, EstablishedOn)  
Add primary keys and foreign keys.

### 3. Many-To-Many Relationship
Create three tables as follows. Use appropriate data types.
* **Students** - (StudentID, Name)
* **Exams** - (ExamID, Name)
* **StudentsExams** - (StudentID, ExamID)  
Add primary keys and foreign keys. Have in mind that table StudentsExams should have a composite primary key.

### 4. Self-Referencing
Create a single table as follows. Use appropriate data types.  
* **Teachers** - (TeacherID, Name, ManagerID)  
Add primary keys and foreign keys. The foreign key should be between ManagerId and TeacherId.

### 5. Online Store Database
Create a new database and design the following structure:
![alt text](https://github.com/DenicaAtanasova/SoftUni/blob/master/III_C%23_DB_Fundamentals/01.MS_SQL_Server/L05_Table_Relations/Store_Database_Diagram.png "Store Database Diagram")

### 6. University Database
Create a new database and design the following structure:
![alt text](https://github.com/DenicaAtanasova/SoftUni/blob/master/III_C%23_DB_Fundamentals/01.MS_SQL_Server/L05_Table_Relations/University_Database_Diagram.png "University Database Diagram")

### 7. Peaks in Rila
Display all peaks for "Rila" mountain. Include:
* MountainRange
* PeakName
* Elevation  
Peaks should be sorted by elevation descending