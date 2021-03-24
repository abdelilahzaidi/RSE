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
    public class TeamService : DBConfig, ITeamRepository<Team, int>
    {
        public IEnumerable<Team> Get()
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTeam", true);
            Func<IDataRecord, Team> convert = (reader) => reader.ToTeam();
            return connection.ExecuteReader<Team>(command, convert);
        }

        public IEnumerable<Team> GetByProjectId(int Id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTeamByProjectId", true);
            command.AddParameter("ProjectId", Id);
            Func<IDataRecord, Team> convert = (reader) => reader.ToTeam();
            return connection.ExecuteReader<Team>(command, convert);
        }


        public Team Get(int Id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTeamById", true);
            command.AddParameter("Id", Id);
            Func<IDataRecord, Team> convert = (reader) => reader.ToTeam();
            return connection.ExecuteReader<Team>(command, convert).SingleOrDefault();
        }
    

        /* public bool Delete(int id)
{
    Connection connection = new Connection(InvariantName, ConnString);
    Command command = new Command("SP_DeleteTeamFull", true);
    command.AddParameter("Id", id);

    return connection.ExecuteNonQuery(command) == 1;
}
public IEnumerable<Team> Get()
{
    Connection connection = new Connection(InvariantName, ConnString);
    Command command = new Command("SP_GetProject", true);
    Func<IDataRecord, Team> convert = (reader) => reader.ToTeam();
    return connection.ExecuteReader<Project>(command, convert);
}*/
        public Team Insert(Team entity)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_CreateTeamFull", true);
            command.AddParameter("Name", entity.Name);

            command.AddParameter("ProjectId", entity.ProjectId);
            command.AddParameter("EmployeeId", entity.TeamManagerId);
            Func<IDataRecord, Team> convert = (reader) => new Team()
            {
                Id = (int)reader["Id"],
                Name = entity.Name,
                ProjectId = entity.ProjectId,
                TeamManagerId = entity.TeamManagerId,
                CreateDate = (DateTime)reader["CreateDate"]
            };

            /*entity.Id = (int)connection.ExecuteScalar(command);*/
            entity = connection.ExecuteReader<Team>(command, convert).SingleOrDefault();
            return entity;

        }
        public bool AddEmployee(int EmployeeId,int TeamId)
        {
            Connection connection = new Connection(InvariantName,ConnString);// créé une connexion avec type de serveur et comment se connecter
            Command command = new Command("SP_AddEmployeeToTeam", true);//Crée une commande qui spécifie la procedure stockée appelée
            command.AddParameter("EmployeeId", EmployeeId);// ajout des parametres à notre commande selon les argument de notre procedure stockées
            command.AddParameter("TeamId", TeamId);
            return connection.ExecuteNonQuery(command) !=0; // execution de notre commande par la connection
                                                            //ExecuteReader<TypeAttendu>(command,convert) =>Elle renvoie un tableau de IDataRecord qui faudra convertir  au type attendu
                                                            //ExecuteScalar(command) =>renvoie une donnée scalaire selon les retours de notre procedure stockées(Exp Id)
                                                            //ExecuteNonQuery(command)=>renvoie 1 ou 0 selon si une modification a été éffectué

        }
        public bool DelEmployee(int EmployeeId,int TeamId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_DeleteEmployeeTeam", true);
            command.AddParameter("EmployeeId", EmployeeId);
            command.AddParameter("TeamId", TeamId);
            return connection.ExecuteNonQuery(command) != 0;

        }

        public bool Update(Team entity)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_UpdateTeamName", true);
            command.AddParameter("Id", entity.Id);
            command.AddParameter("Name", entity.Name);
            return connection.ExecuteNonQuery(command) != 0;

        
        }
        public int CountEmployee(int id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_CountNumberTeamEmployee", true);
            command.AddParameter("Id", id);
            return (int)connection.ExecuteScalar(command);


        }
        public bool Delete(int TeamId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command =new Command("SP_DeleteTeam", true);
            command.AddParameter("Id", TeamId);
            return connection.ExecuteNonQuery(command) != 0;

        }

        public Team GetByTaskId(int taskId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTeamOnTaskByTaskId", true);
            command.AddParameter("TaskId", taskId);
            Func<IDataRecord, Team> convert = (reader) => reader.ToTeam();
            return connection.ExecuteReader<Team>(command, convert).SingleOrDefault();
        }

        public Team GetByMessageId(int messageId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTeamByMessageId", true);
            command.AddParameter("MessageId", messageId);
            Func<IDataRecord, Team> convert = reader => reader.ToTeam();
            return connection.ExecuteReader<Team>(command, convert).SingleOrDefault();
        }

        public IEnumerable<Team> GetByEmployeeId(int employeeId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetTeamByEmployeeId", true);
            command.AddParameter("EmployeeId", employeeId);
            Func<IDataRecord, Team> convert = reader => reader.ToTeam();
            return connection.ExecuteReader<Team>(command, convert);
        }
    }
}

