using Model.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global
{
    public interface IDepartmentRepository<TEntity,TKey>:IRepository<TEntity,TKey>
    {
        /*bool Register(TKey employeeId,TKey departmentId);*/
        TEntity GetByEmployeeId(TKey employeeId);
    }
}
