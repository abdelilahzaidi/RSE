using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class MessageListItem
    {
        private Message _message { get; set; }
        [Key]
        public int Id { get { return _message.Id; } }
        [DisplayName("Objet")]
        public string Title { get { return _message.Title; } }
        [DisplayName("Rédigé le ")]
        [DataType("DateTime-local")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime Date { get { return _message.Date; } }
        [DisplayName("Message")]
        [DataType(DataType.MultilineText)]
        public string Message { get { return _message.Text; } }
        [DisplayName("Par")]
        public CurrentOn Sender { get { return _message.Sender; } }

        public MessageListItem()
        {

        }

        public MessageListItem(Message message)
        {
            _message = message;
        }
    }
}