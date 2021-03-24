CREATE PROCEDURE SP_CreateDepartement

@Name Nvarchar(50),
@Description Nvarchar(250),
@AdminId int

AS

BEGIN
	insert into dbo.Department(Name,Description,AdminId)
	output inserted.id
	values(@Name, @Description, @AdminId)

END