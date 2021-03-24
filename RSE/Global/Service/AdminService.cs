using Model.Global.Data;
using Model.Global.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DB;

namespace Model.Global.Service
{
    public class AdminService:DBConfig,IAdminRepository<Admin,int>
    {
        public Admin Check(Admin entity)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_CheckAdmin", true);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Password", entity.Password);
            Func<IDataRecord, Admin> convert = (reader) => reader.ToAdminLogin();
            return connection.ExecuteReader<Admin>(command, convert).FirstOrDefault();
        }

        public bool Delete(int id)
        {
            Connection connection = new Connection(InvariantName,ConnString);
            Command command = new Command("SP_DeleteAdmin", true);
            command.AddParameter("@EmployeeId", id);
            return (connection.ExecuteNonQuery(command)!=0);
        }

        public Admin Get(int Id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetAdminById", true);
            command.AddParameter("Id", Id);

            Func<IDataRecord, Admin> convert = (reader) => reader.ToAdmin();
            return connection.ExecuteReader<Admin>(command, convert).FirstOrDefault();
        }

        public IEnumerable<Admin> Get()
        {
            throw new NotImplementedException();
        }

        public Admin GetByEmployeeId(int employeeId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetAdminByEmployeeId", true);
            command.AddParameter("@EmployeeId", employeeId);
            Func<IDataRecord, Admin> convert = (reader) => reader.ToAdmin();
            return connection.ExecuteReader<Admin>(command, convert).FirstOrDefault();
        }

        public Admin Insert(Admin entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(int employeeId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_AddAdmin", true);
            command.AddParameter("@EmployeeId", employeeId);
            return (connection.ExecuteNonQuery(command) != 0);
        }

        public bool IsAdminByEmployeeId(int employeeId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_IsAdminByEmployeeId", true);
            command.AddParameter("@EmployeeId", employeeId);
            Func<IDataRecord, int> convert = (reader) => (int)reader["AdminId"];
            return (connection.ExecuteReader<int>(command, convert).FirstOrDefault() != 0);
        }

        public bool ToggleIsAdmin(int employeeId)
        {
            Connection connection = new Connection(InvariantName,ConnString) ;
            Command command = new Command("SP_AddAdminOrToggle", true);
            command.AddParameter("@EmployeeId", employeeId);
            return (connection.ExecuteNonQuery(command) != 0);
        }

        public bool Update(Admin employee)
        {
            throw new NotImplementedException();
        }
    }
}
