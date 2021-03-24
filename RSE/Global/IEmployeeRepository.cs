using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global
{
    public interface IEmployeeRepository<TEntity,TKey> : IRepository<TEntity,TKey>
    {
        TEntity Check(TEntity entity);
        IEnumerable<TEntity> GetByDepartment(TKey departmentId);
        bool AddToDepartment(TKey employeeId, TKey departmentId);
        IEnumerable<TEntity> GetByTeamId(TKey teamId);
        IEnumerable<TEntity> GetByProjectId(TKey projectId);
        TEntity GetByTaskId(TKey taskId);
        TEntity GetMessageSenderByMessageId(TKey messageId);
        TEntity GetMessageReceiverByMessageId(TKey messageId);
        IEnumerable<TEntity> GetByMessageId(TKey messageId);
    }
}
