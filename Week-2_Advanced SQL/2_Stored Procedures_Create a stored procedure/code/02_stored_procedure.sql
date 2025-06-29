DELIMITER //

CREATE PROCEDURE GetEmployeesByDepartment (
    IN deptID INT
)
BEGIN
    SELECT
        EmployeeID,
        FirstName,
        LastName,
        DepartmentID,
        Salary,
        JoinDate
    FROM Employees
    WHERE DepartmentID = deptID;
END //

DELIMITER ;
