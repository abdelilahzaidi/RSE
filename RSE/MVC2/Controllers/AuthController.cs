using MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Client.Service;
using Model.Client.Data;

namespace MVC.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return RedirectToAction("Register");
        }

        public ActionResult Register()
        {
            return View();
        }
        // POST:Auth
        [HttpPost]
        public ActionResult Register(RegisterForm form)
        {
            if (ModelState.IsValid)
            {
                EmployeeService repo = new EmployeeService();
                Employee e = repo.Insert(new Employee(form.FirstName,form.LastName,form.Email,form.Password,form.RegNat,form.HireDate,form.City,form.Street,form.Number,form.NumberBox,form.ZipCode,form.Country,form.GSM,form.BirthDate));
                return RedirectToAction("Login");
            }
            else
            {
                return View(form);
            }
        }
    }
}