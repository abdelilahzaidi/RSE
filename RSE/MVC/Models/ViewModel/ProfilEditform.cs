using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class ProfilEditForm
    {
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

        public ProfilEditForm()
        {
            //Don't Touch or Delete the ctor!
        }

        public ProfilEditForm(Employee emp)
        {
            FirstName = emp.FirstName;
            LastName = emp.LastName;
            City = emp.City;
            Country = emp.Country;
            Street = emp.Street;
            Number = emp.Number;
            NumberBox = emp.NumberBox;
            ZipCode = emp.ZipCode;
            GSM = emp.GSM;
        }
    }
}