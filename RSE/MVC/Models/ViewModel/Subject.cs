using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class Subject
    {
        [DisplayName("Sujet")]
        public string Title { get { return Posts.First().Title; } }
        [Key]
        public int LastMessageId { get { return Posts.Last().Id; } }
        [DisplayName("Messages")]
        public IEnumerable<MessageListItem> Posts { get; set; }
        [DisplayName("Envoyer une réponse")]
        public AnswerMessageForm AnswerForm { get; set; }

        public Subject()
        {

        }

        public Subject(IEnumerable<MessageListItem> posts)
        {
            Posts = posts;
            if (posts.Count() != 0)
                AnswerForm = new AnswerMessageForm(this.LastMessageId, this.Title);
        }
    }
}