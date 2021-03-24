using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CD = Model.Client.Data;
using CS = Model.Client.Service;

namespace MVC.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Envoyé le")]
        [DataType("DateTime-local")]
        public DateTime Date { get; set; }
        [DisplayName("Objet")]
        public string Title { get; set; }
        [DisplayName("Message")]
        public string Text { get; set; }
        [DisplayName("Par")]
        public CurrentOn Sender { get; set; }

        public Message(CD.Message message)
        {
            CS.EmployeeService repoEmployee = new CS.EmployeeService();
            Id = message.Id;
            Date = message.Date;
            Title = message.Title;
            Text = message.Text;
            Sender = new CurrentOn(repoEmployee.Get(message.EmployeeId));
        }
    }
}