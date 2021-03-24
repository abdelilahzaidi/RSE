using CD = Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models.ViewModel
{
    public class EmployeeListItem
    {
        private int _Gsm { get; set; }
        [Key]
        public int Id { get; set; }
        [DisplayName("Nom")]
        public string LastName { get; set; }
        [DisplayName("Prénom")]
        public string FirstName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("GSM")]
        public string GSM { get { return "+32 " + this._Gsm; } }
        [Key]
        public int StateId { get; set; }
        [DisplayName("Statut")]
        public string StateName { get; set; }
        [DisplayName("A partir du :")]
        public DateTime? StartDate { get; set; }
        [DisplayName("Jusqu'au :")]
        public DateTime? EndDate { get; set; }

        public EmployeeListItem()
        {

        }


        public EmployeeListItem(EmployeeWithState empstate)
        {
            Id = empstate.Id;
            LastName = empstate.LastName;
            FirstName = empstate.FirstName;
            Email = empstate.Email;
            _Gsm = empstate.GSM;
            StateId = empstate.StateId;
            StateName = empstate.StateName;
            StartDate = empstate.StartDate;
            EndDate = empstate.EndDate;
        }

        public EmployeeListItem(CD.Employee emp)
        {
            Id = emp.Id;
            LastName = emp.LastName;
            FirstName = emp.FirstName;
            Email = emp.Email;
            _Gsm = emp.GSM;
        }
        
    }
}