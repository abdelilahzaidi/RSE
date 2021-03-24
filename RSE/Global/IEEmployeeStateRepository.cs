using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global
{
    public interface IEEmployeeStateRepository<TEntity,TKey> : IRepository<TEntity,TKey>
    {
        TEntity GetCurrentByEmployee(TKey employeeId);
    }
}
