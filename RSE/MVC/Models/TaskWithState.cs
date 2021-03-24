using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CD=Model.Client.Data;

namespace MVC.Models
{
    public class TaskWithState
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public int ProjectId { get; set; }
        public bool TaskTeam { get; set; }
        public int? MainTaskId { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }

        public TaskWithState(CD.Task task, CD.TaskState taskState)
        {
            Id = task.Id;
            Name = task.Name;
            Description = task.Description;
            StartDate = task.StartDate;
            DeadLine = task.DeadLine;
            ProjectId = task.ProjectId;
            TaskTeam = task.TaskTeam;
            MainTaskId = task.MainTaskId;
            if (taskState != null) {
            StateId = taskState.Id;
            StateName = taskState.Name; }
            else
            {
                StateId = 0;
                StateName = "En cours";
            }
        }
    }
}