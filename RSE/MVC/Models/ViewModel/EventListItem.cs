using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class EventListItem
    {

        [Key]
        public int Id { get; set; }
        [DisplayName("Nom")]
        public string Name { get; set; }
        [DisplayName("Lieu")]
        public AddressObject Address { get; set; }
        [DisplayName("Date de début")]
        public DateTime StartDate { get; set; }
        [DisplayName("Date de fin")]
        public DateTime? EndDate { get; set; }
        [DisplayName("Journée entière")]
        public bool FullDay { get; set; }
        [DisplayName("Organisateur")]
        public CurrentOn Creator { get; set; }


        public EventListItem()
        {

        }


        public EventListItem(Event events, Employee emp)
        {
            Id = events.Id;
            Name = events.Name;
            Address = new AddressObject(events);
            StartDate = events.StartDate;
            EndDate = events.EndDate;
            FullDay = events.FullDay;
            Creator = new CurrentOn(emp);
        }
    }

}