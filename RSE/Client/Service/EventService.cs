using Model.Global;
using System.Text;
using System.Threading.Tasks;
using Model.Client.Data;
using GD = Model.Global.Data;
using Model.Client.Mapper;
using GS = Model.Global.Service;
using System.Collections.Generic;
using System.Linq;

namespace Model.Client.Service
{
    public class EventService : IEventRepository<Event, int>
    {
        private IEventRepository<GD.Event, int> repositoryGlobal { get; set; }


        public EventService()
        {
            repositoryGlobal = new GS.EventService();
        }

        public bool Delete(int id)
        {
            return repositoryGlobal.Delete(id);
        }

        public IEnumerable<Event> Get()
        {
            return repositoryGlobal.Get().Select(e => e.ToClient());
        }

        public Event Get(int Id)
        {
            return repositoryGlobal.Get(Id).ToClient();
        }

        public Event Insert(Event entity)
        {
            return repositoryGlobal.Insert(entity.ToGlobal()).ToClient();
        }

        public bool Update(Event entity)
        {
            return (repositoryGlobal.Update(entity.ToGlobal()));
        }

        public bool InviteEmployee(int eventId, int employeeId)
        {
            return repositoryGlobal.InviteEmployee(eventId, employeeId);
        }

        public IEnumerable<Event> GetByEmployeeId(int creatorId)
        {
            return repositoryGlobal.GetByEmployeeId(creatorId).Select(e => e.ToClient());
        }
    }
}
