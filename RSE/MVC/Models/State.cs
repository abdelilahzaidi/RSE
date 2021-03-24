using CD = Model.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Client.Service;
using Model.Client.Data;

namespace MVC.Models
{
    public class State
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public CurrentOn EmployeeState { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public State(int id, int employeeId, DateTime startdate, DateTime enddate)
        {
            Id = id;
            EmployeeId = employeeId;
            StartDate = startdate;
            EndDate = enddate;
        }

        public State(Employee_EmployeeState ees):this(ees.Id,ees.EmployeeId,ees.StartDate,ees.EndDate)
        {
            EmployeeStateService repoempstate = new EmployeeStateService();
            EmployeeState = new CurrentOn(repoempstate.Get(ees.EmployeeStateId));
        }

        public State(int id)
        {
            EmployeeStateService repoEmpState = new EmployeeStateService();
            EEmployeeStateService repoEEmpState = new EEmployeeStateService();
            Employee_EmployeeState eEmpState = repoEEmpState.Get(id);
            if (eEmpState != null)
            {
                Id = eEmpState.Id;
                EmployeeId = eEmpState.EmployeeId;
                EmployeeState = new CurrentOn(repoEmpState.Get(eEmpState.EmployeeStateId));
                StartDate = eEmpState.StartDate;
                EndDate = eEmpState.EndDate;
            }
        }
    }
}