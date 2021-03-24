CREATE PROCEDURE [dbo].[SP_GetEmployeeNotInDepartment] 

@DepartmentId int
AS
BEGIN
	SELECT  DepartmentId 
      ,DepartmentName
      ,DepartmentDescription
      ,AdminId
      ,JoinDate
      ,EmployeeID as id
      ,EmployeeActive as Active
      ,EmployeeLastName as LastName
      ,EmployeeFirstName as FirstName
      ,EmployeeRegNat as RegNat
      ,EmployeeEmail as Email
      ,EmployeeGSM as GSM
      ,EmployeeCity as City
      ,EmployeeStreet as Street
      ,EmployeeNumber as Number
      ,EmployeeNumberBox as NumberBox
      ,EmployeeZipCode as ZipCode
      ,EmployeeCountry as Country
      ,EmployeeHireDate as HireDate
      ,EmployeeBirthDate as BirthDate
      ,EmployeeAvatar as Avatar
      ,EmployeeCoordGPS as CoordGPS
  FROM [RSE].[dbo].[V_Department_Employee_Now]
  where DepartmentId!=@DepartmentId
 End  
GO


