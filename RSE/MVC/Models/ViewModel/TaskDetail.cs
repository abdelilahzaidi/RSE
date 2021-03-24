using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using CD = Model.Client.Data;

namespace MVC.Models.ViewModel
{
    public class TaskDetail:TaskListItem
    {
        [DisplayName("Projet concerné")]
        public string ProjectName { get; set; }
        [DisplayName("Statut")]
        public string MainTaskState { get; set; }
        [DisplayName("Est une sous-tâche de :")]
        public string MainTaskName { get; set; }
        [DisplayName("Liste de tâches à finaliser avant :")]
        public IEnumerable<TaskListItem> SubTasks { get; set; }
        [DisplayName("Sujets")]
        public IEnumerable<SubjectListItem> Subjects { get; set; }
        [DisplayName("Documents")]
        public IEnumerable<DocumentList> Docs { get; set; }

        public TaskDetail()
        {

        }

        public TaskDetail(TaskWithState task, CurrentOn currentOn, string projectName, TaskWithState mainTask, IEnumerable<TaskListItem> subTask,IEnumerable<SubjectListItem> subjects,IEnumerable<DocumentList> docs) : base(task,currentOn)
        {
            ProjectName = projectName;
            if (mainTask != null)
            {
                MainTaskName = mainTask.Name;
                MainTaskState = mainTask.StateName;
            }
            SubTasks = (subTask != null)?subTask:new List<TaskListItem>();
            Subjects = (subjects != null)?subjects:new List<SubjectListItem>();
            Docs = docs;
        }
    }
}