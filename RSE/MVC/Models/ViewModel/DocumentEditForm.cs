using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class DocumentEditForm
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Nom")]
        public string Name { get; set; }

        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayName("Extention")]
        public string Extention { get; set; }
        [Key]
        public int EmployeeId { get; set; }
        [Key]
        public int FileBinId { get; set; }
        [DisplayName("Taille")]
        public long Size { get; set; }
        [DisplayName("Date de modification")]
        public DateTime ModifiedDate { get; set; }
        [Key]
        public int? OldFileId { get; set; }


        public DocumentEditForm()
        {

        }

        public DocumentEditForm(Document doc)
        {
            Id = doc.Id;
            Name = doc.Name;
            Description = doc.Description;
            Extention = doc.Extention;
            EmployeeId = doc.EmployeeId;
            FileBinId = doc.FileBinId;
            ModifiedDate = doc.CreateDate;
        }
    }
}