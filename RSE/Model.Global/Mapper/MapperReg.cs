using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Global.Data;

namespace Model.Global.Mapper
{
    internal static class MapperReg
    {
        internal static Employee ToUser(this IDataRecord dr)
        {
            return new Employee()
            {
                Id = (int)dr["id"],
                LastName = (string)dr["LastName"],
                FirstName = (string)dr["FirstName"],
                Email = (string)dr["Email"],
                Password = (string)dr["Password"],
                RegNat = (string)dr["RegNat"],
                Hiredate = (DateTime)dr["HireDate"],
                City = (string)dr["City"],
                Street = (string)dr["Street"],
                Number = (string)dr["Number"],
                NumberBox = (string)dr["NumberBox"],
                ZipCode = (string)dr["ZipCode"],
                Country = (string)dr["Country"],
                GSM = (int)dr["GSM"],
                Active = (bool)dr["Active"],
                CoordGps = (string)dr["CoordGps"],
                BirthDate = (DateTime)dr["BirthDate"]




            };
        }
    }
}
