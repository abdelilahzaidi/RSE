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

namespace MVC.Controllers
{
    [AuthRequired]
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            EventService repo = new EventService();
            EmployeeService emprepo = new EmployeeService();
            InviteService repoInvite = new InviteService();
            //-------------------------LIST DES EVENTS QUE L'USER A CREER------------------------------------//
            List<EventListItem> finallist = repo.GetByEmployeeId(UserSession.CurrentUser.Id).Select(e => new EventListItem(e, emprepo.Get(e.EmployeeId))).ToList();
            //-------------------------LIST DES EVENTS AUQUEL L'USER EST INVITER------------------------------------//
            IEnumerable<Invite> invites = repoInvite.GetByEmployeeId(UserSession.CurrentUser.Id);
            List<EventInviteListItem> listInvite = new List<EventInviteListItem>();
            foreach (Invite i in invites)
            {
                Event e = repo.Get(i.EventId);
                EventInviteListItem invite = new EventInviteListItem(e, emprepo.Get(e.EmployeeId), i);
                listInvite.Add(invite);
            }
            return View(new EventIndex(finallist,listInvite));
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            EventService repo = new EventService();
            EmployeeService emprepo = new EmployeeService();
            InviteService repoInvite = new InviteService();
            DocumentService repoDoc = new DocumentService();
            Event events = repo.Get(id);
            IEnumerable<EventEmployeeListItem> employees = repoInvite.GetByEventId(id).Select(i => new EventEmployeeListItem(emprepo.Get(i.EmployeeId),repoInvite.Get(i.EmployeeId,id)));
            IEnumerable<DocumentList> docs = repoDoc.GetByEvent(id).Select(d => new DocumentList(d));
            EventDetail ev = new EventDetail(events, emprepo.Get(events.EmployeeId),employees,docs);
            return View(ev);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventCreateForm collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    EventService repo = new EventService();
                    Event e = repo.Insert(new Event(
                        collection.Name,
                        collection.Description,
                        collection.City,
                        collection.Street,
                        collection.Number,
                        collection.NumberBox,
                        collection.ZipCode,
                        collection.Country,
                        collection.StartDate,
                        collection.EndDate,
                        collection.FullDay,
                        (int)UserSession.CurrentUser.Id));
                    return RedirectToAction("Index");
                }
                return View(collection);

                
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            EventService repo = new EventService();
            Event ev = repo.Get(id);
            EventEditForm events = new EventEditForm(ev);
            
            return View(events);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventEditForm collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    EventService repo = new EventService();
                    Event oldData = repo.Get(id);
                    oldData.Name = collection.Name;
                    oldData.Description = collection.Description;
                    oldData.City = collection.City;
                    oldData.Street = collection.Street;
                    oldData.Number = collection.Number;
                    oldData.NumberBox = collection.NumberBox;
                    oldData.ZipCode = collection.ZipCode;
                    oldData.Country = collection.Country;
                    oldData.StartDate = collection.StartDate;
                    oldData.EndDate = collection.EndDate;
                    oldData.FullDay = collection.FullDay;

                    if (repo.Update(oldData))
                    {
                        RedirectToAction("Index");
                    }
                    else
                    {
                        return View(collection);
                    }
                }
               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            EventService repo = new EventService();
            EmployeeService emprepo = new EmployeeService();
            InviteService repoInvite = new InviteService();
            DocumentService repoDoc = new DocumentService();
            Event events = repo.Get(id);
            IEnumerable<EventEmployeeListItem> employees = repoInvite.GetByEventId(id).Select(i => new EventEmployeeListItem(emprepo.Get(i.EmployeeId), repoInvite.Get(i.EmployeeId, id)));
            IEnumerable<DocumentList> docs = repoDoc.GetByEvent(id).Select(d => new DocumentList(d));
            EventDetail ev = new EventDetail(events, emprepo.Get(events.EmployeeId), employees,docs);
            return View(ev);
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                EventService repo = new EventService();
                repo.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Inviter()
        {

            try
            {
                return View();
            }
            catch
            {

                return View();
            }


            
        }

        // GET: Event/Invite/6
        public ActionResult Invite(int id)
        {
            return View();
        }

        // POST : Event/Invite/6
        [HttpPost]
        public ActionResult Invite(int id, EventInviteEmployee collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EventService repoEvent = new EventService();
                    EmployeeService repoEmployee = new EmployeeService();
                    Employee employee = repoEmployee.Get().Where(e => (e.Email == collection.Email)).SingleOrDefault();
                    if (employee != null)
                    {
                        if(repoEvent.InviteEmployee(id, employee.Id))
                        {
                            return RedirectToAction("Details", new { id = id });
                        }
                        return View(collection);
                    }
                    return View(collection);
                }
                return View(collection);
            }
            catch
            {
                return View(collection);

            }
        }

        // POST : Event/Answer/6?answer=true

        [HttpPost]
        public ActionResult Answer(int id, bool answer)
        {
            InviteService repoInvite = new InviteService();
            repoInvite.Answer(UserSession.CurrentUser.Id, id, answer);
            return RedirectToAction("Index");
        }

        /*[HttpPost]
        public PartialViewResult Answer (int id, bool answer)
        {
            EventService repo = new EventService();
            EmployeeService emprepo = new EmployeeService();
            InviteService repoInvite = new InviteService();
            if(repoInvite.Answer(UserSession.CurrentUser.Id, id, answer){
                IEnumerable<Invite> invites = repoInvite.GetByEmployeeId(UserSession.CurrentUser.Id);
                List<EventInviteListItem> listInvite = new List<EventInviteListItem>();
                foreach (Invite i in invites)
                {
                    Event e = repo.Get(i.EventId);
                    EventInviteListItem invite = new EventInviteListItem(e, emprepo.Get(e.EmployeeId), i);
                    listInvite.Add(invite);
                }
            }
            return PartialView("_InviteList",listInvite);
        }*/


        // GET: Event/NewDoc/6
        public ActionResult NewDoc(int id)
        {
            DocumentCreateForm createForm = new DocumentCreateForm(id, "Event");
            return View(createForm);
        }

        // POST: Event/NewDoc/6
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
                    if (!d.InsertToEvent(doc, id))
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
