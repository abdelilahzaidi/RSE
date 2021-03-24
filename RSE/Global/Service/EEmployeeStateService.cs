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
    public class EEmployeeStateService : DBConfig, IEEmployeeStateRepository<Employee_EmployeeState, int>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee_EmployeeState> Get()
        {
            throw new NotImplementedException();
        }

        public Employee_EmployeeState Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Employee_EmployeeState GetCurrentByEmployee(int employeeId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEmployeeStateByEmployeeId", true);
            command.AddParameter("EmployeeId", employeeId);
            Func<IDataRecord, Employee_EmployeeState> convert = reader => reader.ToEmployee_EmployeeState();
            return connection.ExecuteReader<Employee_EmployeeState>(command,convert).FirstOrDefault();
        }

        public Employee_EmployeeState Insert(Employee_EmployeeState entity)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_InsertEmployee_EmployeeState", true);
            command.AddParameter("EmployeeId", entity.EmployeeId);
            command.AddParameter("EmployeeStateId", entity.EmployeeStateId);
            command.AddParameter("StartDate", entity.StartDate);
            command.AddParameter("EndDate", entity.EndDate);
            entity.Id = (int)connection.ExecuteScalar(command);
            return entity;
        }

        public bool Update(Employee_EmployeeState entity)
        {
            throw new NotImplementedException();
        }
    }
}
