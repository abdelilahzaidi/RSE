using Model.Client.Data;
using Model.Global;
using GD = Model.Global.Data;
using GS = Model.Global.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Client.Mapper;
namespace Model.Client.Service
{
    public class EmployeeStateService : IEmployeeStateRepository<EmployeeState,int>
    {
        private IEmployeeStateRepository<GD.EmployeeState, int> repositoryGlobal { get; set; }

        public EmployeeStateService()
        {
            repositoryGlobal = new GS.EmployeeStateService();
        }
        
        public IEnumerable<EmployeeState> Get()
        {
            return repositoryGlobal.Get().Select(es => es.ToClient());
        }

        public EmployeeState Insert(EmployeeState entity)
        {
            throw new NotImplementedException();
        }

        public EmployeeState Get(int Id)
        {
            return repositoryGlobal.Get(Id).ToClient();
        }

        public bool Update(EmployeeState entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
