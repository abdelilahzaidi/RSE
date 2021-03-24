using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class EventInviteListItem:EventListItem
    {
        [DisplayName("Confirmation de présence")]
        public bool? Present { get; set; }

        public EventInviteListItem(Event ev, Employee employee, Invite invite) :base(ev, employee)
        {
            Present = invite.Present;
        }
    }
}