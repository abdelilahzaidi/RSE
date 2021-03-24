using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CD = Model.Client.Data;

namespace MVC.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string RegNat { get; set; }
        public int GSM { get; set; }
        public string Avatar { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public AddressObject Address { get; set; }
        public string CoordGPS { get; set; }

        public EmployeeModel()
        {

        }

        public EmployeeModel(CD.Employee emp)
        {
            Id = emp.Id;
            LastName = emp.LastName;
            FirstName = emp.FirstName;
            Email = emp.Email;
            Password = emp.Password;
            RegNat = emp.RegNat;
            GSM = emp.GSM;
            Avatar = emp.Avatar;
            BirthDate = emp.BirthDate;
            HireDate = emp.HireDate;
            Address = new AddressObject(emp);
            CoordGPS = emp.CoordGps;
        }
    }
}