using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class SubjectListItem : MessageListItem
    {
        internal Message _lMessage { get; set; }
        [DisplayName("Dernière réponse Par")]
        public CurrentOn LastSender { get { return _lMessage.Sender; } }
        [DisplayName("Date dernière réponse")]
        [DataType("DateTime-local")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime LastDate { get { return _lMessage.Date; } }
        [DisplayName("Aperçu")]
        public string LastMessage { get { return _lMessage.Text; } }

        public SubjectListItem()
        {

        }

        public SubjectListItem(Message firstMessage, Message lastMessage):base(firstMessage)
        {
            _lMessage = lastMessage;
        }
    }
}