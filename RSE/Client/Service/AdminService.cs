using Model.Client.Data;
using GD = Model.Global.Data;
using Model.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Client.Mapper;
using GS = Model.Global.Service;

namespace Model.Client.Service
{
     public class AdminService:IAdminRepository<Admin,int>
    {
        private IAdminRepository<GD.Admin,int> repositoryGlobal { get; set; }

        public AdminService()
        {
            repositoryGlobal = new GS.AdminService();
        }

        public Admin Check(Admin entity)
        {
            return repositoryGlobal.Check(entity.ToLoginGlobal()).ToLoginClient();
        }

        public Admin Get(int Id)
        {
            return repositoryGlobal.Get(Id).ToClient();
        }

        public Admin Insert(Admin entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(int employeeId)
        {
            return repositoryGlobal.Insert(employeeId);
        }

        public bool Update(Admin employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Admin> Get()
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            return repositoryGlobal.Delete(id);
        }

        public bool IsAdminByEmployeeId(int employeeId)
        {
            return repositoryGlobal.IsAdminByEmployeeId(employeeId);
        }

        public Admin GetByEmployeeId(int employeeId)
        {
            return repositoryGlobal.GetByEmployeeId(employeeId).ToClient();
        }

        public bool ToggleIsAdmin(int employeeId)
        {
            return repositoryGlobal.ToggleIsAdmin(employeeId);
        }
    }
}
