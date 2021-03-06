using Model.Client.Data;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Models.ViewModel
{
    public class EmployeeDetail
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [DisplayName("Prénom")]
        [MaxLength(50)]
        [MinLength(1)]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Nom")]
        [MaxLength(50)]
        [MinLength(1)]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Adresse e-mail")]
        [MaxLength(400)]
        [MinLength(5)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date de naissance")]
        public DateTime BirthDate { get; set; }
        [Required]
        [DisplayName("Numéro de registre Nationnal")]
        public string RegNat { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date d'entrée dans l'entreprise")]
        public DateTime HireDate { get; set; }
        [Required]
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
        [MaxLength(10)]
        [MinLength(1)]
        [DisplayName("Boîte")]
        public string NumberBox { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [DisplayName("Pays")]
        public string Country { get; set; }
        [Required]
        [DisplayName("Numéro de Portable")]
        public int GSM { get; set; }
        [DisplayName("Département")]
        public CurrentOn Department { get; set; }

        public EmployeeDetail()
        {

        }

        public EmployeeDetail(Employee emp, Department department)
        {
            Id = emp.Id;
            FirstName = emp.FirstName;
            LastName = emp.LastName;
            Email = emp.Email;
            RegNat = emp.RegNat;
            BirthDate = emp.BirthDate;
            HireDate = emp.HireDate;
            City = emp.City;
            Country = emp.Country;
            Street = emp.Street;
            Number = emp.Number;
            NumberBox = emp.NumberBox;
            ZipCode = emp.ZipCode;
            GSM = emp.GSM;
            Department = new CurrentOn(department);
        }
    }
}