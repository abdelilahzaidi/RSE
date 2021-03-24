using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Model.Client.Data;

namespace MVC.Areas.Admin.Models.ViewModel
{
    public class ProjectEditForm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Nom du projet")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Date de début")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Date de fin")]
        public DateTime? EndDate { get; set; }
        [Required]
        [DisplayName("E-mail du chef de projet")]
        public string ProjectManager { get; set; }


        public ProjectEditForm()
        {

        }
        public ProjectEditForm(Project proj, Employee emp):this(proj)
        {
            ProjectManager = emp.Email;
        }
        public ProjectEditForm(Project proj)
        {
            Id = proj.Id;
            Name = proj.Name;
            Description = proj.Description;
            StartDate = proj.StartDate;
            EndDate = proj.EndDate;
        }




    }
}