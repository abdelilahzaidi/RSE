using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class RegisterForm
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
        [DisplayName("Adresse e-mail")]
        [MaxLength(400)]
        [MinLength(5)]
        public string Email { get; set; }
        [Required]
        [DisplayName("Mot de passe")]
        [MaxLength(50)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DisplayName("Confirmer le mot de passe")]
        [MaxLength(50)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
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
    }
}