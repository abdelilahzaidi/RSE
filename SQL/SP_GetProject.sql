CREATE PROCEDURE SP_GetProject

AS

BEGIN
	SELECT Id, Name,Description,StartDate,EndDate,AdminId FROM dbo.Project


END
