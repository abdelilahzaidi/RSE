USE [RSE]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetDepartementByID]    Script Date: 31/10/2018 11:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[SP_GetDepartementByID]

@Id int

AS

BEGIN

	SELECT Id,Name, Description, AdminId FROM Department WHERE Id = @Id

END;