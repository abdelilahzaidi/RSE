using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class EmployeeCheckableList
    {
        public IList<EmployeeCheckableItem> employees { get; set; }
    }
}