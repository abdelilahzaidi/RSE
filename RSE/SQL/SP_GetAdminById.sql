USE [RSE]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetEmployeeById]    Script Date: 31-10-18 14:25:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAdminById]


	@Id int 
	

AS
	BEGIN
	SELECT AdminId,IsAdmin,Date,EmployeeId,LastName,FirstName,Email,RegNat,HireDate,Avatar,City,Street,Number,NumberBox,ZipCode,Country,GSM,BirthDate FROM V_AdminDetailActive WHERE AdminId = @Id 
	END;
 
