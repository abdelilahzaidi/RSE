using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global
{
    public interface IAdminRepository<TEntity,TKey>:IRepository<TEntity,TKey>
    {
        TEntity Check(TEntity entity);
        bool IsAdminByEmployeeId(TKey employeeId);
        TEntity GetByEmployeeId(TKey employeeId);
        bool ToggleIsAdmin(TKey employeeId);
        bool Insert(TKey employeeId);
    }
}
