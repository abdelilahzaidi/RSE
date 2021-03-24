using CD = Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CurrentOn : IDataObject
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Nom")]
        public string Name { get; set; }

        public CurrentOn(CD.Employee employee)
        {
            if (employee != null)
            {
                Id = employee.Id;
                Name = employee.FirstName + ", " + employee.LastName;
            }
        }

        public CurrentOn(CD.Team team)
        {
            if (team != null)
            {
                Id = team.Id;
                Name = team.Name;
            }
        }

        public CurrentOn(CD.EmployeeState empState)
        {
            if (empState != null)
            {
                Id = empState.Id;
                Name = empState.Name;
            }
        }
        public CurrentOn(CD.Department department)
        {
            if (department != null)
            {
                Id = department.Id;
                Name = department.Name;
            }

        }
    }
}