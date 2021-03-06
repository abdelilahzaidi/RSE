USE [RSE]
GO
/****** Object:  StoredProcedure [dbo].[SP_CheckAdmin]    Script Date: 31/10/2018 13:57:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_CheckAdmin]
	@Email nvarchar(400),
	@Password nvarchar(50)
AS
BEGIN
	SELECT EmployeeId, Email, AdminId  FROM V_AdminDetailActive WHERE Email = @Email AND Password = dbo.SF_CryptPW(@Password)
END;