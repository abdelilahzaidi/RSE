USE [RSE]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetDepartement]    Script Date: 31/10/2018 11:08:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[SP_GetDepartement]


AS

BEGIN

	SELECT Id,Name, Description, AdminId FROM Department

END;