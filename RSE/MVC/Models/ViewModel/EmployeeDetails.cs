using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class EmployeeDetails:EmployeeListItem
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMMM yyyy}")]
        [DisplayName("Date de naissance")]
        public DateTime BirthDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMMM yyyy}")]
        [DisplayName("Date d'entrée dans l'entreprise")]
        public DateTime HireDate { get; set; }
        /*[Required]
        [MaxLength(50)]
        [MinLength(1)]
        [DisplayName("Ville")]
        public string City { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(1)]
        [DisplayName("Code postal")]
        public string ZipCode { get; set; }
        [Required]
        [MaxLength(150)]
        [MinLength(1)]
        [DisplayName("Rue")]
        public string Street { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(1)]
        [DisplayName("Numéro")]
        public string Number { get; set; }
        [DisplayName("Boîte")]
        public string NumberBox { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [DisplayName("Pays")]
        public string Country { get; set; }*/
        [Required]
        [DisplayName("Numéro de registre Nationnal")]
        public string RegNat { get; set; }
        [DisplayName("Département")]
        public CurrentOn Department { get; set; }
        [DisplayName("Domicile")]
        public AddressObject Address { get; set; }


        public EmployeeDetails()
        {

        }

        public EmployeeDetails(EmployeeWithState emp, Department depart):base(emp)
        {
            BirthDate = emp.BirthDate;
            HireDate = emp.HireDate;
            Address = emp.Address;
            RegNat = emp.RegNat;
            Department = new CurrentOn(depart);
        }
    }
}