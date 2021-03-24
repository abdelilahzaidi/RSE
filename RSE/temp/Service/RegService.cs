using Model.Global.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;
using System.Web;
using ToolBox.DB;

namespace Model.Global.Service
{
    public class RegService : IRepository<Employee, int>
    {
        public Employee Insert(Employee entity)
        {
            //Connection connection = new Connection(ConfigurationManager.ConnectionStrings["MSSQLConnection"].Providername, ConfigurationManager.ConnectionStrings["MSSQLConnection"].ConnectionString);
            Connection connection = new Connection("System.Data.SqlClient",@"Data Source = FORMAVDI1610\TFTIC; Initial Catalog = RSE; Persist Security Info = True; User ID = devAccess; Password = tftic@2012");
            Command command = new Command("SP_RegisterEmployee", true);
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Password", entity.Password);
            command.AddParameter("RegNat", entity.RegNat);
            command.AddParameter("HireDate", entity.Hiredate);
            command.AddParameter("City", entity.City);
            command.AddParameter("Street", entity.Street);
            command.AddParameter("Number", entity.Number);
            command.AddParameter("NumberBox", entity.NumberBox);
            command.AddParameter("ZipCode", entity.ZipCode);
            command.AddParameter("Country", entity.Country);
            command.AddParameter("GSM", entity.GSM);
            command.AddParameter("BirthDate", entity.BirthDate);

            entity.Id = (int)connection.ExecuteScalar(command);

            return entity;




        }
    }
}
