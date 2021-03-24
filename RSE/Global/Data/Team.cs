using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    public class Team
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int ProjectId { get; set; }
        public int TeamManagerId { get; set; }
    }
}
