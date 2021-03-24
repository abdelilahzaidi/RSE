using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class DepartmentListItem
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Nom")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Administrateur")]
        public CurrentOn Admin { get; set; }

        public DepartmentListItem() {

        }

        public DepartmentListItem(Department department,Admin admin)
        {
            Id = department.Id;
            Name = department.Name;
            Description = department.Description;
            Admin = new CurrentOn(admin);
        }
    }
}