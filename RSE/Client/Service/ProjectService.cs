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
namespace Model.Client.Service
{
    public class ProjectService : IProjectRepository<Project, int>
    {
        private IProjectRepository<GD.Project, int> repositoryGlobal { get; set; }

        public ProjectService()
        {
            repositoryGlobal = new GS.ProjectService();
        }

        public bool Delete(int id)
        {
            return repositoryGlobal.Delete(id);
        }

        public IEnumerable<Project> Get()
        {
            return repositoryGlobal.Get().Select(p => p.ToClient());
        }

        public Project Get(int Id)
        {
            return repositoryGlobal.Get(Id).ToClient();
        }

        public Project Insert(Project entity)
        {
            return repositoryGlobal.Insert(entity.ToGlobal()).ToClient();
        }

        public bool Update(Project project)
        {
            return (repositoryGlobal.Update(project.ToGlobal()));
        }

        public IEnumerable<Project> GetAll()
        {
            return repositoryGlobal.GetAll().Select(p => p.ToClient());
        }

        public bool UpdatePM(Project project)
        {
            return (repositoryGlobal.UpdatePM(project.ToGlobal()));
        }

        public IEnumerable<Project> GetByEmployeeId(int employeeId)
        {
            return repositoryGlobal.GetByEmployeeId(employeeId).Select(p => p.ToClient());
        }
    }
}
