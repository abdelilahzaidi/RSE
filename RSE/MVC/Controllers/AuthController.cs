using MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Client.Service;
using Model.Client.Data;
using MVC.Infrastructure;
using MVC.Models;

namespace MVC.Controllers
{   
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return RedirectToAction("Register");
        }
        [AnonymousRequired]
        public ActionResult Register()
        {
            return View();
        }
        [AnonymousRequired]
        public ActionResult Login()
        {
            return View();
        }

        // POST:Auth
        [AnonymousRequired]
        [HttpPost]
        public ActionResult Register(RegisterForm form)
        {
            if (ModelState.IsValid)
            {
                EmployeeService repo = new EmployeeService();
                Employee e = repo.Insert(new Employee(
                    form.FirstName,
                    form.LastName,
                    form.Email,
                    form.Password,
                    form.RegNat,
                    form.HireDate,
                    true,
                    null,
                    form.City,
                    form.Street,
                    form.Number,
                    form.NumberBox,
                    form.ZipCode,
                    form.Country,
                    form.GSM,
                    form.BirthDate));
                return RedirectToAction("Login");
            }
            else
            {
                return View(form);
            }
        }

        [HttpPost]
        [AnonymousRequired]
        public ActionResult Login(LoginForm form)
        {
            if (ModelState.IsValid)
            {
                EmployeeService repo = new EmployeeService();
                Employee e = repo.Check(new Employee(form.Email, form.Password));
                if (e != null)
                {
                    UserSession.CurrentUser = new User { Id = e.Id, Email = e.Email, AdminId = null };
                    return RedirectToAction("Index","Member",e.Id);
                }
                else
                {
                    return View(form);
                }
            }
            else
            {
                return View(form);
            }
        }
        [AuthRequired]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");

        }
    }
}