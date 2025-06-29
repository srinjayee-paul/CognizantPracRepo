create database EmployeeManagement;
use EmployeeManagement;

CREATE TABLE Departments ( 
	DepartmentID INT PRIMARY KEY, 
	DepartmentName VARCHAR(100) 
);

CREATE TABLE Employees ( 
	EmployeeID INT PRIMARY KEY, 
	FirstName VARCHAR(50), 
	LastName VARCHAR(50), 
	DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID), 
	Salary DECIMAL(10,2), 
	JoinDate DATE 
); 

INSERT INTO Departments (DepartmentID, DepartmentName) VALUES 
(1, 'HR'), 
(2, 'Finance'), 
(3, 'IT'), 
(4, 'Marketing'); 

INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, 
JoinDate) VALUES 
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'), 
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'), 
(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'), 
(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05');

SELECT * FROM Departments;
SELECT * FROM Employees;

create procedure sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        E.EmployeeID,
        E.FirstName,
        E.LastName,
        D.DepartmentName,
        E.Salary,
        E.JoinDate
    FROM Employees E
    INNER JOIN Departments D ON E.DepartmentID = D.DepartmentID
    WHERE E.DepartmentID = @DepartmentID;
END;
EXEC sp_GetEmployeesByDepartment @DepartmentID = 3;

EXEC sp_rename 'Employees','Employees_Old';

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);

INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
SELECT FirstName, LastName, DepartmentID, Salary, JoinDate
FROM Employees_Old;

DROP TABLE Employees_Old;

CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;

EXEC sp_InsertEmployee 
    @FirstName = 'Alice', 
    @LastName = 'Brown', 
    @DepartmentID = 2, 
    @Salary = 6200.00, 
    @JoinDate = '2022-09-01';

select * from Employees;



