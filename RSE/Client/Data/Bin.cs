using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Bin
    {
        #region Fields
        private int _Id;
        private byte[] _Binaries;
        private string _UploadName;
        private DateTime _UploadDate;
        #endregion

        #region props
        public int Id { get {
                return _Id;
            }
            set {
                _Id = value;
            } }
        
        
        public byte[] Binaries { get => _Binaries; set => _Binaries = value; }
        public string UploadName { get => _UploadName; set => _UploadName = value; }
        public DateTime UploadDate { get => _UploadDate; set => _UploadDate = value; }
        #endregion

        #region ctor
        public Bin(int id,byte[]binaries, string uploadName, DateTime uploadDate)
        {
            Id = id;
            Binaries = binaries;
            UploadName = uploadName;
            UploadDate = uploadDate;


        }
        public Bin()
        {

        }

        #endregion

        #region methods

        #endregion
    }
}
