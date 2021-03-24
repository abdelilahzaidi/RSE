CREATE PROCEDURE SP_UpdateDepartment

@Id int,
@Name nvarchar(50),
@Description nvarchar(250),
@AdminId int

AS

BEGIN 
	Update dbo.Department
	SET
		Name = @Name,
		Description = @Description
	
	WHERE Id = @Id



END