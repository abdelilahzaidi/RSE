using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class EventEmployeeListItem:EmployeeListItem
    {
        [DisplayName("Confirmation de présence")]
        public bool? Present { get; set; }

        public EventEmployeeListItem(Employee employee,Invite invite):base(employee)
        {
            Present = invite.Present;
        }
    }
}