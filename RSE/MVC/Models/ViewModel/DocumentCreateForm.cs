using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class DocumentCreateForm
    {
        #region prop
        [Required]
        [DisplayName("Type de document")]
        public string Kind { get; set; }
        [Required]
        [DisplayName("A destination de")]
        public int ReceiverId { get; set; }
        [Required]
        [DisplayName("Nom du document")]
        [MaxLength(50)]
        [MinLength(1)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Extention du document")]
        [MaxLength(50)]
        [MinLength(1)]
        public string Extention { get; set; }

        [DisplayName("Description du document")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Taille du document")]
        public int Size { get; set; }
        [Required]
        [DisplayName("Date du document")]
        public DateTime ModifiedDate { get; set; }
        [Required]
        [DisplayName("Document")]
        public HttpPostedFileBase FileBinary { get; set; }
        #endregion

        public DocumentCreateForm()
        {

        }

        public DocumentCreateForm(int receiverId,string kind)
        {
            Kind = kind;
            ReceiverId = receiverId;
        }

        public DocumentCreateForm(string name, string description, DateTime modifiedDate, string extention,  int size)
        {
            Name = name;
            Extention = extention;
            Description = description;
           
            ModifiedDate = modifiedDate;
            Extention = extention;
            Size = size;
        }

    }
}