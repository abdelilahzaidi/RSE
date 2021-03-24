using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class PlanningItem
    {
        private int _Id;
        private string _Name;
        private DateTime _StartDate;
        private DateTime _EndDate;
        private int _EmployeeId;
        private string _Type;

        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public DateTime StartDate { get => _StartDate; set => _StartDate = value; }
        public DateTime EndDate { get => _EndDate; set => _EndDate = value; }
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        public string Type { get => _Type; set => _Type = value; }


        public PlanningItem(int id, string name, DateTime startdate, DateTime enddate, int employeeid, string type)
        {
            Id = id;
            Name = name;
            StartDate = startdate;
            EndDate = enddate;
            EmployeeId = employeeid;
            Type = type;
        }
    }
}
