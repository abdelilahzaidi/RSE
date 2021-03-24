using CD = Model.Client.Data;
using GD = Model.Global.Data;
using Model.Global;
using GS = Model.Global.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Client.Mapper;

namespace Model.Client.Service
{
    public class EEmployeeStateService : IEEmployeeStateRepository<CD.Employee_EmployeeState,int>
    {
        private IEEmployeeStateRepository<GD.Employee_EmployeeState, int> repositoryGlobal { get; set; }

        public EEmployeeStateService()
        {
            repositoryGlobal = new GS.EEmployeeStateService();
        }

        public IEnumerable<CD.Employee_EmployeeState> Get()
        {
            throw new NotImplementedException();
        }

        public CD.Employee_EmployeeState Insert(CD.Employee_EmployeeState entity)
        {
            return repositoryGlobal.Insert(entity.ToGlobal()).ToClient();
        }

        public CD.Employee_EmployeeState Get(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(CD.Employee_EmployeeState entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CD.Employee_EmployeeState GetCurrentByEmployee(int employeeId)
        {
            return repositoryGlobal.GetCurrentByEmployee(employeeId).ToClient();
        }
    }
}
