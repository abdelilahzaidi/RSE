CREATE VIEW V_Department_Employee
AS
SELECT d.Id AS DepartmentId,d.Name AS DepartmentName,d.Description AS DepartmentDescription,d.AdminId, e.Id AS EmployeeID ,  e.Active AS EmployeeActive , e.LastName AS EmployeeLastName, e.FirstName AS EmployeeFirstName, e.RegNat AS EmployeeRegNat, e.Email AS EmployeeEmail, e.GSM AS EmployeeGSM, e.City AS EmployeeCity, e.Street AS EmployeeStreet, e.Number AS EmployeeNumber, e.NumberBox AS EmployeeNumberBox, e.ZipCode AS EmployeeZipCode, e.Country AS EmployeeCountry, e.HireDate AS EmployeeHireDate, e.BirthDate AS EmployeeBirthDate, e.Avatar AS EmployeeAvatar, e.CoordGps AS EmployeeCoordGPS
  FROM Department d
  Join Employee_department ed ON d.Id=ed.DepartmentId
  Join Employee e ON ed.EmployeeId = e.Id