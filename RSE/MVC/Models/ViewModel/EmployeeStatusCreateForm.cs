using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models.ViewModel
{
    public class EmployeeStatusCreateForm
    {        
        [Required]
        [DisplayName("Date de début")]
        [DataType("DateTime-local")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm}")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("Date de fin")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm}")]
        [DataType("DateTime-local")]
        public DateTime EndDate { get; set; }

        [HiddenInput]
        public SelectList EmployeeStates { get; set; }

        [DisplayName("Définir un statut")]
        public string SelectedEmployeeState { get; set; }



        public EmployeeStatusCreateForm()
        {

        }


        public EmployeeStatusCreateForm(IEnumerable<EmployeeState> empStates)
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            //---Creation de la liste des status d'employee
            List<SelectListItem> stateList = new List<SelectListItem>();
            foreach (EmployeeState s in empStates)
            {
                stateList.Add(new SelectListItem { Value = s.Id.ToString(), Text = s.Name });
            }
            EmployeeStates = new SelectList(stateList, "Value", "Text");
        }
    }
}