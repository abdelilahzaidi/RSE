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
    public class ProjectService : DBConfig, IProjectRepository<Project, int>
    {
        public bool Delete(int id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_DeleteProject", true);
            command.AddParameter("Id",id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public IEnumerable<Project> Get()
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetProject", true);
            Func<IDataRecord, Project> convert = (reader) => reader.ToProject();
            return connection.ExecuteReader<Project>(command, convert);
        }

        public Project Get(int Id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetProjectById", true);
            command.AddParameter("Id", Id);
            Func<IDataRecord, Project> convert = (reader) => reader.ToProject();
            return connection.ExecuteReader<Project>(command, convert).FirstOrDefault();
        }
 public Project Insert(Project entity)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_CreateProjectFull", true);
            command.AddParameter("Name", entity.Name);
            command.AddParameter("Description", entity.Description);
            command.AddParameter("StartDate", entity.StartDate);
            command.AddParameter("EndDate", entity.EndDate);
            command.AddParameter("AdminId", entity.AdminId);
            command.AddParameter("EmployeeId", entity.ProjectManager);

            entity.Id = (int)connection.ExecuteScalar(command);
            return entity;

        }
       

        public bool Update(Project project)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_UpdateProject", true);
            command.AddParameter("Id", project.Id);
            command.AddParameter("Name", project.Name);
            command.AddParameter("Description", project.Description);
            command.AddParameter("StartDate", project.StartDate);
            command.AddParameter("EndDate", project.EndDate);

            return (connection.ExecuteNonQuery(command) != 0);
        }
        public IEnumerable<Project> GetAll()
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetAllProjects", true);
            Func<IDataRecord, Project> convert = (reader) => reader.ToProject();
            return connection.ExecuteReader<Project>(command, convert);
        }

        public bool UpdatePM(Project entity)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_Employee_Project", true);
            command.AddParameter("ProjectId", entity.Id);
            command.AddParameter("EmployeeId", entity.ProjectManager);

            return (connection.ExecuteNonQuery(command) != 0);
        }

        public IEnumerable<Project> GetByEmployeeId(int employeeId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetProjectByEmployeeId", true);
            command.AddParameter("EmployeeId", employeeId);
            Func<IDataRecord, Project> convert = (reader) => reader.ToProject();
            return connection.ExecuteReader<Project>(command, convert);
        }
    }
}
