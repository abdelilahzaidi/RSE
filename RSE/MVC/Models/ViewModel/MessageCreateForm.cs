using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class MessageCreateForm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Type de destinataire")]
        public string ReceiverKind { get; set; }
        [Required]
        [DisplayName("Destinataire")]
        public string ReceiverId { get; set; }
        [Required]
        [DisplayName("Objet")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Message")]
        [DataType(DataType.MultilineText)]
        [MinLength(3)]
        [MaxLength(500)]
        public string Text { get; set; }

        public MessageCreateForm(int id, string type)
        {
            ReceiverId = id.ToString();
            ReceiverKind = type;
        }

        public MessageCreateForm()
        {

        }
    }
}