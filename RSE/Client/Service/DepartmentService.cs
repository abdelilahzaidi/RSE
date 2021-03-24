using System;
using System.Collections.Generic;
using System.Linq;
using Model.Global;
using System.Text;
using System.Threading.Tasks;
using Model.Client.Data;
using GD = Model.Global.Data;
using Model.Client.Mapper;
using GS = Model.Global.Service;

namespace Model.Client.Service
{
    public class DepartmentService : IDepartmentRepository<Department, int>
    {

        private IDepartmentRepository<GD.Department, int> repositoryGlobal { get; set; }

        public DepartmentService()
        {
            repositoryGlobal = new GS.DepartmentService();
        }

        public bool Delete(int id)
        {
            return repositoryGlobal.Delete(id);
        }

        public IEnumerable<Department> Get()
        {
            return repositoryGlobal.Get().Select(d => d.ToClient());
        }

        public Department Get(int Id)
        {
            return repositoryGlobal.Get(Id).ToClient();
        }

        public Department GetByEmployeeId(int Id)
        {
            return repositoryGlobal.GetByEmployeeId(Id).ToClient();
        }

        public Department Insert(Department entity)
        {
            return repositoryGlobal.Insert(entity.ToGlobal()).ToClient();
        }

        public bool Update(Department entity)
        {
            return (repositoryGlobal.Update(entity.ToGlobal()));
        }

        /*public bool Register(int employeeId, int departmentId)
        {
            return (repositoryGlobal.Register(employeeId,departmentId));
        }*/
    }
}
