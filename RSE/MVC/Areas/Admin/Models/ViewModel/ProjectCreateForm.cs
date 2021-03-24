using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Areas.Admin.Models.ViewModel
{
    public class ProjectCreateForm
    {
        [Required]
        [DisplayName("Nom du projet")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date de lancement")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date d'échéance")]
        public DateTime? EndDate { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Entrez l'adresse mail du chef de projet")]
        public string ProjectManager { get; set; }



        public ProjectCreateForm()
        {

        }


    }
}