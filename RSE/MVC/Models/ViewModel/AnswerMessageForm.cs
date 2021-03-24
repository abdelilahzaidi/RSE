using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class AnswerMessageForm
    {
        [Key]
        public int MessageId { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Objet")]
        public string Title { get; set; }
        [DisplayName("Réponse")]
        [DataType(DataType.MultilineText)]
        [MinLength(3)]
        [MaxLength(500)]
        public string Message { get; set; }

        public AnswerMessageForm()
        {

        }

        public AnswerMessageForm(int id, string title) : this(title)
        {
            MessageId = id;
        }

        public AnswerMessageForm(string title)
        {
            Title = (title.Substring(0, 4) == "Re: ") ? title : "Re: " + title;
        }
    }
}