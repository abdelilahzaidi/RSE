using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class TeamDel
    {
        [Required]
        [DisplayName("Nom")]
        [MaxLength(50)]
        [MinLength(1)]
        public string Name { get; set; }
        [Key]
        public int TeamId { get; set; }

        public TeamDel()
        {

        }
        public TeamDel(String name, int Id)
        {
            Name = name;
            TeamId = Id;

        }
    }
}