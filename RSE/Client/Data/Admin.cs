using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Admin : Employee
    {
        private int _AdminId;
        private DateTime _StartDate;
        private DateTime? _EndDate;

        public int AdminId { get => _AdminId; set => _AdminId = value; }
        public bool IsAdmin { get => (_EndDate!=null)?false:true;}
        public DateTime StartDate { get => _StartDate; set => _StartDate = value; }
        public DateTime? EndDate { get => _EndDate; set => _EndDate = value; }

        public Admin(string email, string password) : base(email, password)
        {
        }

        public Admin(int id, string email) : base(id, email)
        {
        }
        public Admin(int id , string email, int adminid) : this(id,email)
        {
            AdminId = adminid;
        }
        
        public Admin(string firstName, string lastName, string email, string password, string regNat, DateTime hireDate, bool active, string avatar, string city, string street, string number, string numberBox, string zipCode, string country, int gsm, DateTime birthDate) : base(firstName, lastName, email, password, regNat, hireDate, active, avatar, city, street, number, numberBox, zipCode, country, gsm, birthDate)
        {
        }

        internal Admin(int id, string firstName, string lastName, string email, string password, string regNat, DateTime hireDate, bool active, string avatar, string city, string street, string number, string numberBox, string zipCode, string country, int gsm, DateTime birthDate) : base(id, firstName, lastName, email, password, regNat, hireDate, active, avatar, city, street, number, numberBox, zipCode, country, gsm, birthDate)
        {
        }

        internal Admin(Employee employee) : this(employee.Id, employee.FirstName, employee.LastName, employee.Email, employee.Password, employee.RegNat, employee.HireDate,employee.Active, employee.Avatar, employee.City, employee.Street, employee.Number, employee.NumberBox, employee.ZipCode, employee.Country, employee.GSM, employee.BirthDate)
        { }

        public Admin(DateTime endDate, Employee employee) : this (employee)
        {
            EndDate = endDate;
        }

        public Admin(int adminId, Employee employee) : this (employee)
        {
            AdminId = adminId;
        }

        public Admin(int adminId, DateTime startdate, DateTime? enddate, Employee employee) : this(adminId, employee)
        {
            StartDate = startdate;
            EndDate = enddate;
        }

        public Admin(int adminId, DateTime startdate,Employee employee) : this(adminId, startdate, null, employee) { }

        public Admin(int adminId, DateTime startdate, DateTime? enddate, int id, string firstName, string lastName, string email, string password, string regNat, DateTime hireDate, bool active, string avatar, string city, string street, string number, string numberBox, string zipCode, string country, int gsm, DateTime birthDate) : this(adminId, startdate, enddate, new Employee(id, firstName, lastName, email, password, regNat, hireDate, active, avatar, city, street, number, numberBox, zipCode, country, gsm, birthDate))
        {

        }
    }
}
