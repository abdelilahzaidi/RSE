using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global
{
    public interface ITaskStateRepository<TEntity,TKey> : IRepository<TEntity,TKey>
    {
        TEntity GetByTaskId(TKey taskId);
    }
}
