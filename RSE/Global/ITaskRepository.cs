using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global
{
    public interface ITaskRepository<TEntity,TKey> : IRepository<TEntity,TKey>
    {
        TEntity GetMainTask(TKey taskId);
        IEnumerable<TEntity> GetByProjectId(TKey projectId);
        IEnumerable<TEntity> GetMainHierarchy(TKey taskId);
        IEnumerable<TEntity> GetSubHierarchy(TKey taskId);
        bool InsertMainTask(TKey taskId, TKey mainTaskId);
        bool UpdateMainTask(TKey taskId, TKey mainTaskId);
        bool DeleteMainTask(TKey taskId);
        bool InsertTaskState(TKey taskId, TKey taskStateId);
        bool AssignTeam(TKey taskId, TKey teamId);
        bool AssignEmployee(TKey taskId, TKey employeeId);
        IEnumerable<TEntity> GetByEmployeeId(TKey employeeId);
        /*OLD PROCEDURE
         * 
         * bool SetTask_TaskTeam(TKey taskId);
        bool SetTask_TaskEmployee(TKey taskId);*/
    }
}
