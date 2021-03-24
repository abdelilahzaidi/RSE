using System;
using System.Collections.Generic;
using System.Linq;
using Model.Global;
using System.Text;
using System.Threading.Tasks;
using Model.Client.Data;
using GD = Model.Global.Data;
using Model.Client.Mapper;
using GS = Model.Global.Service;
using ToolBox.DB;
using System.Data;

namespace Model.Client.Service
{
    public class TeamService : ITeamRepository<Team, int>
    {
        private ITeamRepository<GD.Team, int> repositoryGlobal { get; set; }
        public TeamService()
        {
            repositoryGlobal = new GS.TeamService();
        }
       

        public IEnumerable<Team> Get()
        {
            return repositoryGlobal.Get().Select(t => t.ToClient());
        }
        public IEnumerable<Team> GetByProjectId(int Id)
        {
              return repositoryGlobal.GetByProjectId(Id).Select(t => t.ToClient()); 
        }

            public Team Get(int Id)
        {
            return repositoryGlobal.Get(Id).ToClient();
        }

        public Team Insert(Team entity)
        {
            return repositoryGlobal.Insert(entity.ToGlobal()).ToClient();
        }

        public bool AddEmployee(int EmployeeId, int TeamId)
        {
            return repositoryGlobal.AddEmployee(EmployeeId, TeamId);
        }
        public bool DelEmployee(int EmployeeId, int TeamId)
        {
            return repositoryGlobal.DelEmployee(EmployeeId, TeamId);
        }

        public bool Update(Team team)
        {
            return repositoryGlobal.Update(team.ToGlobal());
        }
        public int CountEmployee(int id)
        {
            return repositoryGlobal.CountEmployee(id);
        }
        public bool Delete(int TeamId)
        {
            return repositoryGlobal.Delete( TeamId);
        }

        public Team GetByTaskId(int taskId)
        {
            return repositoryGlobal.GetByTaskId(taskId).ToClient();
        }

        public Team GetByMessageId(int messageId)
        {
            return repositoryGlobal.GetByMessageId(messageId).ToClient();
        }

        public IEnumerable<Team> GetByEmployeeId(int employeeId)
        {
            return repositoryGlobal.GetByEmployeeId(employeeId).Select(e => e.ToClient());
        }
    }
}
