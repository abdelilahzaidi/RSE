using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class EventCreateForm
    {
        [DisplayName("Nom")]
        public string Name { get; set; }
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayName("Ville")]
        public string City { get; set; }
        [DisplayName("Rue")]
        public string Street { get; set; }
        [DisplayName("Numéro")]
        public string Number { get; set; }
        [DisplayName("Boîte/Appartement")]
        public string NumberBox { get; set; }
        [DisplayName("Code postal")]
        public string ZipCode { get; set; }
        [DisplayName("Pays")]
        public string Country { get; set; }
        [DisplayName("Date de début")]
        [DataType("DateTime-local")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        [DataType("DateTime-local")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date de fin")]
        public DateTime? EndDate { get; set; }
        [DisplayName("Journée entière ?")]
        public bool FullDay { get; set; }


        public EventCreateForm()
        {

        }



    }
}