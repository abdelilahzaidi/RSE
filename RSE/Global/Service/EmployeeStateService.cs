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
    public class EmployeeStateService : DBConfig, IEmployeeStateRepository<EmployeeState, int>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeState> Get()
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEmployeeState", true);
            Func<IDataRecord, EmployeeState> convert = (reader) => reader.ToEmployeeState();
            return connection.ExecuteReader<EmployeeState>(command, convert);
        }

        public EmployeeState Get(int Id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEmployeeStateById", true);
            command.AddParameter("Id", Id);
            Func<IDataRecord, EmployeeState> convert = (reader) => reader.ToEmployeeState();
            return connection.ExecuteReader<EmployeeState>(command, convert).FirstOrDefault();
        }

        public EmployeeState Insert(EmployeeState entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(EmployeeState entity)
        {
            throw new NotImplementedException();
        }
    }
}
