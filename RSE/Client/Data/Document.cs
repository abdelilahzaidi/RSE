using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Document
    {
        #region fields
        private int _Id;
        private string _Name;
        private string _Description;
        private DateTime _CreateDate;
        private long _Size;
        private string _Extention;
        private int _EmployeeId;
        private int _FileBinId;
        private int? _OldFileId;
        #endregion

        #region Props
        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Description { get => _Description; set => _Description = value; }
        public DateTime CreateDate { get => _CreateDate; set => _CreateDate = value; }
        
        public string Extention { get => _Extention; set => _Extention = value; }
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        public int FileBinId { get => _FileBinId; set => _FileBinId = value; }
        public int? OldFileId{ get => _OldFileId; set => _OldFileId = value; }
        public long Size { get => _Size; set => _Size = value; }
        #endregion

        #region ctor
        public Document()
        {

        }

        public Document(int id, string name, string description, DateTime createDate, int size,  string extention, int employeeId, int fileBinId,int? oldFileId) :this(name, description, createDate, size,extention,employeeId,fileBinId, oldFileId)
        {
            Id = id;
        }
        public Document(string name,string description, DateTime createDate, int size, string extention, int employeeId, int fileBinId, int? oldFileId) :this(name,description,createDate,size)
        {
            Extention = extention;
            EmployeeId = employeeId;
            FileBinId = fileBinId;
            OldFileId = oldFileId;
        }

        public Document (int id, string name, string description, DateTime createDate, int size): this(name, description, createDate,   size)
        {
            Id=id;
        }

        public Document( string name, string description, DateTime createDate,int size)
        {
            Name = name;
            CreateDate = createDate;
            Description = description;
            Size = size;
        }



        #endregion

    }
}
