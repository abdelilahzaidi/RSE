CREATE VIEW [dbo].[V_AdminDetailActive] AS
SELECT df.AdminId, df.IsAdmin, df.Date, df.EmployeeId, df.LastName, df.FirstName, df.Email, df.Password, df.Active, df.RegNat, df.HireDate, df.Avatar, df.CoordGps, df.City, df.Street, df.Number, df.NumberBox, df.ZipCode, df.Country, df.GSM, df.BirthDate FROM V_AdminActive a
JOIN V_AdminDetailFull df ON a.AdminId = df.AdminId
GO


