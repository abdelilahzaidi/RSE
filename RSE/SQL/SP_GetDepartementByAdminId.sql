CREATE Procedure SP_GetDepartementByAdminId

@AdminId int

AS

BEGIN

	SELECT Id,Name, Description, AdminId FROM Department WHERE AdminId = @AdminId

END;