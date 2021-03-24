CREATE VIEW V_AdminDetailFull AS
SELECT a.Id as AdminID, a.IsAdmin, a.Date, e.Id as EmployeeId, e.LastName,e.FirstName, e.Email, e.Password, e.Active, e.RegNat, e.HireDate, e.Avatar, e.CoordGps,e.City,e.Street,e.Number,e.NumberBox,e.ZipCode,e.Country,e.GSM,e.BirthDate FROM Admin a
JOIN Employee e ON a.EmployeeId = e.Id