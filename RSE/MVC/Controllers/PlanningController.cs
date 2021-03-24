using Model.Client.Service;
using CD = Model.Client.Data;
using MVC.Infrastructure;
using MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    [AuthRequired]
    public class PlanningController : Controller
    {
        // GET: Planning
        public ActionResult Index()
        {
            /*PlanningItemService repoPlanning = new PlanningItemService();
            IEnumerable<CD.PlanningItem> items = repoPlanning.GetByEmployeeId(UserSession.CurrentUser.Id);
            List<PlanningItem> model_items = new List<PlanningItem>();
                foreach (CD.PlanningItem item in items) {
                model_items.Add(new PlanningItem(item));
            }//.Select(i => new PlanningItem(i));
            return View(model_items);*/
            return View();
        }
        
        public JsonResult AllEvent(DateTime start,DateTime end,string type)
        {
            PlanningItemService repoPlanning = new PlanningItemService();
            IEnumerable<CD.PlanningItem> items = repoPlanning.GetByEmployeeId(UserSession.CurrentUser.Id,start,end).Where(i=>i.Type==type);
            List<fullCalendarEvent> model_items = new List<fullCalendarEvent>();
            foreach (CD.PlanningItem item in items)
            {
                model_items.Add(new fullCalendarEvent() { id=item.Id, title = item.Name, start = item.StartDate, end = item.EndDate,type=item.Type });
            }
            return Json(model_items,JsonRequestBehavior.AllowGet);
        }

    }
}