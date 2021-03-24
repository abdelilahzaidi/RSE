CREATE VIEW [dbo].[V_AdminActive] AS
	SELECT Detail.AdminId, Detail.EmployeeId, Detail.Date, Detail.IsAdmin FROM V_AdminDetailFull AS Detail
	WHERE Detail.IsAdmin = 1
GO


