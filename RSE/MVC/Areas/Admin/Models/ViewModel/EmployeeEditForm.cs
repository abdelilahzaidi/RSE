using C = Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Models.ViewModel
{
    public class EmployeeEditForm
    {

        [Key]
        public int Id { get; set; }
        [Key]
        public int CurrentDepartmentId { get; set; }
        [DisplayName("Prénom")]
        public string FirstName { get; set; }
        [DisplayName("Nom")]
        public string LastName { get; set; }
        [DisplayName("Adresse e-mail")]
        public string Email { get; set; }
        [DisplayName("Département affecté")]
        public SelectList DepartmentList { get; set; }
        [DisplayName("Compte administrateur")]
        public bool IsAdmin { get; set; }

        public string SelectedItem { get; set; }

        public EmployeeEditForm()
        {

        }

        public EmployeeEditForm(C.Admin admin, C.Department currentDepartment, IEnumerable<C.Department> departmentList):this(admin,currentDepartment,departmentList,admin.IsAdmin)
        {
            
        }

        public EmployeeEditForm(C.Employee employee,C.Department currentDepartment, IEnumerable<C.Department> departmentList, bool isAdmin)
        {
            Id = employee.Id;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Email = employee.Email;
            CurrentDepartmentId = currentDepartment!=null ?currentDepartment.Id: 0;
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (C.Department department in departmentList)
            {
                listItems.Add(new SelectListItem { Value = department.Id.ToString(), Text = department.Name });
            }
            DepartmentList = new SelectList(listItems,"Value","Text");
            SelectedItem = CurrentDepartmentId.ToString();
            IsAdmin = isAdmin;
        }
    }
}