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
    public class DocumentService: DBConfig,IDocumentRepository<Document,int>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> Get()
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetFile", true);
            Func<IDataRecord, Document> convert = (reader) => reader.ToDocument();
            return connection.ExecuteReader<Document>(command, convert);
            
        }

        public Document Get(int Id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetFileById", true);
            command.AddParameter("Id", Id);
            Func<IDataRecord, Document> convert = (reader) => reader.ToDocument();
            return connection.ExecuteReader<Document>(command, convert).SingleOrDefault();
        }

        public IEnumerable<Document> GetByDepartment(int departmentId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetDepartmentFileByDepartmentId", true);
            command.AddParameter("DepartmentId", departmentId);
            Func<IDataRecord, Document> convert = (reader) => reader.ToDocument();
            return connection.ExecuteReader<Document>(command, convert);
        }

        public IEnumerable<Document> GetByEvent(int eventId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEventFileByEventId", true);
            command.AddParameter("EventId", eventId);
            Func<IDataRecord, Document> convert = (reader) => reader.ToDocument();
            return connection.ExecuteReader<Document>(command, convert);
        }

        public IEnumerable<Document> GetByProject(int projectId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetProjectFileByProjectId", true);
            command.AddParameter("ProjectId", projectId);
            Func<IDataRecord, Document> convert = (reader) => reader.ToDocument();
            return connection.ExecuteReader<Document>(command, convert);
        }

        public IEnumerable<Document> GetByTask(int taskId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTaskFileByTaskId", true);
            command.AddParameter("TaskId", taskId);
            Func<IDataRecord, Document> convert = (reader) => reader.ToDocument();
            return connection.ExecuteReader<Document>(command, convert);
        }

        public IEnumerable<Document> GetByTeam(int teamId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTeamFileByTeamId", true);
            command.AddParameter("TeamId", teamId);
            Func<IDataRecord, Document> convert = (reader) => reader.ToDocument();
            return connection.ExecuteReader<Document>(command, convert);
        }

        public Document Insert(Document entity)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_Insert_File", true);
            command.AddParameter("Name", entity.Name);
            command.AddParameter("Description", entity.Description);
            command.AddParameter("CreateDate ", entity.CreateDate);                     
            command.AddParameter("Extention ", entity.Extention);
            command.AddParameter("EmployeeId", entity.EmployeeId);
            command.AddParameter("FileBinId ", entity.FileBinId);
            command.AddParameter("OldFileId", entity.OldFileId);
            command.AddParameter("Size", entity.Size);
            entity.Id = (int)connection.ExecuteScalar(command);
            return entity;
    }

        public bool InsertToDepartment(Document document, int departmentId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_InsertDepartmentFile", true);
            command.AddParameter("FileId", document.Id);
            command.AddParameter("DepartmentId", departmentId);
            return connection.ExecuteNonQuery(command) != 0;
        }

        public bool InsertToEvent(Document document, int eventId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_InsertEventFile", true);
            command.AddParameter("FileId", document.Id);
            command.AddParameter("EventId", eventId);
            return connection.ExecuteNonQuery(command) != 0;
        }

        public bool InsertToProject(Document document, int projectId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_InsertProjectFile", true);
            command.AddParameter("FileId", document.Id);
            command.AddParameter("ProjectId", projectId);
            return connection.ExecuteNonQuery(command) != 0;
        }

        public bool InsertToTask(Document document, int taskId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_InsertTaskFile", true);
            command.AddParameter("FileId", document.Id);
            command.AddParameter("TaskId", taskId);
            return connection.ExecuteNonQuery(command) != 0;
        }

        public bool InsertToTeam(Document document, int teamId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_InsertTeamFile", true);
            command.AddParameter("FileId", document.Id);
            command.AddParameter("TeamId", teamId);
            return connection.ExecuteNonQuery(command) != 0;
        }

        public bool Update(Document entity)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_UpdateFileDescription", true);
            command.AddParameter("Id",entity.Id);
            command.AddParameter("Description", entity.Description);
            return (connection.ExecuteNonQuery(command) != 0);
        }
    }
}
