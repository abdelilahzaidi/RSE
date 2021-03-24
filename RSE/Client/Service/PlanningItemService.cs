using Model.Global;
using System.Text;
using System.Threading.Tasks;
using Model.Client.Data;
using GD = Model.Global.Data;
using Model.Client.Mapper;
using GS = Model.Global.Service;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Model.Client.Service
{
    public class PlanningItemService : IPlanningItemRepository<PlanningItem, int>
    {
        private IPlanningItemRepository<GD.PlanningItem, int> repositoryGlobal { get; set; }

        public PlanningItemService()
        {
            repositoryGlobal = new GS.PlanningItemService();
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanningItem> Get()
        {
            throw new NotImplementedException();
        }

        public PlanningItem Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanningItem> GetByEmployeeId(int EmployeeId,DateTime StartDate, DateTime EndDate)
        {
            return repositoryGlobal.GetByEmployeeId(EmployeeId,StartDate,EndDate).Select(e => e.ToClient());
        }

        public IEnumerable<PlanningItem> GetByMonthly(int EmployeeId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanningItem> GetByWeekly(int EmployeeId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public PlanningItem Insert(PlanningItem entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(PlanningItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
