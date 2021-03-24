using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global
{
     public interface IPlanningItemRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    {
        IEnumerable<TEntity> GetByEmployeeId(TKey EmployeeId, DateTime StartDate, DateTime EndDate);
        IEnumerable<TEntity> GetByMonthly(TKey EmployeeId, DateTime date);
        IEnumerable<TEntity> GetByWeekly(TKey EmployeeId, DateTime date);
    }
}
