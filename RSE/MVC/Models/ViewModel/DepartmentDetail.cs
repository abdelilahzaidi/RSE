using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class DepartmentDetail:DepartmentListItem
    {
        [DisplayName("Membres")]
        public  IEnumerable<EmployeeListItem> Members { get; set; }
        [DisplayName("Documents")]
        public IEnumerable<DocumentList> Docs { get; set; }

      
        public DepartmentDetail()
        {
            
        }

        public DepartmentDetail(Department department, Admin admin, IEnumerable<EmployeeListItem> employees,IEnumerable<DocumentList> docs):base(department,admin)
        {
            Members = employees;
            Docs = docs??new List<DocumentList>();
        }



        /*
        public void addMember(Employee e)
        { Membres.Add(e); }
        */

    }
}