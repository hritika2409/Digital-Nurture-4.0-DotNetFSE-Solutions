IF OBJECT_ID('sp_GetEmployeeCountByDepartment') IS NOT NULL
    DROP PROCEDURE sp_GetEmployeeCountByDepartment;
GO

CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        D.DepartmentName,
        COUNT(E.EmployeeID) AS TotalEmployees
    FROM Employees E
    INNER JOIN Departments D ON E.DepartmentID = D.DepartmentID
    WHERE E.DepartmentID = @DepartmentID
    GROUP BY D.DepartmentName;
END;
GO

EXEC sp_GetEmployeeCountByDepartment @DepartmentID = 3;
GO