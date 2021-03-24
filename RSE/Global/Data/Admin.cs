using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    public class Admin
    {
        public int AdminId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RegNat { get; set; }
        public DateTime HireDate { get; set; }
        public string Avatar { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string NumberBox { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public int GSM { get; set; }
        public bool Active { get; set; }
        public string CoordGps { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
