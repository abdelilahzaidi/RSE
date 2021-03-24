using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data = Model.Global.Data;
using ToolBox.DB;
using System.Data;
using Model.Global.Mapper;

namespace Model.Global.Service
{
    public class TaskService : DBConfig, ITaskRepository<Data.Task, int>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Data.Task> Get()
        {
            Connection connection = new Connection (InvariantName,ConnString);
            Command command = new Command("SP_GetTask", true);
            Func<IDataRecord, Data.Task> convert = (reader) => reader.ToTask();
            return connection.ExecuteReader<Data.Task>(command, convert);
        }

        public Data.Task Get(int Id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTaskById", true);
            command.AddParameter("Id", Id);
            Func<IDataRecord, Data.Task> convert = (reader) => reader.ToTask();
            return connection.ExecuteReader<Data.Task>(command, convert).FirstOrDefault();
        }

        public Data.Task Insert(Data.Task entity)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_AddTask", true);
            command.AddParameter("Name", entity.Name);
            command.AddParameter("Description", entity.Description);
            command.AddParameter("StartDate", entity.StartDate);
            command.AddParameter("DeadLine", entity.DeadLine);
            command.AddParameter("ProjectId", entity.ProjectId);
            command.AddParameter("TaskTeam", entity.TaskTeam);
            entity.Id = (int)connection.ExecuteScalar(command);
            return entity;
        }

        public bool Update(Data.Task task)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_UpdateTask", true);
            command.AddParameter("Id", task.Id);
            command.AddParameter("Name", task.Name);
            command.AddParameter("Description", task.Description);
            command.AddParameter("StartDate", task.StartDate);
            command.AddParameter("DeadLine", task.DeadLine);
            return connection.ExecuteNonQuery(command) != 0;
        }

        public IEnumerable<Data.Task> GetByProjectId(int projectId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTaskByProjectId", true);
            command.AddParameter("ProjectId", projectId);
            Func<IDataRecord, Data.Task> convert = (reader) => reader.ToTask();
            return connection.ExecuteReader<Data.Task>(command, convert);
        }

        public IEnumerable<Data.Task> GetMainHierarchy(int taskId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTaskMainHierarchy", true);
            command.AddParameter("TaskId", taskId);
            Func<IDataRecord, Data.Task> convert = (reader) => reader.ToTask();
            return connection.ExecuteReader<Data.Task>(command, convert);
        }

        public IEnumerable<Data.Task> GetSubHierarchy(int taskId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTaskSubHierarchy", true);
            command.AddParameter("TaskId", taskId);
            Func<IDataRecord, Data.Task> convert = (reader) => reader.ToTask();
            return connection.ExecuteReader<Data.Task>(command, convert);
        }

        public bool InsertMainTask(int taskId, int mainTaskId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_InsertTask_Task", true);
            command.AddParameter("MainTaskId", mainTaskId);
            command.AddParameter("TaskId", taskId);
            return connection.ExecuteNonQuery(command) != 0;
        }

        public bool UpdateMainTask(int taskId, int mainTaskId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_UpdateTask_Task", true);
            command.AddParameter("MainTaskId",mainTaskId);
            command.AddParameter("TaskId",taskId);
            return connection.ExecuteNonQuery(command) != 0;
        }

        public bool DeleteMainTask(int taskId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_DeleteTask_Task", true);
            command.AddParameter("TaskId",taskId);
            return connection.ExecuteNonQuery(command) != 0;
        }

        public bool InsertTaskState(int taskId, int taskStateId)
        {
            Connection connection = new Connection(InvariantName,ConnString);
            Command command = new Command("SP_InsertTask_TaskState", true);
            command.AddParameter("TaskId",taskId);
            command.AddParameter("TaskStateId",taskStateId);
            return (connection.ExecuteNonQuery(command)) != 0;
        }

        public Data.Task GetMainTask(int taskId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetMainTaskByTaskId", true);
            command.AddParameter("TaskId", taskId);
            Func<IDataRecord, Data.Task> convert = (reader) => reader.ToTask();
            return connection.ExecuteReader<Data.Task>(command, convert).SingleOrDefault();
        }

        public bool AssignTeam(int taskId, int teamId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_AddTaskToTeam", true);
            command.AddParameter("TaskId", taskId);
            command.AddParameter("TeamId", teamId);
            return connection.ExecuteNonQuery(command) != 0;
        }

        public bool AssignEmployee(int taskId, int employeeId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_AddTaskToEmployee", true);
            command.AddParameter("TaskId", taskId);
            command.AddParameter("EmployeeId", employeeId);
            return connection.ExecuteNonQuery(command) != 0;
        }

        public IEnumerable<Data.Task> GetByEmployeeId(int employeeId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTaskByEmployeeId", true);
            command.AddParameter("EmployeeId", employeeId);
            Func<IDataRecord, Data.Task> convert = (reader) => reader.ToTask();
            return connection.ExecuteReader<Data.Task>(command, convert);
        }

        /*OLD PROCEDURE
         * 
         * public bool SetTask_TaskEmployee(int taskId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_SetTask_TaskEmployee", true);
            command.AddParameter("TaskId", taskId);
            return (connection.ExecuteNonQuery(command) != 0);
        }

        public bool SetTask_TaskTeam(int taskId)
        {
            Connection connection = new Connection(InvariantName,ConnString);
            Command command = new Command("SP_SetTask_TaskTeam", true);
            command.AddParameter("TaskId", taskId);
            return (connection.ExecuteNonQuery(command) != 0);
        }*/
    }
}
