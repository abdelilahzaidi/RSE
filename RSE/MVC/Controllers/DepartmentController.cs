using Model.Client.Data;
using Model.Client.Service;
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
    public class DepartmentController : Controller
    {
        
        // GET: Department
        public ActionResult Index()
        {
            DepartmentService departRepo = new DepartmentService();
            IEnumerable<Department> departments = departRepo.Get();
            List<DepartmentListItem> finalList = new List<DepartmentListItem>();
            foreach (Department department in departments)
            {
                AdminService adminRepo = new AdminService();
                DepartmentListItem departmentList = new DepartmentListItem(department, adminRepo.Get(department.AdminId));
                finalList.Add(departmentList);
            }
            return View(finalList);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            DepartmentService departRepo = new DepartmentService();
            Department department = departRepo.Get(id);
            AdminService adminRepo = new AdminService();
            EmployeeService employeeRepo = new EmployeeService();
            DocumentService repoDoc = new DocumentService();
            IEnumerable<Employee> employees = employeeRepo.GetByDepartment(id);
            List<EmployeeListItem> finalList = new List<EmployeeListItem>();
            foreach (Employee employee in employees)
            {
                finalList.Add(new EmployeeListItem(employee));
            }
            IEnumerable<DocumentList> docs = repoDoc.GetByDepartment(id).Select(d => new DocumentList(d));
            DepartmentDetail departDetail = new DepartmentDetail(department, adminRepo.Get(department.AdminId), finalList,docs);


            return View(departDetail);
        }


        // GET: Department/NewDoc/6
        public ActionResult NewDoc(int id)
        {
            DocumentCreateForm createForm = new DocumentCreateForm(id, "Department");
            return View(createForm);
        }

        // POST: Department/NewDoc/6
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
                    if (!d.InsertToDepartment(doc, id))
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
