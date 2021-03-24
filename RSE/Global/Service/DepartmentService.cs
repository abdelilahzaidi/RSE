using Model.Global.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Web;
using ToolBox.DB;
using System.Data;
using Model.Global.Mapper;
using System.Configuration;

namespace Model.Global.Service
{
    public class DepartmentService : DBConfig, IDepartmentRepository<Department, int>
    {        
        public bool Delete(int id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_DeleteDepartment", true);
            command.AddParameter("@Id", id);
            return (connection.ExecuteNonQuery(command) != 0);
        }

        public IEnumerable<Department> Get()
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetActiveDepartment", true);
            Func<IDataRecord, Department> convert = (reader) => reader.ToDepartment();
            return connection.ExecuteReader<Department>(command, convert);
        }

        public Department Get(int Id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetDepartmentById", true);
            command.AddParameter("Id", Id);
            Func<IDataRecord, Department> convert = (reader) => reader.ToDepartment();
            return connection.ExecuteReader<Department>(command,convert).SingleOrDefault();
        }

        public Department Insert(Department entity)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_CreateDepartment", true);
            command.AddParameter("Name", entity.Name);
            command.AddParameter("Description", entity.Description);
            command.AddParameter("AdminId", entity.AdminId);
            entity.Id = (int)connection.ExecuteScalar(command);

            return entity;
        }
        /*
        public bool Register(int employeeId, int departmentId)
        {
            Connection connection = new Connection(InvariantName,ConnString);
            Command command = new Command("SP_AddEmployeeToDepartment", true);
            command.AddParameter("EmployeeId", employeeId);
            command.AddParameter("DepartmentId", departmentId);
            return (connection.ExecuteNonQuery(command)!=0);
        }*/

        public bool Update(Department entity)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_UpdateDepartment", true);
            command.AddParameter("Id", entity.Id);
            command.AddParameter("Name", entity.Name);
            command.AddParameter("Description", entity.Description);
            command.AddParameter("AdminId", entity.AdminId);

            return (connection.ExecuteNonQuery(command) != 0);

        }

        public Department GetByEmployeeId(int employeeId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetDepartmentByEmployee", true);
            command.AddParameter("EmployeeId", employeeId);
            Func<IDataRecord, Department> convert = (reader) => reader.ToDepartment();
            return connection.ExecuteReader<Department>(command, convert).FirstOrDefault();
        }
    }
}
