using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class DocumentList
    {
        private string _Description;
        [Key]
        public int Id { get; set; }
        [DisplayName("Nom")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description
        {
            get
            { return (_Description!=null && _Description.Length>=50)?_Description.Substring(0, 49):_Description; }
            set { _Description=value; }
        }
        [DisplayName("Extention")]
        public string Extention { get; set; }
        [Key]
        public int EmployeeId { get; set; }
        [Key]
        public int FileBinId { get; set; }
        [DisplayName("Date de modification")]
        public DateTime ModifiedDate { get; set; }
        [Key]
        public int? OldFileId { get; set; }


        public DocumentList()
        {

        }

        public DocumentList(Document doc)
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