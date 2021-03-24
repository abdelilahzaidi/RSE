using Model.Client.Data;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.ViewModel
{ 

    public class TeamListItem
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Nom de l'équipe")]
        public string Name { get; set; }
        [DisplayName("Date de création")]
        public DateTime CreateDate { get; set; }
        [Key]
        [DisplayName("Chef d'équipe")]
        public CurrentOn TeamManager { get; set; }
        [Key]
        public int ProjectId { get; set; }

        public TeamListItem(Team t, Employee teamManager):this(t)
        {
            TeamManager = new CurrentOn(teamManager);
        }

        public TeamListItem(Team t)
        {
            Id = t.Id;
            Name = t.Name;
            CreateDate = t.CreateDate;
            ProjectId = t.ProjectId;
        }

        public TeamListItem()
        {

        }

       

        
    }
}