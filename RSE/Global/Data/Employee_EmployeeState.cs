using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    public class Employee_EmployeeState
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeStateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
