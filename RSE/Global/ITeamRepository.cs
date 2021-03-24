using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global
{
    public interface ITeamRepository < TEntity, TKey>: IRepository<TEntity, TKey>
    {
        IEnumerable<TEntity> GetByProjectId(TKey projectId);
        bool AddEmployee(TKey employeeId, TKey teamId);
        bool DelEmployee(TKey employeeId, TKey teamId);
        TKey CountEmployee(TKey teamId);
        TEntity GetByTaskId(TKey taskId);
        TEntity GetByMessageId(TKey teamId);
        IEnumerable<TEntity> GetByEmployeeId(TKey employeeId);
    }
}
