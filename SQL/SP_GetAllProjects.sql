CREATE PROCEDURE SP_GetAllProjects

AS

BEGIN
	SELECT Id, Name,Description,StartDate,EndDate,AdminId, EmployeeId FROM dbo.V_ProjectManager


END