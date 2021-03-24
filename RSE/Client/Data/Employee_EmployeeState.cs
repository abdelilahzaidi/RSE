using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Employee_EmployeeState
    {
        private int _Id;
        private int _EmployeeId;
        private int _EmployeeStateId;
        private DateTime _StartDate;
        private DateTime _EndDate;

        public int Id { get => _Id; set => _Id = value; }
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        public int EmployeeStateId { get => _EmployeeStateId; set => _EmployeeStateId = value; }
        public DateTime StartDate { get => _StartDate; set => _StartDate = value; }
        public DateTime EndDate { get => _EndDate; set => _EndDate = value; }

        public Employee_EmployeeState(int id, int employeeId, int employeeStateId, DateTime startDate, DateTime endDate) :this(employeeId, employeeStateId, startDate, endDate)
        {
            Id = id;
        }

        public Employee_EmployeeState(int employeeId,int employeeStateId,DateTime startDate,DateTime endDate)
        {
            EmployeeId = employeeId;
            EmployeeStateId = employeeStateId;
            StartDate = startDate;
            EndDate = endDate;
        }
        public Employee_EmployeeState()
        {

        }
    }
}
