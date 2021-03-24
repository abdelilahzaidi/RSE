using Model.Client.Data;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Areas.Admin.Models.ViewModel
{
    public class ProjectListItem
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Nom")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Date de début")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayName("Date de fin")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime? EndDate { get; set; }
        [DisplayName("Chef de projet")]
        public CurrentOn ProjectManager { get; set; }



        public ProjectListItem()
        {

        }

        public ProjectListItem(Project project, Employee emp)
        {
            Id = project.Id;
            Name = project.Name;
            Description = project.Description;
            StartDate = project.StartDate;
            EndDate = project.EndDate;
            ProjectManager = new CurrentOn(emp);
            
        }

    }
}