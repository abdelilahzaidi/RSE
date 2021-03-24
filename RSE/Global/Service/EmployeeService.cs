using Model.Global.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;
using System.Web;
using ToolBox.DB;
using System.Data;
using Model.Global.Mapper;

namespace Model.Global.Service
{
    public class EmployeeService : DBConfig, IEmployeeRepository<Employee, int>
    {
        
        public Employee Insert(Employee entity)
        {
            Connection connection = new Connection(InvariantName,ConnString);
            Command command = new Command("SP_RegisterEmployee", true);
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Password", entity.Password);
            command.AddParameter("RegNat", entity.RegNat);
            command.AddParameter("HireDate", entity.HireDate);
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
       

        public Employee Check(Employee entity)//login
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_CheckEmployee", true);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Password", entity.Password);
            Func<IDataRecord, Employee> convert = (reader) => reader.ToEmployeeLogin();
            return connection.ExecuteReader<Employee>(command, convert).FirstOrDefault();
        }

        public Employee Get(int Id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEmployeeById", true);
            command.AddParameter("Id", Id);
            
            Func<IDataRecord, Employee> convert = (reader) => reader.ToEmployee();
            return connection.ExecuteReader<Employee>(command, convert).FirstOrDefault();
        }

        public bool Update(Employee entity)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_UpdateEmployee", true);
            command.AddParameter("Id", entity.Id);
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("City", entity.City);
            command.AddParameter("Street", entity.Street);
            command.AddParameter("Number", entity.Number);
            command.AddParameter("NumberBox", entity.NumberBox);
            command.AddParameter("ZipCode", entity.ZipCode);
            command.AddParameter("Country", entity.Country);
            command.AddParameter("GSM", entity.GSM);

            return (connection.ExecuteNonQuery(command)!=0);
        }

        public IEnumerable<Employee> Get()
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEmployee", true);
            Func<IDataRecord, Employee> convert = (reader) => reader.ToEmployee();
            return connection.ExecuteReader<Employee>(command, convert);
        }

        public IEnumerable<Employee> GetByDepartment(int departmentId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEmployeeByDepartment", true);
            command.AddParameter("DepartmentId", departmentId);
            Func<IDataRecord, Employee> convert = (reader) => reader.ToEmployee();
            return connection.ExecuteReader<Employee>(command, convert);
        }


        public bool Delete(int id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_DeleteEmployee", true);
            command.AddParameter("Id", id);
            return (connection.ExecuteNonQuery(command)!=0);
        }

        public bool AddToDepartment(int employeeId,int departmentId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_AddEmployeeToDepartment", true);
            command.AddParameter("EmployeeId", employeeId);
            command.AddParameter("DepartmentId", departmentId);
            return (connection.ExecuteNonQuery(command)!= 0);
        }

        public IEnumerable<Employee> GetByTeamId(int teamId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEmployeeByTeamId", true);
            command.AddParameter("TeamId", teamId);
            Func<IDataRecord, Employee> convert = (reader) => reader.ToEmployee();
            return (connection.ExecuteReader<Employee>(command, convert));
        }

        public IEnumerable<Employee> GetByProjectId(int projectId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEmployeeByProjectId", true);
            command.AddParameter("ProjectId", projectId);
            Func<IDataRecord, Employee> convert = (reader) => reader.ToEmployee();
            return (connection.ExecuteReader<Employee>(command, convert));
        }

        public Employee GetByTaskId(int taskId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEmployeeOnTaskByTaskId", true);
            command.AddParameter("TaskId", taskId);
            Func<IDataRecord, Employee> convert = (reader) => reader.ToEmployee();
            return connection.ExecuteReader<Employee>(command, convert).SingleOrDefault();
        }

        public Employee GetMessageSenderByMessageId(int messageId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEmployeeSenderByMessageId", true);
            command.AddParameter("MessageId", messageId);
            Func<IDataRecord, Employee> convert = (reader) => reader.ToEmployee();
            return connection.ExecuteReader<Employee>(command, convert).SingleOrDefault();
        }

        public Employee GetMessageReceiverByMessageId(int messageId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEmployeeReceiverByEmployeeMessageId", true);
            command.AddParameter("MessageId", messageId);
            Func<IDataRecord, Employee> convert = (reader) => reader.ToEmployee();
            return connection.ExecuteReader<Employee>(command, convert).SingleOrDefault();
        }

        public IEnumerable<Employee> GetByMessageId(int messageId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEmployeeByMessageId", true);
            command.AddParameter("MessageId", messageId);
            Func<IDataRecord, Employee> convert = (reader) => reader.ToEmployee();
            return connection.ExecuteReader<Employee>(command, convert);
        }
    }
}
