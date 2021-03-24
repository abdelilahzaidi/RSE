using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Event : IDataObject
    {
        private int _Id;
        private string _Name;
        private string _Description;
        private string _City;
        private string _Street;
        private string _Number;
        private string _NumberBox;
        private string _ZipCode;
        private string _Country;
        private DateTime _StartDate;
        private DateTime? _EndDate;
        private bool _FullDay;
        private int _EmployeeId;

        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Description { get => _Description; set => _Description = value; }
        public string City { get => _City; set => _City = value; }
        public string Street { get => _Street; set => _Street = value; }
        public string Number { get => _Number; set => _Number = value; }
        public string NumberBox { get => _NumberBox; set => _NumberBox = value; }
        public string ZipCode { get => _ZipCode; set => _ZipCode = value; }
        public string Country { get => _Country; set => _Country = value; }
        public DateTime StartDate { get => _StartDate; set => _StartDate = value; }
        public DateTime? EndDate { get => _EndDate; set => _EndDate = value; }
        public bool FullDay { get => _FullDay; set => _FullDay = value; }
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }










        public Event(int id ,string name, string description, string city, string street, string number, string numberbox, string zipcode, string country, DateTime startdate, DateTime? enddate, bool fullday, int employeeid): this(name, description,city,street,number,numberbox,zipcode,country,startdate,enddate,fullday,employeeid)
        {
            Id = id;
        }


        public Event(string name, string description, string city, string street, string number, string numberbox, string zipcode, string country, DateTime startdate, DateTime? enddate, bool fullday, int employeeid)
        {
            Name = name;
            Description = description;
            City = city;
            Street = street;
            Number = number;
            NumberBox = numberbox;
            ZipCode = zipcode;
            Country = country;
            StartDate = startdate;
            EndDate = enddate;
            FullDay = fullday;
            EmployeeId = employeeid;



        }


        public Event()
        {

        }



    }
}
