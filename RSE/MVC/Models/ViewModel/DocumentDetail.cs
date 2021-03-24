using Model.Client.Data;
using Model.Client.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class DocumentDetail
    {   
        [Key]
        public int Id { get; set; }
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayName("Date de modification")]
        [DataType("datetime-local")]
        public DateTime CreateDate { get; set; }
        [DisplayName("Nom")]
        public string Name { get; set; }
        [DisplayName("Extention")]
        public string Extention { get; set; }
        [DisplayName("Publier par")]
        public CurrentOn Employee { get; set; }
        [Key]
        public int FileBinId { get; set; }
        [Key]
        public int? OldFileId { get; set; }
        [DisplayName("Taille du fichier")]
        public long Size { get; set; }

        public DocumentDetail()
        {

        }

        public DocumentDetail(Document document)
        {
            EmployeeService repoEmployee = new EmployeeService();
            Id = document.Id;
            Name = document.Name;
            Description =document.Description;
            CreateDate = document.CreateDate;
            Extention = document.Extention;
            Employee = new CurrentOn(repoEmployee.Get(document.EmployeeId));
            FileBinId = document.FileBinId;
            OldFileId = document.OldFileId;
            Size = document.Size;
        }
    }
}