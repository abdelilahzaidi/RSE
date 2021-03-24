using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global
{
    public interface IEventRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    {
        IEnumerable<TEntity> GetByEmployeeId(TKey creatorId);
        bool InviteEmployee(TKey eventId, TKey employeeId);
    }
}
