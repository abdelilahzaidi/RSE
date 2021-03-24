using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Invite
    {
        public int EmployeeId { get; set; }
        public int EventId { get; set; }
        public bool? Present { get; set; }

        public Invite(int employeeId,int eventId, bool? present)
        {
            EmployeeId = employeeId;
            EventId = eventId;
            Present = present;
        }
    }
}
