using CD = Model.Client.Data;
using Model.Client.Service;
using MVC.Areas.Admin.Models.ViewModel;
using MVC.Infrastructure;
using MVC.Models.ViewModel;
using M=MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Client.Data;

namespace MVC.Controllers
{
    
    public class TeamController : Controller
    {
        
        [AuthRequired]
        // GET: Team/Index/6
        public ActionResult Index(int id)
        {
            TeamService teamrepo = new TeamService();

            IEnumerable<CD.Team> teams = teamrepo.GetByProjectId(id);//prendre un iEINumeralbe de team qui correspond à l'ensemble des equipes, faisant partie d'un seul et même projet
            List<TeamListItem> tfinalList = new List<TeamListItem>();// on créer une liste vide de teamlist
            foreach (CD.Team t in teams)//Pour chaque equipe de notre ennsemble d'equipe faisant partie d'un mememe et seul projet
            {
                EmployeeService employeeRepo = new EmployeeService();// on demande les methodes de l'employee
                TeamListItem teamList = new TeamListItem(t, employeeRepo.Get(t.TeamManagerId));// on créer une team list à partir de l'equipe et de son teamManager
                
                tfinalList.Add(teamList);//ajouter le teamList crée à notre liste de teamlist
            }
            return View(tfinalList);
            
        }

        // GET: Team/Details/5
        public ActionResult Details(int id)
        {
            TeamService teamRepo = new TeamService();
            CD.Team team = teamRepo.Get(id);
            EmployeeService employeeRepo = new EmployeeService();
            DocumentService repoDoc = new DocumentService();
            IEnumerable<CD.Employee> employees = employeeRepo.GetByTeamId(id);
            List<EmployeeListItem> finalList = new List<EmployeeListItem>();
            foreach (CD.Employee employee in employees)
            {
                finalList.Add(new EmployeeListItem(employee));
            }
            MessageService repoMessage = new MessageService();
            IEnumerable<ConversationListItem> conversations = repoMessage.GetTeamMessages(id).Select(m => new ConversationListItem(new M.Message(m), new M.Message(repoMessage.GetLastMessage(m.Id)), team));
            IEnumerable<DocumentList> docs = repoDoc.GetByTeam(id).Select(d => new DocumentList(d));
            TeamDetail teamDetail = new TeamDetail(team, employeeRepo.Get(team.TeamManagerId), finalList,conversations,docs);
            return View(teamDetail);
            
        }

        // GET: Team/Create/6 formulaire
        /*[ProjectManagerRequired]*/
        public ActionResult Create(int id)
        {
            return View();
        }

        // POST: Team/Create/6
        [HttpPost]
        public ActionResult Create(int id,TeamCreateForm collection)
        {
            try
            {
                // TODO: Add insert logic here
                TeamService r = new TeamService();
                EmployeeService employeeRepo = new EmployeeService();
                CD.Employee TeamManager = employeeRepo.Get().Where<CD.Employee>(emp => emp.Email == collection.TeamManagerId).SingleOrDefault();
                CD.Team t = new CD.Team(collection.Name, id, TeamManager.Id);
                t = r.Insert(t);
                return RedirectToAction("Details",new { controller = "Project",id=id});
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Team/Edit/5
        /*[ProjectManagerRequired]*/
        public ActionResult Edit(int id)
        {
            TeamService r = new TeamService();
            CD.Team t = r.Get(id);
            TeamEdit te = new TeamEdit(t);
            return View(te);            
        }

        // POST: Team/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,TeamEdit collection)
        {
            TeamService r = new TeamService();// Procure les methodes d'acces à la DB
            CD.Team t = new CD.Team(id,collection.Name );// Création d'une nouvelle équipe à partir du formulaire (collection)
            if(r.Update(t))// r.update(): appel de la methide update pour mettre à jour la team, le if(conntrolle si la mise à jour a été faite)
                return RedirectToAction("Details", new { controller = "Team", id = id });// nous redirige vers l'action detail, se trouvant dans le controller Team avec le parametre Id
            return View(collection);//retourne le formulaire
        }
 

        // GET: Team/Delete/5
        /*[ProjectManagerRequired]*/
        public ActionResult Delete(int id)
        {
            /* try
             {
                 // TODO: Add insert logic here
                 TeamService r = new TeamService();
                 r.Delete(id);
                 return RedirectToAction("Index");
             }
             catch(Exception e)
             {
                 Debug.WriteLine(e.Message);
                 return RedirectToAction("Index");
             }*/
            TeamService r = new TeamService();//Je fais appel aux methdes de mon TeamService
           
            if (r.CountEmployee(id) == 0)// je controlle le nombe d'elements de ma team
            {
                EmployeeService repoEmployee =new EmployeeService();
                CD.Team team = r.Get(id);
                CD.Employee teamManager = repoEmployee.Get(team.TeamManagerId);
                TeamListItem t = new TeamListItem(team,teamManager);//Je crée ma teamDetail
                return View(t);// je renvoie les details de ma vue
            }
            return RedirectToAction("Details", new { id = id });
        }

        // POST: Team/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TeamListItem collection)
        {
            try
            {
                // TODO: Add insert logic here
                TeamService r = new TeamService();
                if (r.Delete(id))
                    return RedirectToAction("Details", new { controller="Project",id =r.Get(id).ProjectId });
                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }
        
        
        // GET: Team/addEmployee/6 formulaire
        public ActionResult AddEmployee(int id)
        {
            return View();

        }
        [HttpPost]
        // POST: Team/addEmploye/6
        public ActionResult AddEmployee(int id, TeamAddEmployee collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    EmployeeService employeeRepo = new EmployeeService();
                    CD.Employee employee = employeeRepo.Get().Where<CD.Employee>(emp => emp.Email == collection.Email).SingleOrDefault();
                    if (employee != null)
                    {
                        TeamService r = new TeamService();
                        if(r.AddEmployee(employee.Id, id))
                        { return RedirectToAction("Details",new { id=id}) ; }
                        else
                        { return View(collection); }
                        
                    }
                    else
                    {
                        return View(collection);

                    }
                
                }
                else
                {
                    return View(collection);
                }
            }
            catch
            {
                return View(collection);
            }

        }
        // GET: Team/delEmployee/6 formulaire 
        public ActionResult DelEmployee(int id)
        {

            
            EmployeeService employeeRepo = new EmployeeService();
            IEnumerable<CD.Employee> employees = employeeRepo.GetByTeamId(id);
            List<EmployeeListItem> finalList = new List<EmployeeListItem>();
            foreach (CD.Employee employee in employees)
            {
                finalList.Add(new EmployeeListItem(employee));
            }
            return View(finalList);

        }

        [HttpPost]
        public ActionResult DelEmployee(int id, TeamDelEmployee collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    EmployeeService employeeRepo = new EmployeeService();
                    CD.Employee employee = employeeRepo.Get().Where<CD.Employee>(emp => emp.Email == collection.Email).SingleOrDefault();
                    if (employee != null)
                    {
                        TeamService r = new TeamService();
                        if (r.AddEmployee(employee.Id, id)) //<<----------------Merci, j'ai bien rit ;)
                        { return RedirectToAction("Details", new { id = id }); }
                        else
                        { return View(collection); }

                    }
                    else
                    {
                        return View(collection);

                    }

                }
                else
                {
                    return View(collection);
                }
            }
            catch
            {
                return View(collection);
            }

        }

        public ActionResult ConfirmDeleteEmployee(int teamId,int employeeId)
        {
            EmployeeService employeeRepo = new EmployeeService();
            CD.Employee employees = employeeRepo.Get(employeeId);
            
            ProfilDetail pepito = new ProfilDetail( employees);



            return View(pepito);
        }

        [HttpPost]
        public ActionResult ConfirmDeleteEmployee(int teamId, /*int employeeId,*/ ProfilDetail collection)
        {

            try
            {
                // TODO: Add insert logic here
                TeamService r = new TeamService();
                if(r.DelEmployee(collection.Id, teamId))                 
                    return RedirectToAction("Details", new { id = teamId });
                return View(collection);
            }
            catch
            {
                return View(collection);
            }

        }

        // GET: Team/NewMessage/6
        public ActionResult NewMessage(int id)
        {
            MessageCreateForm createForm = new MessageCreateForm(id, "Team");
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
                    message = repoMessage.SendToTeam(message, id);
                    return RedirectToAction("Details", new { controller="Message", id = message.Id });
                }
                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Team/NewDoc/6
        public ActionResult NewDoc(int id)
        {
            DocumentCreateForm createForm = new DocumentCreateForm(id, "Team");
            return View(createForm);
        }

        // POST: Team/NewDoc/6
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
                    if (!d.InsertToTeam(doc, id))
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
