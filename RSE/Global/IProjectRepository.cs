using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global
{
    public interface IProjectRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    {
        IEnumerable<TEntity> GetAll();
        bool UpdatePM(TEntity entity);
        IEnumerable<TEntity> GetByEmployeeId(TKey employeeId);
    }
}
