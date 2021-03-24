using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class ProfilDetail:EmployeeModel
    {
        [Required]
        [DisplayName("Numéro de registre Nationnal")]
        public string RegNat { get; set; }

        public ProfilDetail()
        {

        }

        public ProfilDetail(Employee emp):base(emp)
        {
            RegNat = emp.RegNat;
        }
    }
}