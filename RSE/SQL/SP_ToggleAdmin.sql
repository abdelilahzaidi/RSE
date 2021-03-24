CREATE PROCEDURE SP_ToggleAdmin
	@EmployeeId int
AS
BEGIN
	INSERT INTO Admin(EmployeeId,IsAdmin) VALUES (@EmployeeId, (
		SELECT ~IsAdmin FROM Admin WHERE EmployeeId = @EmployeeId AND Date =(
			SELECT Max(Date) 
			FROM Admin 
			WHERE EmployeeId = @EmployeeId)))
END;