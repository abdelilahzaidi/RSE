using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Global.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RegNat { get; set; }
        public DateTime Hiredate { get; set; }
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
