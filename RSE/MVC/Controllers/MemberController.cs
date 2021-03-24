using Model.Client.Data;
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
{   [AuthRequired]
    public class MemberController : Controller
    {
        // GET: Member
        
        public ActionResult Index()
        {
           // ProjectIRepository irepo = new ProjectIRepository();
            return View();
        }

        // GET: Member/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
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

        // GET: Member/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Member/Edit/5
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

        // GET: Member/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Member/Delete/5
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
        //GET:Member/ProfilDetail
        public ActionResult ProfilDetail()//Methode retournant les details du profil, grâce au get dans le service client
        {
            EmployeeService repo = new EmployeeService();
            DepartmentService repoDepart = new DepartmentService();
            EmployeeDetails profil = new EmployeeDetails(new EmployeeWithState(UserSession.CurrentUser.Id),repoDepart.GetByEmployeeId(UserSession.CurrentUser.Id));
            return View(profil);
        }
        //GET:Member/ProfilEdit
        public ActionResult ProfilEdit()
        {
            EmployeeService repo = new EmployeeService();
            Employee e = repo.Get(UserSession.CurrentUser.Id);
            ProfilEditForm profil = new ProfilEditForm(e);
            return View(profil);
        }

        //POST:Member/ProfilEdit
        [HttpPost]
        public ActionResult ProfilEdit(ProfilEditForm form)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    EmployeeService repo = new EmployeeService();
                    Employee oldData = repo.Get(UserSession.CurrentUser.Id);
                    oldData.LastName = form.LastName;
                    oldData.FirstName = form.FirstName;
                    oldData.City = form.City;
                    oldData.Street = form.Street;
                    oldData.Number = form.Number;
                    oldData.NumberBox = form.NumberBox;
                    oldData.ZipCode = form.ZipCode;
                    oldData.Country = form.Country;
                    oldData.GSM = form.GSM;
                    if (repo.Update(oldData))
                    {
                        return RedirectToAction("ProfilDetail");
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

        // GET: MEMBER/CreateStatus
        public ActionResult CreateStatus()
        {
            EmployeeStateService repo = new EmployeeStateService();
            EmployeeStatusCreateForm e = new EmployeeStatusCreateForm(repo.Get());

            return View(e);
        }


        // POST : MEMBER/CreateStatus
        [HttpPost]
        public ActionResult CreateStatus(EmployeeStatusCreateForm form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int SelectedEmployeeState = Int32.Parse(form.SelectedEmployeeState);
                    EEmployeeStateService emprepo = new EEmployeeStateService();
                    Employee_EmployeeState es = new Employee_EmployeeState()
                    {
                        EmployeeId = UserSession.CurrentUser.Id,
                        EmployeeStateId = Int32.Parse(form.SelectedEmployeeState),
                        StartDate = form.StartDate,
                        EndDate = form.EndDate
                    };
                    es = emprepo.Insert(es);
                    return RedirectToAction("ProfilDetail");
                }
                return View(form);
            }
            
            catch
            {

                return View();
            }
        }







        //-----CHEAT-----//

        public ActionResult BeAdmin()
        {
            throw new NotImplementedException();
        }
    }
}
