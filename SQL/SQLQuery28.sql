USE [RSE]
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateProjectFull]    Script Date: 06/11/2018 16:04:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_CreateProjectFull]



@Name Nvarchar(50),
@Description Nvarchar(250),
@StartDate Datetime2,
@EndDate Datetime2,
@AdminId int,
@EmployeeId int


AS

BEGIN
declare @id int
	EXEC SP_CreateProject @Name,@Description,@StartDate,@EndDate, @AdminId, @id output
	EXEC SP_Employee_Project @EmployeeId, @id

END