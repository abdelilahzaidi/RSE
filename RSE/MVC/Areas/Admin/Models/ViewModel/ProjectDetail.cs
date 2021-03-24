using CD = Model.Client.Data;
using MVC.Models;
using MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Model.Client.Data;

namespace MVC.Areas.Admin.Models.ViewModel
{
    public class ProjectDetail:ProjectListItem
    {
        
        [DisplayName("Ensemble des tâches")]
        public IEnumerable<TaskListItem> Tasks { get; set; }
        //public int ProjectManager { get; set; }
        public IEnumerable<TeamListItem> Teams { get; set; }//IEnumerable n'est pas une liste mais un ensemble IEnemurable
        [DisplayName("Sujets")]
        public IEnumerable<SubjectListItem> Subjects { get; set; }
        [DisplayName("Documents")]
        public IEnumerable<DocumentList> Docs { get; set; }

        public ProjectDetail()
        {

        }

        public ProjectDetail(Project project, Employee emp, IEnumerable<TeamListItem> teams, IEnumerable<TaskListItem> tasks, IEnumerable<SubjectListItem> subjects, IEnumerable<DocumentList> docs) : this(project, emp, teams, tasks,subjects)
        {
            Docs = docs;
        }

        public ProjectDetail(Project project, Employee emp, IEnumerable<TeamListItem> teams, IEnumerable<TaskListItem> tasks, IEnumerable<SubjectListItem> subjects) : this(project, emp,teams,tasks)
        {
            Subjects = subjects;
        }

        public ProjectDetail(CD.Project project, CD.Employee emp,IEnumerable<TeamListItem> teams, IEnumerable<TaskListItem> tasks) : base(project, emp)
        {
            Tasks = (tasks != null) ? tasks.ToList() : new List<TaskListItem>();
            Teams = teams;
        }
    }
}