using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        [MinLength(6)]
        [MaxLength(64)]
        [DisplayName("Adresse e-Mail")]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginForm()
        {

        }
    }
}