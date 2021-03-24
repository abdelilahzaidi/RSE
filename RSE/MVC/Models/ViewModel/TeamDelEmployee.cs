using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class TeamDelEmployee
    {
        #region prop
        [Required]
        [DisplayName("E-mail de l'employé")]
        [MaxLength(400)]
        [MinLength(5)]
        public string Email { get; set; }
        #endregion
        public TeamDelEmployee()
        { }
    }
    
}