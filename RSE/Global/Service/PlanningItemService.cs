using Model.Global.Data;
using Model.Global.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DB;

namespace Model.Global.Service
{
    public class PlanningItemService : DBConfig, IPlanningItemRepository<PlanningItem, int>
    {
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
        public PlanningItem Insert(PlanningItem entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(PlanningItem entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanningItem> GetByEmployeeId(int EmployeeId,DateTime StartDate, DateTime EndDate)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetPlanningItemsByEmployeeId", true);
            command.AddParameter("EmployeeId", EmployeeId);
            command.AddParameter("StartDate", StartDate);
            command.AddParameter("EndDate", EndDate);
            Func<IDataRecord, PlanningItem> convert = (reader) => reader.ToPlanning();
            return connection.ExecuteReader<PlanningItem>(command, convert);
        }

        public IEnumerable<PlanningItem>GetByMonthly(int EmployeeId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanningItem>GetByWeekly(int EmployeeId, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
