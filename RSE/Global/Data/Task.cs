using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public int ProjectId { get; set; }
        public bool TaskTeam { get; set; }
        public int? MainTaskId { get; set; }
    }
}
