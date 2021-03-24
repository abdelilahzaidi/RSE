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
    public class InviteService : DBConfig, IInviteRepository<Invite, int>
    {
        public bool Answer(int employeeId, int eventId, bool answer)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_InviteAnswer", true);
            command.AddParameter("EmployeeId", employeeId);
            command.AddParameter("EventId",eventId);
            command.AddParameter("Answer", answer);
            return connection.ExecuteNonQuery(command) != 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invite> Get()
        {
            throw new NotImplementedException();
        }

        public Invite Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Invite Get(int employeeId, int eventId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetInviteByIds", true);
            command.AddParameter("EmployeeId", employeeId);
            command.AddParameter("EventId", eventId);
            Func<IDataRecord, Invite> convert = (reader) => reader.ToInvite();
            return connection.ExecuteReader<Invite>(command, convert).SingleOrDefault();
        }

        public IEnumerable<Invite> GetByEmployeeId(int employeeId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetInviteAnswerByEmployeeId", true);
            command.AddParameter("EmployeeId", employeeId);
            Func<IDataRecord, Invite> convert = (reader) => reader.ToInvite();
            return connection.ExecuteReader<Invite>(command, convert);
        }

        public IEnumerable<Invite> GetByEventId(int eventId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetInviteAnswerByEventId", true);
            command.AddParameter("EventId", eventId);
            Func<IDataRecord, Invite> convert = (reader) => reader.ToInvite();
            return connection.ExecuteReader<Invite>(command, convert);
        }

        public Invite Insert(Invite entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Invite entity)
        {
            throw new NotImplementedException();
        }
    }
}
