using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class AddressObject
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string NumberBox { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string GMapAddress { get { return (Street + " " + Number + " " + NumberBox + ", " + ZipCode + " " + City + " " + Country).Replace(" ", "+"); } }


        public AddressObject(Event evenement)
        {
            City = evenement.City;
            Street = evenement.Street;
            Number = evenement.Number;
            NumberBox = evenement.NumberBox;
            ZipCode = evenement.ZipCode;
            Country = evenement.Country;
        }

        public AddressObject(Employee employee)
        {
            City = employee.City;
            Street = employee.Street;
            Number = employee.Number;
            NumberBox = employee.NumberBox;
            ZipCode = employee.ZipCode;
            Country = employee.Country;
        }
    }
}