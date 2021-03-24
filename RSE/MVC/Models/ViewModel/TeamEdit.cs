using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class TeamEdit
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int ProjectId { get; set; }
        [Required]
        [DisplayName("Nom")]
        public string Name { get; set; }
        public TeamEdit()
        {

        }

        public TeamEdit(Team team)
        {
            Id = team.Id;
            ProjectId = team.ProjectId;
            Name = team.Name;
        }
    }
}