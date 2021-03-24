using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Model.Client.Data;

namespace MVC.Areas.Admin.Models.ViewModel
{
    public class DepartEditForm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Nom")]
        [MaxLength(50)]
        [MinLength(1)]
        public string Name { get; set; }
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }



        public DepartEditForm()
        {

        }
        public DepartEditForm(Department dep)
        {
            Id = dep.Id;
            Name = dep.Name;
            Description = dep.Description;
        }



    }
}