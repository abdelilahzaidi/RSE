using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global
{
    public interface IDocumentRepository<TEntity,TKey>:IRepository<TEntity,TKey>
    {
        bool InsertToTask(TEntity document, TKey taskId);
        bool InsertToProject(TEntity document, TKey projectId);
        bool InsertToTeam(TEntity document, TKey teamId);
        bool InsertToEvent(TEntity document, TKey eventId);
        bool InsertToDepartment(TEntity document, TKey departmentId);
        IEnumerable<TEntity> GetByProject(TKey projectId);
        IEnumerable<TEntity> GetByTask(TKey taskId);
        IEnumerable<TEntity> GetByTeam(TKey teamId);
        IEnumerable<TEntity> GetByEvent(TKey eventId);
        IEnumerable<TEntity> GetByDepartment(TKey departmentId);
    }
}
