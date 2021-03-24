using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CD = Model.Client.Data;

namespace MVC.Models.ViewModel
{
    public class TaskHierarchy
    {
        private bool _TaskTeam;
        [Key]
        public int Id { get; set; }
        [Key]
        public int ProjectId { get; set; }
        [Key]
        public int TaskStateId { get; set; }
        [Key]
        public int? MainTaskId { get; set; }

        [DisplayName("Nom")]
        public string Name { get; set; }
        [HiddenInput]
        [DisplayName("Type de tâche")]
        public string TaskTeam { get { return (_TaskTeam) ? "Équipe" : "Employee"; } }
        [DisplayName("Date de début")]
        [DataType("DateTime-local")]
        public DateTime StartDate { get; set; }
        [DisplayName("Date limite de réalisation")]
        [DataType("DateTime-local")]
        public DateTime DeadLine { get; set; }
        [DisplayName("Statut")]
        public string TaskState { get; set; }
        [DisplayName("Assigné à la tâche")]
        public string CurrentOn { get; set; }

        public List<TaskHierarchy> SubTasks { get; set; }
        


        public TaskHierarchy()
        {

        }

        public TaskHierarchy(CD.Task task, CD.TaskState taskState, IEnumerable<TaskHierarchy> subTasks) : this(task,taskState)
        {
            SubTasks = subTasks.ToList();
        }

        public TaskHierarchy(CD.Task task, CD.TaskState taskState, string currentOn) : this(task, taskState)
        {
            CurrentOn = currentOn;
        }

        public TaskHierarchy(CD.Task task, CD.TaskState taskState) : this(task)
        {
            TaskStateId = taskState.Id;
            TaskState = taskState.Name;
        }

        private TaskHierarchy(CD.Task task)
        {
            Id = task.Id;
            Name = task.Name;
            _TaskTeam = task.TaskTeam;
            StartDate = task.StartDate;
            DeadLine = task.DeadLine;
            ProjectId = task.ProjectId;
            MainTaskId = task.MainTaskId;
        }
    }
}