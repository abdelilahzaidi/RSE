using CD = Model.Client.Data;
using GD = Model.Global.Data;
using GS = Model.Global.Service;
using Model.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Client.Mapper;

namespace Model.Client.Service
{
    public class InviteService:IInviteRepository<CD.Invite,int>
    {
        private IInviteRepository<GD.Invite,int> repositoryGlobal { get; set; }

        public InviteService()
        {
            repositoryGlobal = new GS.InviteService();
        }

        public IEnumerable<CD.Invite> GetByEmployeeId(int employeeId)
        {
            return repositoryGlobal.GetByEmployeeId(employeeId).Select(i => i.ToClient());
        }

        public IEnumerable<CD.Invite> GetByEventId(int eventId)
        {
            return repositoryGlobal.GetByEventId(eventId).Select(i => i.ToClient());
        }

        public IEnumerable<CD.Invite> Get()
        {
            throw new NotImplementedException();
        }

        public CD.Invite Insert(CD.Invite entity)
        {
            throw new NotImplementedException();
        }

        public CD.Invite Get(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(CD.Invite entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CD.Invite Get(int employeeId, int eventId)
        {
            return repositoryGlobal.Get(employeeId, eventId).ToClient();
        }

        public bool Answer(int employeeId, int eventId, bool answer)
        {
            return repositoryGlobal.Answer(employeeId, eventId, answer);
        }
    }
}
