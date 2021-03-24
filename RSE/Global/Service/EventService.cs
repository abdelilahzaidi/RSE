using Model.Global.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;
using System.Web;
using ToolBox.DB;
using System.Data;
using Model.Global.Mapper;

namespace Model.Global.Service
{
    public class EventService : DBConfig, IEventRepository<Event, int>
    {
        public bool Delete(int id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_DeleteEvent", true);
            command.AddParameter("Id", id);
            return connection.ExecuteNonQuery(command) == 1;
        }

        public IEnumerable<Event> Get()
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEvent", true);
            Func<IDataRecord, Event> convert = (reader) => reader.ToEvent();
            return connection.ExecuteReader<Event>(command, convert);
        }

        public Event Get(int Id)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEventById", true);
            command.AddParameter("Id", Id);
            Func<IDataRecord, Event> convert = (reader) => reader.ToEvent();
            return connection.ExecuteReader<Event>(command, convert).SingleOrDefault();
        }

        public IEnumerable<Event> GetByEmployeeId(int creatorId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_GetEventByCreatorId", true);
            command.AddParameter("CreatorId", creatorId);
            Func<IDataRecord, Event> convert = (reader) => reader.ToEvent();
            return connection.ExecuteReader<Event>(command, convert);
        }

        public Event Insert(Event entity)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_CreateEvent", true);
            command.AddParameter("Name", entity.Name);
            command.AddParameter("Description", entity.Description);
            command.AddParameter("City", entity.City);
            command.AddParameter("Street", entity.Street);
            command.AddParameter("Number", entity.Number);
            command.AddParameter("NumberBox", entity.NumberBox);
            command.AddParameter("ZipCode", entity.ZipCode);
            command.AddParameter("Country", entity.Country);
            command.AddParameter("StartDate", entity.StartDate);
            command.AddParameter("EndDate", entity.EndDate);
            command.AddParameter("FullDay", entity.FullDay);
            command.AddParameter("EmployeeId", entity.EmployeeId);

            entity.Id = (int)connection.ExecuteScalar(command);
            return entity;
        }

        public bool InviteEmployee(int eventId, int employeeId)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_InviteEmployeeToEvent", true);
            command.AddParameter("EventId", eventId);
            command.AddParameter("EmployeeId", employeeId);
            return connection.ExecuteNonQuery(command) != 0;
        }

        public bool Update(Event entity)
        {
            Connection connection = new Connection(InvariantName, ConnString);
            Command command = new Command("SP_UpdateEvent", true);
            command.AddParameter("Id", entity.Id);
            command.AddParameter("Name", entity.Name);
            command.AddParameter("Description", entity.Description);
            command.AddParameter("City", entity.City);
            command.AddParameter("Street", entity.Street);
            command.AddParameter("Number", entity.Number);
            command.AddParameter("NumberBox", entity.NumberBox);
            command.AddParameter("ZipCode", entity.ZipCode);
            command.AddParameter("Country", entity.Country);
            command.AddParameter("StartDate", entity.StartDate);
            command.AddParameter("EndDate", entity.EndDate);
            command.AddParameter("FullDay", entity.FullDay);



            return (connection.ExecuteNonQuery(command) != 0);


        }
    }
}
