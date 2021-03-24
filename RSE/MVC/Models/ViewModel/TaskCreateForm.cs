using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C = Model.Client.Data;

namespace MVC.Models.ViewModel
{
    public class TaskCreateForm
    {
        [Required]
        [DisplayName("Nom de la tâche")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Description")]
        public string Description { get; set; }
        [Required]
        [DataType("DateTime-local")]
        [DisplayName("Date de début")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType("DateTime-local")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Date limite de réalisation")]
        public DateTime DeadLine { get; set; }
        [Required]
        [DisplayName("Attribuer la tâche à :")]
        public bool TaskTeam { get; set; }
        [HiddenInput]
        public int ProjectId { get; set; }
        [HiddenInput]
        public int MainTaskId { get; set; }


        public TaskCreateForm()
        {

        }

        public TaskCreateForm(C.Task task)
        {
            Name = task.Name;
            Description = task.Description;
            StartDate = task.StartDate;
            DeadLine = task.DeadLine;
            TaskTeam = task.TaskTeam;
            ProjectId = task.ProjectId;
            MainTaskId = (task.MainTaskId!=null)?(int)task.MainTaskId:0;
        }
    }
}