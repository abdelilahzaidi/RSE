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
    public class TaskEditForm
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int CurrentMainTask { get; set; }
        [Key]
        public int CurrentTaskState { get; set; }
        [Required]
        [DisplayName("Nom")]
        public string Name { get; set; }
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [DisplayName("Date de début")]
        [DataType("DateTime-local")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm}")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("Date limite de réalisation")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm}")]
        [DataType("DateTime-local")]
        public DateTime DeadLine { get; set; }
        [HiddenInput]
        public int ProjectId { get; set; }

        [HiddenInput]
        public SelectList MainTaskList { get; set; }
        [HiddenInput]
        public SelectList TaskStates { get; set; }
        [HiddenInput]
        public bool TaskTeam { get; set; }

        [DisplayName("Définir comme sous-tâche de :")]
        public string SelectedMainTask { get; set; }
        [DisplayName("Définir un statut")]
        public string SelectedTaskState { get; set; }

        public TaskEditForm()
        {

        }
        
        public TaskEditForm(CD.Task task, CD.TaskState taskState,IEnumerable<CD.Task> tasks, IEnumerable<CD.TaskState> taskStates)
        {
            Id = task.Id;
            Name = task.Name;
            Description = task.Description;
            StartDate = task.StartDate;
            DeadLine = task.DeadLine;
            ProjectId = task.ProjectId;
            TaskTeam = task.TaskTeam;

            //-------------Création de la liste des Tâches
            CurrentMainTask = (task.MainTaskId != null)? (int)task.MainTaskId : 0;
            List<SelectListItem> taskList = new List<SelectListItem>();
            foreach(CD.Task t in tasks)
            {
                taskList.Add(new SelectListItem { Value = t.Id.ToString(), Text = t.Name });
            }
            MainTaskList = new SelectList(taskList.Where(t=>t.Value!=Id.ToString()),"Value","Text");
            SelectedMainTask = CurrentMainTask.ToString();

            //-------------Création de la liste des Statuts de tâche
            CurrentTaskState = taskState.Id;
            List<SelectListItem> stateList = new List<SelectListItem>();
            foreach (CD.TaskState s in taskStates)
            {
                stateList.Add(new SelectListItem { Value = s.Id.ToString(), Text = s.Name });
            }
            TaskStates = new SelectList(stateList, "Value", "Text");
            SelectedTaskState = CurrentTaskState.ToString();
        }
    }
}