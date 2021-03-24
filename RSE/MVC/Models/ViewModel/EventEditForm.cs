using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class EventEditForm
    {
        [Key]
        public int Id { get; set; }
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
        [DataType("Datetime-local")]
        [DisplayName("Date de début")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm}")]
        public DateTime StartDate { get; set; }
        [DataType("Datetime-local")]
        [DisplayName("Date de fin")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm}")]
        public DateTime? EndDate { get; set; }
        [DisplayName("Journée entière?")]
        public bool FullDay { get; set; }



        public EventEditForm()
        {

        }


        public EventEditForm(Event events)
        {
            Id = events.Id;
            Name = events.Name;
            Description = events.Description;
            City = events.City;
            Street = events.Street;
            Number = events.Number;
            NumberBox = events.NumberBox;
            ZipCode = events.ZipCode;
            Country = events.Country;
            StartDate = events.StartDate;
            EndDate = events.EndDate;
            FullDay = events.FullDay;
        }
    }
}