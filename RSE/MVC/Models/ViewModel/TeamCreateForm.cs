using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    
    public class TeamCreateForm
    {
        #region prop
        [Required]
        [DisplayName("Nom")]
        [MaxLength(50)]
        [MinLength(1)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Email du chef d'équipe")]
        [MaxLength(400)]
        [MinLength(5)]
        public string TeamManagerId { get; set; }
        #endregion
        
        public TeamCreateForm()
        { }
        
        public TeamCreateForm(string name, string teamManager)
        {
            Name = name;
            TeamManagerId = teamManager;
        }
    }
}
 
