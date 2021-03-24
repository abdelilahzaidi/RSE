using Model.Client.Data;
using Model.Client.Service;
using MVC.Areas.Admin.Models.ViewModel;
using MVC.Infrastructure;
using MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC.Controllers
{
    public class DocumentController : Controller
    {
         [AuthRequired]
        // GET: Document
        public ActionResult Index()
        {
            DocumentService docrepo = new DocumentService();
            IEnumerable<DocumentList> documents = docrepo.Get().Select(d=>new DocumentList(d));
            return View(documents);
        }

        // GET: Document/Details/5
        public ActionResult Details(int id)
        {
            DocumentService documentrepo = new DocumentService();
            Document documents = documentrepo.Get(id);
            DocumentDetail documentDetail = new DocumentDetail(documents);
            return View(documentDetail);
        }

        // GET: Document/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Document/Create
        [HttpPost]
        public ActionResult Create( DocumentCreateForm collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    DocumentService d = new DocumentService();
                    BinService b = new BinService();
                    byte[] buffer = new byte[collection.FileBinary.ContentLength];
                    collection.FileBinary.InputStream.Read(buffer, 0, collection.FileBinary.ContentLength);
                    Bin fileBin = new Bin() {
                        Binaries = buffer,
                        UploadName = collection.FileBinary.FileName
                    };
                    fileBin = b.Insert(fileBin);

                    Document doc = new Document(collection.Name, collection.Description, collection.ModifiedDate, collection.Size, collection.Extention,UserSession.CurrentUser.Id,fileBin.Id, null);
                    doc = d.Insert(doc);
                    switch (collection.Kind)
                    {
                        case "Task":
                            //procedure task
                            d.InsertToTask(doc, collection.ReceiverId);
                            break;
                        case "Project":
                            //procedure project
                            d.InsertToProject(doc, collection.ReceiverId);
                            break;
                        case "Team":
                            //procedure team
                            d.InsertToTeam(doc, collection.ReceiverId);
                            break;
                        case "Department":
                            //procedure department
                            d.InsertToDepartment(doc, collection.ReceiverId);
                            break;
                        case "Event":
                            //procedure Event
                            d.InsertToEvent(doc, collection.ReceiverId);
                            break;
                        default:
                            /*-----------If don't have receiver, don't saved in DB------------*/
                            //b.Delete(fileBin.Id);
                            //d.Delete(doc.Id);
                            return View(collection);
                    }
                    return RedirectToAction("Details", new { id = doc.Id});
                }
                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Document/Edit/5
        public ActionResult Edit(int id)
        {
            DocumentService repo = new DocumentService();
            Document dc = repo.Get(id);
            DocumentEditForm documents = new DocumentEditForm(dc);
            return View(documents);
        }

        // POST: Document/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DocumentEditForm collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    DocumentService dc = new DocumentService();
                    Document newDoc = new Document() {
                        Id=collection.Id,
                        Name=collection.Name,
                        Description=collection.Description,
                        Extention=collection.Extention,
                        EmployeeId=collection.EmployeeId,
                        FileBinId=collection.FileBinId,
                        OldFileId = collection.OldFileId,
                        CreateDate = collection.ModifiedDate,
                        Size = collection.Size
                    };
                   

                    if (dc.Update(newDoc))
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

        // GET: Document/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Document/Delete/5
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

       
        //*****************************************       DOWNLOAD    ***************************************************************/////

        // post: Document/Download
        
       /* public ActionResult Download(int id)
        {

           DocumentService repoDoc = new DocumentService();
           Document doc= repoDoc.Get(id);
            if (doc.FileBinId != 0)
            {
                string path = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                path = Path.Combine(path, "Downloads");
                BinaryWriter binW = new BinaryWriter(new FileStream(Path.Combine(path,doc.Name + "." + doc.Extention), FileMode.Create));
                BinService repoBin = new BinService();
                Bin file = repoBin.Get(doc.FileBinId);
                //binW.Write(file.Binaries);
                binW.Close();
                return File(file.Binaries,);
            }

                     
            return RedirectToAction("index");

        }*/
        public FileResult Download(int id)
        {
            DocumentService repoDoc = new DocumentService();
            Document doc = repoDoc.Get(id);
         
                string path = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                path = Path.Combine(path, "Downloads");
                BinService repoBin = new BinService();
                Bin file = repoBin.Get(doc.FileBinId);
                return File(file.Binaries, System.Net.Mime.MediaTypeNames.Application.Octet, doc.Name + "." + doc.Extention);
            
         
              

        }

        public PartialViewResult AjaxTaskDropDownListByEmployee()
        {
            TaskService repoTask = new TaskService();
            IEnumerable<SelectListItem> items = repoTask.GetByEmployeeId(UserSession.CurrentUser.Id).Select(t => new SelectListItem() { Value = t.Id.ToString(), Text = t.Name });
            SelectList tasks = new SelectList(items.ToList(), "Value", "Text");
            return PartialView("_SelectList", tasks);
        }

        public PartialViewResult AjaxProjectDropDownListByEmployee()
        {
            ProjectService repoProject = new ProjectService();
            IEnumerable<SelectListItem> items = repoProject.GetByEmployeeId(UserSession.CurrentUser.Id).Select(t => new SelectListItem() { Value = t.Id.ToString(), Text = t.Name });
            SelectList projects = new SelectList(items.ToList(), "Value", "Text");
            return PartialView("_SelectList", projects);
        }

        public PartialViewResult AjaxDepartmentDropDownListByEmployee()
        {
            DepartmentService repoDepart = new DepartmentService();
            IEnumerable<SelectListItem> items = repoDepart.Get().Select(t => new SelectListItem() { Value = t.Id.ToString(), Text = t.Name });
            SelectList departs = new SelectList(items.ToList(), "Value", "Text");
            return PartialView("_SelectList", departs);
        }

        public PartialViewResult AjaxEventDropDownListByEmployee()
        {
            EventService repoEvent = new EventService();
            IEnumerable<SelectListItem> items = repoEvent.GetByEmployeeId(UserSession.CurrentUser.Id).Select(t => new SelectListItem() { Value = t.Id.ToString(), Text = t.Name });
            SelectList events = new SelectList(items.ToList(), "Value", "Text");
            return PartialView("_SelectList", events);
        }

        public PartialViewResult AjaxTeamDropDownListByEmployee()
        {
            TeamService repoTeam = new TeamService();
            IEnumerable<SelectListItem> items = repoTeam.GetByEmployeeId(UserSession.CurrentUser.Id).Select(t => new SelectListItem() { Value = t.Id.ToString(), Text = t.Name });
            SelectList teams = new SelectList(items.ToList(), "Value", "Text");
            return PartialView("_SelectList", teams);
        }




    }
}
