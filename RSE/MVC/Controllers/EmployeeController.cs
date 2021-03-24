using CD = Model.Client.Data;
using Model.Client.Service;
using MVC.Infrastructure;
using MVC.Models;
using MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            EmployeeService repo = new EmployeeService();
            DepartmentService repoDepart = new DepartmentService();
            EmployeeDetails emp = new EmployeeDetails(new EmployeeWithState(id),repoDepart.GetByEmployeeId(id));
            return View(emp);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
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

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
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

        // GET: Team/NewMessage/6
        public ActionResult NewMessage(int id)
        {
            MessageCreateForm createForm = new MessageCreateForm(id, "Employee");
            return View(createForm);
        }

        // POST: Task/NewSubject/6
        [HttpPost]
        public ActionResult NewMessage(int id, MessageCreateForm collection)
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
                    message = repoMessage.SendToEmployee(message, id);
                    return RedirectToAction("Details", new { controller="Message",id = message.Id });
                }
                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }
    }
}
