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
    public class TaskStateService : DBConfig, ITaskStateRepository<TaskState, int>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskState> Get()
        {
            Connection connection = new Connection(InvariantName,ConnString);
            Command command = new Command("SP_GetTaskState", true);
            Func<IDataRecord, TaskState> convert = (reader) => reader.ToTaskState();
            return connection.ExecuteReader<TaskState>(command, convert);
        }

        public TaskState Get(int Id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTaskStateById", true);
            command.AddParameter("Id", Id);
            Func<IDataRecord, TaskState> convert = (reader) => reader.ToTaskState();
            return connection.ExecuteReader<TaskState>(command, convert).FirstOrDefault();
        }

        public TaskState GetByTaskId(int taskId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTaskStateByTaskId", true);
            command.AddParameter("TaskId", taskId);
            Func<IDataRecord, TaskState> convert = (reader) => reader.ToTaskState();
            return connection.ExecuteReader<TaskState>(command, convert).FirstOrDefault();
        }

        public TaskState Insert(TaskState entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(TaskState employee)
        {
            throw new NotImplementedException();
        }
    }
}
