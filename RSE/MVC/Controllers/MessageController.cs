using CD = Model.Client.Data;
using Model.Client.Service;
using MVC.Infrastructure;
using MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M = MVC.Models;

namespace MVC.Controllers
{
    [AuthRequired]
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            MessageService repoMessage = new MessageService();
            EmployeeService repoEmp = new EmployeeService();
            TeamService repoTeam = new TeamService();
            IEnumerable<ConversationListItem> empMessages = repoMessage.GetEmployeeMessages(UserSession.CurrentUser.Id).Select(m => new ConversationListItem(new M.Message(m), new M.Message(repoMessage.GetLastMessage(m.Id)), repoEmp.GetMessageReceiverByMessageId(m.Id)));
            IEnumerable<ConversationListItem> teamMessages = repoMessage.GetTeamMessagesByEmployee(UserSession.CurrentUser.Id).Select(m => new ConversationListItem(new M.Message(m), new M.Message(repoMessage.GetLastMessage(m.Id)), repoTeam.GetByMessageId(m.Id)));
            IEnumerable<ConversationListItem> messages = empMessages.Union<ConversationListItem>(teamMessages);
            return View(messages);
        }

        public PartialViewResult AjaxIndexAll()
        {
            MessageService repoMessage = new MessageService();
            EmployeeService repoEmp = new EmployeeService();
            TeamService repoTeam = new TeamService();
            IEnumerable<ConversationListItem> empMessages = repoMessage.GetEmployeeMessages(UserSession.CurrentUser.Id).Select(m => new ConversationListItem(new M.Message(m), new M.Message(repoMessage.GetLastMessage(m.Id)), repoEmp.GetMessageReceiverByMessageId(m.Id)));
            IEnumerable<ConversationListItem> teamMessages = repoMessage.GetTeamMessagesByEmployee(UserSession.CurrentUser.Id).Select(m => new ConversationListItem(new M.Message(m), new M.Message(repoMessage.GetLastMessage(m.Id)), repoTeam.GetByMessageId(m.Id)));
            IEnumerable<ConversationListItem> messages = empMessages.Union<ConversationListItem>(teamMessages);
            return PartialView("_ConversationList", messages);
        }

        public PartialViewResult AjaxIndexEmployee()
        {
            MessageService repoMessage = new MessageService();
            EmployeeService repoEmp = new EmployeeService();
            IEnumerable<ConversationListItem> messages = repoMessage.GetEmployeeMessages(UserSession.CurrentUser.Id).Select(m => new ConversationListItem(new M.Message(m), new M.Message(repoMessage.GetLastMessage(m.Id)), repoEmp.GetMessageReceiverByMessageId(m.Id)));
            return PartialView("_ConversationList", messages);
        }

        public PartialViewResult AjaxIndexTeam()
        {
            MessageService repoMessage = new MessageService();
            TeamService repoTeam = new TeamService();
            IEnumerable<ConversationListItem> messages = repoMessage.GetTeamMessagesByEmployee(UserSession.CurrentUser.Id).Select(m => new ConversationListItem(new M.Message(m), new M.Message(repoMessage.GetLastMessage(m.Id)), repoTeam.GetByMessageId(m.Id)));
            return PartialView("_ConversationList", messages);
        }

        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            MessageService repoMessage = new MessageService();
            EmployeeService repoEmp = new EmployeeService();
            IEnumerable<MessageListItem> messages = repoMessage.GetConversation(id).Select(m=> new MessageListItem(new M.Message(m)));
            IEnumerable<M.CurrentOn> participants = repoEmp.GetByMessageId(id).Select(e => new M.CurrentOn(e));
            Messaging messaging = new Messaging(messages, participants);
            return View(messaging);
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(MessageCreateForm collection)
        {
            try
            {
                int receiverId = 0;
                if (!Int32.TryParse(collection.ReceiverId, out receiverId))
                {
                    EmployeeService repoEmp = new EmployeeService();
                    receiverId = repoEmp.Get().Where(e => e.Email == collection.ReceiverId).SingleOrDefault().Id;
                }
                if (ModelState.IsValid && receiverId!=0)
                {
                    MessageService repoMessage = new MessageService();
                    CD.Message message = new CD.Message(
                                    collection.Title,
                                    collection.Text,
                                    UserSession.CurrentUser.Id
                                );
                    switch (collection.ReceiverKind)
                    {
                        case "Employee":
                            message = repoMessage.SendToEmployee(message,receiverId);
                            break;
                        case "Team":
                            message = repoMessage.SendToTeam(message, receiverId);
                            break;
                        default:
                            return View(collection);
                    }
                    return RedirectToAction("Index",new { id = message.Id });
                }
                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Message/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Message/Edit/5
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

        // GET: Message/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Message/Delete/5
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

        // GET: Message/Answer/12
        public ActionResult Answer(int id)
        {
            MessageService repoMessage = new MessageService();
            CD.Message m = repoMessage.Get(id);
            AnswerMessageForm form = new AnswerMessageForm(id,m.Title);
            return View(form);
        }

        // POST: Message/Answer/12
        [HttpPost]
        public ActionResult Answer(int id, AnswerMessageForm collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MessageService repoMessage = new MessageService();
                    CD.Message m = repoMessage.Answer(new CD.Message() {
                        Title=collection.Title,
                        Text=collection.Message,
                        EmployeeId = UserSession.CurrentUser.Id
                    }, id);
                    return RedirectToAction("Details", new { id = m.Id });
                }
                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }

        public PartialViewResult AjaxAnswer(int id,AnswerMessageForm collection)
        {
            MessageService repoMessage = new MessageService();
            EmployeeService repoEmp = new EmployeeService();
            CD.Message answer = repoMessage.Answer(new CD.Message()
            {
                Title = collection.Title,
                Text = collection.Message,
                EmployeeId = UserSession.CurrentUser.Id
            }, collection.MessageId);
            IEnumerable<MessageListItem> messages = repoMessage.GetConversation(id).Select(m => new MessageListItem(new M.Message(m)));
            IEnumerable<M.CurrentOn> participants = repoEmp.GetByMessageId(id).Select(e => new M.CurrentOn(e));
            Messaging messaging = new Messaging(messages, participants);
            return PartialView("_Messaging", messaging);
        }

        public PartialViewResult AjaxTeamDropDownListByEmployee()
        {
            TeamService repoTeam = new TeamService();
            IEnumerable<SelectListItem> items = repoTeam.GetByEmployeeId(UserSession.CurrentUser.Id).Select(t=>new SelectListItem() { Value = t.Id.ToString(), Text = t.Name });
            SelectList teams = new SelectList(items.ToList(),"Value","Text");
            return PartialView("_SelectList",teams);
        }
    }
}
