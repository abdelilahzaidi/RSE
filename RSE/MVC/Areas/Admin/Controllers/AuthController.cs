using Model.Client.Service;
using CD = Model.Client.Data;
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
    
    public class AuthController : Controller
    {
        // GET: Admin/Auth
        [AnonymousRequired]
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        // GET: Admin/Auth/Login
        [AnonymousRequired]
        public ActionResult Login()
        {
            return View();
        }
        
        // POST: Admin/Auth/Login
        [HttpPost]
        [AnonymousRequired]
        public ActionResult Login(LoginForm form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AdminService repo = new AdminService();
                    CD.Admin a = repo.Check(new CD.Admin(form.Email,form.Password));
                    if (a == null) return View(form);
                    UserSession.CurrentUser = new User { Id = a.Id, Email = a.Email, AdminId = a.AdminId };
                    return RedirectToAction("Index","Employee",  a.Id);
                }
                else
                {
                    return View(form);
                }
            }
            catch (Exception) {
                return View(form);
            }
        }
        //GET:Admin/Auth/Logout
        [AuthRequiredAsAdmin]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}