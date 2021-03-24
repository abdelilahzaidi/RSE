using Model.Client.Service;
using CD = Model.Client.Data;
using MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Client;
using System.Diagnostics;
using M = MVC.Models;
using Model.Client.Data;
using MVC.Infrastructure;
using MVC.Models;

namespace MVC.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task/Index/6  6=> Numéro du project
        public ActionResult Index(int id)
        {
            TaskService repoTask = new TaskService();
            IEnumerable<CD.Task> Tasks = repoTask.GetByProjectId(id);
            List<TaskListItem> finalTaskList = new List<TaskListItem>();
            foreach (CD.Task task in Tasks)
            {
                TaskStateService repoTS = new TaskStateService();
                TaskListItem taskList = null;
                if (task.TaskTeam)
                {
                    taskList = new TaskListItem(task, repoTS.GetByTaskId(task.Id));
                }
                else
                {
                    taskList = new TaskListItem(task, repoTS.GetByTaskId(task.Id));
                }
                finalTaskList.Add(taskList);
            }
            return View(finalTaskList);
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            TaskService repoTask = new TaskService();
            TaskStateService repoTaskState = new TaskStateService();
            ProjectService repoProject = new ProjectService();
            TeamService repoTeam = new TeamService();
            EmployeeService repoEmployee = new EmployeeService();
            DocumentService repoDoc = new DocumentService();
            M.TaskWithState task = new M.TaskWithState(repoTask.Get(id),repoTaskState.GetByTaskId(id));
            M.CurrentOn currentOn = (task.TaskTeam)?new M.CurrentOn(repoTeam.GetByTaskId(id)):new M.CurrentOn(repoEmployee.GetByTaskId(id));
            M.TaskWithState mainTask = null;
            if (task.MainTaskId!=null)
                mainTask = new M.TaskWithState(repoTask.GetMainTask(id),repoTaskState.GetByTaskId((int)task.MainTaskId));
            IEnumerable<CD.Task> subTasks = repoTask.GetSubHierarchy(id);
            List<TaskListItem> finalSubList = new List<TaskListItem>();
            foreach (CD.Task t in subTasks)
            {
                if (t.Id != id)
                {
                    M.CurrentOn currentOnSubTask = (t.TaskTeam)?new M.CurrentOn(repoTeam.GetByTaskId(t.Id)):new M.CurrentOn(repoEmployee.GetByTaskId(t.Id));
                    TaskListItem tl = new TaskListItem(new M.TaskWithState(t, repoTaskState.GetByTaskId(t.Id)),currentOnSubTask);
                    finalSubList.Add(tl);
                }
            }
            MessageService repoMessage = new MessageService();
            IEnumerable<SubjectListItem> subjects = repoMessage.GetTaskMessages(id).Select(m => new SubjectListItem(new M.Message(m),new M.Message(repoMessage.GetLastMessage(m.Id))));
            IEnumerable<DocumentList> docs = repoDoc.GetByTask(id).Select(d => new DocumentList(d));
            TaskDetail taskDetail = new TaskDetail(
                task,
                currentOn,
                repoProject.Get(task.ProjectId).Name,
                mainTask,
                finalSubList,
                subjects,
                docs);
            return View(taskDetail);
        }



        // GET: Task/Create/6  6=> Numéro du project
        /*[ProjectManagerRequired]*/
        public ActionResult Create(int id)
        {
            return View ();
        }

        // POST: Task/Create/6  6=> Numéro du project
        [HttpPost]
        public ActionResult Create(int id,TaskCreateForm collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TaskService repoTask = new TaskService();
                    CD.Task task = new CD.Task(
                        collection.Name,
                        collection.Description,
                        collection.StartDate,
                        collection.DeadLine,                        
                        id,
                        collection.TaskTeam,
                        (collection.MainTaskId!=0)?(int?)collection.MainTaskId:null);
                    task = repoTask.Insert(task);
                    return RedirectToAction("Details","Project",new { id=id});
                }
                return View(id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return View(id);
            }
        }

        /*[ProjectManagerRequired]*/
        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            TaskService repoTask = new TaskService();
            CD.Task task = repoTask.Get(id);
            TaskStateService repoTaskState = new TaskStateService();
            IEnumerable<CD.Task> tasks = repoTask.GetByProjectId(task.ProjectId);
            IEnumerable<CD.Task> taskHierarchy = repoTask.GetSubHierarchy(id);
            IEnumerable<CD.Task> taskList = tasks.Except(taskHierarchy,new IdComparer<CD.Task>());
            TaskEditForm taskEdit = new TaskEditForm(
                task,
                repoTaskState.GetByTaskId(id),
                taskList,
                repoTaskState.Get()
                );
            return View(taskEdit);
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TaskEditForm collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    TaskService repoTask = new TaskService();
                    int SelectedMainTask = (collection.SelectedMainTask!=null)?Int32.Parse(collection.SelectedMainTask):0;
                    int SelectedTaskState = Int32.Parse(collection.SelectedTaskState);
                    if ( SelectedMainTask!= collection.CurrentMainTask)
                        if (SelectedMainTask == 0)
                            repoTask.DeleteMainTask(collection.Id);//DELETE FROM Task_Task WHERE TaskId = , SubTaskId = 
                        else
                            repoTask.InsertMainTask(collection.Id,SelectedMainTask);//INSERT TaskId, SubTaskId INTO Task_Task
                    if (SelectedTaskState != collection.CurrentTaskState)
                        repoTask.InsertTaskState(id, SelectedTaskState);
                    if (repoTask.Update(new CD.Task(
                        collection.Id,
                        collection.Name,
                        collection.Description,
                        collection.StartDate,
                        collection.DeadLine,
                        collection.ProjectId,
                        collection.TaskTeam,
                        (collection.SelectedMainTask!=null)?(int?)Int32.Parse(collection.SelectedMainTask):null)))
                        return RedirectToAction("Details", "Task", new { id = collection.Id });
                    return View(id);
                }
                return View(id);
            }
            catch
            {
                return View(id);
            }
        }

        /*[ProjectManagerRequired]*/
        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Task/Delete/5
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

        // GET: Task/AssignTeam/5

        ///*[ProjectManagerRequired]*/
        public ActionResult AssignTeam(int id)
        {
            TaskService repoTask = new TaskService();
            if (repoTask.Get(id).TaskTeam)
            {
                TeamService repoTeam = new TeamService();
                EmployeeService repoEmployee = new EmployeeService();
                IEnumerable<TeamListItem> teams = repoTeam.GetByProjectId(repoTask.Get(id).ProjectId).Select(t => new TeamListItem(t, repoEmployee.Get(t.TeamManagerId)));
                return View(teams);
            }
            return RedirectToAction("Details",new { id = id });
        }

        ///*[ProjectManagerRequired]*/
        public ActionResult ConfirmAssignTeam(int taskId, int teamId)
        {
            TeamService repoTeam = new TeamService();
            EmployeeService repoEmployee = new EmployeeService();
            Team team = repoTeam.Get(teamId);
            TeamDetail teamDetail = new TeamDetail(team,repoEmployee.Get(team.TeamManagerId),repoEmployee.GetByTeamId(teamId).Select(e=>new EmployeeListItem(e)));
            return View(teamDetail);
        }

        [HttpPost]
        public ActionResult ConfirmAssignTeam(int taskId,TeamDetail collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TaskService repoTask = new TaskService();
                    if (repoTask.AssignTeam(taskId, collection.Id))
                    {
                        return RedirectToAction("Details", new { id = taskId });
                    }
                    return RedirectToAction("AssignTeam", new { id = taskId });
                }
                return RedirectToAction("AssignTeam", new { id = taskId });
            }
            catch (Exception)
            {
                return RedirectToAction("AssignTeam", new { id = taskId });
            }
        }

        // GET: Task/AssignEmployee/5

        ///*[ProjectManagerRequired]*/
        public ActionResult AssignEmployee(int id)
        {
            TaskService repoTask = new TaskService();
            if (!repoTask.Get(id).TaskTeam)
            {
                EmployeeService repoEmployee = new EmployeeService();
                IEnumerable<EmployeeListItem> employees = repoEmployee.GetByProjectId(repoTask.Get(id).ProjectId).Select(e => new EmployeeListItem(e));
                return View(employees);
            }
            return RedirectToAction("Details", new { id = id });
        }

        ///*[ProjectManagerRequired]*/
        public ActionResult ConfirmAssignEmployee(int taskId, int empId)
        {
            DepartmentService repoDepart = new DepartmentService();
            EmployeeDetails employee = new EmployeeDetails(new EmployeeWithState(empId), repoDepart.GetByEmployeeId(empId));
            return View(employee);
        }

        [HttpPost]
        public ActionResult ConfirmAssignEmployee(int taskId, EmployeeDetails collection)
        {
            try
            {
                if (collection!=null && collection.Id!=0)
                {
                    TaskService repoTask = new TaskService();
                    if (repoTask.AssignEmployee(taskId, collection.Id))
                    {
                        return RedirectToAction("Details", new { id = taskId });
                    }
                    return RedirectToAction("AssignEmployee", new { id = taskId });
                }
                return RedirectToAction("AssignEmployee", new { id = taskId });
            }
            catch (Exception)
            {
                return RedirectToAction("AssignEmployee", new { id = taskId });
            }
        }



        // GET: Task/NewSubject/6
        public ActionResult NewSubject(int id)
        {
            MessageCreateForm createForm = new MessageCreateForm(id, "Task");
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
                    message = repoMessage.SendToTask(message, id);
                    return RedirectToAction("Subject", new { id = message.Id });
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
            Subject finalList = new Subject(repoMessage.GetConversation(id).Select(m=>new MessageListItem(new M.Message(m))).ToList());
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

        /*-------------PARTIAL VIEW AJAX
         * 
        public PartialViewResult IndexTeam(int id)
        {
            TaskService repoTask = new TaskService();
            IEnumerable<CD.Task> Tasks = repoTask.GetByProjectId(id).Where(t=>t.TaskTeam);
            List<TaskList> finalTaskList = new List<TaskList>();
            foreach (CD.Task task in Tasks)
            {
                TaskStateService repoTS = new TaskStateService();
                TaskList taskList = new TaskList(task, repoTS.GetByTaskId(task.Id));
                finalTaskList.Add(taskList);
            }
            return PartialView("_TaskList",finalTaskList);
        }

        public PartialViewResult IndexEmployee(int id)
        {
            TaskService repoTask = new TaskService();
            IEnumerable<CD.Task> Tasks = repoTask.GetByProjectId(id).Where(t => !t.TaskTeam);
            List<TaskList> finalTaskList = new List<TaskList>();
            foreach (CD.Task task in Tasks)
            {
                TaskStateService repoTS = new TaskStateService();
                TaskList taskList = new TaskList(task, repoTS.GetByTaskId(task.Id));
                finalTaskList.Add(taskList);
            }
            return PartialView("_TaskList", finalTaskList);
        }*/

        // GET: Task/NewDoc/6
        public ActionResult NewDoc(int id)
        {
            DocumentCreateForm createForm = new DocumentCreateForm(id, "Task");
            return View(createForm);
        }

        // POST: Task/NewDoc/6
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
                    if (!d.InsertToTask(doc, id))
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
