using Model.Client.Data;
using Model.Client.Service;
using MVC.Areas.Admin.Models.ViewModel;
using MVC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    [AuthRequiredAsAdmin]
    public class ProjectController : Controller
    {
        // GET: Admin/Project
        public ActionResult Index()
        {
            ProjectService projrepo = new ProjectService();
            IEnumerable<Project> projects = projrepo.Get();
            List<ProjectListItem> finalList = new List<ProjectListItem>();
            foreach (Project proj in projects)
            {
                EmployeeService empRepo = new EmployeeService();
                ProjectListItem projectList = new ProjectListItem(proj, empRepo.Get(proj.ProjectManager));
                finalList.Add(projectList);
            }
            return View(finalList);
        }

        // GET: Admin/Project/Details/5
        /*public ActionResult Details(int id)
        {
            ProjectService projrepo = new ProjectService();
            EmployeeService repemp = new EmployeeService();
            Project project = projrepo.Get(id);
            ProjectDetail proj = new ProjectDetail(project, repemp.Get(project.ProjectManager));
            return View(proj);

        }*/

        // GET: Admin/Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Project/Create
        [HttpPost]
        public ActionResult Create(ProjectCreateForm collection)
        {
            try
            {
                if ((ModelState.IsValid) && (UserSession.CurrentUser.AdminId != null))
                {
                    EmployeeService repoemployee = new EmployeeService();
                    Employee Projectmanager = repoemployee.Get().Where<Employee>((emp) => emp.Email == collection.ProjectManager).FirstOrDefault();
                    if (Projectmanager != null)
                    {

                        ProjectService repo = new ProjectService();
                        Project d = repo.Insert(new Project(
                            collection.Name,
                            collection.Description,
                            collection.StartDate,
                            collection.EndDate,
                            (int)UserSession.CurrentUser.AdminId,
                            Projectmanager.Id));
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(collection);
                    }
                }

                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Admin/Project/Edit/5
        public ActionResult Edit(int id)
        {
            ProjectService repo = new ProjectService();
            Project proj = repo.Get(id);
            EmployeeService emp = new EmployeeService();
            Employee e = emp.Get(proj.ProjectManager);
            ProjectEditForm project = new ProjectEditForm(proj, e);
            return View(project);
        }

        // POST: Admin/Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProjectEditForm collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    ProjectService repo = new ProjectService();
                    EmployeeService repoemployee = new EmployeeService();
                    Employee Projectmanager = repoemployee.Get().Where<Employee>((emp) => emp.Email == collection.ProjectManager).FirstOrDefault();
                    Project oldData = repo.Get(id);

                    if(Projectmanager == null)
                    {
                        return View(collection);
                    }

                    bool isUpdated = false;

                    if (Projectmanager.Id != oldData.ProjectManager)
                    {
                        oldData.ProjectManager = Projectmanager.Id;
                        isUpdated = repo.UpdatePM(oldData);
                    }
                        oldData.Name = collection.Name;
                        oldData.Description = collection.Description;
                        oldData.StartDate = collection.StartDate;
                        oldData.EndDate = collection.EndDate;
                        isUpdated = repo.Update(oldData);

                    

                    if (isUpdated)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(collection);
                    }
                }
                else { return View(collection); }



            }
            catch
            {

                return View();
            }
        }

        // GET: Admin/Project/Delete/5
        public ActionResult Delete(int id)
        {
            ProjectService repo = new ProjectService();

            return View(repo.Get(id));
        }

        // POST: Admin/Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                ProjectService repo = new ProjectService();
                repo.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
