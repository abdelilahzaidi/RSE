using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class ConversationListItem : SubjectListItem
    {
        [DisplayName("Pour")]
        public CurrentOn Receiver { get; set; }
        public string ReceiverType { get; set; }

        public ConversationListItem()
        {

        }

        public ConversationListItem(Message firstMessage, Message lastMessage, Employee receiver) : base(firstMessage, lastMessage)
        {
            Receiver = new CurrentOn(receiver);
            ReceiverType = "Employee";
        }

        public ConversationListItem(Message firstMessage, Message lastMessage, Team receiver) : base(firstMessage, lastMessage)
        {
            Receiver = new CurrentOn(receiver);
            ReceiverType = "Team";
        }
    }
}