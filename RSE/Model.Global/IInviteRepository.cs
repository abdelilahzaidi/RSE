using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global
{
    public interface IInviteRepository<TEntity,TKey> : IRepository<TEntity,TKey>
    {
        IEnumerable<TEntity> GetByEmployeeId(TKey employeeId);
        IEnumerable<TEntity> GetByEventId(TKey eventId);
        TEntity Get(TKey employeeId, TKey eventId);
        bool Answer(TKey employeeId, TKey eventId, bool answer);
    }
}
