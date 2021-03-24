using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string Extention { get; set; }
        public int EmployeeId { get; set; }
        public int FileBinId { get; set; }
        public int? OldFileId { get; set; }
        public long Size { get; set; }
    }
}
