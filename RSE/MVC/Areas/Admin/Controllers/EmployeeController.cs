using C = Model.Client.Data;
using Model.Client.Service;
using MVC.Areas.Admin.Models.ViewModel;
using MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Infrastructure;
using MVC.Models;

namespace MVC.Areas.Admin.Controllers
{
    [AuthRequiredAsAdmin]
    public class EmployeeController : Controller
    {
        // GET: Admin/Employee
        public ActionResult Index()
        {
            EmployeeService repoEmployee = new EmployeeService();
            IEnumerable<EmployeeListItem> employees = repoEmployee.Get().Select(e => new EmployeeListItem(e));
            return View(employees);
            //return RedirectToAction("Index","Home");
        }

        // GET: Admin/Employee/Details/5
        public ActionResult Details(int id)
        {
            EmployeeService repo = new EmployeeService();
            DepartmentService repoDepart = new DepartmentService();
            EmployeeDetails emp = new EmployeeDetails(new EmployeeWithState(id),repoDepart.GetByEmployeeId(id));
            return View(emp);
        }

        // GET: Admin/Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Employee/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeService repoEmp = new EmployeeService();
            AdminService repoAdmin = new AdminService();
            DepartmentService repoDepart = new DepartmentService();
            C.Employee employee = repoEmp.Get(id);/*
            C.Admin a = null;
            if (repoAdmin.IsAdminByEmployeeId(id))
            {
                a = repoAdmin.GetByEmployeeId(id);
            }
            else
            {
                a = new C.Admin(, e);
            }*/
            C.Department currentDepart = repoDepart.GetByEmployeeId(employee.Id);
            IEnumerable<C.Department> departmentList = repoDepart.Get();
            EmployeeEditForm profil = new EmployeeEditForm(employee,currentDepart,departmentList,repoAdmin.IsAdminByEmployeeId(id));
            return View(profil);
        }

        // POST: Admin/Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeEditForm collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeService repoEmployee = new EmployeeService();
                    if (collection.CurrentDepartmentId != Int32.Parse(collection.SelectedItem))
                        repoEmployee.AddToDepartment(id, Int32.Parse(collection.SelectedItem));

                    AdminService repoAdmin = new AdminService();
                    bool isAdmin = repoAdmin.IsAdminByEmployeeId(id);
                    if (collection.IsAdmin !=isAdmin)
                    {
                        if (isAdmin)
                            repoAdmin.Delete(id);
                        else
                            repoAdmin.Insert(id);
                    }

                    C.Employee emp = repoEmployee.Get(collection.Id);
                    emp.Id = collection.Id;
                    emp.FirstName = collection.FirstName;
                    emp.LastName = collection.LastName;
                    emp.Email = collection.Email;
                    if (!repoEmployee.Update(emp))
                        return View(collection);
                    return RedirectToAction("Index");
                }
                return View(collection);

            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Admin/Employee/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeService repo = new EmployeeService();
            DepartmentService repoDepart = new DepartmentService();
            EmployeeDetails emp = new EmployeeDetails(new EmployeeWithState(id), repoDepart.GetByEmployeeId(id));
            return View(emp);
        }

        // POST: Admin/Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmployeeDetails collection)
        {
            try
            {
                // TODO: Add delete logic here
                EmployeeService employeeRepo = new EmployeeService();
                if(employeeRepo.Delete(id))
                    return RedirectToAction("Index");
                return View(id);
            }
            catch
            {
                return View(id);
            }
        }
    }
}
