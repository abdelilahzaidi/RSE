using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using CD = Model.Client.Data; 

namespace MVC.Models.ViewModel
{
    public class PlanningItem
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Nom")]
        public string Name { get; set; }
        [DisplayName("Date de début")]
        [DataType("DateTime-local")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm}")]
        public DateTime StartDate { get; set; }
        [DisplayName("Date de fin")]
        [DataType("DateTime-local")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm}")]
        public DateTime EndDate { get; set; }
        [Key]
        public int EmployeeId { get; set; }
        [DisplayName("Type d'objet")]
        public string Type { get; set; }

        public PlanningItem(CD.PlanningItem item):this(item.Id,item.Name,item.StartDate,item.EndDate,item.EmployeeId,item.Type)
        {

        }

        public PlanningItem(int id, string name, DateTime startDate, DateTime endDate, int employeeId, string type)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            EmployeeId = employeeId;
            Type = type;
        }

    }
}