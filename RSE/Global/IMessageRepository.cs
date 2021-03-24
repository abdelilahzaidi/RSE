using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global
{
    public interface IMessageRepository<TEntity,TKey> : IRepository<TEntity, TKey>
    {
        TEntity Answer(TEntity answer, TKey messageId);
        TEntity SendToEmployee(TEntity message, TKey employeeId);
        TEntity SendToTeam(TEntity message, TKey teamId);
        TEntity SendToProject(TEntity message, TKey projectId);
        TEntity SendToTask(TEntity message, TKey taskId);
        IEnumerable<TEntity> GetEmployeeMessages(TKey employeeId);
        IEnumerable<TEntity> GetProjectMessages(TKey projectId);
        IEnumerable<TEntity> GetTaskMessages(TKey taskId);
        IEnumerable<TEntity> GetTeamMessages(TKey teamId);
        IEnumerable<TEntity> GetTeamMessagesByEmployee(TKey employeeId);
        IEnumerable<TEntity> GetConversation(TKey messageId);
        TEntity GetLastMessage(TKey messageId);
    }
}
