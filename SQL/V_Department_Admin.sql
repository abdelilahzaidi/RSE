CREATE VIEW V_Department_Admin
AS
SELECT d.Id AS DepartmentId,d.Name AS DepartmentName,d.Description AS DepartmentDescription,d.AdminId, a.IsAdmin, a.Date AS AdminDate, a.LastName As AdminLastName, a.FirstName AS AdminFirstName, a.RegNat As AdminRegNat ,a.Email As AdminEmail, a.GSM AS AdminGSM, a.City AS AdminCity, a.Street AS AdminStreet, a.Number AS AdminNumber, a.NumberBox AS AdminNumberBox, a.ZipCode AS AdminZipCode, a.Country AS AdminCountry, a.HireDate AS AdminHireDate, a.BirthDate AS AdminBirthDate, a.Avatar AS AdminAvatar, a.CoordGps AS AdminCoordGPS
  FROM Department d
  Join V_AdminDetailFull a on d.AdminId = a.AdminID