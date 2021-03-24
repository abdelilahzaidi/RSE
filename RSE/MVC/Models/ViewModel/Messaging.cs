using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class Messaging : Subject
    {
        [DisplayName("Participants")]
        public IEnumerable<CurrentOn> Participants { get; set; }

        public Messaging(IEnumerable<MessageListItem> messages, IEnumerable<CurrentOn> employees):base(messages)
        {
            Participants = employees;
        }
    }
}