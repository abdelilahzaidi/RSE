ALTER PROCEDURE SP_CreateProject

@Name nvarchar(50),
@Description nvarchar(250),
@Startdate datetime2,
@EndDate datetime2,
@Adminid int,

@Id int output


AS

BEGIN
	insert into dbo.Project(Name,Description,StartDate,EndDate,AdminId)
	values(@Name,@Description,@Startdate,@EndDate,@Adminid)
	set @Id = @@IDENTITY


END

