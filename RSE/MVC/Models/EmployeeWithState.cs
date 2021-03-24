using Model.Client.Data;
using Model.Client.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CD = Model.Client.Data;

namespace MVC.Models
{
    public class EmployeeWithState
    {
        private EmployeeModel employee { get; set; }
        private State state { get; set; }

        public int Id { get { return this.employee.Id;  } }       
        public string LastName { get { return this.employee.LastName; } }       
        public string FirstName { get { return this.employee.FirstName; } }        
        public string Email { get { return this.employee.Email; } }
        public int GSM { get { return this.employee.GSM; } }
        public string RegNat { get { return this.employee.RegNat; } }
        public DateTime BirthDate { get { return this.employee.BirthDate; } }       
        public DateTime HireDate { get { return this.employee.HireDate; } }
        public AddressObject Address { get { return this.employee.Address; } }
        public string City { get { return this.employee.Address.City; } }
        public string ZipCode { get { return this.employee.Address.ZipCode; } }
        public string Street { get { return this.employee.Address.Street; } }
        public string Number { get { return this.employee.Address.Number; } }
        public string NumberBox { get { return this.employee.Address.NumberBox; } }
        public string Country { get { return this.employee.Address.Country; } }
        public int StateId { get { return (this.state == null) ? 0 : this.state.EmployeeState.Id; } }
        public string StateName { get { return (this.state == null) ? "Actif" : this.state.EmployeeState.Name; } }
        public DateTime? StartDate { get { return (this.state == null) ?null: (DateTime?)this.state.StartDate; } }
        public DateTime? EndDate { get { return (this.state == null) ? null : (DateTime?)this.state.EndDate; } }

        public EmployeeWithState(EmployeeModel emp, State empstate)
        {
            if (empstate != null)
            {
                employee = emp;
                state = empstate;
            }
        }
        public EmployeeWithState(int EmployeeId)
        {
            EmployeeService repoEmployee = new EmployeeService();
            EEmployeeStateService repostate = new EEmployeeStateService();
            employee = new EmployeeModel(repoEmployee.Get(EmployeeId));
            Employee_EmployeeState ees = repostate.GetCurrentByEmployee(EmployeeId);
            state = (ees != null)?new State(ees):null;
        }
    }
}