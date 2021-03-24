using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class EventDetail : EventListItem
    {
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Participants")]
        public IEnumerable<EventEmployeeListItem> Participants{ get; set; }
        [DisplayName("Documents")]
        public IEnumerable<DocumentList> Docs { get; set; }

        public EventDetail(Event ev, Employee emp, IEnumerable<EventEmployeeListItem> part, IEnumerable<DocumentList> docs):this(ev,emp)
        {
            if (part == null)
                Participants = new List<EventEmployeeListItem>();
            else
                Participants = part;
            Docs = docs;
        }
        public EventDetail(Event events, Employee emp) : base(events,emp)
        {
            Description = events.Description;
        }

    }
}