CREATE PROCEDURE SP_AddEmployeeToDepartment
@EmployeeId int,
@DepartmentId int
AS
BEGIN
	INSERT INTO Employee_Department(EmployeeId,DepartmentId) VALUES(@EmployeeId,@DepartmentId)
END