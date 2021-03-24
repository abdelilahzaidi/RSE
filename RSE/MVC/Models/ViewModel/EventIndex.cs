using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class EventIndex
    {
        [DisplayName("Mes événements")]
        public IEnumerable<EventListItem> EventCreated { get; set; }
        [DisplayName("Mes invitations")]
        public IEnumerable<EventInviteListItem> EventInvited { get; set; }

        public EventIndex()
        {

        }

        public EventIndex(IEnumerable<EventListItem> events,IEnumerable<EventInviteListItem> invites)
        {
            if (events != null)
                EventCreated = events;
            else
                EventCreated = new List<EventListItem>();
            if (invites != null)
                EventInvited = invites;
            else
                EventInvited = new List<EventInviteListItem>();
        }
    }
}