using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    //Model Client Employee
     public class Employee : IDataObject
    {
        private int _Id;
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _Password;
        private bool _Active;
        private string _RegNat;
        private DateTime _HireDate;
        private string _Avatar;
        private string _CoordGps;
        private string _City;
        private string _Street;
        private string _Number;
        private string _NumberBox;
        private string _ZipCode;
        private string _Country;
        private int _GSM;
        private DateTime _BirthDate;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Password {
            get { return _Password; }
            set { _Password = value; }
        }

        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        public string RegNat
        {
            get { return _RegNat; }
            set { _RegNat = value; }
        }
        public DateTime HireDate
        {
            get { return _HireDate; }
            set { _HireDate = value; }
        }
        public string Avatar
        {
            get { return _Avatar; }
            set { _Avatar = value; }
        }
        public string CoordGps
        {
            get { return _CoordGps; }
            set { _CoordGps = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        public string Street
        {
            get { return _Street; }
            set { _Street = value; }
        }
        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        public string NumberBox
        {
            get { return _NumberBox; }
            set { _NumberBox = value; }
        }
        public string ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
        public int GSM
        {
            get { return _GSM; }
            set { _GSM = value; }
        }
        public DateTime BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; }
        }

        public Employee(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public Employee(int id,string email) : this(email, "********")
        {
            Id = id;
        }

        /*Sans Avatar
         * 
         * public Employee(string firstName, string lastName, string email, string password, string regNat, DateTime hireDate, string city, string street, string number, string numberBox, string zipCode, string country, int gsm, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            RegNat = regNat;
            HireDate = hireDate;
            City = city;
            Street = street;
            Number = number;
            NumberBox = numberBox;
            ZipCode = zipCode;
            Country = country;
            GSM = gsm;
            BirthDate = birthDate;
        }

        internal Employee(int id, string firstName, string lastName, string email, string password, string regNat, DateTime hireDate, string city, string street, string number, string numberBox, string zipCode, string country, int gsm, DateTime birthDate) : this(firstName, lastName, email, password, regNat, hireDate, city, street, number, numberBox, zipCode, country, gsm, birthDate)
        {
            Id = id;
        }*/

        public Employee(string firstName, string lastName, string email, string password, string regNat, DateTime hireDate, bool active, string avatar,string city, string street, string number, string numberBox, string zipCode, string country, int gsm, DateTime birthDate) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            RegNat = regNat;
            HireDate = hireDate;
            Active = active;
            Avatar = avatar;
            City = city;
            Street = street;
            Number = number;
            NumberBox = numberBox;
            ZipCode = zipCode;
            Country = country;
            GSM = gsm;
            BirthDate = birthDate;
        }

        internal Employee(int id, string firstName, string lastName, string email, string password, string regNat, DateTime hireDate, bool active, string avatar, string city, string street, string number, string numberBox, string zipCode, string country, int gsm, DateTime birthDate) : this(firstName, lastName, email, password, regNat, hireDate, active, avatar, city, street, number, numberBox, zipCode, country, gsm, birthDate)
        {
            Id = id;
        }

        public Employee(int id)
        {
            Id = id;
        }
    }
}
