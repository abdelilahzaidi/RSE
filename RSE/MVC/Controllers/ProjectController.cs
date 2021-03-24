using CD = Model.Client.Data;
using Model.Client.Service;
using MVC.Areas.Admin.Models.ViewModel;
using MVC.Infrastructure;
using M = MVC.Models;
using MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Client.Data;

namespace MVC.Controllers
{
    [AuthRequired]
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index(bool? showAll)
        {
            if (showAll.HasValue && showAll.Value == true)
            {
                ProjectService projrepo = new ProjectService();
                IEnumerable<CD.Project> projects = projrepo.GetAll();
                List<ProjectListItem> finalList = new List<ProjectListItem>();
                foreach (CD.Project proj in projects)
                {
                    EmployeeService empRepo = new EmployeeService();
                    ProjectListItem projectList = new ProjectListItem(proj, empRepo.Get(proj.ProjectManager));
                    finalList.Add(projectList);
                }
                return View(finalList);
            }
            else
            {
                ProjectService projrepo = new ProjectService();
                IEnumerable<CD.Project> projects = projrepo.Get();
                List<ProjectListItem> finalList = new List<ProjectListItem>();
                foreach (CD.Project proj in projects)
                {
                    EmployeeService empRepo = new EmployeeService();
                    ProjectListItem projectList = new ProjectListItem(proj, empRepo.Get(proj.ProjectManager));
                    finalList.Add(projectList);
                }
                return View(finalList);
            }
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            ProjectService projrepo = new ProjectService();
            EmployeeService repemp = new EmployeeService();
            CD.Project project = projrepo.Get(id);
            TaskService repoTask = new TaskService();
            TaskStateService repoTS = new TaskStateService();
            TeamService teamrepo = new TeamService();
            MessageService repoMessage = new MessageService();
            DocumentService repoDoc = new DocumentService();
            IEnumerable<CD.Task> tasks = repoTask.GetByProjectId(id);
            /*--------------Possible mainTasks.groupJoin(tasks) pour arboresence?...
            IEnumerable<Task> mainTasks = tasks.Where(t => t.MainTaskId == null);*/

            List<TaskListItem> taskList = new List<TaskListItem>();
            foreach (CD.Task t in tasks) {
                M.CurrentOn currentOn = (t.TaskTeam)?new M.CurrentOn(teamrepo.GetByTaskId(t.Id)):new M.CurrentOn(repemp.GetByTaskId(t.Id));
                TaskListItem taskListItem = new TaskListItem(new M.TaskWithState(t, repoTS.GetByTaskId(t.Id)),currentOn);
                taskList.Add(taskListItem);
            }

            IEnumerable<CD.Team> teams = teamrepo.GetByProjectId(id);//prendre un iEINumeralbe de team qui correspond à l'ensemble des equipes, faisant partie d'un seul et même projet
            /*List<TeamList> tfinalList = new List<TeamList>();// on créer une liste vide de teamlist
            foreach (Team t in teams)//Pour chaque equipe de notre ennsemble d'equipe faisant partie d'un mememe et seul projet
            {
                EmployeeService employeeRepo = new EmployeeService();// on demande les methodes de l'employee
                TeamList teamList = new TeamList(t, employeeRepo.Get(t.TeamManagerId));// on créer une team list à partir de l'equipe et de son teamManager

                tfinalList.Add(teamList);//ajouter le teamList crée à notre liste de teamlist
            } la boucl au dessus a été resumé en Linq sur la ligne qui suit*/
            List<TeamListItem> tfinalList = teams.Select(team => new TeamListItem(team, repemp.Get(team.TeamManagerId))).ToList();
            IEnumerable<SubjectListItem> subjects = repoMessage.GetProjectMessages(id).Select(m => new SubjectListItem(new Models.Message(m), new Models.Message(repoMessage.GetLastMessage(m.Id))));
            IEnumerable<DocumentList> docs = repoDoc.GetByProject(id).Select(d => new DocumentList(d));
            ProjectDetail proj = new ProjectDetail(project, repemp.Get(project.ProjectManager),tfinalList,taskList,subjects,docs);
            return View(proj);
        }
        

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProjectEditForm collection)
        {
            try
            {
                // TODO: Add update logic here
                return View();



            }
            catch
            {

                return View();
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // GET: Task/NewSubject/6
        public ActionResult NewSubject(int id)
        {
            MessageCreateForm createForm = new MessageCreateForm(id, "Project");
            return View(createForm);
        }

        // POST: Task/NewSubject/6
        [HttpPost]
        public ActionResult NewSubject(int id, MessageCreateForm collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MessageService repoMessage = new MessageService();
                    CD.Message message = new CD.Message(
                                    collection.Title,
                                    collection.Text,
                                    UserSession.CurrentUser.Id
                                );
                    message = repoMessage.SendToProject(message, id);
                    return RedirectToAction("Index", new { id = message.Id });
                }
                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }

        public ActionResult Subject(int id)
        {
            MessageService repoMessage = new MessageService();
            Subject finalList = new Subject(repoMessage.GetConversation(id).Select(m => new MessageListItem(new M.Message(m))));
            return View(finalList);
        }


        public PartialViewResult AjaxAnswer(int id, AnswerMessageForm collection)
        {
            MessageService repoMessage = new MessageService();
            CD.Message answer = repoMessage.Answer(new CD.Message()
            {
                Title = collection.Title,
                Text = collection.Message,
                EmployeeId = UserSession.CurrentUser.Id
            }, collection.MessageId);
            Subject subject = new Subject(repoMessage.GetConversation(id).Select(m => new MessageListItem(new M.Message(m))));
            return PartialView("_Subject", subject);
        }

        /*// POST : /Project/Index/1
        
        public ActionResult Index(int id)
        {
            if (id == 1)
            {
                ProjectService projrepo = new ProjectService();
                IEnumerable<Project> projects = projrepo.GetAll();
                List<ProjectList> finalList = new List<ProjectList>();
                foreach (Project proj in projects)
                {
                    EmployeeService empRepo = new EmployeeService();
                    ProjectList projectList = new ProjectList(proj, empRepo.Get(proj.ProjectManager));
                    finalList.Add(projectList);
                }
                return View(finalList);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }*/


        // GET: Project/NewDoc/6
        public ActionResult NewDoc(int id)
        {
            DocumentCreateForm createForm = new DocumentCreateForm(id, "Project");
            return View(createForm);
        }

        // POST: Project/NewDoc/6
        [HttpPost]
        public ActionResult NewDoc(int id, DocumentCreateForm collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DocumentService d = new DocumentService();
                    BinService b = new BinService();
                    byte[] buffer = new byte[collection.FileBinary.ContentLength];
                    collection.FileBinary.InputStream.Read(buffer, 0, collection.FileBinary.ContentLength);
                    Bin fileBin = new Bin()
                    {
                        Binaries = buffer,
                        UploadName = collection.FileBinary.FileName
                    };
                    fileBin = b.Insert(fileBin);

                    Document doc = new Document(collection.Name, collection.Description, collection.ModifiedDate, collection.Size, collection.Extention, UserSession.CurrentUser.Id, fileBin.Id, null);
                    doc = d.Insert(doc);
                    if(!d.InsertToProject(doc, id))
                    {
                        /*-----------If don't have receiver, don't saved in DB------------*/
                        //b.Delete(fileBin.Id);
                        //d.Delete(doc.Id);
                    }
                }
                return RedirectToAction("Details", new { id = id });
            }
            catch
            {
                return RedirectToAction("Details", new { id = id });
            }
        }
    }
}
