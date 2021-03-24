using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Client.Data;

namespace MVC.Models.ViewModel
{
    public class EmployeeCheckableItem : EmployeeListItem
    {
        public bool IsChecked { get; set; }

        public EmployeeCheckableItem(Employee emp):base(emp)
        {

        }
    }
}