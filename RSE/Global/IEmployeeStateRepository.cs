using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global
{
    public interface IEmployeeStateRepository<TEntity,TKey> : IRepository<TEntity,TKey>
    {
    }
}
