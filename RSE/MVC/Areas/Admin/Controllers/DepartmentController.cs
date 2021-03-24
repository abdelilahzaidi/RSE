using Model.Client.Data;
using Model.Client.Service;
using MVC.Areas.Admin.Models.ViewModel;
using MVC.Infrastructure;
using MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    [AuthRequiredAsAdmin]
    public class DepartmentController : Controller
    {
        // GET: Admin/Department
        public ActionResult Index()
        {
            DepartmentService departRepo = new DepartmentService();
            IEnumerable<Department> departments = departRepo.Get();
            List<DepartmentListItem> finalList = new List<DepartmentListItem>();
            foreach (Department department in departments)
            {
                AdminService adminRepo = new AdminService();
                DepartmentListItem departmentList  = new DepartmentListItem (department, adminRepo.Get(department.AdminId));
                finalList.Add(departmentList);
            }
            return View(finalList);
        }

        // GET: Admin/Department/Details/5
        public ActionResult Details(int id)
        {
            DepartmentService departRepo = new DepartmentService();
            Department department = departRepo.Get(id);
            AdminService adminRepo = new AdminService();
            EmployeeService employeeRepo = new EmployeeService();
            DocumentService repoDoc = new DocumentService();
            IEnumerable<Employee> employees = employeeRepo.GetByDepartment(id);
            List<EmployeeListItem> finalList = new List<EmployeeListItem>();
            foreach(Employee employee in employees)
            {
                finalList.Add(new EmployeeListItem(employee));
            }
            IEnumerable<DocumentList> docs = repoDoc.GetByDepartment(id).Select(d => new DocumentList(d));
            DepartmentDetail departDetail = new DepartmentDetail(department, adminRepo.Get(department.AdminId),finalList,docs);
            
            return View(departDetail);
        }

        // GET: Admin/Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Department/Create
        [HttpPost]
        public ActionResult Create(DepartForm collection)
        {
            try
            {
                if ((ModelState.IsValid) && (UserSession.CurrentUser.AdminId!=null))
                {
                    DepartmentService repo = new DepartmentService();
                    Department d = repo.Insert(new Department(
                        collection.Name,
                        collection.Description,
                        (int)UserSession.CurrentUser.AdminId));
                    return RedirectToAction("Index");
                }

                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Admin/Department/Edit/5
        public ActionResult Edit(int id)
        {
            DepartmentService repo = new DepartmentService();
            Department dep = repo.Get(id);
            DepartEditForm depart = new DepartEditForm(dep);
            return View(depart);
        }

        // POST: Admin/Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,DepartEditForm form)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    DepartmentService repo = new DepartmentService();
                    Department oldData = repo.Get(id);
                    oldData.Name = form.Name;
                    oldData.Description = form.Description;
                    if (repo.Update(oldData))
                    {
                        return RedirectToAction("Details/"+id);
                    }
                    else
                    {
                        return View(form);
                    }
                }
                else { return View(form); }
            }
            catch
            {
                return View();
            }
        }
        
        /*
        //GET : Admin/Department/Register/5
        public ActionResult Register(int departmentId)
        {
            EmployeeService repoEmployee = new EmployeeService();
            return View();
        }

        //POST : Admin/Department/Register/5
        [HttpPost]
        public ActionResult Register(int dempartmentId,SelectEmployee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DepartmentService repoDepart = new DepartmentService();
                    repoDepart.Register(employee.Id, dempartmentId);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }*/

        // GET: Admin/Department/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeService repoEmployee = new EmployeeService();
            if (repoEmployee.GetByDepartment(id).Count() != 0)
                return RedirectToAction("Details", new { id = id });
            DepartmentService departRepo = new DepartmentService();
            Department department = departRepo.Get(id);
            AdminService adminRepo = new AdminService();
            DepartmentListItem departList = new DepartmentListItem(department, adminRepo.Get(department.AdminId));
            return View(departList);            
        }

        //POST: Admin/Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DepartmentListItem departmentList)
        {
            try
            {
                EmployeeService employeeRepo = new EmployeeService();
                IEnumerable<Employee> empl = employeeRepo.GetByDepartment(id);
                if (empl.Count() == 0)
                {
                    DepartmentService departRepo = new DepartmentService();
                    if (departRepo.Delete(id))
                        return RedirectToAction("Index");
                }
                return View(id);
            }
            catch
            {
                return View(id);
            }
        }
    }
}
