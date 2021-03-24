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
    public class TaskListItem
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Nom")]
        public string Name { get; set; }
        [HiddenInput]
        [DisplayName("Type de tâche")]
        public bool TaskTeam { get; set; }
        [DisplayName("Date de début")]
        [DataType("DateTime-local")]
        public DateTime StartDate { get; set; }
        [DisplayName("Date limite de réalisation")]
        [DataType("DateTime-local")]
        public DateTime DeadLine { get; set; }
        [HiddenInput]
        public int ProjectId { get; set; }
        [HiddenInput]
        public int TaskStateId { get; set; }
        [DisplayName("Statut")]
        public string TaskState { get; set; }
        [DisplayName("Assigné à la tâche")]
        public CurrentOn CurrentOn { get; set; }
        [HiddenInput]
        public int? MainTaskId { get; set; }


        public TaskListItem()
        {

        }

        public TaskListItem(TaskWithState task , CurrentOn currentOn):this(task)
        {
            CurrentOn = currentOn;
        }

        public TaskListItem(CD.Task task, CD.TaskState taskState) : this(new TaskWithState(task,taskState))
        {
        }

        public TaskListItem(TaskWithState task)
        {
            Id = task.Id;
            Name = task.Name;
            TaskTeam = task.TaskTeam;
            StartDate = task.StartDate;
            DeadLine = task.DeadLine;
            ProjectId = task.ProjectId;
            MainTaskId = task.MainTaskId;
            TaskStateId = task.StateId;
            TaskState = task.StateName;
        }

        private TaskListItem(CD.Task task)
        {
            Id = task.Id;
            Name = task.Name;
            TaskTeam = task.TaskTeam;
            StartDate = task.StartDate;
            DeadLine = task.DeadLine;
            ProjectId = task.ProjectId;
            MainTaskId = task.MainTaskId;
        }
    }
}