using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD=Model.Client.Data;
using Model.Client.Mapper;
using Model.Global;
using GD = Model.Global.Data;
using GS = Model.Global.Service;

namespace Model.Client.Service
{
    public class DocumentService : IDocumentRepository<CD.Document,int>
    {
        private IDocumentRepository<GD.Document, int> RepositoryGlobal { get; set; }
        public DocumentService()
        {
            RepositoryGlobal = new GS.DocumentService();

        }
        public IEnumerable<CD.Document> Get()
        {
            return RepositoryGlobal.Get().Select(t => t.ToClient());
        }

        public CD.Document Get(int Id)
        {
            return RepositoryGlobal.Get(Id).ToClient();
        }
        public CD.Document Insert(CD.Document entity)
        {
            return RepositoryGlobal.Insert(entity.ToGlobal()).ToClient();
        }

        public bool Update(CD.Document entity)
        {
            return (RepositoryGlobal.Update(entity.ToGlobal()));
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool InsertToTask(CD.Document document, int taskId)
        {
            return RepositoryGlobal.InsertToTask(document.ToGlobal(), taskId);
        }

        public bool InsertToProject(CD.Document document, int projectId)
        {
            return RepositoryGlobal.InsertToProject(document.ToGlobal(), projectId);
        }

        public bool InsertToTeam(CD.Document document, int teamId)
        {
            return RepositoryGlobal.InsertToTeam(document.ToGlobal(), teamId);
        }

        public bool InsertToEvent(CD.Document document, int eventId)
        {
            return RepositoryGlobal.InsertToEvent(document.ToGlobal(), eventId);
        }

        public bool InsertToDepartment(CD.Document document, int departmentId)
        {
            return RepositoryGlobal.InsertToDepartment(document.ToGlobal(), departmentId);
        }

        public IEnumerable<CD.Document> GetByProject(int projectId)
        {
            return RepositoryGlobal.GetByProject(projectId).Select(d => d.ToClient());
        }

        public IEnumerable<CD.Document> GetByTask(int taskId)
        {
            return RepositoryGlobal.GetByTask(taskId).Select(d => d.ToClient());
        }

        public IEnumerable<CD.Document> GetByTeam(int teamId)
        {
            return RepositoryGlobal.GetByTeam(teamId).Select(d => d.ToClient());
        }

        public IEnumerable<CD.Document> GetByEvent(int eventId)
        {
            return RepositoryGlobal.GetByEvent(eventId).Select(d => d.ToClient());
        }

        public IEnumerable<CD.Document> GetByDepartment(int departmentId)
        {
            return RepositoryGlobal.GetByDepartment(departmentId).Select(d => d.ToClient());
        }
    }
}
