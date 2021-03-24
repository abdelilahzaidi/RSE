using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Model.Client.Data;

namespace MVC.Areas.Admin.Models.ViewModel
{
    public class DepartForm
    {
        [Required]
        [DisplayName("Nom")]
        [MaxLength(50)]
        [MinLength(1)]
        public string Name { get; set; }
        
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        [MaxLength(250)]
        public string Description { get; set; }


        public DepartForm()
        {

        }
    }
}